// Generates per-entity view-<kebab> + form-data folders for all 265
// inventory-style entities (core/services/-<kebab>.service.ts).
// Run from the project root:  node generate-entity-modules.js
const fs = require('fs');
const path = require('path');

const ROOT = __dirname;
const SERVICES_DIR = path.join(ROOT, 'src/app/core/services');
const MODELS_DIR = path.join(ROOT, 'src/app/Shared/Model');
const FEATURE_DIR = path.join(ROOT, 'src/app/Feature');
const ROUTES_FILE = path.join(ROOT, 'src/app/app.routes.ts');

function kebabToPascal(kebab) {
  return kebab
    .split('-')
    .filter(Boolean)
    .map((p) => p.charAt(0).toUpperCase() + p.slice(1))
    .join('');
}

// "AdUser" -> "Ad User"
function pascalToLabel(pascal) {
  return pascal.replace(/([A-Z])/g, ' $1').trim();
}

function pluralize(word) {
  if (word.toLowerCase().endsWith('s')) return word + 'es';
  return word + 's';
}

// Parse one interface block like:  export interface FooPayload {  a?: string; ... }
function parseInterfaceFields(file, iface) {
  const re = new RegExp(
    `export interface ${iface}\\s*{([\\s\\S]*?)\\n}\\s*\\n`,
    'm'
  );
  // fallback without trailing newline
  const re2 = new RegExp(`export interface ${iface}\\s*{([\\s\\S]*?)}\\s*\\n}`, 'm');
  let m = re.exec(file) || re2.exec(file);
  if (!m) return [];

  const body = m[1];
  const lines = body.split('\n');
  const fields = [];
  const lineRe = /^\s*([A-Za-z_][A-Za-z0-9_]*)\??\s*:\s*(.+?);\s*$/;
  for (const l of lines) {
    const lm = lineRe.exec(l.trim());
    if (!lm) continue;
    const name = lm[1];
    const raw = lm[2].trim().replace(/\|/g, ' ').split(/[ \t]+/).filter(Boolean).join(' ');
    // base type after stripping nullable unions
    const base = raw.replace(/\bnull\b/g, '').replace(/\bundefined\b/g, '').trim() || 'any';
    fields.push({ name, raw, base });
  }
  return fields;
}

// Scalar, editable field types
const SCALAR = new Set(['string', 'number', 'boolean', 'Date']);

function usableFields(modelFile, key) {
  const payloadName = key + 'Payload';
  const all = parseInterfaceFields(modelFile, payloadName);
  const out = [];
  for (const f of all) {
    if (f.base === 'any') continue; // skip Navigation / complex
    if (!SCALAR.has(f.base)) continue;
    out.push(f);
  }
  return out;
}

function fieldType(f) {
  const b = f.base;
  if (b === 'boolean') return 'boolean';
  if (b === 'number') return 'number';
  if (b === 'Date') return 'date';
  return 'string';
}

function rel(fromDir, toAbs) {
  return path.relative(fromDir, toAbs).replace(/\\/g, '/');
}

function writeFile(file, content) {
  fs.mkdirSync(path.dirname(file), { recursive: true });
  fs.writeFileSync(file, content, 'utf8');
}

