import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateAssetCountPlan, AssetCountPlan } from '../../../Shared/Model/-asset-count-plan.model';
import { AssetCountPlanService } from './asset-count-plan.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface AssetCountPlanFormDialogData {
  mode: FormMode;
  item?: AssetCountPlan;
}

@Component({
  selector: 'app-asset-count-plan-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './asset-count-plan-form.component.html',
  styleUrl: './asset-count-plan-form.component.css',
})
export class AssetCountPlanFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(AssetCountPlanService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<AssetCountPlanFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: AssetCountPlan;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Asset Count Plan' : 'Edit Asset Count Plan';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      planNumber: [''],
      name: [''],
      nameAr: [''],
      assetCountPlanTypeFk: [null],
      assetCountPlanStatusFk: [null],
      planeDate: [null],
      executionDate: [null],
      assignedToUserFk: [null],
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
    const value = this.form.getRawValue() as CreateAssetCountPlan;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Asset Count Plan created.' : 'Asset Count Plan updated.'
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
      planNumber: this.item?.planNumber ?? '',
      name: this.item?.name ?? '',
      nameAr: this.item?.nameAr ?? '',
      assetCountPlanTypeFk: this.item?.assetCountPlanTypeFk ?? null,
      assetCountPlanStatusFk: this.item?.assetCountPlanStatusFk ?? null,
      planeDate: this.toDateInput(this.item?.planeDate),
      executionDate: this.toDateInput(this.item?.executionDate),
      assignedToUserFk: this.item?.assignedToUserFk ?? null,
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
    this.router.navigate(['/inventory/asset-count-plan']);
  }
}
