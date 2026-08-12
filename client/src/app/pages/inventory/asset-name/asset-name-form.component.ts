import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateAsset, Asset } from '../../../Shared/Model/-asset.model';
import { AssetNameService } from './asset-name.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface AssetFormDialogData {
  mode: FormMode;
  item?: Asset;
}

@Component({
  selector: 'app-asset-name-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './asset-name-form.component.html',
  styleUrl: './asset-name-form.component.css',
})
export class AssetFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(AssetNameService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<AssetFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: Asset;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Asset Name' : 'Edit Asset Name';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      assetGroupFk: [null],
      assetTypeFk: [null],
      toolsTypeFk: [null],
      code: [''],
      name: [''],
      nameAr: [''],
      zoneFk: [null],
      equipmentCodeFk: [null],
      equipmentLocationCode: [''],
      functionalCode: [''],
      quantity: [null],
      costPerHour: [null],
      currencyFk: [null],
      warrantyStatusFk: [null],
      rfid: [''],
      remarks: [''],
      possessionTypeFk: [null],
      operationDate: [null],
      isOperational: [false],
      insuranceVendorFk: [null],
      policyNumber: [''],
      policyDate: [null],
      policyExpiryDate: [null],
      policyAmount: [null],
      manufactureFk: [null],
      model: [''],
      modelYearFk: [null],
      serialNumber: [''],
      guaranteeExpiryDate: [null],
      technicalInformation: [''],
      axsynced: [false],
      projectFk: [null],
      assetStatusFk: [null],
      purchasePrice: [null],
      purchaseDate: [null],
      checkDate: [null],
      lifeTime: [null],
      depreciationRate: [null],
      plannedDepreciationDate: [null],
      actualDepreciationDate: [null],
      oufk: [null],
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
    const value = this.form.getRawValue() as CreateAsset;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Asset Name created.' : 'Asset Name updated.'
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
      assetGroupFk: this.item?.assetGroupFk ?? null,
      assetTypeFk: this.item?.assetTypeFk ?? null,
      toolsTypeFk: this.item?.toolsTypeFk ?? null,
      code: this.item?.code ?? '',
      name: this.item?.name ?? '',
      nameAr: this.item?.nameAr ?? '',
      zoneFk: this.item?.zoneFk ?? null,
      equipmentCodeFk: this.item?.equipmentCodeFk ?? null,
      equipmentLocationCode: this.item?.equipmentLocationCode ?? '',
      functionalCode: this.item?.functionalCode ?? '',
      quantity: this.item?.quantity ?? null,
      costPerHour: this.item?.costPerHour ?? null,
      currencyFk: this.item?.currencyFk ?? null,
      warrantyStatusFk: this.item?.warrantyStatusFk ?? null,
      rfid: this.item?.rfid ?? '',
      remarks: this.item?.remarks ?? '',
      possessionTypeFk: this.item?.possessionTypeFk ?? null,
      operationDate: this.toDateInput(this.item?.operationDate),
      isOperational: this.item?.isOperational ?? false,
      insuranceVendorFk: this.item?.insuranceVendorFk ?? null,
      policyNumber: this.item?.policyNumber ?? '',
      policyDate: this.toDateInput(this.item?.policyDate),
      policyExpiryDate: this.toDateInput(this.item?.policyExpiryDate),
      policyAmount: this.item?.policyAmount ?? null,
      manufactureFk: this.item?.manufactureFk ?? null,
      model: this.item?.model ?? '',
      modelYearFk: this.item?.modelYearFk ?? null,
      serialNumber: this.item?.serialNumber ?? '',
      guaranteeExpiryDate: this.toDateInput(this.item?.guaranteeExpiryDate),
      technicalInformation: this.item?.technicalInformation ?? '',
      axsynced: this.item?.axsynced ?? false,
      projectFk: this.item?.projectFk ?? null,
      assetStatusFk: this.item?.assetStatusFk ?? null,
      purchasePrice: this.item?.purchasePrice ?? null,
      purchaseDate: this.toDateInput(this.item?.purchaseDate),
      checkDate: this.toDateInput(this.item?.checkDate),
      lifeTime: this.item?.lifeTime ?? null,
      depreciationRate: this.item?.depreciationRate ?? null,
      plannedDepreciationDate: this.toDateInput(this.item?.plannedDepreciationDate),
      actualDepreciationDate: this.toDateInput(this.item?.actualDepreciationDate),
      oufk: this.item?.oufk ?? null,
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
    this.router.navigate(['/inventory/asset-name']);
  }
}
