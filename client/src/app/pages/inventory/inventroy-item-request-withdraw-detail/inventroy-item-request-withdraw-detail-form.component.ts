import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateInventroyItemRequestWithdrawDetail, InventroyItemRequestWithdrawDetail } from '../../../Shared/Model/-inventroy-item-request-withdraw-detail.model';
import { InventroyItemRequestWithdrawDetailService } from './inventroy-item-request-withdraw-detail.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface InventroyItemRequestWithdrawDetailFormDialogData {
  mode: FormMode;
  item?: InventroyItemRequestWithdrawDetail;
}

@Component({
  selector: 'app-inventroy-item-request-withdraw-detail-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './inventroy-item-request-withdraw-detail-form.component.html',
  styleUrl: './inventroy-item-request-withdraw-detail-form.component.css',
})
export class InventroyItemRequestWithdrawDetailFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(InventroyItemRequestWithdrawDetailService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<InventroyItemRequestWithdrawDetailFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: InventroyItemRequestWithdrawDetail;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Inventroy Item Request Withdraw Detail' : 'Edit Inventroy Item Request Withdraw Detail';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      requestWfk: [null],
      inventoryItemFk: [null],
      requestedQuantity: [null],
      pickedQuantity: [null],
      deliveredQuantity: [null],
      returnedQuantity: [null],
      scrapedQuantity: [null],
      requestLineItemStatusFk: [null],
      fromSerial: [null],
      toSerial: [null],
      integrationId: [null],
      isSync: [false],
      lastPurchasePrice: [null],
      avgCost: [null],
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
    const value = this.form.getRawValue() as CreateInventroyItemRequestWithdrawDetail;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Inventroy Item Request Withdraw Detail created.' : 'Inventroy Item Request Withdraw Detail updated.'
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
      requestWfk: this.item?.requestWfk ?? null,
      inventoryItemFk: this.item?.inventoryItemFk ?? null,
      requestedQuantity: this.item?.requestedQuantity ?? null,
      pickedQuantity: this.item?.pickedQuantity ?? null,
      deliveredQuantity: this.item?.deliveredQuantity ?? null,
      returnedQuantity: this.item?.returnedQuantity ?? null,
      scrapedQuantity: this.item?.scrapedQuantity ?? null,
      requestLineItemStatusFk: this.item?.requestLineItemStatusFk ?? null,
      fromSerial: this.item?.fromSerial ?? null,
      toSerial: this.item?.toSerial ?? null,
      integrationId: this.item?.integrationId ?? null,
      isSync: this.item?.isSync ?? false,
      lastPurchasePrice: this.item?.lastPurchasePrice ?? null,
      avgCost: this.item?.avgCost ?? null,
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/inventory/inventroy-item-request-withdraw-detail']);
  }
}
