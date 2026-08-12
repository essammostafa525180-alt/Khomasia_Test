import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateAssetItem, AssetItem } from '../../../Shared/Model/-asset-item.model';
import { AssetItemService } from './asset-item.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface AssetItemFormDialogData {
  mode: FormMode;
  item?: AssetItem;
}

@Component({
  selector: 'app-asset-item-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './asset-item-form.component.html',
  styleUrl: './asset-item-form.component.css',
})
export class AssetItemFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(AssetItemService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<AssetItemFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: AssetItem;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Asset Item' : 'Edit Asset Item';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      assetStatusFk: [null],
      purchaseValue: [null],
      departmentFk: [null],
      projectFk: [null],
      assetLocationFk: [null],
      employeeFk: [null],
      moveDate: [null],
      assetWarrantyStatusFk: [null],
      isOperational: [false],
      depreciationRate: [null],
      depreciationDuration: [null],
      fixedAssetAccountCode: [''],
      depreciationAccountCode: [''],
      insuranceVendorFk: [null],
      insuranceAccountCode: [''],
      policyNumber: [''],
      policyAmount: [null],
      modelName: [''],
      description: [''],
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
    const value = this.form.getRawValue() as CreateAssetItem;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Asset Item created.' : 'Asset Item updated.'
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
      assetStatusFk: this.item?.assetStatusFk ?? null,
      purchaseValue: this.item?.purchaseValue ?? null,
      departmentFk: this.item?.departmentFk ?? null,
      projectFk: this.item?.projectFk ?? null,
      assetLocationFk: this.item?.assetLocationFk ?? null,
      employeeFk: this.item?.employeeFk ?? null,
      moveDate: this.toDateInput(this.item?.moveDate),
      assetWarrantyStatusFk: this.item?.assetWarrantyStatusFk ?? null,
      isOperational: this.item?.isOperational ?? false,
      depreciationRate: this.item?.depreciationRate ?? null,
      depreciationDuration: this.item?.depreciationDuration ?? null,
      fixedAssetAccountCode: this.item?.fixedAssetAccountCode ?? '',
      depreciationAccountCode: this.item?.depreciationAccountCode ?? '',
      insuranceVendorFk: this.item?.insuranceVendorFk ?? null,
      insuranceAccountCode: this.item?.insuranceAccountCode ?? '',
      policyNumber: this.item?.policyNumber ?? '',
      policyAmount: this.item?.policyAmount ?? null,
      modelName: this.item?.modelName ?? '',
      description: this.item?.description ?? '',
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
    this.router.navigate(['/inventory/asset-item']);
  }
}
