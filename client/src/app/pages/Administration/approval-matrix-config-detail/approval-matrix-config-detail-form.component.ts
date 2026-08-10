import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateApprovalMatrixConfigDetail, ApprovalMatrixConfigDetail } from '../../../Shared/Model/-approval-matrix-config-detail.model';
import { ApprovalMatrixConfigDetailService } from './approval-matrix-config-detail.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface ApprovalMatrixConfigDetailFormDialogData {
  mode: FormMode;
  item?: ApprovalMatrixConfigDetail;
}

@Component({
  selector: 'app-approval-matrix-config-detail-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './approval-matrix-config-detail-form.component.html',
  styleUrl: './approval-matrix-config-detail-form.component.css',
})
export class ApprovalMatrixConfigDetailFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(ApprovalMatrixConfigDetailService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<ApprovalMatrixConfigDetailFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: ApprovalMatrixConfigDetail;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Approval Matrix Config Detail' : 'Edit Approval Matrix Config Detail';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      approvalMatrixConfigFk: [null],
      approvalMatrixRangeFk: [null],
      stepNo: [null],
      stepName: [''],
      stepNameAr: [''],
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
    const value = this.form.getRawValue() as CreateApprovalMatrixConfigDetail;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Approval Matrix Config Detail created.' : 'Approval Matrix Config Detail updated.'
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
      approvalMatrixConfigFk: this.item?.approvalMatrixConfigFk ?? null,
      approvalMatrixRangeFk: this.item?.approvalMatrixRangeFk ?? null,
      stepNo: this.item?.stepNo ?? null,
      stepName: this.item?.stepName ?? '',
      stepNameAr: this.item?.stepNameAr ?? '',
      userFk: this.item?.userFk ?? null,
      email: this.item?.email ?? '',
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/administration/approval-matrix-config-detail']);
  }
}
