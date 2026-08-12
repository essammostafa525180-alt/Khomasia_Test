import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateAssetItemMove, AssetItemMove } from '../../../Shared/Model/-asset-item-move.model';
import { AssetMoveService } from './asset-move.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface AssetItemMoveFormDialogData {
  mode: FormMode;
  item?: AssetItemMove;
}

@Component({
  selector: 'app-asset-move-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './asset-move-form.component.html',
  styleUrl: './asset-move-form.component.css',
})
export class AssetItemMoveFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(AssetMoveService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<AssetItemMoveFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: AssetItemMove;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Asset Move' : 'Edit Asset Move';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      code: [''],
      assetItemFk: [null],
      assetMoveTypeFk: [null],
      fromProjectFk: [null],
      fromAssetLocationFk: [null],
      toProjectFk: [null],
      toAssetLocationFk: [null],
      employeeFk: [null],
      ownerApprovedFk: [null],
      isOwnerApprovedFk: [null],
      ownerApprovedDate: [null],
      managerApprovedFk: [null],
      isManagerApprovedFk: [null],
      managerApprovedDate: [null],
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
    const value = this.form.getRawValue() as CreateAssetItemMove;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Asset Move created.' : 'Asset Move updated.'
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
      code: this.item?.code ?? '',
      assetItemFk: this.item?.assetItemFk ?? null,
      assetMoveTypeFk: this.item?.assetMoveTypeFk ?? null,
      fromProjectFk: this.item?.fromProjectFk ?? null,
      fromAssetLocationFk: this.item?.fromAssetLocationFk ?? null,
      toProjectFk: this.item?.toProjectFk ?? null,
      toAssetLocationFk: this.item?.toAssetLocationFk ?? null,
      employeeFk: this.item?.employeeFk ?? null,
      ownerApprovedFk: this.item?.ownerApprovedFk ?? null,
      isOwnerApprovedFk: this.item?.isOwnerApprovedFk ?? null,
      ownerApprovedDate: this.toDateInput(this.item?.ownerApprovedDate),
      managerApprovedFk: this.item?.managerApprovedFk ?? null,
      isManagerApprovedFk: this.item?.isManagerApprovedFk ?? null,
      managerApprovedDate: this.toDateInput(this.item?.managerApprovedDate),
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
    this.router.navigate(['/inventory/asset-move']);
  }
}
