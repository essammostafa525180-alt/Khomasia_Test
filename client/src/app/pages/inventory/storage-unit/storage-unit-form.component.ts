import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateStorageUnit, StorageUnit } from '../../../Shared/Model/-storage-unit.model';
import { StorageUnitService } from './storage-unit.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface StorageUnitFormDialogData {
  mode: FormMode;
  item?: StorageUnit;
}

@Component({
  selector: 'app-storage-unit-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './storage-unit-form.component.html',
  styleUrl: './storage-unit-form.component.css',
})
export class StorageUnitFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(StorageUnitService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<StorageUnitFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: StorageUnit;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Storage Unit' : 'Edit Storage Unit';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      warehouseFk: [null],
      type: [null],
      code: [''],
      name: [''],
      description: [''],
      capacity: [null],
      capacityUnit: [''],
      isActive: [true],
    });

    if (this.data) {
      this.mode = this.data.mode;
      this.item = this.data.item;
      this.patchForm();
      return;
    }

    this.mode = this.route.snapshot.data['mode'] === 'edit' ? 'edit' : 'create';
    if (this.mode === 'edit') {
      this.loadItem();
    }
  }

  save(): void {
    if (this.form.invalid || this.saving) {
      this.form.markAllAsTouched();
      return;
    }

    this.saving = true;
    const value = this.form.getRawValue() as CreateStorageUnit;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Storage Unit created.' : 'Storage Unit updated.'
        );
        this.close(true);
      },
      error: () => {
        this.saving = false;
      },
    });
  }

  cancel(): void {
    this.close(false);
  }

  private loadItem(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if (!Number.isInteger(id) || id <= 0) {
      this.notification.error('Invalid record identifier.');
      this.close(false);
      return;
    }

    this.loading = true;
    this.service.getById(id).subscribe({
      next: (item) => {
        this.loading = false;
        this.item = item;
        this.patchForm();
      },
      error: () => {
        this.loading = false;
        this.close(false);
      },
    });
  }

  private patchForm(): void {
    this.form.patchValue({
      warehouseFk: this.item?.warehouseFk ?? null,
      type: this.item?.type ?? null,
      code: this.item?.code ?? '',
      name: this.item?.name ?? '',
      description: this.item?.description ?? '',
      capacity: this.item?.capacity ?? null,
      capacityUnit: this.item?.capacityUnit ?? '',
      isActive: this.item?.isActive ?? true,
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/inventory/storage-unit']);
  }
}
