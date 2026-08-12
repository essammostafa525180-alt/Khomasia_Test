import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateAnnualStockCount, AnnualStockCount } from '../../../Shared/Model/-annual-stock-count.model';
import { AnnualStockCountService } from './annual-stock-count.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface AnnualStockCountFormDialogData {
  mode: FormMode;
  item?: AnnualStockCount;
}

@Component({
  selector: 'app-annual-stock-count-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './annual-stock-count-form.component.html',
  styleUrl: './annual-stock-count-form.component.css',
})
export class AnnualStockCountFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(AnnualStockCountService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<AnnualStockCountFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: AnnualStockCount;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Annual Stock Count' : 'Edit Annual Stock Count';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      yearId: [null],
      storeFk: [null],
      isCompleted: [false],
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
    const value = this.form.getRawValue() as CreateAnnualStockCount;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Annual Stock Count created.' : 'Annual Stock Count updated.'
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
      yearId: this.item?.yearId ?? null,
      storeFk: this.item?.storeFk ?? null,
      isCompleted: this.item?.isCompleted ?? false,
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/inventory/annual-stock-count']);
  }
}
