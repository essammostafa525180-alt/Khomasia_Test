import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateRwPickedSerial, RwPickedSerial } from '../../../Shared/Model/-rw-picked-serial.model';
import { RwPickedSerialService } from './rw-picked-serial.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface RwPickedSerialFormDialogData {
  mode: FormMode;
  item?: RwPickedSerial;
}

@Component({
  selector: 'app-rw-picked-serial-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './rw-picked-serial-form.component.html',
  styleUrl: './rw-picked-serial-form.component.css',
})
export class RwPickedSerialFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(RwPickedSerialService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<RwPickedSerialFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: RwPickedSerial;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Rw Picked Serial' : 'Edit Rw Picked Serial';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      rwPickedBatchFk: [null],
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
    const value = this.form.getRawValue() as CreateRwPickedSerial;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Rw Picked Serial created.' : 'Rw Picked Serial updated.'
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
      rwPickedBatchFk: this.item?.rwPickedBatchFk ?? null,
      serialFk: this.item?.serialFk ?? null,
      axsynced: this.item?.axsynced ?? false,
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/inventory/rw-picked-serial']);
  }
}
