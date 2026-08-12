import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreatePurchaseOrderService, PurchaseOrderService } from '../../../Shared/Model/-purchase-order-service.model';
import { PurchaseOrderServiceService } from './purchase-order-service.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface PurchaseOrderServiceFormDialogData {
  mode: FormMode;
  item?: PurchaseOrderService;
}

@Component({
  selector: 'app-purchase-order-service-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './purchase-order-service-form.component.html',
  styleUrl: './purchase-order-service-form.component.css',
})
export class PurchaseOrderServiceFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(PurchaseOrderServiceService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<PurchaseOrderServiceFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: PurchaseOrderService;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Purchase Order Service' : 'Edit Purchase Order Service';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      orderScreenFk: [null],
      poserviceTypeFk: [null],
      vendorOrderTypeFk: [null],
      vendorFk: [null],
      prfk: [null],
      orderNo: [''],
      requestDate: [null],
      orderDate: [null],
      orderByUserFk: [null],
      projectFk: [null],
      locationFk: [null],
      serviceMainCategoryFk: [null],
      scopeFk: [null],
      vendorOrderStatusFk: [null],
      paymentTermFk: [null],
      paymentTerms: [''],
      isApproved: [false],
      duration: [null],
      companyFk: [null],
      contractId: [null],
      startDate: [null],
      endDate: [null],
      contractCode: [''],
      totalCost: [null],
      description: [''],
      inventoryItemBudgetFk: [null],
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
    const value = this.form.getRawValue() as CreatePurchaseOrderService;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Purchase Order Service created.' : 'Purchase Order Service updated.'
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
      orderScreenFk: this.item?.orderScreenFk ?? null,
      poserviceTypeFk: this.item?.poserviceTypeFk ?? null,
      vendorOrderTypeFk: this.item?.vendorOrderTypeFk ?? null,
      vendorFk: this.item?.vendorFk ?? null,
      prfk: this.item?.prfk ?? null,
      orderNo: this.item?.orderNo ?? '',
      requestDate: this.toDateInput(this.item?.requestDate),
      orderDate: this.toDateInput(this.item?.orderDate),
      orderByUserFk: this.item?.orderByUserFk ?? null,
      projectFk: this.item?.projectFk ?? null,
      locationFk: this.item?.locationFk ?? null,
      serviceMainCategoryFk: this.item?.serviceMainCategoryFk ?? null,
      scopeFk: this.item?.scopeFk ?? null,
      vendorOrderStatusFk: this.item?.vendorOrderStatusFk ?? null,
      paymentTermFk: this.item?.paymentTermFk ?? null,
      paymentTerms: this.item?.paymentTerms ?? '',
      isApproved: this.item?.isApproved ?? false,
      duration: this.item?.duration ?? null,
      companyFk: this.item?.companyFk ?? null,
      contractId: this.item?.contractId ?? null,
      startDate: this.toDateInput(this.item?.startDate),
      endDate: this.toDateInput(this.item?.endDate),
      contractCode: this.item?.contractCode ?? '',
      totalCost: this.item?.totalCost ?? null,
      description: this.item?.description ?? '',
      inventoryItemBudgetFk: this.item?.inventoryItemBudgetFk ?? null,
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
    this.router.navigate(['/procurement/purchase-order-service']);
  }
}
