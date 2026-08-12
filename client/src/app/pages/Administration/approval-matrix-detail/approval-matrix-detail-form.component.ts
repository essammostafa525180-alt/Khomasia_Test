import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateApprovalMatrixDetail, ApprovalMatrixDetail } from '../../../Shared/Model/-approval-matrix-detail.model';
import { ApprovalMatrixDetailService } from './approval-matrix-detail.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface ApprovalMatrixDetailFormDialogData {
  mode: FormMode;
  item?: ApprovalMatrixDetail;
}

@Component({
  selector: 'app-approval-matrix-detail-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './approval-matrix-detail-form.component.html',
  styleUrl: './approval-matrix-detail-form.component.css',
})
export class ApprovalMatrixDetailFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(ApprovalMatrixDetailService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<ApprovalMatrixDetailFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: ApprovalMatrixDetail;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Approval Matrix Detail' : 'Edit Approval Matrix Detail';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      approvalMatrixFk: [null],
      approvalMatrixConfigDetailFk: [null],
      approvalStatusFk: [null],
      approvalDate: [null],
      userFk: [null],
      email: [''],
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
    const value = this.form.getRawValue() as CreateApprovalMatrixDetail;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Approval Matrix Detail created.' : 'Approval Matrix Detail updated.'
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
      approvalMatrixFk: this.item?.approvalMatrixFk ?? null,
      approvalMatrixConfigDetailFk: this.item?.approvalMatrixConfigDetailFk ?? null,
      approvalStatusFk: this.item?.approvalStatusFk ?? null,
      approvalDate: this.toDateInput(this.item?.approvalDate),
      userFk: this.item?.userFk ?? null,
      email: this.item?.email ?? '',
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
    this.router.navigate(['/administration/approval-matrix-detail']);
  }
}
