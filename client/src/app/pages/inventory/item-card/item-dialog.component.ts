import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormsModule,
  ReactiveFormsModule,
  FormBuilder,
  FormGroup
} from '@angular/forms';
import {
  MAT_DIALOG_DATA,
  MatDialogModule,
  MatDialogRef
} from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatButtonModule } from '@angular/material/button';
import { TranslatePipe } from '@ngx-translate/core';
import { InventoryItem, InventoryItemPayload } from '../../../Shared/Model/inventory-item.model';

export type ItemDialogMode = 'view' | 'create' | 'edit';

export interface ItemDialogData {
  mode: ItemDialogMode;
  item?: InventoryItem
}

@Component({
  selector: 'app-item-dialog',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatCheckboxModule,
    MatButtonModule,
    TranslatePipe
  ],
  template: `
    <h2 mat-dialog-title>{{ title | translate }}</h2>

    <mat-dialog-content>
      <form [formGroup]="form" class="item-form">
        <div class="form-grid">
          <mat-form-field appearance="outline">
            <mat-label>{{ 'GRID.ITEM_NUMBER' | translate }}</mat-label>
            <input matInput formControlName="itemNumber" />
          </mat-form-field>

          <mat-form-field appearance="outline">
            <mat-label>{{ 'GRID.ITEM_NAME_EN' | translate }}</mat-label>
            <input matInput formControlName="name" />
          </mat-form-field>

          <mat-form-field appearance="outline">
            <mat-label>{{ 'GRID.ITEM_NAME_AR' | translate }}</mat-label>
            <input matInput formControlName="nameAr" />
          </mat-form-field>

          <mat-form-field appearance="outline">
            <mat-label>{{ 'GRID.ITEM_CODE' | translate }}</mat-label>
            <input matInput formControlName="itemCode" />
          </mat-form-field>

          <mat-form-field appearance="outline">
            <mat-label>{{ 'GRID.RFID' | translate }}</mat-label>
            <input matInput formControlName="rfid" />
          </mat-form-field>

          <mat-form-field appearance="outline">
            <mat-label>{{ 'GRID.TOTAL_QUANTITY' | translate }}</mat-label>
            <input matInput type="number" formControlName="totalQuantity" />
          </mat-form-field>

          <mat-form-field appearance="outline">
            <mat-label>{{ 'GRID.AVG_COST' | translate }}</mat-label>
            <input matInput type="number" formControlName="avgCost" />
          </mat-form-field>

          <mat-form-field appearance="outline">
            <mat-label>{{ 'GRID.LAST_PURCHASE_PRICE' | translate }}</mat-label>
            <input matInput type="number" formControlName="lastPurchasePrice" />
          </mat-form-field>

          <mat-form-field appearance="outline">
            <mat-label>{{ 'GRID.MIN_LEVEL' | translate }}</mat-label>
            <input matInput type="number" formControlName="minLevel" />
          </mat-form-field>

          <mat-form-field appearance="outline">
            <mat-label>{{ 'GRID.MAX_LEVEL' | translate }}</mat-label>
            <input matInput type="number" formControlName="maxLevel" />
          </mat-form-field>

          <mat-form-field appearance="outline">
            <mat-label>{{ 'GRID.AUTO_REQUEST_QUANTITY' | translate }}</mat-label>
            <input matInput type="number" formControlName="autoRequestQuantity" />
          </mat-form-field>
        </div>

        <div class="form-checks">
          <mat-checkbox formControlName="isActive">{{ 'GRID.IS_ACTIVE' | translate }}</mat-checkbox>
          <mat-checkbox formControlName="isDisabled">{{ 'GRID.IS_DISABLED' | translate }}</mat-checkbox>
          <mat-checkbox formControlName="isBatch">{{ 'GRID.IS_BATCH' | translate }}</mat-checkbox>
          <mat-checkbox formControlName="isSerial">{{ 'GRID.IS_SERIAL' | translate }}</mat-checkbox>
          <mat-checkbox formControlName="isScrap">{{ 'GRID.IS_SCRAP' | translate }}</mat-checkbox>
          <mat-checkbox formControlName="isMaintainable">{{ 'GRID.IS_MAINTAINABLE' | translate }}</mat-checkbox>
          <mat-checkbox formControlName="autoReplenishment">{{ 'GRID.AUTO_REPLENISHMENT' | translate }}</mat-checkbox>
        </div>
      </form>
    </mat-dialog-content>

    <mat-dialog-actions align="end">
      <button mat-button (click)="onClose()">{{ 'COMMON.CANCEL' | translate }}</button>
      @if (!isView) {
        <button mat-flat-button color="primary" (click)="onSubmit()">
          {{ 'COMMON.SAVE' | translate }}
        </button>
      }
    </mat-dialog-actions>
  `,
  styles: [
    `
      .item-form { display: flex; flex-direction: column; gap: 8px; min-width: 640px; }
      .form-grid { display: grid; grid-template-columns: repeat(2, 1fr); gap: 8px 16px; }
      .form-checks { display: flex; flex-wrap: wrap; gap: 4px 20px; margin: 8px 0 0; }
    `
  ]
})
export class ItemDialogComponent {
  private readonly dialogRef = inject(MatDialogRef<ItemDialogComponent>);
  private readonly fb = inject(FormBuilder);
  private readonly data = inject<ItemDialogData>(MAT_DIALOG_DATA);

