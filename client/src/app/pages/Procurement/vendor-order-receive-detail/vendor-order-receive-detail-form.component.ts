import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateVendorOrderReceiveDetail, VendorOrderReceiveDetail } from '../../../Shared/Model/-vendor-order-receive-detail.model';
import { VendorOrderReceiveDetailService } from './vendor-order-receive-detail.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface VendorOrderReceiveDetailFormDialogData {
  mode: FormMode;
  item?: VendorOrderReceiveDetail;
}

@Component({
  selector: 'app-vendor-order-receive-detail-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './vendor-order-receive-detail-form.component.html',
  styleUrl: './vendor-order-receive-detail-form.component.css',
})
export class VendorOrderReceiveDetailFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(VendorOrderReceiveDetailService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<VendorOrderReceiveDetailFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: VendorOrderReceiveDetail;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Vendor Order Receive Detail' : 'Edit Vendor Order Receive Detail';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      vendorOrderReceiveFk: [null],
      vendorOrderQualityDetailFk: [null],
      inventoryItemFk: [null],
      receivedQuantity: [null],
      returnedQuantity: [null],
      fromSerialize: [null],
      toSerialize: [null],
      notes: [''],
      partNo: [''],
      manufacturerCountry: [''],
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
    const value = this.form.getRawValue() as CreateVendorOrderReceiveDetail;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Vendor Order Receive Detail created.' : 'Vendor Order Receive Detail updated.'
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
      vendorOrderReceiveFk: this.item?.vendorOrderReceiveFk ?? null,
      vendorOrderQualityDetailFk: this.item?.vendorOrderQualityDetailFk ?? null,
      inventoryItemFk: this.item?.inventoryItemFk ?? null,
      receivedQuantity: this.item?.receivedQuantity ?? null,
      returnedQuantity: this.item?.returnedQuantity ?? null,
      fromSerialize: this.item?.fromSerialize ?? null,
      toSerialize: this.item?.toSerialize ?? null,
      notes: this.item?.notes ?? '',
      partNo: this.item?.partNo ?? '',
      manufacturerCountry: this.item?.manufacturerCountry ?? '',
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/procurement/vendor-order-receive-detail']);
  }
}
