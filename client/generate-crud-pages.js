// Generates Country-style (BaseService + client-side pagination) view + form +
// service files for groups of pages (Administration / Procurement / etc.).
// Run:  node generate-crud-pages.js
const fs = require('fs');
const path = require('path');

const ROOT = __dirname;
const MODELS_DIR = path.join(ROOT, 'src/app/Shared/Model');
const PAGES_DIR = path.join(ROOT, 'src/app/pages');

// ---------------------------------------------------------------------------
// Group definitions
// ---------------------------------------------------------------------------
const ADMIN_PAGES = [
  'ad-user', 'allowed-company', 'approval-matrix', 'approval-matrix-config',
  'approval-matrix-config-detail', 'approval-matrix-detail', 'approval-matrix-range',
  'approval-screen', 'approval-status', 'assign-asset-type-to-asset-group',
  'assign-cost-center-to-sector', 'assign-site-section', 'assign-vendor-evaluation-criterion',
  'assign-vendor-specialization', 'classifications', 'company', 'contact', 'contact-type',
  'contacts', 'days-of-week', 'employee', 'employee-job', 'gender', 'language',
  'module-setting', 'notification', 'notification-place-holder', 'notification-state',
  'notification-template', 'notification-template-contact', 'notification-type', 'ou',
  'pdaassignment', 'pdadetail', 'pdamodel', 'pdarequests-log', 'pruser', 'rank', 'scope',
  'sec-configuration', 'sec-model', 'sec-model-attribute', 'sec-module', 'sec-property',
  'sec-role', 'sec-role-model-attribute', 'sec-role-module', 'sec-role-property',
  'sec-role-securable-value', 'sec-role-view-action', 'sec-user-model-atrribute',
  'sec-user-module', 'sec-user-property', 'sec-user-securable-value', 'sec-user-view-action',
  'sec-view', 'sec-view-action', 'sitemap', 'sys-key-value', 'user',
];

const PROCUREMENT_PAGES = [
  'insurance-vendor', 'inventory-item-vendor', 'order-line-item-status', 'payment-term',
  'poservice-asset', 'poservice-detail', 'poservice-outsource',
  'poservice-recomended-resource', 'poservice-terms-and-condition', 'poservice-type',
  'purchase-order-service', 'purchase-order-service-attachment', 'request-line-item-status',
  'terms-and-condition', 'vendor', 'vendor-evaluation-criterion', 'vendor-order',
  'vendor-order-attachment', 'vendor-order-detail', 'vendor-order-partially-received-note',
  'vendor-order-quality', 'vendor-order-quality-attachment', 'vendor-order-quality-detail',
  'vendor-order-quality-detail-batch', 'vendor-order-receive', 'vendor-order-receive-attachment',
  'vendor-order-receive-detail', 'vendor-order-receive-detail-batch',
  'vendor-order-receive-detail-batch-serial', 'vendor-order-receive-serial',
  'vendor-order-screen', 'vendor-order-status', 'vendor-order-type',
  'vendor-order-vendor-selection', 'vendor-order-vendor-suggested', 'vendor-return',
  'vendor-return-attachment', 'vendor-return-detail', 'vendor-return-detail-batch',
  'vendor-return-detail-batch-serial', 'vendor-return-serial', 'vendor-specialization',
  'vendor-status', 'vendor-type',
];

