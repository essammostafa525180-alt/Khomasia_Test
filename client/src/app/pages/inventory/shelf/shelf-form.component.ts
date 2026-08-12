import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateShelf, Shelf } from '../../../Shared/Model/-shelf.model';
import { ShelfService } from './shelf.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface ShelfFormDialogData {
  mode: FormMode;
  item?: Shelf;
}

@Component({
  selector: 'app-shelf-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './shelf-form.component.html',
  styleUrl: './shelf-form.component.css',
})
export class ShelfFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(ShelfService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<ShelfFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: Shelf;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Shelf' : 'Edit Shelf';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      isleFk: [null],
      code: [''],
      name: [''],
      level: [null],
      maxWeight: [null],
      isActive: [true],
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
    const value = this.form.getRawValue() as CreateShelf;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Shelf created.' : 'Shelf updated.'
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
      isleFk: this.item?.isleFk ?? null,
      code: this.item?.code ?? '',
      name: this.item?.name ?? '',
      level: this.item?.level ?? null,
      maxWeight: this.item?.maxWeight ?? null,
      isActive: this.item?.isActive ?? true,
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/inventory/shelf']);
  }
}