  readonly isView = this.data.mode === 'view';
  readonly title =
    this.data.mode === 'create'
      ? 'COMMON.ADD'
      : this.data.mode === 'edit'
        ? 'COMMON.EDIT'
        : 'COMMON.VIEW';

  form: FormGroup = this.fb.group({
    itemNumber: [this.data.item?.itemNumber ?? ''],
    name: [this.data.item?.name ?? ''],
    nameAr: [this.data.item?.nameAr ?? ''],
    itemCode: [this.data.item?.itemCode ?? ''],
    rfid: [this.data.item?.rfid ?? ''],
    totalQuantity: [this.data.item?.totalQuantity ?? null],
    avgCost: [this.data.item?.avgCost ?? null],
    lastPurchasePrice: [this.data.item?.lastPurchasePrice ?? null],
    minLevel: [this.data.item?.minLevel ?? null],
    maxLevel: [this.data.item?.maxLevel ?? null],
    autoRequestQuantity: [this.data.item?.autoRequestQuantity ?? null],
    isBatch: [this.data.item?.isBatch ?? false],
    isSerial: [this.data.item?.isSerial ?? false],
    isScrap: [this.data.item?.isScrap ?? false],
    isMaintainable: [this.data.item?.isMaintainable ?? false],
    autoReplenishment: [this.data.item?.autoReplenishment ?? false],
    isActive: [this.data.item?.isActive ?? true],
    isDisabled: [this.data.item?.isDisabled ?? false]
  });

  constructor() {
    if (this.isView) {
      this.form.disable();
    }
  }

  onSubmit(): void {
    if (this.form.invalid) {
      return;
    }

    const raw = this.form.getRawValue();
    const payload: InventoryItemPayload = {
      itemNumber: this.nullIfEmpty(raw.itemNumber),
      name: this.nullIfEmpty(raw.name),
      nameAr: this.nullIfEmpty(raw.nameAr),
      itemCode: this.nullIfEmpty(raw.itemCode),
      rfid: this.nullIfEmpty(raw.rfid),
      totalQuantity: raw.totalQuantity ?? null,
      avgCost: raw.avgCost ?? null,
      lastPurchasePrice: raw.lastPurchasePrice ?? null,
      minLevel: raw.minLevel ?? null,
      maxLevel: raw.maxLevel ?? null,
      autoRequestQuantity: raw.autoRequestQuantity ?? null,
      isBatch: !!raw.isBatch,
      isSerial: !!raw.isSerial,
      isScrap: !!raw.isScrap,
      isMaintainable: !!raw.isMaintainable,
      autoReplenishment: !!raw.autoReplenishment,
      isActive: !!raw.isActive,
      isDisabled: !!raw.isDisabled
    };

    this.dialogRef.close(payload);
  }

  onClose(): void {
    this.dialogRef.close();
  }

  private nullIfEmpty(value: unknown): string | null {
    return typeof value === 'string' && value.trim() === '' ? null : (value as string) ?? null;
  }
}
