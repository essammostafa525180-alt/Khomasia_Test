// Generates the entity sidebar groups for the 265 generated entities,
// categorized into Administration / Procurement / Reports / Other.
// Run:  node generate-sidebar.js
const fs = require('fs');
const path = require('path');

const SERVICES_DIR = path.join(__dirname, 'src/app/core/services');
const OUT_FILE = path.join(__dirname, 'src/app/core/layout/main-layout/entity-sidebar-groups.ts');

const kebabs = fs
  .readdirSync(SERVICES_DIR)
  .filter((f) => f.startsWith('-') && f.endsWith('.service.ts'))
  .map((f) => f.replace(/^-/, '').replace(/\.service\.ts$/, ''))
  .sort();

function pretty(kebab) {
  return kebab
    .split('-')
    .filter(Boolean)
    .map((w) => w.charAt(0).toUpperCase() + w.slice(1))
    .join(' ');
}

const CATEGORY = {
  ADMIN: 'admin',
  PROCUREMENT: 'procurement',
  INVENTORY: 'inventory',
  REPORTS: 'reports',
  OTHER: 'other',
};

function categorize(k) {
  // Reports first (logs / sales)
  if (
    k.includes('audit-trail') ||
    k.includes('user-session-info') ||
    k.includes('notification-log') ||
    k.includes('sales-invoice') ||
    k.includes('sales-quotation') ||
    k === 'report'
  ) return CATEGORY.REPORTS;

  // Administration
  if (
    k.startsWith('sec-') ||
    k.startsWith('assign-') ||
    k.includes('user') ||
    k.includes('approval') ||
    k.includes('audit') ||
    k.includes('company') ||
    k.includes('employee') ||
    k.includes('module-setting') ||
    k.includes('sys-key-value') ||
    k.includes('language') ||
    k.includes('sitemap') ||
    k.includes('notification') ||
    k.includes('role') ||
    k.includes('rank') ||
    k.includes('job') ||
    k.includes('gender') ||
    k.includes('days-of-week') ||
    k.includes('pda') ||
    k.includes('contact') ||
    k.includes('classification') ||
    k === 'pruser' ||
    k === 'scope' ||
    k === 'ou'
  ) return CATEGORY.ADMIN;

  // Procurement
  if (
    k.includes('vendor') ||
    k.includes('poservice') ||
    k.includes('purchase-order-service') ||
    k === 'payment-term' ||
    k === 'terms-and-condition' ||
    k === 'order-line-item-status' ||
    k === 'request-line-item-status'
  ) return CATEGORY.PROCUREMENT;

  // Inventory
  if (
    k.includes('asset') ||
    k.includes('inventory') ||
    k.includes('inventroy') ||
    k.includes('item') ||
    k.includes('stock') ||
    k.includes('transfer') ||
    k.includes('transfere') ||
    k.includes('issue') ||
    k.includes('withdraw') ||
    k.startsWith('rw-') ||
    k.includes('store') ||
    k.includes('unit-of-measure') ||
    k.includes('material') ||
    k.includes('spare-part') ||
    k.includes('tools-type') ||
    k.includes('equipment-code') ||
    k.includes('location') ||
    k.includes('rack') ||
    k.includes('shelf') ||
    k.includes('isle') ||
    k.includes('partitions') ||
    k === 'return-reason' ||
    k === 'return-status' ||
    k === 'chemical-group' ||
    k === 'warranty-status' ||
    k === 'possession-type' ||
    k === 'manufacture'
  ) return CATEGORY.INVENTORY;

  return CATEGORY.OTHER;
}

const buckets = {
  [CATEGORY.ADMIN]: [],
  [CATEGORY.PROCUREMENT]: [],
  [CATEGORY.INVENTORY]: [],
  [CATEGORY.REPORTS]: [],
  [CATEGORY.OTHER]: [],
};

for (const k of kebabs) {
  buckets[categorize(k)].push(k);
}

const GROUP_DEFS = [
  { cat: CATEGORY.INVENTORY, title: 'Inventory Entities', icon: 'category' },
  { cat: CATEGORY.ADMIN, title: 'MENU.ADMINISTRATION', icon: 'admin_panel_settings' },
  { cat: CATEGORY.PROCUREMENT, title: 'MENU.PROCUREMENT', icon: 'local_shipping' },
  { cat: CATEGORY.REPORTS, title: 'MENU.REPORTS', icon: 'bar_chart' },
  { cat: CATEGORY.OTHER, title: 'Other Entities', icon: 'grid_view' },
];

const lines = [];
lines.push('// Auto-generated entity sidebar groups for the 265 generated entities.');
lines.push('// Regenerate with:  node generate-sidebar.js');
lines.push('');
lines.push('export interface EntitySidebarLink {');
lines.push('  label: string;');
lines.push('  path: string;');
lines.push('}');
lines.push('');
lines.push('export interface EntitySidebarGroup {');
lines.push("  kind: 'group';");
lines.push('  title: string;');
lines.push('  icon: string;');
lines.push('  links: EntitySidebarLink[];');
lines.push('}');
lines.push('');
lines.push('export const entitySidebarGroups: EntitySidebarGroup[] = [');
for (const def of GROUP_DEFS) {
  const list = buckets[def.cat];
  lines.push('  {');
  lines.push(`    kind: 'group',`);
  lines.push(`    title: '${def.title}',`);
  lines.push(`    icon: '${def.icon}',`);
  lines.push('    links: [');
  for (const k of list) {
    lines.push(`      { label: '${pretty(k)}', path: '/${k}' },`);
  }
  lines.push('    ],');
  lines.push('  },');
}
lines.push('];');
lines.push('');

fs.writeFileSync(OUT_FILE, lines.join('\n'), 'utf8');

const total = Object.values(buckets).reduce((a, b) => a + b.length, 0);
console.log('Total entities:', total);
for (const def of GROUP_DEFS) {
  console.log(`  ${def.title}: ${buckets[def.cat].length}`);
}
console.log('Wrote', OUT_FILE);
