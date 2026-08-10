import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CreateInventroyItemRequestWithdraw, InventroyItemRequestWithdraw } from '../../../Shared/Model/-inventroy-item-request-withdraw.model';
import { IssueOutService } from './issue-out.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface InventroyItemRequestWithdrawFormDialogData {
  mode: FormMode;
  item?: InventroyItemRequestWithdraw;
}

@Component({
  selector: 'app-issue-out-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './issue-out-form.component.html',
  styleUrl: './issue-out-form.component.css',
})
export class InventroyItemRequestWithdrawFormComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(IssueOutService);
  private readonly notification = inject(NotificationService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<InventroyItemRequestWithdrawFormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: InventroyItemRequestWithdraw;
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New Issue Out' : 'Edit Issue Out';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      itemTypeFk: [null],
      requestNo: [''],
      requestDate: [null],
      descriptionEn: [''],
      descriptionAr: [''],
      isApproved: [false],
      requestedByFk: [null],
      requestedBy: [''],
      assignedToUserFk: [null],
      itemRequestStatusFk: [null],
      workOrderNo: [''],
      storeFk: [null],
      sentCount: [null],
      axsynced: [false],
      projectFk: [null],
      oufk: [null],
      itemNeededDate: [null],
      scopeFk: [null],
      companyFk: [null],
      serviceMainCategoryFk: [null],
      siteManagerApproval: [false],
      siteManagerApprovalUserId: [null],
      siteManagerApprovalDateTime: [null],
      warehouseManagerApprovalUserId: [null],
      warehouseManagerApprovalDateTime: [null],
      locationFk: [null],
      inventoryItemBudgetFk: [null],
      sourceTypeId: [null],
      entityId: [null],
      entityFormula: [''],
      receivedFk: [null],
      vehicleFk: [null],
      lineFk: [null],
      sourceEntity: [''],
      sourceId: [null],
      sectorFk: [null],
      costCenterFk: [null],
      customerFk: [null],
      factoryFk: [null],
      factoryLineFk: [null],
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
    const value = this.form.getRawValue() as CreateInventroyItemRequestWithdraw;

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? 'Issue Out created.' : 'Issue Out updated.'
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
      itemTypeFk: this.item?.itemTypeFk ?? null,
      requestNo: this.item?.requestNo ?? '',
      requestDate: this.toDateInput(this.item?.requestDate),
      descriptionEn: this.item?.descriptionEn ?? '',
      descriptionAr: this.item?.descriptionAr ?? '',
      isApproved: this.item?.isApproved ?? false,
      requestedByFk: this.item?.requestedByFk ?? null,
      requestedBy: this.item?.requestedBy ?? '',
      assignedToUserFk: this.item?.assignedToUserFk ?? null,
      itemRequestStatusFk: this.item?.itemRequestStatusFk ?? null,
      workOrderNo: this.item?.workOrderNo ?? '',
      storeFk: this.item?.storeFk ?? null,
      sentCount: this.item?.sentCount ?? null,
      axsynced: this.item?.axsynced ?? false,
      projectFk: this.item?.projectFk ?? null,
      oufk: this.item?.oufk ?? null,
      itemNeededDate: this.toDateInput(this.item?.itemNeededDate),
      scopeFk: this.item?.scopeFk ?? null,
      companyFk: this.item?.companyFk ?? null,
      serviceMainCategoryFk: this.item?.serviceMainCategoryFk ?? null,
      siteManagerApproval: this.item?.siteManagerApproval ?? false,
      siteManagerApprovalUserId: this.item?.siteManagerApprovalUserId ?? null,
      siteManagerApprovalDateTime: this.toDateInput(this.item?.siteManagerApprovalDateTime),
      warehouseManagerApprovalUserId: this.item?.warehouseManagerApprovalUserId ?? null,
      warehouseManagerApprovalDateTime: this.toDateInput(this.item?.warehouseManagerApprovalDateTime),
      locationFk: this.item?.locationFk ?? null,
      inventoryItemBudgetFk: this.item?.inventoryItemBudgetFk ?? null,
      sourceTypeId: this.item?.sourceTypeId ?? null,
      entityId: this.item?.entityId ?? null,
      entityFormula: this.item?.entityFormula ?? '',
      receivedFk: this.item?.receivedFk ?? null,
      vehicleFk: this.item?.vehicleFk ?? null,
      lineFk: this.item?.lineFk ?? null,
      sourceEntity: this.item?.sourceEntity ?? '',
      sourceId: this.item?.sourceId ?? null,
      sectorFk: this.item?.sectorFk ?? null,
      costCenterFk: this.item?.costCenterFk ?? null,
      customerFk: this.item?.customerFk ?? null,
      factoryFk: this.item?.factoryFk ?? null,
      factoryLineFk: this.item?.factoryLineFk ?? null,
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
    this.router.navigate(['/inventory/issue-out']);
  }
}