const INVENTORY_EXTRA_PAGES = [
  'annual-stock-count', 'annual-stock-count-item-merge', 'annual-stock-count-item-quantity', 'asset',
  'asset-attachment', 'asset-commissioning', 'asset-compline', 'asset-component', 'asset-count',
  'asset-count-detail', 'asset-count-issue', 'asset-count-issue-status', 'asset-count-plan',
  'asset-count-plan-detail', 'asset-count-plan-status', 'asset-count-plan-type', 'asset-count-status',
  'asset-disposed', 'asset-functionality', 'asset-item', 'asset-item-attachment',
  'asset-item-maintenance', 'asset-item-move', 'asset-item-scrap', 'asset-maintenance-status',
  'asset-move-type', 'asset-scrap-status', 'asset-status', 'asset-warranty-status', 'assets-group',
  'assets-type', 'chemical-group', 'equipment-code', 'inventory-currency', 'inventory-item-asset',
  'inventory-item-budget', 'inventory-item-budget-detail', 'inventory-item-cost',
  'inventory-item-equivalent-sp', 'inventory-item-location', 'inventory-item-location-batch',
  'inventory-item-location-batch-serial', 'inventory-item-location-detail', 'inventory-item-return',
  'inventory-item-return-attachment', 'inventory-item-return-batch', 'inventory-item-return-batch-serial',
  'inventory-item-return-detail', 'inventory-item-return-serial', 'inventory-item-serial',
  'inventory-item-serial-status', 'inventory-item-status', 'inventory-item-transaction-type',
  'inventory-item-trasnsaction-type', 'inventory-item-uo-m', 'inventory-stock-count',
  'inventory-stock-count-detail', 'inventory-stock-count-detail-batch',
  'inventory-stock-count-detail-batch-serial', 'inventory-stock-count-plan',
  'inventory-stock-count-plan-detail', 'inventory-stock-count-status', 'inventory-transfere',
  'inventory-transfere-attachment', 'inventory-transfere-detail', 'inventory-transfere-detail-batch',
  'inventory-transfere-detail-batch-serial', 'inventory-transfere-serial', 'inventory-year',
  'inventroy-item-request-withdraw', 'inventroy-item-request-withdraw-attachment',
  'inventroy-item-request-withdraw-detail', 'isle', 'item-balance-status', 'item-expiry-type',
  'item-quantity-type', 'item-request-status', 'item-type', 'location', 'manufacture',
  'material-category', 'material-group', 'material-sub-category', 'partitions', 'possession-type',
  'rack', 'request-withdraw-serial', 'return-reason', 'return-status', 'rw-delivered-batch',
  'rw-delivered-quantity', 'rw-delivered-serial', 'rw-picked-batch', 'rw-picked-quantity',
  'rw-picked-serial', 'shelf', 'spare-part-group', 'stock-count-plan-status', 'stock-count-plan-type',
  'store', 'store-keeper', 'store-sequence', 'tools-type', 'transfer-reason', 'transfer-status',
  'transfere-type', 'unit-of-measure', 'warranty-status',
];

const REPORTS_PAGES = [
  'audit-trail', 'audit-trail-detail', 'notification-log', 'sales-invoice', 'sales-invoice-item',
  'sales-quotation', 'sales-quotation-detail', 'user-session-info', 'user-session-info-detail',
];

const OTHER_PAGES = [
  'air-filter-type', 'babs', 'battery-type', 'books', 'commission-condition', 'cost-center',
  'customer', 'engine-size', 'expense', 'factory', 'factory-line', 'hadith-collections',
  'hadith-sharh-missing', 'hadiths', 'line', 'narrators', 'oil', 'ownership', 'project', 'section',
  'sector', 'service', 'service-category', 'service-main-category', 'service-sub-category',
  'service-type', 'sharhs', 'state', 'sub-section', 'takheejs', 'transmission-type', 'vehicle',
  'vehicle-brand', 'vehicle-color', 'vehicle-model', 'vehicle-option', 'vehicle-status',
  'vehicle-type', 'view-request-status', 'visit', 'worker-type', 'ws-last-sync-table', 'zone',
  'zone-status',
];

const GROUPS = [
  { dir: 'Administration', prefix: 'administration', bannerIcon: 'admin_panel_settings', pages: ADMIN_PAGES },
  { dir: 'Procurement', prefix: 'procurement', bannerIcon: 'local_shipping', pages: PROCUREMENT_PAGES },
  { dir: 'inventory', prefix: 'inventory', bannerIcon: 'category', pages: INVENTORY_EXTRA_PAGES },
  { dir: 'Reports', prefix: 'reports', bannerIcon: 'bar_chart', pages: REPORTS_PAGES },
  { dir: 'Other', prefix: 'other', bannerIcon: 'grid_view', pages: OTHER_PAGES },
];

