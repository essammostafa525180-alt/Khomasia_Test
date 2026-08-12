import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateAuditTrail, AuditTrail } from '../../../Shared/Model/-audit-trail.model';
import { AuditTrailService } from './audit-trail.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface AuditTrailFormDialogData {
  mode: FormMode;
  item?: AuditTrail;
}

@Component({
  selector: 'app-audit-trail-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './audit-trail-form.component.html',
  styleUrl: './audit-trail-form.component.css',
})
export class AuditTrailFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(AuditTrailService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<AuditTrailFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: AuditTrail;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Audit Trail' : 'Edit Audit Trail';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      tableName: [''],
      action: [''],
      executedAt: [null],
      userId: [null],
      entityId: [null],
      clientComputerName: [''],
      clientIp: [''],
      parentAuditTrailId: [null],
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
    const value = this.form.getRawValue() as CreateAuditTrail;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Audit Trail created.' : 'Audit Trail updated.'
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
      tableName: this.item?.tableName ?? '',
      action: this.item?.action ?? '',
      executedAt: this.toDateInput(this.item?.executedAt),
      userId: this.item?.userId ?? null,
      entityId: this.item?.entityId ?? null,
      clientComputerName: this.item?.clientComputerName ?? '',
      clientIp: this.item?.clientIp ?? '',
      parentAuditTrailId: this.item?.parentAuditTrailId ?? null,
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
    this.router.navigate(['/reports/audit-trail']);
  }
}
