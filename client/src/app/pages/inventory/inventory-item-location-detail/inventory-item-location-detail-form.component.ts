import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateInventoryItemLocationDetail, InventoryItemLocationDetail } from '../../../Shared/Model/-inventory-item-location-detail.model';
import { InventoryItemLocationDetailService } from './inventory-item-location-detail.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface InventoryItemLocationDetailFormDialogData {
  mode: FormMode;
  item?: InventoryItemLocationDetail;
}

@Component({
  selector: 'app-inventory-item-location-detail-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './inventory-item-location-detail-form.component.html',
  styleUrl: './inventory-item-location-detail-form.component.css',
})
export class InventoryItemLocationDetailFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(InventoryItemLocationDetailService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<InventoryItemLocationDetailFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: InventoryItemLocationDetail;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Inventory Item Location Detail' : 'Edit Inventory Item Location Detail';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      storeFk: [null],
      inventoryItemFk: [null],
      itemQuantityTypeFk: [null],
      transactionTypeFk: [null],
      screen: [''],
      entityId: [null],
      entityCode: [''],
      entityDate: [null],
      entityDetailId: [null],
      inventoryItemLocationFk: [null],
      quantityBefore: [null],
      quantity: [null],
      quantityAfter: [null],
      entityDetailCost: [null],
      avgcost: [null],
      inventoryItemLocationBatchFk: [null],
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
    const value = this.form.getRawValue() as CreateInventoryItemLocationDetail;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Inventory Item Location Detail created.' : 'Inventory Item Location Detail updated.'
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
      storeFk: this.item?.storeFk ?? null,
      inventoryItemFk: this.item?.inventoryItemFk ?? null,
      itemQuantityTypeFk: this.item?.itemQuantityTypeFk ?? null,
      transactionTypeFk: this.item?.transactionTypeFk ?? null,
      screen: this.item?.screen ?? '',
      entityId: this.item?.entityId ?? null,
      entityCode: this.item?.entityCode ?? '',
      entityDate: this.toDateInput(this.item?.entityDate),
      entityDetailId: this.item?.entityDetailId ?? null,
      inventoryItemLocationFk: this.item?.inventoryItemLocationFk ?? null,
      quantityBefore: this.item?.quantityBefore ?? null,
      quantity: this.item?.quantity ?? null,
      quantityAfter: this.item?.quantityAfter ?? null,
      entityDetailCost: this.item?.entityDetailCost ?? null,
      avgcost: this.item?.avgcost ?? null,
      inventoryItemLocationBatchFk: this.item?.inventoryItemLocationBatchFk ?? null,
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
    this.router.navigate(['/inventory/inventory-item-location-detail']);
  }
}
