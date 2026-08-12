import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateRwPickedQuantity, RwPickedQuantity } from '../../../Shared/Model/-rw-picked-quantity.model';
import { RwPickedQuantityService } from './rw-picked-quantity.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface RwPickedQuantityFormDialogData {
  mode: FormMode;
  item?: RwPickedQuantity;
}

@Component({
  selector: 'app-rw-picked-quantity-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './rw-picked-quantity-form.component.html',
  styleUrl: './rw-picked-quantity-form.component.css',
})
export class RwPickedQuantityFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(RwPickedQuantityService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<RwPickedQuantityFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: RwPickedQuantity;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Rw Picked Quantity' : 'Edit Rw Picked Quantity';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      requestWdfk: [null],
      pickedQuantity: [null],
      pickedDate: [null],
      axsynced: [false],
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
    const value = this.form.getRawValue() as CreateRwPickedQuantity;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Rw Picked Quantity created.' : 'Rw Picked Quantity updated.'
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
      requestWdfk: this.item?.requestWdfk ?? null,
      pickedQuantity: this.item?.pickedQuantity ?? null,
      pickedDate: this.toDateInput(this.item?.pickedDate),
      axsynced: this.item?.axsynced ?? false,
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
    this.router.navigate(['/inventory/rw-picked-quantity']);
  }
}