// Some generated form class names would collide with the hand-made inventory
// pages (which reused the semantic model key), so give those pages a distinct
// form class name. Keep this map in sync with generate-crud-routes.js.
const FORM_CLASS_OVERRIDE = {
  'asset': 'AssetEntityFormComponent',
  'asset-count-issue': 'AssetCountIssueEntityFormComponent',
  'asset-item-move': 'AssetItemMoveEntityFormComponent',
  'inventory-item-location-batch-serial': 'InventoryItemLocationBatchSerialEntityFormComponent',
  'inventory-item-return': 'InventoryItemReturnEntityFormComponent',
  'inventory-item-serial': 'InventoryItemSerialEntityFormComponent',
  'inventory-stock-count': 'InventoryStockCountEntityFormComponent',
  'inventory-transfere': 'InventoryTransfereEntityFormComponent',
  'inventroy-item-request-withdraw': 'InventroyItemRequestWithdrawEntityFormComponent',
};

function formClassName(page) {
  return FORM_CLASS_OVERRIDE[page.page] || `${page.key}FormComponent`;
}

// ---------------------------------------------------------------------------
// Helpers
// ---------------------------------------------------------------------------
function kebabToPascal(kebab) {
  return kebab
    .split('-')
    .filter(Boolean)
    .map((p) => p.charAt(0).toUpperCase() + p.slice(1))
    .join('');
}

function pascalToLabel(pascal) {
  let name = pascal
    .replace(/Fk$/i, '')
    .replace(/Sk$/i, '')
    .replace(/Id$/, '')
    .replace(/([a-z0-9])([A-Z])/g, '$1 $2')
    .replace(/\bRfid\b/gi, 'RFID')
    .replace(/\bDft\b/gi, 'DFT')
    .replace(/\bAx\b/gi, 'AX')
    .replace(/\bOf\b/gi, 'of');
  return name.charAt(0).toUpperCase() + name.slice(1);
}

function parsePayloadFields(modelFile, key) {
  const file = fs.readFileSync(path.join(MODELS_DIR, modelFile + '.ts'), 'utf8');
  const re = new RegExp(`export interface ${key}Payload \\s*\\{([\\s\\S]*?)\\n\\}`, 'm');
  const m = re.exec(file);
  if (!m) return [];
  const body = m[1];
  const fields = [];
  const lineRe = /^\s*([A-Za-z_][A-Za-z0-9_]*)\??\s*:\s*(.+?);\s*$/;
  for (const l of body.split('\n')) {
    const lm = lineRe.exec(l.trim());
    if (!lm) continue;
    const name = lm[1];
    const raw = lm[2].trim().replace(/\|/g, ' ').split(/[ \t]+/).filter(Boolean).join(' ');
    let base = raw.replace(/\bnull\b/g, '').replace(/\bundefined\b/g, '').trim();
    if (base.includes(' ')) base = base.split(' ')[0];
    if (['string', 'number', 'boolean', 'Date'].includes(base) && !/Navigation$/.test(name) && name !== 'id' && name !== 'isDeleted') {
      fields.push({ name, type: base });
    }
  }
  return fields;
}

function columnFields(fields) {
  return fields.filter((f) => !/fk$/i.test(f.name)).slice(0, 6);
}

function labelFieldFor(columns) {
  const str = columns.find((c) => c.type === 'string');
  return str ? str.name : 'id';
}

// ---------------------------------------------------------------------------
// File builders (same country-style templates as generate-inventory-pages.js)
// ---------------------------------------------------------------------------
function buildService(page) {
  const svc = `${kebabToPascal(page.page)}Service`;
  return `import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from '../../../core/services/base.service';
import { Configurations } from '../../../Configurations/config';
import { Create${page.key}, ${page.key} } from '../../../Shared/Model/${page.model}';

@Injectable({ providedIn: 'root' })
export class ${svc} extends BaseService<Create${page.key}, ${page.key}> {
  constructor(http: HttpClient) {
    super(http, Configurations.${page.config});
  }
}
`;
}

