import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreatePdarequestsLog, PdarequestsLog } from '../../../Shared/Model/-pdarequests-log.model';
import { PdarequestsLogService } from './pdarequests-log.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface PdarequestsLogFormDialogData {
  mode: FormMode;
  item?: PdarequestsLog;
}

@Component({
  selector: 'app-pdarequests-log-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './pdarequests-log-form.component.html',
  styleUrl: './pdarequests-log-form.component.css',
})
export class PdarequestsLogFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(PdarequestsLogService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<PdarequestsLogFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: PdarequestsLog;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Pdarequests Log' : 'Edit Pdarequests Log';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      requestFk: [null],
      assignedToFk: [null],
      isChanged: [false],
      pdarequestType: [''],
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
    const value = this.form.getRawValue() as CreatePdarequestsLog;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Pdarequests Log created.' : 'Pdarequests Log updated.'
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
      requestFk: this.item?.requestFk ?? null,
      assignedToFk: this.item?.assignedToFk ?? null,
      isChanged: this.item?.isChanged ?? false,
      pdarequestType: this.item?.pdarequestType ?? '',
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/administration/pdarequests-log']);
  }
}
