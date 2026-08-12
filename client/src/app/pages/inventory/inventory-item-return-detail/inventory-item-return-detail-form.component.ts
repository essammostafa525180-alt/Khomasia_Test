import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateInventoryItemReturnDetail, InventoryItemReturnDetail } from '../../../Shared/Model/-inventory-item-return-detail.model';
import { InventoryItemReturnDetailService } from './inventory-item-return-detail.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface InventoryItemReturnDetailFormDialogData {
  mode: FormMode;
  item?: InventoryItemReturnDetail;
}

@Component({
  selector: 'app-inventory-item-return-detail-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './inventory-item-return-detail-form.component.html',
  styleUrl: './inventory-item-return-detail-form.component.css',
})
export class InventoryItemReturnDetailFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(InventoryItemReturnDetailService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<InventoryItemReturnDetailFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: InventoryItemReturnDetail;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Inventory Item Return Detail' : 'Edit Inventory Item Return Detail';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      inventoryItemReturnFk: [null],
      inventoryItemFk: [null],
      returnedQuantity: [null],
      returnReasonFk: [null],
      notes: [''],
      externalReturnedQuantity: [null],
      requestWdfk: [null],
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
    const value = this.form.getRawValue() as CreateInventoryItemReturnDetail;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Inventory Item Return Detail created.' : 'Inventory Item Return Detail updated.'
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
      inventoryItemReturnFk: this.item?.inventoryItemReturnFk ?? null,
      inventoryItemFk: this.item?.inventoryItemFk ?? null,
      returnedQuantity: this.item?.returnedQuantity ?? null,
      returnReasonFk: this.item?.returnReasonFk ?? null,
      notes: this.item?.notes ?? '',
      externalReturnedQuantity: this.item?.externalReturnedQuantity ?? null,
      requestWdfk: this.item?.requestWdfk ?? null,
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/inventory/inventory-item-return-detail']);
  }
}