function buildViewTs(page, fields, columns, labelField) {
  const pascal = kebabToPascal(page.page);
  const formClass = formClassName(page);
  const notifAlias = page.key === 'Notification' ? 'CoreNotificationService' : 'NotificationService';
  const notifImport = page.key === 'Notification' ? 'NotificationService as CoreNotificationService' : 'NotificationService';
  const colKeys = columns.map((c) => `'${c.name}'`).join(', ');
  const exportCols = ['{ key: \'id\', label: \'ID\' }'].concat(
    columns.map((c) => `{ key: '${c.name}', label: '${pascalToLabel(c.name)}' }`)
  ).join(',\n    ');
  const labelExpr = labelField === 'id' ? 'row.id' : `(row.${labelField} ?? row.id)`;

  return `import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { SelectionModel } from '@angular/cdk/collections';
import { ${page.key} } from '../../../Shared/Model/${page.model}';
import { ${kebabToPascal(page.page)}Service } from './${page.page}.service';
import { SharedService } from '../../../core/services/shared.service';
import { ${notifImport} } from '../../../core/services/notification.service';
import { FormViewModeService } from '../../../core/services/form-view-mode.service';
import { ExportColumn } from '../../../Shared/Model/ExportColumn';
import { EXPORT_BUTTONS } from '../../../Shared/constants/ExportType.const';
import { ${formClass} } from './${page.page}-form.component';
import { ConfirmDialogComponent } from '../../../Shared/Components/confirm-dialog/confirm-dialog.component';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

@Component({
  selector: 'app-view-${page.page}',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './${page.page}.component.html',
  styleUrl: './${page.page}.component.css',
})
export class View${pascal}Component implements AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  readonly exportButtons = EXPORT_BUTTONS;

  pageSize = 10;
  searchText = '';

  dataSource = new MatTableDataSource<${page.key}>([]);
  selection = new SelectionModel<${page.key}>(true, []);

  displayedColumns: string[] = ['select', 'id', ${colKeys}${columns.length ? ', ' : ''}'actions'];

  exportColumns: ExportColumn[] = [
    ${exportCols},
  ];

  constructor(
    public service: ${kebabToPascal(page.page)}Service,
    private sharedService: SharedService,
    private notification: ${notifAlias},
    private viewMode: FormViewModeService,
    private router: Router,
    private dialog: MatDialog,
  ) {}

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.loadData();
  }

   loadData(): void {
     this.service.getAll<${page.key}[]>().subscribe((data) => {
       this.dataSource.data = (data || []).filter((r: any) => r?.isDeleted !== true && r?.IsDeleted !== true);
       this.selection.clear();
     });
   }

   onSearch(): void {
     this.dataSource.filter = this.searchText.trim().toLowerCase();
   }

   onReset(): void {
     this.searchText = '';
     this.dataSource.filter = '';
   }

   onNew(): void {
     if (this.viewMode.isDialog()) {
       this.openForm({ mode: 'create' });
       return;
     }
     this.router.navigate(['/${page.prefix}/${page.page}/new']);
   }

   onEdit(row: ${page.key}): void {
     if (this.viewMode.isDialog()) {
       this.openForm({ mode: 'edit', item: row });
       return;
     }
     this.router.navigate(['/${page.prefix}/${page.page}', row.id, 'edit']);
   }

   onDelete(row: ${page.key}): void {
     this.dialog
       .open(ConfirmDialogComponent, {
         width: '400px',
         data: { title: 'Delete ${page.title}', message: 'Delete "' + ${labelExpr} + '"? This action sets the record inactive (soft delete).' },
       })
       .afterClosed()
       .subscribe((confirmed) => {
         if (!confirmed) return;
         this.service.softDelete(row.id).subscribe({
           next: () => {
             this.notification.success('${page.title} removed (soft delete).');
             this.loadData();
           },
         });
       });
   }

  onExport(type: string): void {
    const rows = this.selection.selected.length ? this.selection.selected : this.dataSource.filteredData;
    this.sharedService.export(rows, this.exportColumns, type);
  }

  onPageChange(event: PageEvent): void {
    this.pageSize = event.pageSize;
  }

  isAllSelected(): boolean {
    return (
      this.selection.selected.length === this.dataSource.filteredData.length &&
      this.dataSource.filteredData.length > 0
    );
  }

  toggleAllRows(): void {
    if (this.isAllSelected()) {
      this.selection.clear();
    } else {
      this.selection.select(...this.dataSource.filteredData);
    }
  }

  checkboxLabel(row?: ${page.key}): string {
    if (!row) return \`\${this.isAllSelected() ? 'deselect' : 'select'} all\`;
    return \`\${this.selection.isSelected(row) ? 'deselect' : 'select'} row\`;
  }

  private openForm(data: { mode: 'create' | 'edit'; item?: ${page.key} }): void {
    this.dialog
      .open(${formClass}, { width: '720px', panelClass: 'crud-dialog', data })
      .afterClosed()
      .subscribe((saved) => {
        if (saved) this.loadData();
      });
  }
}
`;
}

