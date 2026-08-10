import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateInventoryStockCountPlan, InventoryStockCountPlan } from '../../../Shared/Model/-inventory-stock-count-plan.model';
import { InventoryStockCountPlanService } from './inventory-stock-count-plan.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface InventoryStockCountPlanFormDialogData {
  mode: FormMode;
  item?: InventoryStockCountPlan;
}

@Component({
  selector: 'app-inventory-stock-count-plan-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './inventory-stock-count-plan-form.component.html',
  styleUrl: './inventory-stock-count-plan-form.component.css',
})
export class InventoryStockCountPlanFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(InventoryStockCountPlanService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<InventoryStockCountPlanFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: InventoryStockCountPlan;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Inventory Stock Count Plan' : 'Edit Inventory Stock Count Plan';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      countPlanNo: [''],
      name: [''],
      nameAr: [''],
      planDate: [null],
      executionDate: [null],
      stockCountPlanStatusFk: [null],
      stockCountPlanTypeFk: [null],
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
    const value = this.form.getRawValue() as CreateInventoryStockCountPlan;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Inventory Stock Count Plan created.' : 'Inventory Stock Count Plan updated.'
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
      countPlanNo: this.item?.countPlanNo ?? '',
      name: this.item?.name ?? '',
      nameAr: this.item?.nameAr ?? '',
      planDate: this.toDateInput(this.item?.planDate),
      executionDate: this.toDateInput(this.item?.executionDate),
      stockCountPlanStatusFk: this.item?.stockCountPlanStatusFk ?? null,
      stockCountPlanTypeFk: this.item?.stockCountPlanTypeFk ?? null,
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
    this.router.navigate(['/inventory/inventory-stock-count-plan']);
  }
}
