import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateVendorOrderReceiveDetailBatch, VendorOrderReceiveDetailBatch } from '../../../Shared/Model/-vendor-order-receive-detail-batch.model';
import { VendorOrderReceiveDetailBatchService } from './vendor-order-receive-detail-batch.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface VendorOrderReceiveDetailBatchFormDialogData {
  mode: FormMode;
  item?: VendorOrderReceiveDetailBatch;
}

@Component({
  selector: 'app-vendor-order-receive-detail-batch-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './vendor-order-receive-detail-batch-form.component.html',
  styleUrl: './vendor-order-receive-detail-batch-form.component.css',
})
export class VendorOrderReceiveDetailBatchFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(VendorOrderReceiveDetailBatchService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<VendorOrderReceiveDetailBatchFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: VendorOrderReceiveDetailBatch;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Vendor Order Receive Detail Batch' : 'Edit Vendor Order Receive Detail Batch';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      vendorOrderReceiveDetailFk: [null],
      shelfFk: [null],
      batchNumber: [''],
      quantity: [null],
      returnedQuantity: [null],
      expiryDate: [null],
      productionDate: [null],
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
    const value = this.form.getRawValue() as CreateVendorOrderReceiveDetailBatch;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Vendor Order Receive Detail Batch created.' : 'Vendor Order Receive Detail Batch updated.'
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
      vendorOrderReceiveDetailFk: this.item?.vendorOrderReceiveDetailFk ?? null,
      shelfFk: this.item?.shelfFk ?? null,
      batchNumber: this.item?.batchNumber ?? '',
      quantity: this.item?.quantity ?? null,
      returnedQuantity: this.item?.returnedQuantity ?? null,
      expiryDate: this.toDateInput(this.item?.expiryDate),
      productionDate: this.toDateInput(this.item?.productionDate),
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
    this.router.navigate(['/procurement/vendor-order-receive-detail-batch']);
  }
}