function buildViewHtml(page, fields, columns) {
  const colBlocks = columns.map((c) => {
    const label = pascalToLabel(c.name);
    if (c.type === 'boolean') {
      return `      <ng-container matColumnDef="${c.name}">
        <th mat-header-cell *matHeaderCellDef>${label}</th>
        <td mat-cell *matCellDef="let row">
          <mat-checkbox [checked]="!!row.${c.name}" disabled></mat-checkbox>
        </td>
      </ng-container>`;
    }
    if (c.type === 'Date') {
      return `      <ng-container matColumnDef="${c.name}">
        <th mat-header-cell *matHeaderCellDef>${label}</th>
        <td mat-cell *matCellDef="let row">{{ row.${c.name} | date: 'short' }}</td>
      </ng-container>`;
    }
    return `      <ng-container matColumnDef="${c.name}">
        <th mat-header-cell *matHeaderCellDef>${label}</th>
        <td mat-cell *matCellDef="let row">{{ row.${c.name} }}</td>
      </ng-container>`;
  }).join('\n');

  return `<div class="page-card">
  <!-- ---- Banner ---- -->
  <div class="banner">
    <div class="banner__icon">
      <mat-icon>${page.bannerIcon}</mat-icon>
    </div>
    <div class="banner__title">${page.title}</div>
  </div>

  <!-- ---- Filter bar ---- -->
  <app-accordion [item]="{ title: 'Filter', icon: 'filter_list' }">
    <div class="filter-bar">
      <div class="filter-bar__row">
        <mat-form-field appearance="outline">
          <mat-label>Search</mat-label>
          <input matInput [(ngModel)]="searchText" placeholder="Search..." (keyup.enter)="onSearch()" />
          <mat-icon matSuffix>search</mat-icon>
        </mat-form-field>
      </div>
      <div class="filter-bar__search-row">
        <button mat-flat-button class="btn-primary" (click)="onSearch()">
          <mat-icon>search</mat-icon> Search
        </button>
        <button mat-stroked-button (click)="onReset()">
          <mat-icon>refresh</mat-icon> Reset
        </button>
      </div>
    </div>
  </app-accordion>

  <!-- ---- Table actions + export toolbar ---- -->
  <div class="table-header">
    <div class="table-actions">
      <button mat-flat-button class="btn-primary" (click)="onNew()">
        <mat-icon>add</mat-icon> New ${page.title}
      </button>
    </div>

    <div class="table-toolbar">
      <div class="table-toolbar__exports">
        <button *ngFor="let btn of exportButtons" mat-stroked-button class="export-btn" (click)="onExport(btn.type)"
          [matTooltip]="btn.type">
          <mat-icon>{{ btn.icon }}</mat-icon>
          <span class="export-btn__label">{{ btn.type }}</span>
        </button>
      </div>
    </div>
  </div>

  <!-- ---- Table ---- -->
  <div class="table-wrapper">
    <table mat-table [dataSource]="dataSource" class="data-table">
      <ng-container matColumnDef="select">
        <th mat-header-cell *matHeaderCellDef>
          <mat-checkbox (change)="$event ? toggleAllRows() : null" [checked]="selection.hasValue() && isAllSelected()"
            [indeterminate]="selection.hasValue() && !isAllSelected()" [aria-label]="checkboxLabel()"></mat-checkbox>
        </th>
        <td mat-cell *matCellDef="let row">
          <mat-checkbox (click)="$event.stopPropagation()" (change)="$event ? selection.toggle(row) : null"
            [checked]="selection.isSelected(row)" [aria-label]="checkboxLabel(row)"></mat-checkbox>
        </td>
      </ng-container>

      <ng-container matColumnDef="id">
        <th mat-header-cell *matHeaderCellDef>ID</th>
        <td mat-cell *matCellDef="let row">{{ row.id }}</td>
      </ng-container>

${colBlocks}

      <ng-container matColumnDef="actions">
        <th mat-header-cell *matHeaderCellDef>Actions</th>
        <td mat-cell *matCellDef="let row">
          <button mat-icon-button class="action-btn action-btn--edit" [matTooltip]="'Edit'"
            (click)="onEdit(row)">
            <mat-icon>edit</mat-icon>
          </button>
          <button mat-icon-button class="action-btn action-btn--delete" [matTooltip]="'Delete'"
            (click)="onDelete(row)">
            <mat-icon>delete_outline</mat-icon>
          </button>
        </td>
      </ng-container>

      <tr mat-header-row *matHeaderRowDef="displayedColumns"></tr>
      <tr mat-row *matRowDef="let row; columns: displayedColumns"></tr>
    </table>

    <div class="table-empty" *ngIf="!dataSource.filteredData.length">
      No ${page.title} records found.
    </div>

    <mat-paginator #paginator [length]="dataSource.filteredData.length" [pageSize]="pageSize"
      [pageSizeOptions]="[5, 10, 25, 100]" (page)="onPageChange($event)" showFirstLastButtons></mat-paginator>
  </div>
</div>
`;
}

