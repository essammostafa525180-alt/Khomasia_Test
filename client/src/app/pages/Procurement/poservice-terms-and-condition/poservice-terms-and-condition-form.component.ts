import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreatePoserviceTermsAndCondition, PoserviceTermsAndCondition } from '../../../Shared/Model/-poservice-terms-and-condition.model';
import { PoserviceTermsAndConditionService } from './poservice-terms-and-condition.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface PoserviceTermsAndConditionFormDialogData {
  mode: FormMode;
  item?: PoserviceTermsAndCondition;
}

@Component({
  selector: 'app-poservice-terms-and-condition-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './poservice-terms-and-condition-form.component.html',
  styleUrl: './poservice-terms-and-condition-form.component.css',
})
export class PoserviceTermsAndConditionFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(PoserviceTermsAndConditionService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<PoserviceTermsAndConditionFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: PoserviceTermsAndCondition;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Poservice Terms And Condition' : 'Edit Poservice Terms And Condition';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      poserviceFk: [null],
      termsAndConditionFk: [null],
      description: [''],
      isActive1: [false],
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
    const value = this.form.getRawValue() as CreatePoserviceTermsAndCondition;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Poservice Terms And Condition created.' : 'Poservice Terms And Condition updated.'
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
      poserviceFk: this.item?.poserviceFk ?? null,
      termsAndConditionFk: this.item?.termsAndConditionFk ?? null,
      description: this.item?.description ?? '',
      isActive1: this.item?.isActive1 ?? false,
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/procurement/poservice-terms-and-condition']);
  }
}
