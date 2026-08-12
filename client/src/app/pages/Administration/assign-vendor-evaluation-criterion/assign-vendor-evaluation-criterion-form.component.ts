import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateAssignVendorEvaluationCriterion, AssignVendorEvaluationCriterion } from '../../../Shared/Model/-assign-vendor-evaluation-criterion.model';
import { AssignVendorEvaluationCriterionService } from './assign-vendor-evaluation-criterion.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface AssignVendorEvaluationCriterionFormDialogData {
  mode: FormMode;
  item?: AssignVendorEvaluationCriterion;
}

@Component({
  selector: 'app-assign-vendor-evaluation-criterion-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './assign-vendor-evaluation-criterion-form.component.html',
  styleUrl: './assign-vendor-evaluation-criterion-form.component.css',
})
export class AssignVendorEvaluationCriterionFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(AssignVendorEvaluationCriterionService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<AssignVendorEvaluationCriterionFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: AssignVendorEvaluationCriterion;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Assign Vendor Evaluation Criterion' : 'Edit Assign Vendor Evaluation Criterion';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      vendorFk: [null],
      vendorEvaluationCriteriaFk: [null],
      rankFk: [null],
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
    const value = this.form.getRawValue() as CreateAssignVendorEvaluationCriterion;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Assign Vendor Evaluation Criterion created.' : 'Assign Vendor Evaluation Criterion updated.'
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
      vendorFk: this.item?.vendorFk ?? null,
      vendorEvaluationCriteriaFk: this.item?.vendorEvaluationCriteriaFk ?? null,
      rankFk: this.item?.rankFk ?? null,
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/administration/assign-vendor-evaluation-criterion']);
  }
}