function buildViewCss() {
  return `:host {
  display: block;
}

.code-badge {
  display: inline-block;
  background: var(--page-accent-soft);
  color: var(--page-accent-dark);
  font-size: 12px;
  font-weight: 700;
  padding: 2px 8px;
  border-radius: 6px;
  letter-spacing: 0.05em;
}
`;
}

function buildFormTs(page, fields, hasDate) {
  const formClass = formClassName(page);
  const notifAlias = page.key === 'Notification' ? 'CoreNotificationService' : 'NotificationService';
  const notifImport = page.key === 'Notification' ? 'NotificationService as CoreNotificationService' : 'NotificationService';
  const groups = fields.map((f) => {
    const def = f.type === 'string' ? "''" : f.type === 'boolean' ? 'false' : 'null';
    return `      ${f.name}: [${def}],`;
  }).join('\n');
  const patches = fields.map((f) => {
    if (f.type === 'boolean') return `      ${f.name}: this.item?.${f.name} ?? false,`;
    if (f.type === 'Date') return `      ${f.name}: this.toDateInput(this.item?.${f.name}),`;
    if (f.type === 'number') return `      ${f.name}: this.item?.${f.name} ?? null,`;
    return `      ${f.name}: this.item?.${f.name} ?? '',`;
  }).join('\n');

  const dateHelper = hasDate ? `
  private toDateInput(value: Date | string | null | undefined): string | null {
    if (!value) return null;
    const d = new Date(value);
    return isNaN(d.getTime()) ? null : d.toISOString().split('T')[0];
  }
` : '';

  return `import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Create${page.key}, ${page.key} } from '../../../Shared/Model/${page.model}';
import { ${kebabToPascal(page.page)}Service } from './${page.page}.service';
import { ${notifImport} } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface ${page.key}FormDialogData {
  mode: FormMode;
  item?: ${page.key};
}

@Component({
  selector: 'app-${page.page}-form',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './${page.page}-form.component.html',
  styleUrl: './${page.page}-form.component.css',
})
export class ${formClass} implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly service = inject(${kebabToPascal(page.page)}Service);
  private readonly notification = inject(${notifAlias});
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<${page.key}FormDialogData | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: ${page.key};
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New ${page.title}' : 'Edit ${page.title}';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
${groups}
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
    const value = this.form.getRawValue() as Create${page.key};

    const request$ =
      this.mode === 'create'
        ? this.service.create(value)
        : this.service.update(this.item!.id, value);

    request$.subscribe({
      next: () => {
        this.saving = false;
        this.notification.success(
          this.mode === 'create' ? '${page.title} created.' : '${page.title} updated.'
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
${patches}
    });
  }
${dateHelper}
  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/${page.prefix}/${page.page}']);
  }
}
`;
}

