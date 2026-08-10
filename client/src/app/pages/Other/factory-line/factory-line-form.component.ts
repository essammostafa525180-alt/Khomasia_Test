import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateFactoryLine, FactoryLine } from '../../../Shared/Model/-factory-line.model';
import { FactoryLineService } from './factory-line.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface FactoryLineFormDialogData {
  mode: FormMode;
  item?: FactoryLine;
}

@Component({
  selector: 'app-factory-line-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './factory-line-form.component.html',
  styleUrl: './factory-line-form.component.css',
})
export class FactoryLineFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(FactoryLineService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<FactoryLineFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: FactoryLine;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Factory Line' : 'Edit Factory Line';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      code: [''],
      description: [''],
      factoryFk: [null],
      name: [''],
      nameAr: [''],
      capacity: [null],
      lineTypes: [''],
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
    const value = this.form.getRawValue() as CreateFactoryLine;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Factory Line created.' : 'Factory Line updated.'
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
      code: this.item?.code ?? '',
      description: this.item?.description ?? '',
      factoryFk: this.item?.factoryFk ?? null,
      name: this.item?.name ?? '',
      nameAr: this.item?.nameAr ?? '',
      capacity: this.item?.capacity ?? null,
      lineTypes: this.item?.lineTypes ?? '',
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/other/factory-line']);
  }
}
