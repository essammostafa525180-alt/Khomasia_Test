import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateInventoryStockCountDetailBatchSerial, InventoryStockCountDetailBatchSerial } from '../../../Shared/Model/-inventory-stock-count-detail-batch-serial.model';
import { InventoryStockCountDetailBatchSerialService } from './inventory-stock-count-detail-batch-serial.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface InventoryStockCountDetailBatchSerialFormDialogData {
  mode: FormMode;
  item?: InventoryStockCountDetailBatchSerial;
}

@Component({
  selector: 'app-inventory-stock-count-detail-batch-serial-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './inventory-stock-count-detail-batch-serial-form.component.html',
  styleUrl: './inventory-stock-count-detail-batch-serial-form.component.css',
})
export class InventoryStockCountDetailBatchSerialFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(InventoryStockCountDetailBatchSerialService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<InventoryStockCountDetailBatchSerialFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: InventoryStockCountDetailBatchSerial;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Inventory Stock Count Detail Batch Serial' : 'Edit Inventory Stock Count Detail Batch Serial';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      inventoryStockCountDetailBatchFk: [null],
      inventoryItemLocationBatchSerialFk: [null],
      isNew: [false],
      isSerialExist: [false],
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
    const value = this.form.getRawValue() as CreateInventoryStockCountDetailBatchSerial;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Inventory Stock Count Detail Batch Serial created.' : 'Inventory Stock Count Detail Batch Serial updated.'
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
      inventoryStockCountDetailBatchFk: this.item?.inventoryStockCountDetailBatchFk ?? null,
      inventoryItemLocationBatchSerialFk: this.item?.inventoryItemLocationBatchSerialFk ?? null,
      isNew: this.item?.isNew ?? false,
      isSerialExist: this.item?.isSerialExist ?? false,
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/inventory/inventory-stock-count-detail-batch-serial']);
  }
}