function genView(key, kebab, fields, routes) {
  const EntityLabel = pascalToLabel(key);
  const EntityPlural = pluralize(EntityLabel);
  const serviceClass = key + 'Service';
  const componentClass = 'View' + key + 'Component';
  const selector = 'app-view-' + kebab;
  const routeBase = kebab;
  const colNames = ['select', 'id', ...fields.map((f) => f.name), 'actions'];
  const fieldLabels = fields.map((f) => pascalToLabel(f.name));

  // ---- view-<kebab>.component.ts ----
  const viewTs = `import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { SelectionModel } from '@angular/cdk/collections';
import { ${key}, PagedResult } from '../../../Shared/Model/-${kebab}.model';
import { ${serviceClass} } from '../../../core/services/-${kebab}.service';
import { SharedService } from '../../../core/services/shared.service';
import { NotificationService as NotifyService } from '../../../core/services/notification.service';
import { FormViewModeService } from '../../../core/services/form-view-mode.service';
import { ExportColumn } from '../../../Shared/Model/ExportColumn';
import { EXPORT_BUTTONS } from '../../../Shared/constants/ExportType.const';
import { ${key}FormComponent } from '../form-data/form-data.component';
import { ConfirmDialogComponent } from '../../../Shared/Components/confirm-dialog/confirm-dialog.component';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

@Component({
  selector: '${selector}',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './view-${kebab}.component.html',
  styleUrl: './view-${kebab}.component.css',
})
export class ${componentClass} implements AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  readonly exportButtons = EXPORT_BUTTONS;

  pageSize = 10;
  pageIndex = 0;
  totalItems = 0;
  searchText = '';

  dataSource = new MatTableDataSource<${key}>([]);
  selection = new SelectionModel<${key}>(true, []);

  displayedColumns: string[] = ${JSON.stringify(colNames)};

  exportColumns: ExportColumn[] = [
    { key: 'id', label: 'ID' },
${fields
    .map((f) => `    { key: '${f.name}', label: '${pascalToLabel(f.name)}' },`)
    .join('\n')}
  ];

  constructor(
    public ${serviceClass.toLowerCase()}: ${serviceClass},
    private sharedService: SharedService,
    private notify: NotifyService,
    private viewMode: FormViewModeService,
    private router: Router,
    private dialog: MatDialog
  ) {}

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.loadData();
  }

  loadData(): void {
    this.${serviceClass.toLowerCase()}
      .getAll({
        pageNumber: this.pageIndex + 1,
        pageSize: this.pageSize,
        searchText: this.searchText.trim(),
      })
      .subscribe((res: PagedResult<${key}>) => {
        this.dataSource.data = res.items ?? [];
        this.totalItems = res.totalItems ?? 0;
        this.selection.clear();
      });
  }

  onSearch(): void {
    this.pageIndex = 0;
    this.loadData();
  }

  onReset(): void {
    this.searchText = '';
    this.pageIndex = 0;
    this.dataSource.filter = '';
    this.loadData();
  }

  onNew(): void {
    if (this.viewMode.isDialog()) {
      this.openForm({ mode: 'create' });
      return;
    }
    this.router.navigate(['/${routeBase}/new']);
  }

  onEdit(row: ${key}): void {
    if (this.viewMode.isDialog()) {
      this.openForm({ mode: 'edit', item: row });
      return;
    }
    this.router.navigate(['/${routeBase}', row.id, 'edit']);
  }

  onDelete(row: ${key}): void {
    this.dialog
      .open(ConfirmDialogComponent, {
        width: '400px',
        data: {
          title: 'Delete ${EntityLabel}',
          message: \`Delete ${EntityLabel} #\${row.id}? This action cannot be undone.\`,
        },
      })
      .afterClosed()
      .subscribe((confirmed) => {
        if (!confirmed) return;
        this.${serviceClass.toLowerCase()}.delete(row.id).subscribe(() => {
          this.notify.success('${EntityLabel} deleted.');
          this.loadData();
        });
      });
  }

  onExport(type: string): void {
    const rows = this.selection.selected.length
      ? this.selection.selected
      : this.dataSource.filteredData;
    this.sharedService.export(rows, this.exportColumns, type);
  }

  onPageChange(event: PageEvent): void {
    this.pageSize = event.pageSize;
    this.pageIndex = event.pageIndex;
    this.loadData();
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

  checkboxLabel(row?: ${key}): string {
    if (!row) return \`\${this.isAllSelected() ? 'deselect' : 'select'} all\`;
    return \`\${this.selection.isSelected(row) ? 'deselect' : 'select'} row\`;
  }

  private openForm(data: { mode: 'create' | 'edit'; item?: ${key} }): void {
    this.dialog
      .open(${key}FormComponent, { width: '720px', data })
      .afterClosed()
      .subscribe((saved) => {
        if (saved) this.loadData();
      });
  }
}
`;

  // ---- view-<kebab>.component.html ----
  const viewHtml = `<div class="page-card">
  <!-- Banner -->
  <div class="banner">
    <div class="banner__icon">
      <mat-icon>list</mat-icon>
    </div>
    <div class="banner__title">${EntityLabel} Management</div>
  </div>

  <!-- Filter bar -->
  <app-accordion [item]="{ title: 'Filter', icon: 'filter_list' }">
    <div class="filter-bar">
      <div class="filter-bar__row">
        <mat-form-field appearance="outline">
          <mat-label>Search ${EntityLabel}</mat-label>
          <input matInput [(ngModel)]="searchText" [placeholder]="'Type to search'"
            (keyup.enter)="onSearch()" />
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

  <!-- Table actions + export -->
  <div class="table-header">
    <div class="table-actions">
      <button mat-flat-button class="btn-primary" (click)="onNew()">
        <mat-icon>add</mat-icon> New ${EntityLabel}
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

  <!-- Table -->
  <div class="table-wrapper">
    <table mat-table [dataSource]="dataSource" class="data-table">
      <!-- Checkbox -->
      <ng-container matColumnDef="select">
        <th mat-header-cell *matHeaderCellDef>
          <mat-checkbox (change)="\$event ? toggleAllRows() : null" [checked]="selection.hasValue() && isAllSelected()"
            [indeterminate]="selection.hasValue() && !isAllSelected()" [aria-label]="checkboxLabel()"></mat-checkbox>
        </th>
        <td mat-cell *matCellDef="let row">
          <mat-checkbox (click)="\$event.stopPropagation()" (change)="\$event ? selection.toggle(row) : null"
            [checked]="selection.isSelected(row)" [aria-label]="checkboxLabel(row)"></mat-checkbox>
        </td>
      </ng-container>

      <!-- ID -->
      <ng-container matColumnDef="id">
        <th mat-header-cell *matHeaderCellDef>ID</th>
        <td mat-cell *matCellDef="let row">{{ row.id }}</td>
      </ng-container>

${fields
    .map(
      (f) => `      <!-- ${f.name} -->
      <ng-container matColumnDef="${f.name}">
        <th mat-header-cell *matHeaderCellDef>${pascalToLabel(f.name)}</th>
        <td mat-cell *matCellDef="let row">{{ row.${f.name} }}</td>
      </ng-container>`
    )
    .join('\n')}

      <!-- Actions -->
      <ng-container matColumnDef="actions">
        <th mat-header-cell *matHeaderCellDef>Actions</th>
        <td mat-cell *matCellDef="let row">
          <button mat-icon-button class="action-btn action-btn--edit" [matTooltip]="'Edit'" (click)="onEdit(row)">
            <mat-icon>edit</mat-icon>
          </button>
          <button mat-icon-button class="action-btn action-btn--delete" [matTooltip]="'Delete'" (click)="onDelete(row)">
            <mat-icon>delete_outline</mat-icon>
          </button>
        </td>
      </ng-container>

      <tr mat-header-row *matHeaderRowDef="displayedColumns"></tr>
      <tr mat-row *matRowDef="let row; columns: displayedColumns"></tr>
    </table>

    <div class="table-empty" *ngIf="!dataSource.filteredData.length">
      No ${EntityPlural} found.
    </div>

    <mat-paginator #paginator [length]="totalItems" [pageSize]="pageSize"
      [pageSizeOptions]="[5, 10, 25, 100]" (page)="onPageChange($event)" showFirstLastButtons></mat-paginator>
  </div>
</div>
`;

  // ---- view-<kebab>.component.css ----
  const hasCode = fields.some((f) => f.name === 'code');
  const viewCss = hasCode
    ? `:host {
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
`
    : `/* ${kebab} view styles */\n`;

  return {
    ts: viewTs,
    html: viewHtml,
    css: viewCss,
    selector,
    componentClass,
  };
}

