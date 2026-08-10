import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateHadithSharhMissing, HadithSharhMissing } from '../../../Shared/Model/-hadith-sharh-missing.model';
import { HadithSharhMissingService } from './hadith-sharh-missing.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface HadithSharhMissingFormDialogData {
  mode: FormMode;
  item?: HadithSharhMissing;
}

@Component({
  selector: 'app-hadith-sharh-missing-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './hadith-sharh-missing-form.component.html',
  styleUrl: './hadith-sharh-missing-form.component.css',
})
export class HadithSharhMissingFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(HadithSharhMissingService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<HadithSharhMissingFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: HadithSharhMissing;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Hadith Sharh Missing' : 'Edit Hadith Sharh Missing';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      hadithNumber: [null],
      babId: [null],
      bookSharhId: [null],
      sharhWithSign: [''],
      sharhWithNoSign: [''],
      hadithId: [null],
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
    const value = this.form.getRawValue() as CreateHadithSharhMissing;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Hadith Sharh Missing created.' : 'Hadith Sharh Missing updated.'
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
      hadithNumber: this.item?.hadithNumber ?? null,
      babId: this.item?.babId ?? null,
      bookSharhId: this.item?.bookSharhId ?? null,
      sharhWithSign: this.item?.sharhWithSign ?? '',
      sharhWithNoSign: this.item?.sharhWithNoSign ?? '',
      hadithId: this.item?.hadithId ?? null,
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/other/hadith-sharh-missing']);
  }
}
