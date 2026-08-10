import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateInventoryItemReturn, InventoryItemReturn } from '../../../Shared/Model/-inventory-item-return.model';
import { InventoryItemReturnService } from './inventory-item-return.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface InventoryItemReturnFormDialogData {
  mode: FormMode;
  item?: InventoryItemReturn;
}

@Component({
  selector: 'app-inventory-item-return-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './inventory-item-return-form.component.html',
  styleUrl: './inventory-item-return-form.component.css',
})
export class InventoryItemReturnEntityFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(InventoryItemReturnService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<InventoryItemReturnFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: InventoryItemReturn;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Inventory Item Return' : 'Edit Inventory Item Return';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      requestWithdrawFk: [null],
      returnNo: [''],
      returnDate: [null],
      returnedByFk: [null],
      returnedBy: [''],
      descriptionEn: [''],
      descriptionAr: [''],
      itemReturnStatusFk: [null],
      isAprove: [false],
      axsynced: [false],
      sourceId: [null],
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
    const value = this.form.getRawValue() as CreateInventoryItemReturn;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Inventory Item Return created.' : 'Inventory Item Return updated.'
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
      requestWithdrawFk: this.item?.requestWithdrawFk ?? null,
      returnNo: this.item?.returnNo ?? '',
      returnDate: this.toDateInput(this.item?.returnDate),
      returnedByFk: this.item?.returnedByFk ?? null,
      returnedBy: this.item?.returnedBy ?? '',
      descriptionEn: this.item?.descriptionEn ?? '',
      descriptionAr: this.item?.descriptionAr ?? '',
      itemReturnStatusFk: this.item?.itemReturnStatusFk ?? null,
      isAprove: this.item?.isAprove ?? false,
      axsynced: this.item?.axsynced ?? false,
      sourceId: this.item?.sourceId ?? null,
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
    this.router.navigate(['/inventory/inventory-item-return']);
  }
}
