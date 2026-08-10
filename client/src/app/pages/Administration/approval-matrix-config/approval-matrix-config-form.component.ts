import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateApprovalMatrixConfig, ApprovalMatrixConfig } from '../../../Shared/Model/-approval-matrix-config.model';
import { ApprovalMatrixConfigService } from './approval-matrix-config.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface ApprovalMatrixConfigFormDialogData {
  mode: FormMode;
  item?: ApprovalMatrixConfig;
}

@Component({
  selector: 'app-approval-matrix-config-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './approval-matrix-config-form.component.html',
  styleUrl: './approval-matrix-config-form.component.css',
})
export class ApprovalMatrixConfigFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(ApprovalMatrixConfigService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<ApprovalMatrixConfigFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: ApprovalMatrixConfig;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Approval Matrix Config' : 'Edit Approval Matrix Config';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      screenFk: [null],
      companyFk: [null],
      projectFk: [null],
      scopeFk: [null],
      serviceMainCategoryFk: [null],
      locationFk: [null],
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
    const value = this.form.getRawValue() as CreateApprovalMatrixConfig;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Approval Matrix Config created.' : 'Approval Matrix Config updated.'
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
      companyFk: this.item?.companyFk ?? null,
      projectFk: this.item?.projectFk ?? null,
      scopeFk: this.item?.scopeFk ?? null,
      serviceMainCategoryFk: this.item?.serviceMainCategoryFk ?? null,
      locationFk: this.item?.locationFk ?? null,
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/administration/approval-matrix-config']);
  }
}
