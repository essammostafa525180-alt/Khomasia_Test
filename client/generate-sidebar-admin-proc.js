// Generates the sidebar groups + i18n JSON additions for Administration /
// Procurement pages, and prints the TS snippet to stdout for manual insertion.
// Run:  node generate-sidebar-admin-proc.js
const fs = require('fs');
const path = require('path');

const EN_JSON = path.join(__dirname, 'public/i18n/en.json');
const AR_JSON = path.join(__dirname, 'public/i18n/ar.json');

function pascal(k) {
  return k.split('-').filter(Boolean).map((w) => w.charAt(0).toUpperCase() + w.slice(1)).join('');
}

function pretty(k) {
  return pascal(k).replace(/([A-Z])/g, ' $1').trim();
}

function labelKey(k) {
  return 'MENU.' + k.replace(/-/g, '_').toUpperCase();
}

const ADMIN_SUBGROUPS = [
  { key: 'MENU.ADMIN_SECURITY', icon: 'security', pages: ['ad-user', 'user', 'pruser', 'scope', 'ou', 'sec-configuration', 'sec-model', 'sec-model-attribute', 'sec-module', 'sec-property', 'sec-role', 'sec-role-model-attribute', 'sec-role-module', 'sec-role-property', 'sec-role-securable-value', 'sec-role-view-action', 'sec-user-model-atrribute', 'sec-user-module', 'sec-user-property', 'sec-user-securable-value', 'sec-user-view-action', 'sec-view', 'sec-view-action', 'sitemap', 'sys-key-value'] },
  { key: 'MENU.ADMIN_APPROVALS', icon: 'approval', pages: ['approval-matrix', 'approval-matrix-config', 'approval-matrix-config-detail', 'approval-matrix-detail', 'approval-matrix-range', 'approval-screen', 'approval-status'] },
  { key: 'MENU.ADMIN_COMPANY', icon: 'business', pages: ['company', 'allowed-company', 'employee', 'employee-job', 'gender', 'rank', 'days-of-week', 'language'] },
  { key: 'MENU.ADMIN_NOTIFICATIONS', icon: 'notifications', pages: ['notification', 'notification-place-holder', 'notification-state', 'notification-template', 'notification-template-contact', 'notification-type'] },
  { key: 'MENU.ADMIN_PDA', icon: 'devices', pages: ['pdaassignment', 'pdadetail', 'pdamodel', 'pdarequests-log'] },
  { key: 'MENU.ADMIN_GENERAL', icon: 'tune', pages: ['classifications', 'contact', 'contact-type', 'contacts', 'module-setting', 'assign-asset-type-to-asset-group', 'assign-cost-center-to-sector', 'assign-site-section', 'assign-vendor-evaluation-criterion', 'assign-vendor-specialization'] },
];

const PROC_SUBGROUPS = [
  { key: 'MENU.PROC_VENDORS', icon: 'local_shipping', pages: ['vendor', 'vendor-specialization', 'vendor-status', 'vendor-type', 'vendor-evaluation-criterion', 'insurance-vendor', 'inventory-item-vendor'] },
  { key: 'MENU.PROC_VENDOR_ORDERS', icon: 'receipt_long', pages: ['vendor-order', 'vendor-order-attachment', 'vendor-order-detail', 'vendor-order-partially-received-note', 'vendor-order-screen', 'vendor-order-status', 'vendor-order-type', 'vendor-order-vendor-selection', 'vendor-order-vendor-suggested'] },
  { key: 'MENU.PROC_RECEIVING', icon: 'fact_check', pages: ['vendor-order-quality', 'vendor-order-quality-attachment', 'vendor-order-quality-detail', 'vendor-order-quality-detail-batch', 'vendor-order-receive', 'vendor-order-receive-attachment', 'vendor-order-receive-detail', 'vendor-order-receive-detail-batch', 'vendor-order-receive-detail-batch-serial', 'vendor-order-receive-serial'] },
  { key: 'MENU.PROC_RETURNS', icon: 'assignment_return', pages: ['vendor-return', 'vendor-return-attachment', 'vendor-return-detail', 'vendor-return-detail-batch', 'vendor-return-detail-batch-serial', 'vendor-return-serial'] },
  { key: 'MENU.PROC_POSERVICES', icon: 'handyman', pages: ['poservice-asset', 'poservice-detail', 'poservice-outsource', 'poservice-recomended-resource', 'poservice-terms-and-condition', 'poservice-type', 'purchase-order-service', 'purchase-order-service-attachment'] },
  { key: 'MENU.PROC_LOOKUPS', icon: 'category', pages: ['order-line-item-status', 'request-line-item-status', 'payment-term', 'terms-and-condition'] },
];

