import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateAssetItemScrap, AssetItemScrap } from '../../../Shared/Model/-asset-item-scrap.model';
import { AssetItemScrapService } from './asset-item-scrap.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface AssetItemScrapFormDialogData {
  mode: FormMode;
  item?: AssetItemScrap;
}

@Component({
  selector: 'app-asset-item-scrap-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './asset-item-scrap-form.component.html',
  styleUrl: './asset-item-scrap-form.component.css',
})
export class AssetItemScrapFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(AssetItemScrapService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<AssetItemScrapFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: AssetItemScrap;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Asset Item Scrap' : 'Edit Asset Item Scrap';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      assetItemFk: [null],
      code: [''],
      assetItemMoveFk: [null],
      assetItemMaintenanceFk: [null],
      assetScrapStatusFk: [null],
      approvalStatusFk: [null],
      soldAmount: [null],
      actionDate: [null],
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
    const value = this.form.getRawValue() as CreateAssetItemScrap;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Asset Item Scrap created.' : 'Asset Item Scrap updated.'
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
      assetItemFk: this.item?.assetItemFk ?? null,
      code: this.item?.code ?? '',
      assetItemMoveFk: this.item?.assetItemMoveFk ?? null,
      assetItemMaintenanceFk: this.item?.assetItemMaintenanceFk ?? null,
      assetScrapStatusFk: this.item?.assetScrapStatusFk ?? null,
      approvalStatusFk: this.item?.approvalStatusFk ?? null,
      soldAmount: this.item?.soldAmount ?? null,
      actionDate: this.toDateInput(this.item?.actionDate),
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
    this.router.navigate(['/inventory/asset-item-scrap']);
  }
}
