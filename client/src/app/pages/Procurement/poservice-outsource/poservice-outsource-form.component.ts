import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreatePoserviceOutsource, PoserviceOutsource } from '../../../Shared/Model/-poservice-outsource.model';
import { PoserviceOutsourceService } from './poservice-outsource.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface PoserviceOutsourceFormDialogData {
  mode: FormMode;
  item?: PoserviceOutsource;
}

@Component({
  selector: 'app-poservice-outsource-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './poservice-outsource-form.component.html',
  styleUrl: './poservice-outsource-form.component.css',
})
export class PoserviceOutsourceFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(PoserviceOutsourceService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<PoserviceOutsourceFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: PoserviceOutsource;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Poservice Outsource' : 'Edit Poservice Outsource';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      poserviceFk: [null],
      workerTypeFk: [null],
      employeeJobFk: [null],
      quantity: [null],
      costPerDay: [null],
      totalCost: [null],
      contractTaskEmployeeId: [null],
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
    const value = this.form.getRawValue() as CreatePoserviceOutsource;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Poservice Outsource created.' : 'Poservice Outsource updated.'
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
      poserviceFk: this.item?.poserviceFk ?? null,
      workerTypeFk: this.item?.workerTypeFk ?? null,
      employeeJobFk: this.item?.employeeJobFk ?? null,
      quantity: this.item?.quantity ?? null,
      costPerDay: this.item?.costPerDay ?? null,
      totalCost: this.item?.totalCost ?? null,
      contractTaskEmployeeId: this.item?.contractTaskEmployeeId ?? null,
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/procurement/poservice-outsource']);
  }
}
