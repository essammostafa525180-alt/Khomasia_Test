import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateAssetCountDetail, AssetCountDetail } from '../../../Shared/Model/-asset-count-detail.model';
import { AssetCountDetailService } from './asset-count-detail.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface AssetCountDetailFormDialogData {
  mode: FormMode;
  item?: AssetCountDetail;
}

@Component({
  selector: 'app-asset-count-detail-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './asset-count-detail-form.component.html',
  styleUrl: './asset-count-detail-form.component.css',
})
export class AssetCountDetailFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(AssetCountDetailService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<AssetCountDetailFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: AssetCountDetail;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Asset Count Detail' : 'Edit Asset Count Detail';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      assetCountFk: [null],
      assetFk: [null],
      assetCountStatusFk: [null],
      notes: [''],
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
    const value = this.form.getRawValue() as CreateAssetCountDetail;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Asset Count Detail created.' : 'Asset Count Detail updated.'
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
      assetCountFk: this.item?.assetCountFk ?? null,
      assetFk: this.item?.assetFk ?? null,
      assetCountStatusFk: this.item?.assetCountStatusFk ?? null,
      notes: this.item?.notes ?? '',
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/inventory/asset-count-detail']);
  }
}
