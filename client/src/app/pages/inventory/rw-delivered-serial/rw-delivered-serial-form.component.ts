import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateRwDeliveredSerial, RwDeliveredSerial } from '../../../Shared/Model/-rw-delivered-serial.model';
import { RwDeliveredSerialService } from './rw-delivered-serial.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface RwDeliveredSerialFormDialogData {
  mode: FormMode;
  item?: RwDeliveredSerial;
}

@Component({
  selector: 'app-rw-delivered-serial-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './rw-delivered-serial-form.component.html',
  styleUrl: './rw-delivered-serial-form.component.css',
})
export class RwDeliveredSerialFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(RwDeliveredSerialService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<RwDeliveredSerialFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: RwDeliveredSerial;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Rw Delivered Serial' : 'Edit Rw Delivered Serial';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      rwDeliveredBatchFk: [null],
      serialFk: [null],
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
    const value = this.form.getRawValue() as CreateRwDeliveredSerial;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Rw Delivered Serial created.' : 'Rw Delivered Serial updated.'
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
      rwDeliveredBatchFk: this.item?.rwDeliveredBatchFk ?? null,
      serialFk: this.item?.serialFk ?? null,
      axsynced: this.item?.axsynced ?? false,
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/inventory/rw-delivered-serial']);
  }
}
