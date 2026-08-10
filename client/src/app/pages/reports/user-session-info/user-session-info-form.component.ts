import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateUserSessionInfo, UserSessionInfo } from '../../../Shared/Model/-user-session-info.model';
import { UserSessionInfoService } from './user-session-info.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface UserSessionInfoFormDialogData {
  mode: FormMode;
  item?: UserSessionInfo;
}

@Component({
  selector: 'app-user-session-info-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './user-session-info-form.component.html',
  styleUrl: './user-session-info-form.component.css',
})
export class UserSessionInfoFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(UserSessionInfoService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<UserSessionInfoFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: UserSessionInfo;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New User Session Info' : 'Edit User Session Info';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      userId: [null],
      lastHit: [null],
      expireAt: [null],
      remeberMe: [false],
      language: [''],
      validModules: [''],
      userToken: [''],
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
    const value = this.form.getRawValue() as CreateUserSessionInfo;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'User Session Info created.' : 'User Session Info updated.'
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
      lastHit: this.toDateInput(this.item?.lastHit),
      expireAt: this.toDateInput(this.item?.expireAt),
      remeberMe: this.item?.remeberMe ?? false,
      language: this.item?.language ?? '',
      validModules: this.item?.validModules ?? '',
      userToken: this.item?.userToken ?? '',
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
    this.router.navigate(['/reports/user-session-info']);
  }
}
