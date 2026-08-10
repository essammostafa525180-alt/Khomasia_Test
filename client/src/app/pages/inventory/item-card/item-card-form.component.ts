import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateInventoryItem, InventoryItem } from '../../../Shared/Model/inventory-item.model';
import { ItemCardService } from './item-card.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface InventoryItemFormDialogData {
  mode: FormMode;
  item?: InventoryItem;
}

@Component({
  selector: 'app-item-card-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './item-card-form.component.html',
  styleUrl: './item-card-form.component.css',
})
export class InventoryItemFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(ItemCardService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<InventoryItemFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: InventoryItem;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Item Card' : 'Edit Item Card';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      itemNumber: [''],
      name: [''],
      nameAr: [''],
      itemTypeFK: [null],
      chemicalGroupFK: [null],
      assetGroupFK: [null],
      materialGroupFK: [null],
      sparePartGroupFK: [null],
      totalQuantity: [null],
      unitOfMeasureFK: [null],
      itemExpiryTypeFK: [null],
      warrantyStatusFK: [null],
      rfid: [''],
      englishDescription: [''],
      arabicDescription: [''],
      autoReplenishment: [false],
      isMaintainable: [false],
      manufactureFK: [null],
      minLevel: [null],
      maxLevel: [null],
      autoRequestQuantity: [null],
      model: [''],
      deliveryPeriodDays: [null],
      concentration: [null],
      isBatch: [false],
      isSerial: [false],
      avgCost: [null],
      axSynced: [false],
      idelPeriod: [null],
      lastPurchasePrice: [null],
      isScrap: [false],
      itemQuantityTypeFK: [null],
      materialCategoryFK: [null],
      materialSubCategoryFK: [null],
      isDisabled: [false],
      density: [null],
      volumeSolid: [null],
      spreadingRate: [null],
      dft: [null],
      packing: [null],
      itemCode: [''],
      isActive: [false],
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
    debugger
    if (this.form.invalid || this.saving) {
      this.form.markAllAsTouched();
      return;
    }

    this.saving = true;
    const value = this.form.getRawValue() as CreateInventoryItem;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Item Card created.' : 'Item Card updated.'
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
      itemNumber: this.item?.itemNumber ?? '',
      name: this.item?.name ?? '',
      nameAr: this.item?.nameAr ?? '',
      itemTypeFK: this.item?.itemTypeFK ?? null,
      chemicalGroupFK: this.item?.chemicalGroupFK ?? null,
      assetGroupFK: this.item?.assetGroupFK ?? null,
      materialGroupFK: this.item?.materialGroupFK ?? null,
      sparePartGroupFK: this.item?.sparePartGroupFK ?? null,
      totalQuantity: this.item?.totalQuantity ?? null,
      unitOfMeasureFK: this.item?.unitOfMeasureFK ?? null,
      itemExpiryTypeFK: this.item?.itemExpiryTypeFK ?? null,
      warrantyStatusFK: this.item?.warrantyStatusFK ?? null,
      rfid: this.item?.rfid ?? '',
      englishDescription: this.item?.englishDescription ?? '',
      arabicDescription: this.item?.arabicDescription ?? '',
      autoReplenishment: this.item?.autoReplenishment ?? false,
      isMaintainable: this.item?.isMaintainable ?? false,
      manufactureFK: this.item?.manufactureFK ?? null,
      minLevel: this.item?.minLevel ?? null,
      maxLevel: this.item?.maxLevel ?? null,
      autoRequestQuantity: this.item?.autoRequestQuantity ?? null,
      model: this.item?.model ?? '',
      deliveryPeriodDays: this.item?.deliveryPeriodDays ?? null,
      concentration: this.item?.concentration ?? null,
      isBatch: this.item?.isBatch ?? false,
      isSerial: this.item?.isSerial ?? false,
      avgCost: this.item?.avgCost ?? null,
      axSynced: this.item?.axSynced ?? false,
      idelPeriod: this.item?.idelPeriod ?? null,
      lastPurchasePrice: this.item?.lastPurchasePrice ?? null,
      isScrap: this.item?.isScrap ?? false,
      itemQuantityTypeFK: this.item?.itemQuantityTypeFK ?? null,
      materialCategoryFK: this.item?.materialCategoryFK ?? null,
      materialSubCategoryFK: this.item?.materialSubCategoryFK ?? null,
      isDisabled: this.item?.isDisabled ?? false,
      density: this.item?.density ?? null,
      volumeSolid: this.item?.volumeSolid ?? null,
      spreadingRate: this.item?.spreadingRate ?? null,
      dft: this.item?.dft ?? null,
      packing: this.item?.packing ?? null,
      itemCode: this.item?.itemCode ?? '',
      isActive: this.item?.isActive ?? false,
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/inventory/item-card']);
  }
}
