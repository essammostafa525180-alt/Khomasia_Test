import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateVehicle, Vehicle } from '../../../Shared/Model/-vehicle.model';
import { VehicleService } from './vehicle.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface VehicleFormDialogData {
  mode: FormMode;
  item?: Vehicle;
}

@Component({
  selector: 'app-vehicle-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './vehicle-form.component.html',
  styleUrl: './vehicle-form.component.css',
})
export class VehicleFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(VehicleService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<VehicleFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: Vehicle;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Vehicle' : 'Edit Vehicle';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      code: [''],
      barcode: [''],
      rfid: [''],
      equipmentTypeFk: [null],
      vehicleTypeFk: [null],
      vehicleBrandFk: [null],
      vehicleModelFk: [null],
      yearFk: [null],
      serialNumber: [''],
      plateNumber: [''],
      colorFk: [null],
      description: [''],
      vehicleStatusFk: [null],
      ownershipFk: [null],
      oufk: [null],
      costCenterFk: [null],
      employeeFk: [null],
      grossWeight: [null],
      height: [null],
      width: [null],
      wheelBase: [null],
      length: [null],
      chassisNumber: [''],
      engineNumber: [''],
      engineSizeFk: [null],
      transmissionTypeFk: [null],
      cylindersNumber: [null],
      batteryTypeFk: [null],
      airFilterTypeFk: [null],
      sectorFk: [null],
      operationDate: [null],
      tagNumber: [''],
      retireDate: [null],
      bookValue: [null],
      laborRateRatio: [null],
      sparePartRateRatio: [null],
      depreciation: [null],
      originalValue: [null],
      serviceLife: [null],
      vehicleOptionFk: [null],
      remainingMonths: [null],
      companyFk: [null],
      projectFk: [null],
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
    const value = this.form.getRawValue() as CreateVehicle;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Vehicle created.' : 'Vehicle updated.'
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
      code: this.item?.code ?? '',
      barcode: this.item?.barcode ?? '',
      rfid: this.item?.rfid ?? '',
      equipmentTypeFk: this.item?.equipmentTypeFk ?? null,
      vehicleTypeFk: this.item?.vehicleTypeFk ?? null,
      vehicleBrandFk: this.item?.vehicleBrandFk ?? null,
      vehicleModelFk: this.item?.vehicleModelFk ?? null,
      yearFk: this.item?.yearFk ?? null,
      serialNumber: this.item?.serialNumber ?? '',
      plateNumber: this.item?.plateNumber ?? '',
      colorFk: this.item?.colorFk ?? null,
      description: this.item?.description ?? '',
      vehicleStatusFk: this.item?.vehicleStatusFk ?? null,
      ownershipFk: this.item?.ownershipFk ?? null,
      oufk: this.item?.oufk ?? null,
      costCenterFk: this.item?.costCenterFk ?? null,
      employeeFk: this.item?.employeeFk ?? null,
      grossWeight: this.item?.grossWeight ?? null,
      height: this.item?.height ?? null,
      width: this.item?.width ?? null,
      wheelBase: this.item?.wheelBase ?? null,
      length: this.item?.length ?? null,
      chassisNumber: this.item?.chassisNumber ?? '',
      engineNumber: this.item?.engineNumber ?? '',
      engineSizeFk: this.item?.engineSizeFk ?? null,
      transmissionTypeFk: this.item?.transmissionTypeFk ?? null,
      cylindersNumber: this.item?.cylindersNumber ?? null,
      batteryTypeFk: this.item?.batteryTypeFk ?? null,
      airFilterTypeFk: this.item?.airFilterTypeFk ?? null,
      sectorFk: this.item?.sectorFk ?? null,
      operationDate: this.toDateInput(this.item?.operationDate),
      tagNumber: this.item?.tagNumber ?? '',
      retireDate: this.toDateInput(this.item?.retireDate),
      bookValue: this.item?.bookValue ?? null,
      laborRateRatio: this.item?.laborRateRatio ?? null,
      sparePartRateRatio: this.item?.sparePartRateRatio ?? null,
      depreciation: this.item?.depreciation ?? null,
      originalValue: this.item?.originalValue ?? null,
      serviceLife: this.item?.serviceLife ?? null,
      vehicleOptionFk: this.item?.vehicleOptionFk ?? null,
      remainingMonths: this.item?.remainingMonths ?? null,
      companyFk: this.item?.companyFk ?? null,
      projectFk: this.item?.projectFk ?? null,
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
    this.router.navigate(['/other/vehicle']);
  }
}
