import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateSalesQuotation, SalesQuotation } from '../../../Shared/Model/-sales-quotation.model';
import { SalesQuotationService } from './sales-quotation.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface SalesQuotationFormDialogData {
  mode: FormMode;
  item?: SalesQuotation;
}

@Component({
  selector: 'app-sales-quotation-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './sales-quotation-form.component.html',
  styleUrl: './sales-quotation-form.component.css',
})
export class SalesQuotationFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(SalesQuotationService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<SalesQuotationFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: SalesQuotation;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Sales Quotation' : 'Edit Sales Quotation';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      companyFk: [null],
      requestForQuotationFk: [null],
      orderNo: [''],
      orderDate: [null],
      customerFk: [null],
      notes: [''],
      totalRatio: [null],
      totalCost: [null],
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
    const value = this.form.getRawValue() as CreateSalesQuotation;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Sales Quotation created.' : 'Sales Quotation updated.'
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
      companyFk: this.item?.companyFk ?? null,
      requestForQuotationFk: this.item?.requestForQuotationFk ?? null,
      orderNo: this.item?.orderNo ?? '',
      orderDate: this.toDateInput(this.item?.orderDate),
      customerFk: this.item?.customerFk ?? null,
      notes: this.item?.notes ?? '',
      totalRatio: this.item?.totalRatio ?? null,
      totalCost: this.item?.totalCost ?? null,
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
    this.router.navigate(['/reports/sales-quotation']);
  }
}