function genForm(key, kebab, fields) {
  const EntityLabel = pascalToLabel(key);
  const EntitySingular = EntityLabel;
  const serviceClass = key + 'Service';
  const componentClass = key + 'FormComponent';
  const selector = 'app-' + kebab + '-form';
  const routeBase = kebab;

  // form control defs
  const controlDefs = fields
    .map((f) => {
      const ctrl = `${f.name}: ['', []]`;
      return `      ${f.name}: ['', []]`;
    })
    .join(',\n');

  // patchForm lines
  const patchLines = fields
    .map((f) => `      ${f.name}: this.item?.${f.name} ?? '',`)
    .join('\n');

  // HTML form fields via ngFor over formFields metadata
  // We render per-field blocks in the template.
  const fieldBlocks = fields
    .map((f) => {
      const ft = fieldType(f);
      const label = pascalToLabel(f.name);
      if (ft === 'boolean') {
        return `        <mat-checkbox formControlName="${f.name}">${label}</mat-checkbox>`;
      }
      if (ft === 'number') {
        return `        <mat-form-field appearance="outline">
          <mat-label>${label}</mat-label>
          <input matInput type="number" formControlName="${f.name}" />
        </mat-form-field>`;
      }
      if (ft === 'date') {
        return `        <mat-form-field appearance="outline">
          <mat-label>${label}</mat-label>
          <input matInput type="date" formControlName="${f.name}" />
        </mat-form-field>`;
      }
      return `        <mat-form-field appearance="outline">
          <mat-label>${label}</mat-label>
          <input matInput formControlName="${f.name}" placeholder="${label}" maxlength="255" />
        </mat-form-field>`;
    })
    .join('\n');

  const formTs = `import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ${key}, ${key}Payload } from '../../../Shared/Model/-${kebab}.model';
import { ${serviceClass} } from '../../../core/services/-${kebab}.service';
import { NotificationService as NotifyService } from '../../../core/services/notification.service';
import { FormMode } from '../../../Shared/Model/FormMode';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

export interface ${componentClass}Data {
  mode: FormMode;
  item?: ${key};
}

@Component({
  selector: '${selector}',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './form-data.component.html',
  styleUrl: './form-data.component.css',
})
export class ${componentClass} implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly ${serviceClass.toLowerCase()} = inject(${serviceClass});
  private readonly notify = inject(NotifyService);
  private readonly router = inject(Router);
  private readonly route = inject(ActivatedRoute);

  private readonly dialogRef = inject(MatDialogRef, { optional: true });
  private readonly data = inject<${componentClass}Data | null>(MAT_DIALOG_DATA, { optional: true });

  readonly isDialog = !!this.dialogRef;

  form!: FormGroup;
  mode: FormMode = 'create';
  item?: ${key};
  saving = false;
  loading = false;

  get title(): string {
    return this.mode === 'create' ? 'New ${EntitySingular}' : 'Edit ${EntitySingular}';
  }

  ngOnInit(): void {
    this.form = this.fb.group({
${controlDefs}
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
    const value = this.form.getRawValue() as ${key}Payload;

    const handler = {
      next: () => {
        this.saving = false;
        this.notify.success(
          this.mode === 'create' ? '${EntitySingular} created.' : '${EntitySingular} updated.'
        );
        this.close(true);
      },
      error: () => {
        this.saving = false;
      },
    };

    if (this.mode === 'create') {
      this.${serviceClass.toLowerCase()}.create(value).subscribe(handler);
    } else {
      this.${serviceClass.toLowerCase()}.update(this.item!.id, value).subscribe(handler);
    }
  }


  cancel(): void {
    this.close(false);
  }

  private loadItem(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if (!Number.isInteger(id) || id <= 0) {
      this.notify.error('Invalid record identifier.');
      this.close(false);
      return;
    }
    this.loading = true;
    this.${serviceClass.toLowerCase()}.getById(id).subscribe({
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
${patchLines}
    });
  }

  private close(saved: boolean): void {
    if (this.dialogRef) {
      this.dialogRef.close(saved);
      return;
    }
    this.router.navigate(['/${routeBase}']);
  }
}
`;

  const formHtml = `<div class="page-card" [class.page-card--dialog]="isDialog">
  <div class="banner" *ngIf="!isDialog">
    <div class="banner__icon">
      <mat-icon>{{ mode === 'create' ? 'add_circle' : 'edit' }}</mat-icon>
    </div>
    <div class="banner__title">{{ title }}</div>
  </div>

  <form [formGroup]="form" (ngSubmit)="save()" class="form-page">
    <div class="form-page__header" *ngIf="isDialog">
      <mat-icon>{{ mode === 'create' ? 'add_circle' : 'edit' }}</mat-icon>
      {{ title }}
    </div>

    <div class="form-page__loading" *ngIf="loading">Loading ${EntitySingular}…</div>

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

  const formCss = `/* ${kebab} form styles */\n`;

  return { ts: formTs, html: formHtml, css: formCss };
}

function genRoute(key, kebab, componentClass, formClass) {
  return `      {
        path: '${kebab}',
        title: '${pascalToLabel(key)}',
        loadComponent: () =>
          import('./Feature/${key}Module/view-${kebab}/view-${kebab}.component').then(
            (m) => m.${componentClass}
          ),
      },
      {
        path: '${kebab}/new',
        title: 'New ${pascalToLabel(key)}',
        data: { mode: 'create' },
        loadComponent: () =>
          import('./Feature/${key}Module/form-data/form-data.component').then(
            (m) => m.${formClass}
          ),
      },
      {
        path: '${kebab}/:id/edit',
        title: 'Edit ${pascalToLabel(key)}',
        data: { mode: 'edit' },
        loadComponent: () =>
          import('./Feature/${key}Module/form-data/form-data.component').then(
            (m) => m.${formClass}
          ),
      },`;
}

// ---- main ----
const serviceFiles = fs
  .readdirSync(SERVICES_DIR)
  .filter((f) => f.startsWith('-') && f.endsWith('.service.ts'));

console.log('Found ' + serviceFiles.length + ' generated service files.');

let count = 0;
const routeBlocks = [];
const errors = [];

for (const sf of serviceFiles) {
  const kebab = sf.replace(/^-/, '').replace(/\.service\.ts$/, '');
  const servicePath = path.join(SERVICES_DIR, sf);
  const serviceSrc = fs.readFileSync(servicePath, 'utf8');

  const clsMatch = serviceSrc.match(/export class (\w+Service)/);
  const cfgMatch = serviceSrc.match(/Configurations\.(\w+)/);
  if (!clsMatch || !cfgMatch) {
    errors.push('SKIP ' + sf + ': no class/config');
    continue;
  }
  const key = cfgMatch[1]; // e.g. AdUser
  const serviceClass = clsMatch[1];

  const modelPath = path.join(MODELS_DIR, '-' + kebab + '.model.ts');
  if (!fs.existsSync(modelPath)) {
    errors.push('SKIP ' + sf + ': model missing');
    continue;
  }
  const modelSrc = fs.readFileSync(modelPath, 'utf8');
  const fields = usableFields(modelSrc, key);

  const viewDir = path.join(FEATURE_DIR, key + 'Module', 'view-' + kebab);
  const formDir = path.join(FEATURE_DIR, key + 'Module', 'form-data');

  const v = genView(key, kebab, fields, routeBlocks);
  const f = genForm(key, kebab, fields);

  writeFile(path.join(viewDir, 'view-' + kebab + '.component.ts'), v.ts);
  writeFile(path.join(viewDir, 'view-' + kebab + '.component.html'), v.html);
  writeFile(path.join(viewDir, 'view-' + kebab + '.component.css'), v.css);

  writeFile(path.join(formDir, 'form-data.component.ts'), f.ts);
  writeFile(path.join(formDir, 'form-data.component.html'), f.html);
  writeFile(path.join(formDir, 'form-data.component.css'), f.css);

  routeBlocks.push(genRoute(key, kebab, v.componentClass, key + 'FormComponent'));
  count++;
}

// ---- inject routes (idempotent) ----
let routesSrc = fs.readFileSync(ROUTES_FILE, 'utf8');
const MARKER = '      // ---- Auto-generated entity routes (view + form) ----';
const anchor = `      { path: '**', redirectTo: 'dashboard' },`;
if (!routesSrc.includes(anchor)) {
  errors.push('Could not find route anchor');
} else {
  // Strip any previously inserted generated block (everything from the marker
  // up to the anchor) so re-runs do not duplicate routes.
  if (routesSrc.includes(MARKER)) {
    const markerIdx = routesSrc.indexOf(MARKER);
    const anchorIdx = routesSrc.indexOf(anchor);
    routesSrc = routesSrc.slice(0, markerIdx) + routesSrc.slice(anchorIdx);
  }
  const block =
    MARKER + '\n' +
    routeBlocks.join('\n') +
    '\n';
  const updated = routesSrc.replace(anchor, block + anchor);
  fs.writeFileSync(ROUTES_FILE, updated, 'utf8');
  console.log('Inserted ' + routeBlocks.length + ' route groups into app.routes.ts');
}

console.log('Done. Generated view+form for ' + count + ' entities.');
if (errors.length) {
  console.log('ERRORS:');
  errors.forEach((e) => console.log('  ' + e));
}
