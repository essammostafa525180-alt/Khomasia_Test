import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateSecRoleViewAction, SecRoleViewAction } from '../../../Shared/Model/-sec-role-view-action.model';
import { SecRoleViewActionService } from './sec-role-view-action.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface SecRoleViewActionFormDialogData {
  mode: FormMode;
  item?: SecRoleViewAction;
}

@Component({
  selector: 'app-sec-role-view-action-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './sec-role-view-action-form.component.html',
  styleUrl: './sec-role-view-action-form.component.css',
})
export class SecRoleViewActionFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(SecRoleViewActionService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<SecRoleViewActionFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: SecRoleViewAction;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Sec Role View Action' : 'Edit Sec Role View Action';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      viewActionId: [null],
      roleId: [null],
      isAllow: [false],
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
    const value = this.form.getRawValue() as CreateSecRoleViewAction;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Sec Role View Action created.' : 'Sec Role View Action updated.'
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
      viewActionId: this.item?.viewActionId ?? null,
      roleId: this.item?.roleId ?? null,
      isAllow: this.item?.isAllow ?? false,
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/administration/sec-role-view-action']);
  }
}
