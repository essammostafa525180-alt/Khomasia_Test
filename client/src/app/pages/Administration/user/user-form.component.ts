import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateUser, User } from '../../../Shared/Model/-user.model';
import { UserService } from './user.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface UserFormDialogData {
  mode: FormMode;
  item?: User;
}

@Component({
  selector: 'app-user-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './user-form.component.html',
  styleUrl: './user-form.component.css',
})
export class UserFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(UserService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<UserFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: User;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New User' : 'Edit User';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      updatedOn: [null],
      code: [''],
      name: [''],
      userId: [''],
      password: [''],
      email: [''],
      phone: [''],
      address: [''],
      contact: [null],
      active: [false],
      ouid: [null],
      nameAr: [''],
      branchId: [null],
      lastLogin: [null],
      forcePasswordChange: [false],
      employeeId: [null],
      maxDiscount: [null],
      passwordCreationDate: [null],
      fullName: [''],
      adUserId: [null],
      isPda: [false],
      singleSession: [null],
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
    const value = this.form.getRawValue() as CreateUser;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'User created.' : 'User updated.'
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
      updatedOn: this.toDateInput(this.item?.updatedOn),
      code: this.item?.code ?? '',
      name: this.item?.name ?? '',
      userId: this.item?.userId ?? '',
      password: this.item?.password ?? '',
      email: this.item?.email ?? '',
      phone: this.item?.phone ?? '',
      address: this.item?.address ?? '',
      contact: this.item?.contact ?? null,
      active: this.item?.active ?? false,
      ouid: this.item?.ouid ?? null,
      nameAr: this.item?.nameAr ?? '',
      branchId: this.item?.branchId ?? null,
      lastLogin: this.toDateInput(this.item?.lastLogin),
      forcePasswordChange: this.item?.forcePasswordChange ?? false,
      employeeId: this.item?.employeeId ?? null,
      maxDiscount: this.item?.maxDiscount ?? null,
      passwordCreationDate: this.toDateInput(this.item?.passwordCreationDate),
      fullName: this.item?.fullName ?? '',
      adUserId: this.item?.adUserId ?? null,
      isPda: this.item?.isPda ?? false,
      singleSession: this.item?.singleSession ?? null,
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
    this.router.navigate(['/administration/user']);
  }
}
