import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateSecUserModelAtrribute, SecUserModelAtrribute } from '../../../Shared/Model/-sec-user-model-atrribute.model';
import { SecUserModelAtrributeService } from './sec-user-model-atrribute.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface SecUserModelAtrributeFormDialogData {
  mode: FormMode;
  item?: SecUserModelAtrribute;
}

@Component({
  selector: 'app-sec-user-model-atrribute-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './sec-user-model-atrribute-form.component.html',
  styleUrl: './sec-user-model-atrribute-form.component.css',
})
export class SecUserModelAtrributeFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(SecUserModelAtrributeService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<SecUserModelAtrributeFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: SecUserModelAtrribute;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Sec User Model Atrribute' : 'Edit Sec User Model Atrribute';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      userId: [null],
      modelAttributeId: [null],
      mode: [null],
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
    const value = this.form.getRawValue() as CreateSecUserModelAtrribute;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Sec User Model Atrribute created.' : 'Sec User Model Atrribute updated.'
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
      userId: this.item?.userId ?? null,
      modelAttributeId: this.item?.modelAttributeId ?? null,
      mode: this.item?.mode ?? null,
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/administration/sec-user-model-atrribute']);
  }
}