const SUBGROUP_TITLES = {
  'MENU.ADMIN_SECURITY': 'Security & Users',
  'MENU.ADMIN_APPROVALS': 'Approvals',
  'MENU.ADMIN_COMPANY': 'Company & Employees',
  'MENU.ADMIN_NOTIFICATIONS': 'Notifications',
  'MENU.ADMIN_PDA': 'PDA Devices',
  'MENU.ADMIN_GENERAL': 'General',
  'MENU.PROC_VENDORS': 'Vendors',
  'MENU.PROC_VENDOR_ORDERS': 'Vendor Orders',
  'MENU.PROC_RECEIVING': 'Receiving & Quality',
  'MENU.PROC_RETURNS': 'Returns',
  'MENU.PROC_POSERVICES': 'PO Services',
  'MENU.PROC_LOOKUPS': 'Lookups',
};

// ---- Sidebar snippet ----
const lines = [];
// All admin pages live under /administration/<page>, proc under /procurement/<page>.
function emitGroupSimple(groupTitle, icon, prefix, subgroups) {
  lines.push(`    {
      kind: 'group',
      title: '${groupTitle}',
      icon: '${icon}',
      children: [`);
  for (const sub of subgroups) {
    lines.push(`        {
          title: '${sub.key}',
          icon: '${sub.icon}',
          links: [`);
    for (const k of sub.pages) {
      lines.push(`            { label: '${labelKey(k)}', path: '/${prefix}/${k}' },`);
    }
    lines.push(`          ],
        },`);
  }
  lines.push(`      ],
    },`);
}

lines.push('// 2) Administration');
emitGroupSimple('MENU.ADMINISTRATION', 'admin_panel_settings', 'administration', ADMIN_SUBGROUPS);
lines.push('// 3) Procurement');
emitGroupSimple('MENU.PROCUREMENT', 'local_shipping', 'procurement', PROC_SUBGROUPS);

const snippet = lines.join('\n') + '\n';
fs.writeFileSync(path.join(__dirname, 'sidebar-admin-proc.snippet.ts'), snippet, 'utf8');
console.log('Sidebar snippet written to sidebar-admin-proc.snippet.ts');
console.log('---BEGIN---');
console.log(snippet);
console.log('---END---');

// ---- i18n additions ----
const en = JSON.parse(fs.readFileSync(EN_JSON, 'utf8'));
const ar = JSON.parse(fs.readFileSync(AR_JSON, 'utf8'));

const subAdd = {};
for (const [k, v] of Object.entries(SUBGROUP_TITLES)) {
  const short = k.replace('MENU.', '');
  subAdd[short] = v;
}
const labelAdd = {};
for (const sub of [...ADMIN_SUBGROUPS, ...PROC_SUBGROUPS]) {
  for (const k of sub.pages) {
    labelAdd[k.replace(/-/g, '_').toUpperCase()] = pretty(k);
  }
}

function merge(trans, add) {
  trans.MENU = Object.assign({}, trans.MENU, add, trans.MENU);
  return trans;
}
const enMerged = merge(en, Object.assign({}, subAdd, labelAdd));
const arMerged = merge(ar, Object.assign({}, subAdd, labelAdd));

fs.writeFileSync(EN_JSON, JSON.stringify(enMerged, null, 2) + '\n', 'utf8');
fs.writeFileSync(AR_JSON, JSON.stringify(arMerged, null, 2) + '\n', 'utf8');
console.log(`i18n updated. en keys=${Object.keys(enMerged.MENU).length} ar keys=${Object.keys(arMerged.MENU).length}`);
