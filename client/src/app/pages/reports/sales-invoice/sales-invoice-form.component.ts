import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateSalesInvoice, SalesInvoice } from '../../../Shared/Model/-sales-invoice.model';
import { SalesInvoiceService } from './sales-invoice.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface SalesInvoiceFormDialogData {
  mode: FormMode;
  item?: SalesInvoice;
}

@Component({
  selector: 'app-sales-invoice-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './sales-invoice-form.component.html',
  styleUrl: './sales-invoice-form.component.css',
})
export class SalesInvoiceFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(SalesInvoiceService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<SalesInvoiceFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: SalesInvoice;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Sales Invoice' : 'Edit Sales Invoice';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      customerId: [null],
      userId: [null],
      address: [''],
      contactPerson: [''],
      vatpercentage: [null],
      vatamount: [null],
      totalAmount: [null],
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
    const value = this.form.getRawValue() as CreateSalesInvoice;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Sales Invoice created.' : 'Sales Invoice updated.'
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
      customerId: this.item?.customerId ?? null,
      userId: this.item?.userId ?? null,
      address: this.item?.address ?? '',
      contactPerson: this.item?.contactPerson ?? '',
      vatpercentage: this.item?.vatpercentage ?? null,
      vatamount: this.item?.vatamount ?? null,
      totalAmount: this.item?.totalAmount ?? null,
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
    this.router.navigate(['/reports/sales-invoice']);
  }
}
