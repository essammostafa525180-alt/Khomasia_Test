import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateSalesInvoiceItem, SalesInvoiceItem } from '../../../Shared/Model/-sales-invoice-item.model';
import { SalesInvoiceItemService } from './sales-invoice-item.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface SalesInvoiceItemFormDialogData {
  mode: FormMode;
  item?: SalesInvoiceItem;
}

@Component({
  selector: 'app-sales-invoice-item-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './sales-invoice-item-form.component.html',
  styleUrl: './sales-invoice-item-form.component.css',
})
export class SalesInvoiceItemFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(SalesInvoiceItemService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<SalesInvoiceItemFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: SalesInvoiceItem;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Sales Invoice Item' : 'Edit Sales Invoice Item';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      salesInvoiceId: [null],
      productId: [null],
      quantity: [null],
      price: [null],
      discount: [null],
      netAmount: [null],
      updatedOn: [null],
      updatedBy: [null],
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
    const value = this.form.getRawValue() as CreateSalesInvoiceItem;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Sales Invoice Item created.' : 'Sales Invoice Item updated.'
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
      salesInvoiceId: this.item?.salesInvoiceId ?? null,
      productId: this.item?.productId ?? null,
      quantity: this.item?.quantity ?? null,
      price: this.item?.price ?? null,
      discount: this.item?.discount ?? null,
      netAmount: this.item?.netAmount ?? null,
      updatedOn: this.toDateInput(this.item?.updatedOn),
      updatedBy: this.item?.updatedBy ?? null,
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
    this.router.navigate(['/reports/sales-invoice-item']);
  }
}
