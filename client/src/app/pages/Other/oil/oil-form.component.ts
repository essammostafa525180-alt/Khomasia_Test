import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateOil, Oil } from '../../../Shared/Model/-oil.model';
import { OilService } from './oil.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface OilFormDialogData {
  mode: FormMode;
  item?: Oil;
}

@Component({
  selector: 'app-oil-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './oil-form.component.html',
  styleUrl: './oil-form.component.css',
})
export class OilFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(OilService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<OilFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: Oil;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Oil' : 'Edit Oil';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      storeId: [null],
      storeName: [''],
      stockCountDate: [null],
      inventoryItemId: [null],
      inventoryItemCode: [''],
      inventoryItemName: [''],
      avgCost: [null],
      totalQuantity: [null],
      stockCountQuantity: [null],
      mmbalance: [null],
      isMatch: [''],
      isUpdated: [null],
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
    const value = this.form.getRawValue() as CreateOil;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Oil created.' : 'Oil updated.'
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
      storeId: this.item?.storeId ?? null,
      storeName: this.item?.storeName ?? '',
      stockCountDate: this.toDateInput(this.item?.stockCountDate),
      inventoryItemId: this.item?.inventoryItemId ?? null,
      inventoryItemCode: this.item?.inventoryItemCode ?? '',
      inventoryItemName: this.item?.inventoryItemName ?? '',
      avgCost: this.item?.avgCost ?? null,
      totalQuantity: this.item?.totalQuantity ?? null,
      stockCountQuantity: this.item?.stockCountQuantity ?? null,
      mmbalance: this.item?.mmbalance ?? null,
      isMatch: this.item?.isMatch ?? '',
      isUpdated: this.item?.isUpdated ?? null,
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
    this.router.navigate(['/other/oil']);
  }
}
