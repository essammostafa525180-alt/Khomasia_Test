import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CountryModel, CreateCountryModel } from '../../../core/Models/CountryModel/country.model';
import { CountryService } from '../../../core/services/country.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface CountryFormDialogData {
  mode: FormMode;
  item?: CountryModel;
}

/**
 * Create/edit form for a country. The same component is used in both
 * presentations: opened through MatDialog (data supplied via MAT_DIALOG_DATA)
 * or rendered as a routed page (mode from route data, id from route params).
 */
@Component({
  selector: 'app-country-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './country-form.component.html',
  styleUrl: './country-form.component.css',
})
export class CountryFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly countryService = inject(CountryService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  // Present only when opened through MatDialog; null on the routed page.
  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<CountryFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  /** True when hosted in a dialog, false when rendered as a page. */
  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: CountryModel;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Country' : 'Edit Country';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      name: ['', [Validators.required, Validators.maxLength(100)]],
      code: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(3)]],
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
    const value = this.form.getRawValue() as CreateCountryModel;

    const request$ =
      this.mode === 'create'
        ? this.countryService.create(value)
        : this.countryService.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Country created.' : 'Country updated.'
        );
        this.close(true);
      },
      // The message is already shown by the HTTP error interceptor.
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
    this.countryService.getById<CountryModel>(id).subscribe({
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
      name: this.item?.name ?? '',
      code: this.item?.code ?? '',
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/country']);
  }
}
