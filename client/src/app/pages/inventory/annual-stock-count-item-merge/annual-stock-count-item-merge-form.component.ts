import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateAnnualStockCountItemMerge, AnnualStockCountItemMerge } from '../../../Shared/Model/-annual-stock-count-item-merge.model';
import { AnnualStockCountItemMergeService } from './annual-stock-count-item-merge.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface AnnualStockCountItemMergeFormDialogData {
  mode: FormMode;
  item?: AnnualStockCountItemMerge;
}

@Component({
  selector: 'app-annual-stock-count-item-merge-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './annual-stock-count-item-merge-form.component.html',
  styleUrl: './annual-stock-count-item-merge-form.component.css',
})
export class AnnualStockCountItemMergeFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(AnnualStockCountItemMergeService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<AnnualStockCountItemMergeFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: AnnualStockCountItemMerge;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Annual Stock Count Item Merge' : 'Edit Annual Stock Count Item Merge';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      annualStockCountFk: [null],
      inventoryItemFk: [null],
      currentQuantity: [null],
      activeInventoryItemFk: [null],
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
    const value = this.form.getRawValue() as CreateAnnualStockCountItemMerge;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Annual Stock Count Item Merge created.' : 'Annual Stock Count Item Merge updated.'
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
      annualStockCountFk: this.item?.annualStockCountFk ?? null,
      inventoryItemFk: this.item?.inventoryItemFk ?? null,
      currentQuantity: this.item?.currentQuantity ?? null,
      activeInventoryItemFk: this.item?.activeInventoryItemFk ?? null,
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/inventory/annual-stock-count-item-merge']);
  }
}
