import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateVendorOrderQualityDetail, VendorOrderQualityDetail } from '../../../Shared/Model/-vendor-order-quality-detail.model';
import { VendorOrderQualityDetailService } from './vendor-order-quality-detail.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface VendorOrderQualityDetailFormDialogData {
  mode: FormMode;
  item?: VendorOrderQualityDetail;
}

@Component({
  selector: 'app-vendor-order-quality-detail-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './vendor-order-quality-detail-form.component.html',
  styleUrl: './vendor-order-quality-detail-form.component.css',
})
export class VendorOrderQualityDetailFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(VendorOrderQualityDetailService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<VendorOrderQualityDetailFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: VendorOrderQualityDetail;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Vendor Order Quality Detail' : 'Edit Vendor Order Quality Detail';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      vendorOrderQualityFk: [null],
      vendorOrderDetailFk: [null],
      inventoryItemFk: [null],
      receivedQuantity: [null],
      landedCost: [null],
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
    const value = this.form.getRawValue() as CreateVendorOrderQualityDetail;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Vendor Order Quality Detail created.' : 'Vendor Order Quality Detail updated.'
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
      vendorOrderQualityFk: this.item?.vendorOrderQualityFk ?? null,
      vendorOrderDetailFk: this.item?.vendorOrderDetailFk ?? null,
      inventoryItemFk: this.item?.inventoryItemFk ?? null,
      receivedQuantity: this.item?.receivedQuantity ?? null,
      landedCost: this.item?.landedCost ?? null,
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/procurement/vendor-order-quality-detail']);
  }
}
