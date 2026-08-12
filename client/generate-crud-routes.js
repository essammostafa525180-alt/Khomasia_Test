// Generates route files for the generated Administration / Procurement pages.
// Run:  node generate-crud-routes.js
const fs = require('fs');
const path = require('path');

const ROOT = __dirname;
const PAGES_DIR = path.join(ROOT, 'src/app/pages');

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

function pascal(k) {
  return k.split('-').filter(Boolean).map((w) => w.charAt(0).toUpperCase() + w.slice(1)).join('');
}

function pretty(k) {
  return pascal(k).replace(/([A-Z])/g, ' $1').trim();
}

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

// Keep in sync with generate-crud-pages.js.
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

function formClassName(k) {
  return FORM_CLASS_OVERRIDE[k] || `${pascal(k)}FormComponent`;
}

function buildRoutesFile(dir, exportName, prefix, pages) {
  const lines = [];
  lines.push('import { Routes } from \'@angular/router\';');
  lines.push('');
  lines.push(`// Auto-generated routes for the ${pages.length} ${dir} pages.`);
  lines.push(`// Regenerate with:  node generate-crud-routes.js`);
  lines.push('');
  lines.push(`export const ${exportName}: Routes = [`);
  for (const k of pages) {
    const key = pascal(k);
    const title = pretty(k);
    const rel = `./${k}/${k}`;
    lines.push(`  {
    path: '${prefix}/${k}',
    title: '${title}',
    loadComponent: () =>
      import('${rel}.component').then((m) => m.View${key}Component),
  },
  {
    path: '${prefix}/${k}/new',
    title: 'New ${title}',
    data: { mode: 'create' },
    loadComponent: () =>
      import('${rel}-form.component').then((m) => m.${formClassName(k)}),
  },
  {
    path: '${prefix}/${k}/:id/edit',
    title: 'Edit ${title}',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('${rel}-form.component').then((m) => m.${formClassName(k)}),
  },`);
  }
  lines.push('];');
  lines.push('');
  return lines.join('\n');
}

const groups = [
  { dir: 'Administration', prefix: 'administration', exportName: 'administrationRoutes', file: 'administration.routes', pages: ADMIN_PAGES },
  { dir: 'Procurement', prefix: 'procurement', exportName: 'procurementRoutes', file: 'procurement.routes', pages: PROCUREMENT_PAGES },
  { dir: 'inventory', prefix: 'inventory', exportName: 'inventoryExtraRoutes', file: 'inventory-extra.routes', pages: INVENTORY_EXTRA_PAGES },
  { dir: 'Reports', prefix: 'reports', exportName: 'reportsRoutes', file: 'reports.routes', pages: REPORTS_PAGES },
  { dir: 'Other', prefix: 'other', exportName: 'otherRoutes', file: 'other.routes', pages: OTHER_PAGES },
];

let totalRoutes = 0;
for (const g of groups) {
  const out = path.join(PAGES_DIR, g.dir, `${g.file}.ts`);
  fs.writeFileSync(out, buildRoutesFile(g.dir, g.exportName, g.prefix, g.pages), 'utf8');
  totalRoutes += g.pages.length * 3;
  console.log(`Wrote ${out} (${g.pages.length * 3} routes)`);
}
console.log(`Total ${totalRoutes} routes.`);
