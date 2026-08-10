// Generates the sidebar groups for the remaining 161 entities (inventory extra /
// reports / other) and merges their MENU i18n keys (English) into en.json + ar.json.
// Run:  node generate-extra-sidebar.js
const fs = require('fs');
const path = require('path');

const ROOT = __dirname;
const OUT_FILE = path.join(ROOT, 'src/app/core/layout/main-layout/extra-sidebar-groups.ts');

const INVENTORY_EXTRA = [
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

const REPORTS = [
  'audit-trail', 'audit-trail-detail', 'notification-log', 'sales-invoice', 'sales-invoice-item',
  'sales-quotation', 'sales-quotation-detail', 'user-session-info', 'user-session-info-detail',
];

const OTHER = [
  'air-filter-type', 'babs', 'battery-type', 'books', 'commission-condition', 'cost-center',
  'customer', 'engine-size', 'expense', 'factory', 'factory-line', 'hadith-collections',
  'hadith-sharh-missing', 'hadiths', 'line', 'narrators', 'oil', 'ownership', 'project', 'section',
  'sector', 'service', 'service-category', 'service-main-category', 'service-sub-category',
  'service-type', 'sharhs', 'state', 'sub-section', 'takheejs', 'transmission-type', 'vehicle',
  'vehicle-brand', 'vehicle-color', 'vehicle-model', 'vehicle-option', 'vehicle-status',
  'vehicle-type', 'view-request-status', 'visit', 'worker-type', 'ws-last-sync-table', 'zone',
  'zone-status',
];

function pascal(k) {
  return k.split('-').filter(Boolean).map((w) => w.charAt(0).toUpperCase() + w.slice(1)).join('');
}
function pretty(k) {
  return pascal(k).replace(/([A-Z])/g, ' $1').trim();
}
function menuKey(k) {
  return k.split('-').filter(Boolean).map((w) => w.toUpperCase()).join('_');
}

// ---------------------------------------------------------------------------
// Bucket the inventory extras into sub-groups (rule order matters; last rule is
// a catch-all). The script asserts every entity lands in exactly one bucket.
// ---------------------------------------------------------------------------
const INV_RULES = [
  { title: 'MENU.INV_ASSET_MGMT', icon: 'settings_suggest', rule: (k) => k.startsWith('asset') || k.startsWith('assets-') },
  { title: 'MENU.INV_STOCK_COUNT', icon: 'fact_check', rule: (k) => k.includes('stock-count') },
  { title: 'MENU.INV_RETURNS_TRANSFERS', icon: 'assignment_return', rule: (k) => k.includes('-return') || k.includes('transfere') || k.includes('transfer-') || ['return-reason', 'return-status', 'warranty-status', 'possession-type', 'transfere-type'].includes(k) },
  { title: 'MENU.INV_REQUESTS', icon: 'inbox', rule: (k) => k.startsWith('inventroy-') || k.startsWith('rw-') || k.startsWith('request-withdraw-') },
  { title: 'MENU.INV_STORES_LOCATIONS', icon: 'storefront', rule: (k) => k.includes('store') || k.includes('location') || ['isle', 'rack', 'shelf', 'partitions'].includes(k) },
  { title: 'MENU.INV_MATERIALS_PARTS', icon: 'widgets', rule: (k) => k.includes('material') || k.includes('spare-part') || ['tools-type', 'equipment-code', 'chemical-group', 'manufacture'].includes(k) },
  { title: 'MENU.INV_ITEM_MASTER', icon: 'inventory', rule: () => true },
];

const OTHER_RULES = [
  { title: 'MENU.OTHER_VEHICLES', icon: 'directions_car', rule: (k) => k === 'vehicle' || k.startsWith('vehicle-') || ['engine-size', 'transmission-type', 'battery-type', 'air-filter-type', 'oil'].includes(k) },
  { title: 'MENU.OTHER_SERVICES', icon: 'handyman', rule: (k) => k === 'service' || k.startsWith('service-') || ['commission-condition', 'cost-center', 'expense', 'ownership', 'project', 'visit', 'view-request-status', 'worker-type', 'ws-last-sync-table', 'customer'].includes(k) },
  { title: 'MENU.OTHER_COMPANY', icon: 'account_tree', rule: (k) => ['factory', 'factory-line', 'line', 'section', 'sector', 'state', 'zone', 'zone-status', 'sub-section'].includes(k) },
  { title: 'MENU.OTHER_LEGACY', icon: 'auto_stories', rule: (k) => ['babs', 'books', 'hadiths', 'hadith-collections', 'hadith-sharh-missing', 'narrators', 'sharhs', 'takheejs'].includes(k) },
];

function bucket(list, rules, expected) {
  const out = rules.map((r) => ({ ...r, items: [] }));
  const leftover = [];
  for (const k of list) {
    let placed = false;
    for (const b of out) {
      if (b.rule(k)) {
        b.items.push(k);
        placed = true;
        break;
      }
    }
    if (!placed) leftover.push(k);
  }
  if (leftover.length || out.reduce((a, b) => a + b.items.length, 0) !== expected) {
    console.error('BUCKET MISMATCH for list of', expected, ':');
    console.error('  leftover:', JSON.stringify(leftover));
    console.error('  counts:', out.map((b) => b.items.length).join(','));
    process.exit(1);
  }
  return out;
}

const invBuckets = bucket(INVENTORY_EXTRA, INV_RULES, 108);
const otherBuckets = bucket(OTHER, OTHER_RULES, 44);

// ---------------------------------------------------------------------------
// Emit extra-sidebar-groups.ts
// ---------------------------------------------------------------------------
function childBlock(b) {
  const links = b.items.map((k) => `      { label: 'MENU.${menuKey(k)}', path: '/${k}' },`).join('\n');
  return `    {
      title: '${b.title}',
      icon: '${b.icon}',
      links: [
${links}
      ],
    },`;
}

const invChildren = invBuckets.map(childBlock).join('\n');
const otherChildren = otherBuckets.map(childBlock).join('\n');
const reportLinks = REPORTS.map((k) => `      { label: 'MENU.${menuKey(k)}', path: '/reports/${k}' },`).join('\n');

const ts = `// Auto-generated sidebar groups for the remaining 161 entities.
// Regenerate with:  node generate-extra-sidebar.js
import type { SidebarItem } from './main-layout.component';

export interface ExtraLink {
  label: string;
  path: string;
}

export interface ExtraChild {
  title: string;
  icon: string;
  links: ExtraLink[];
}

export const inventoryExtraChildren: ExtraChild[] = [
${invChildren}
];

export const reportsExtraGroup: SidebarItem = {
  kind: 'group',
  title: 'MENU.REPORTS',
  icon: 'bar_chart',
  links: [
${reportLinks}
  ],
};

export const otherExtraGroup: SidebarItem = {
  kind: 'group',
  title: 'MENU.OTHER_ENTITIES',
  icon: 'grid_view',
  children: [
${otherChildren}
  ],
};
`;

fs.writeFileSync(OUT_FILE, ts, 'utf8');
console.log('Wrote', OUT_FILE);

// ---------------------------------------------------------------------------
// Merge MENU i18n keys (English) into en.json + ar.json
// ---------------------------------------------------------------------------
const menu = {};
for (const k of INVENTORY_EXTRA) menu[menuKey(k)] = pretty(k);
for (const k of REPORTS) menu[menuKey(k)] = pretty(k);
for (const k of OTHER) menu[menuKey(k)] = pretty(k);
Object.assign(menu, {
  INV_ASSET_MGMT: 'Asset Management',
  INV_STOCK_COUNT: 'Stock Count',
  INV_ITEM_MASTER: 'Item Master & Lookups',
  INV_RETURNS_TRANSFERS: 'Returns & Transfers',
  INV_REQUESTS: 'Requests & Withdrawals',
  INV_STORES_LOCATIONS: 'Stores & Locations',
  INV_MATERIALS_PARTS: 'Materials & Parts',
  OTHER_ENTITIES: 'Other Entities',
  OTHER_VEHICLES: 'Vehicles',
  OTHER_SERVICES: 'Services & Business',
  OTHER_COMPANY: 'Company Structure',
  OTHER_LEGACY: 'Legacy',
});

for (const file of ['public/i18n/en.json', 'public/i18n/ar.json']) {
  const p = path.join(ROOT, file);
  const json = JSON.parse(fs.readFileSync(p, 'utf8'));
  json.MENU = { ...json.MENU, ...menu };
  fs.writeFileSync(p, JSON.stringify(json, null, 2) + '\n', 'utf8');
  console.log(`Merged ${Object.keys(menu).length} MENU keys into ${file}`);
}