function buildFormHtml(page, fields) {
  const fieldBlocks = fields.map((f) => {
    const label = pascalToLabel(f.name);
    if (f.type === 'boolean') {
      return `      <mat-checkbox formControlName="${f.name}">${label}</mat-checkbox>`;
    }
    const typeAttr = f.type === 'number' ? ' type="number"' : f.type === 'Date' ? ' type="date"' : '';
    return `      <mat-form-field appearance="outline">
        <mat-label>${label}</mat-label>
        <input matInput${typeAttr} formControlName="${f.name}" />
      </mat-form-field>`;
  }).join('\n');

  return `<div class="page-card" [class.page-card--dialog]="isDialog">
  <div class="banner" *ngIf="!isDialog">
    <div class="banner__icon">
      <mat-icon>{{ mode === 'create' ? 'add_circle' : '${page.bannerIcon}' }}</mat-icon>
    </div>
    <div class="banner__title">{{ title }}</div>
  </div>

  <form [formGroup]="form" (ngSubmit)="save()" class="form-page">
    <div class="form-page__header" *ngIf="isDialog">
      <mat-icon>{{ mode === 'create' ? 'add_circle' : '${page.bannerIcon}' }}</mat-icon>
      {{ title }}
    </div>

    <div class="form-page__loading" *ngIf="loading">Loading…</div>

    <div class="field-grid">
${fieldBlocks}
    </div>

    <div class="form-page__actions">
      <button mat-button type="button" (click)="cancel()">Cancel</button>
      <button mat-flat-button type="submit" class="btn-primary" [disabled]="form.invalid || saving || loading">
        {{ saving ? 'Saving…' : 'Save' }}
      </button>
    </div>
  </form>
</div>
`;
}

function buildFormCss() {
  return `:host {
  display: block;
}
`;
}

// ---------------------------------------------------------------------------
// Generate
// ---------------------------------------------------------------------------
const configSrc = fs.readFileSync(path.join(ROOT, 'src/app/Configurations/config.ts'), 'utf8');
const configKeys = new Set([...configSrc.matchAll(/static readonly (\w+) = \{\s*\.\.\.endPoint\(/g)].map((m) => m[1]));

let total = 0;
const errors = [];
for (const group of GROUPS) {
  for (const k of group.pages) {
    const key = kebabToPascal(k);
    const page = {
      page: k,
      title: pascalToLabel(key),
      key,
      model: `-${k}.model`,
      config: key,
      prefix: group.prefix,
      bannerIcon: group.bannerIcon,
    };
    if (!configKeys.has(page.config)) {
      errors.push(`MISSING CONFIG KEY: ${page.config} (for ${k})`);
      continue;
    }
    if (!fs.existsSync(path.join(MODELS_DIR, page.model + '.ts'))) {
      errors.push(`MISSING MODEL FILE: ${page.model} (for ${k})`);
      continue;
    }
    const fields = parsePayloadFields(page.model, page.key);
    const columns = columnFields(fields);
    const labelField = labelFieldFor(columns);
    const hasDate = fields.some((f) => f.type === 'Date');

    const dir = path.join(PAGES_DIR, group.dir, page.page);
    fs.mkdirSync(dir, { recursive: true });

    const files = {
      [`${page.page}.service.ts`]: buildService(page),
      [`${page.page}.component.ts`]: buildViewTs(page, fields, columns, labelField),
      [`${page.page}.component.html`]: buildViewHtml(page, fields, columns),
      [`${page.page}.component.css`]: buildViewCss(),
      [`${page.page}-form.component.ts`]: buildFormTs(page, fields, hasDate),
      [`${page.page}-form.component.html`]: buildFormHtml(page, fields),
      [`${page.page}-form.component.css`]: buildFormCss(),
    };

    for (const [name, content] of Object.entries(files)) {
      fs.writeFileSync(path.join(dir, name), content, 'utf8');
      total++;
    }
    console.log(`${group.dir.padEnd(15)} ${page.page.padEnd(38)} cols=[${columns.map((c) => c.name).join(', ') || 'id'}] formFields=${fields.length}`);
  }
}

console.log(`Generated ${total} files.`);
if (errors.length) {
  console.log('ERRORS:');
  for (const e of errors) console.log('  ' + e);
  process.exitCode = 1;
}
