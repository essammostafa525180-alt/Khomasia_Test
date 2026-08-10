import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreatePoserviceAsset, PoserviceAsset } from '../../../Shared/Model/-poservice-asset.model';
import { PoserviceAssetService } from './poservice-asset.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface PoserviceAssetFormDialogData {
  mode: FormMode;
  item?: PoserviceAsset;
}

@Component({
  selector: 'app-poservice-asset-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './poservice-asset-form.component.html',
  styleUrl: './poservice-asset-form.component.css',
})
export class PoserviceAssetFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(PoserviceAssetService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<PoserviceAssetFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: PoserviceAsset;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Poservice Asset' : 'Edit Poservice Asset';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      poserviceFk: [null],
      contractServiceId: [null],
      contractAssetId: [null],
      assetId: [null],
      assetCode: [''],
      assetDescription: [''],
      assetDescriptionAr: [''],
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
    const value = this.form.getRawValue() as CreatePoserviceAsset;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Poservice Asset created.' : 'Poservice Asset updated.'
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
      poserviceFk: this.item?.poserviceFk ?? null,
      contractServiceId: this.item?.contractServiceId ?? null,
      contractAssetId: this.item?.contractAssetId ?? null,
      assetId: this.item?.assetId ?? null,
      assetCode: this.item?.assetCode ?? '',
      assetDescription: this.item?.assetDescription ?? '',
      assetDescriptionAr: this.item?.assetDescriptionAr ?? '',
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/procurement/poservice-asset']);
  }
}
