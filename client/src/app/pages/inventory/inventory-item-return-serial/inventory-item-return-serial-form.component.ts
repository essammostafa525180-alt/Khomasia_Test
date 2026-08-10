import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateInventoryItemReturnSerial, InventoryItemReturnSerial } from '../../../Shared/Model/-inventory-item-return-serial.model';
import { InventoryItemReturnSerialService } from './inventory-item-return-serial.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface InventoryItemReturnSerialFormDialogData {
  mode: FormMode;
  item?: InventoryItemReturnSerial;
}

@Component({
  selector: 'app-inventory-item-return-serial-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './inventory-item-return-serial-form.component.html',
  styleUrl: './inventory-item-return-serial-form.component.css',
})
export class InventoryItemReturnSerialFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(InventoryItemReturnSerialService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<InventoryItemReturnSerialFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: InventoryItemReturnSerial;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Inventory Item Return Serial' : 'Edit Inventory Item Return Serial';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      inventoryItemReturnFk: [null],
      inventoryItemReturnDetailFk: [null],
      inventoryItemSerialFk: [null],
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
    const value = this.form.getRawValue() as CreateInventoryItemReturnSerial;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Inventory Item Return Serial created.' : 'Inventory Item Return Serial updated.'
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
      inventoryItemReturnFk: this.item?.inventoryItemReturnFk ?? null,
      inventoryItemReturnDetailFk: this.item?.inventoryItemReturnDetailFk ?? null,
      inventoryItemSerialFk: this.item?.inventoryItemSerialFk ?? null,
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/inventory/inventory-item-return-serial']);
  }
}
