import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateVendorOrderVendorSuggested, VendorOrderVendorSuggested } from '../../../Shared/Model/-vendor-order-vendor-suggested.model';
import { VendorOrderVendorSuggestedService } from './vendor-order-vendor-suggested.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface VendorOrderVendorSuggestedFormDialogData {
  mode: FormMode;
  item?: VendorOrderVendorSuggested;
}

@Component({
  selector: 'app-vendor-order-vendor-suggested-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './vendor-order-vendor-suggested-form.component.html',
  styleUrl: './vendor-order-vendor-suggested-form.component.css',
})
export class VendorOrderVendorSuggestedFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(VendorOrderVendorSuggestedService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<VendorOrderVendorSuggestedFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: VendorOrderVendorSuggested;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Vendor Order Vendor Suggested' : 'Edit Vendor Order Vendor Suggested';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      vendorOrderFk: [null],
      vendorName: [''],
      address: [''],
      phone: [''],
      email: [''],
      website: [''],
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
    const value = this.form.getRawValue() as CreateVendorOrderVendorSuggested;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Vendor Order Vendor Suggested created.' : 'Vendor Order Vendor Suggested updated.'
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
      vendorOrderFk: this.item?.vendorOrderFk ?? null,
      vendorName: this.item?.vendorName ?? '',
      address: this.item?.address ?? '',
      phone: this.item?.phone ?? '',
      email: this.item?.email ?? '',
      website: this.item?.website ?? '',
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/procurement/vendor-order-vendor-suggested']);
  }
}
