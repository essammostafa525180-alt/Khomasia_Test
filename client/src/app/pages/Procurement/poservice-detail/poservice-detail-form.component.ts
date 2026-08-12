import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreatePoserviceDetail, PoserviceDetail } from '../../../Shared/Model/-poservice-detail.model';
import { PoserviceDetailService } from './poservice-detail.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface PoserviceDetailFormDialogData {
  mode: FormMode;
  item?: PoserviceDetail;
}

@Component({
  selector: 'app-poservice-detail-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './poservice-detail-form.component.html',
  styleUrl: './poservice-detail-form.component.css',
})
export class PoserviceDetailFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(PoserviceDetailService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<PoserviceDetailFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: PoserviceDetail;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Poservice Detail' : 'Edit Poservice Detail';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      poserviceFk: [null],
      serviceTypeFk: [null],
      serviceMainCategoryFk: [null],
      serviceCategoryFk: [null],
      serviceSubCategoryFk: [null],
      serviceFk: [null],
      quantity: [null],
      costPerService: [null],
      totalCost: [null],
      contractServiceId: [null],
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
    const value = this.form.getRawValue() as CreatePoserviceDetail;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Poservice Detail created.' : 'Poservice Detail updated.'
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
      serviceTypeFk: this.item?.serviceTypeFk ?? null,
      serviceMainCategoryFk: this.item?.serviceMainCategoryFk ?? null,
      serviceCategoryFk: this.item?.serviceCategoryFk ?? null,
      serviceSubCategoryFk: this.item?.serviceSubCategoryFk ?? null,
      serviceFk: this.item?.serviceFk ?? null,
      quantity: this.item?.quantity ?? null,
      costPerService: this.item?.costPerService ?? null,
      totalCost: this.item?.totalCost ?? null,
      contractServiceId: this.item?.contractServiceId ?? null,
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/procurement/poservice-detail']);
  }
}
