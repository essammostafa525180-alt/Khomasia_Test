import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateNotification, Notification } from '../../../Shared/Model/-notification.model';
import { NotificationService } from './notification.service';
import { NotificationService as CoreNotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface NotificationFormDialogData {
  mode: FormMode;
  item?: Notification;
}

@Component({
  selector: 'app-notification-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './notification-form.component.html',
  styleUrl: './notification-form.component.css',
})
export class NotificationFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(NotificationService);
  private readonly notification = inject(CoreNotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<NotificationFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: Notification;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Notification' : 'Edit Notification';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      to: [''],
      cc: [''],
      bcc: [''],
      phoneNumber: [''],
      subject: [''],
      body: [''],
      statusId: [null],
      createDate: [null],
      lastUpdateDate: [null],
      sendDate: [null],
      notificationTypeId: [null],
      notificationSource: [''],
      errorMessage: [''],
      sendTries: [null],
      notificationDateTime: [null],
      attachmentType: [''],
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
    const value = this.form.getRawValue() as CreateNotification;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Notification created.' : 'Notification updated.'
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
      to: this.item?.to ?? '',
      cc: this.item?.cc ?? '',
      bcc: this.item?.bcc ?? '',
      phoneNumber: this.item?.phoneNumber ?? '',
      subject: this.item?.subject ?? '',
      body: this.item?.body ?? '',
      statusId: this.item?.statusId ?? null,
      createDate: this.toDateInput(this.item?.createDate),
      lastUpdateDate: this.toDateInput(this.item?.lastUpdateDate),
      sendDate: this.toDateInput(this.item?.sendDate),
      notificationTypeId: this.item?.notificationTypeId ?? null,
      notificationSource: this.item?.notificationSource ?? '',
      errorMessage: this.item?.errorMessage ?? '',
      sendTries: this.item?.sendTries ?? null,
      notificationDateTime: this.toDateInput(this.item?.notificationDateTime),
      attachmentType: this.item?.attachmentType ?? '',
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
    this.router.navigate(['/administration/notification']);
  }
}
