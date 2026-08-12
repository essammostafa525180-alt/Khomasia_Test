import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateApprovalMatrix, ApprovalMatrix } from '../../../Shared/Model/-approval-matrix.model';
import { ApprovalMatrixService } from './approval-matrix.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface ApprovalMatrixFormDialogData {
  mode: FormMode;
  item?: ApprovalMatrix;
}

@Component({
  selector: 'app-approval-matrix-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './approval-matrix-form.component.html',
  styleUrl: './approval-matrix-form.component.css',
})
export class ApprovalMatrixFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(ApprovalMatrixService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<ApprovalMatrixFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: ApprovalMatrix;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Approval Matrix' : 'Edit Approval Matrix';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      screenFk: [null],
      entityId: [null],
      approvalMatrixConfigFk: [null],
      approvalStatusFk: [null],
      approvalDate: [null],
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
    const value = this.form.getRawValue() as CreateApprovalMatrix;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Approval Matrix created.' : 'Approval Matrix updated.'
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
      screenFk: this.item?.screenFk ?? null,
      entityId: this.item?.entityId ?? null,
      approvalMatrixConfigFk: this.item?.approvalMatrixConfigFk ?? null,
      approvalStatusFk: this.item?.approvalStatusFk ?? null,
      approvalDate: this.toDateInput(this.item?.approvalDate),
    });
  }

  private toDateInput(value: Date | string | null | undefined): string | null {
    if (!value) return null;
    const d = new Date(value);
    return isNaN(d.getTime()) ? null : d.toISOString().split('T')[0];
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/administration/approval-matrix']);
  }
}
