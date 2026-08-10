import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateNotificationTemplate, NotificationTemplate } from '../../../Shared/Model/-notification-template.model';
import { NotificationTemplateService } from './notification-template.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface NotificationTemplateFormDialogData {
  mode: FormMode;
  item?: NotificationTemplate;
}

@Component({
  selector: 'app-notification-template-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './notification-template-form.component.html',
  styleUrl: './notification-template-form.component.css',
})
export class NotificationTemplateFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(NotificationTemplateService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<NotificationTemplateFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: NotificationTemplate;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Notification Template' : 'Edit Notification Template';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      notificationTypeId: [null],
      languageId: [null],
      subject: [''],
      subjectAr: [''],
      bodySms: [''],
      bodySmsar: [''],
      bodyEmail: [''],
      bodyEmailAr: [''],
      code: [''],
      codeAr: [''],
      durationInDays: [null],
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
    const value = this.form.getRawValue() as CreateNotificationTemplate;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Notification Template created.' : 'Notification Template updated.'
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
      notificationTypeId: this.item?.notificationTypeId ?? null,
      languageId: this.item?.languageId ?? null,
      subject: this.item?.subject ?? '',
      subjectAr: this.item?.subjectAr ?? '',
      bodySms: this.item?.bodySms ?? '',
      bodySmsar: this.item?.bodySmsar ?? '',
      bodyEmail: this.item?.bodyEmail ?? '',
      bodyEmailAr: this.item?.bodyEmailAr ?? '',
      code: this.item?.code ?? '',
      codeAr: this.item?.codeAr ?? '',
      durationInDays: this.item?.durationInDays ?? null,
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/administration/notification-template']);
  }
}
