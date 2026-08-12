import { Routes } from '@angular/router';

// Auto-generated routes for the 9 Reports pages.
// Regenerate with:  node generate-crud-routes.js

export const reportsRoutes: Routes = [
  {
    path: 'reports/audit-trail',
    title: 'Audit Trail',
    loadComponent: () =>
      import('./audit-trail/audit-trail.component').then((m) => m.ViewAuditTrailComponent),
  },
  {
    path: 'reports/audit-trail/new',
    title: 'New Audit Trail',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./audit-trail/audit-trail-form.component').then((m) => m.AuditTrailFormComponent),
  },
  {
    path: 'reports/audit-trail/:id/edit',
    title: 'Edit Audit Trail',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./audit-trail/audit-trail-form.component').then((m) => m.AuditTrailFormComponent),
  },
  {
    path: 'reports/audit-trail-detail',
    title: 'Audit Trail Detail',
    loadComponent: () =>
      import('./audit-trail-detail/audit-trail-detail.component').then((m) => m.ViewAuditTrailDetailComponent),
  },
  {
    path: 'reports/audit-trail-detail/new',
    title: 'New Audit Trail Detail',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./audit-trail-detail/audit-trail-detail-form.component').then((m) => m.AuditTrailDetailFormComponent),
  },
  {
    path: 'reports/audit-trail-detail/:id/edit',
    title: 'Edit Audit Trail Detail',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./audit-trail-detail/audit-trail-detail-form.component').then((m) => m.AuditTrailDetailFormComponent),
  },
  {
    path: 'reports/notification-log',
    title: 'Notification Log',
    loadComponent: () =>
      import('./notification-log/notification-log.component').then((m) => m.ViewNotificationLogComponent),
  },
  {
    path: 'reports/notification-log/new',
    title: 'New Notification Log',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./notification-log/notification-log-form.component').then((m) => m.NotificationLogFormComponent),
  },
  {
    path: 'reports/notification-log/:id/edit',
    title: 'Edit Notification Log',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./notification-log/notification-log-form.component').then((m) => m.NotificationLogFormComponent),
  },
  {
    path: 'reports/sales-invoice',
    title: 'Sales Invoice',
    loadComponent: () =>
      import('./sales-invoice/sales-invoice.component').then((m) => m.ViewSalesInvoiceComponent),
  },
  {
    path: 'reports/sales-invoice/new',
    title: 'New Sales Invoice',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./sales-invoice/sales-invoice-form.component').then((m) => m.SalesInvoiceFormComponent),
  },
  {
    path: 'reports/sales-invoice/:id/edit',
    title: 'Edit Sales Invoice',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./sales-invoice/sales-invoice-form.component').then((m) => m.SalesInvoiceFormComponent),
  },
  {
    path: 'reports/sales-invoice-item',
    title: 'Sales Invoice Item',
    loadComponent: () =>
      import('./sales-invoice-item/sales-invoice-item.component').then((m) => m.ViewSalesInvoiceItemComponent),
  },
  {
    path: 'reports/sales-invoice-item/new',
    title: 'New Sales Invoice Item',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./sales-invoice-item/sales-invoice-item-form.component').then((m) => m.SalesInvoiceItemFormComponent),
  },
  {
    path: 'reports/sales-invoice-item/:id/edit',
    title: 'Edit Sales Invoice Item',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./sales-invoice-item/sales-invoice-item-form.component').then((m) => m.SalesInvoiceItemFormComponent),
  },
  {
    path: 'reports/sales-quotation',
    title: 'Sales Quotation',
    loadComponent: () =>
      import('./sales-quotation/sales-quotation.component').then((m) => m.ViewSalesQuotationComponent),
  },
  {
    path: 'reports/sales-quotation/new',
    title: 'New Sales Quotation',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./sales-quotation/sales-quotation-form.component').then((m) => m.SalesQuotationFormComponent),
  },
  {
    path: 'reports/sales-quotation/:id/edit',
    title: 'Edit Sales Quotation',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./sales-quotation/sales-quotation-form.component').then((m) => m.SalesQuotationFormComponent),
  },
  {
    path: 'reports/sales-quotation-detail',
    title: 'Sales Quotation Detail',
    loadComponent: () =>
      import('./sales-quotation-detail/sales-quotation-detail.component').then((m) => m.ViewSalesQuotationDetailComponent),
  },
  {
    path: 'reports/sales-quotation-detail/new',
    title: 'New Sales Quotation Detail',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./sales-quotation-detail/sales-quotation-detail-form.component').then((m) => m.SalesQuotationDetailFormComponent),
  },
  {
    path: 'reports/sales-quotation-detail/:id/edit',
    title: 'Edit Sales Quotation Detail',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./sales-quotation-detail/sales-quotation-detail-form.component').then((m) => m.SalesQuotationDetailFormComponent),
  },
  {
    path: 'reports/user-session-info',
    title: 'User Session Info',
    loadComponent: () =>
      import('./user-session-info/user-session-info.component').then((m) => m.ViewUserSessionInfoComponent),
  },
  {
    path: 'reports/user-session-info/new',
    title: 'New User Session Info',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./user-session-info/user-session-info-form.component').then((m) => m.UserSessionInfoFormComponent),
  },
  {
    path: 'reports/user-session-info/:id/edit',
    title: 'Edit User Session Info',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./user-session-info/user-session-info-form.component').then((m) => m.UserSessionInfoFormComponent),
  },
  {
    path: 'reports/user-session-info-detail',
    title: 'User Session Info Detail',
    loadComponent: () =>
      import('./user-session-info-detail/user-session-info-detail.component').then((m) => m.ViewUserSessionInfoDetailComponent),
  },
  {
    path: 'reports/user-session-info-detail/new',
    title: 'New User Session Info Detail',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./user-session-info-detail/user-session-info-detail-form.component').then((m) => m.UserSessionInfoDetailFormComponent),
  },
  {
    path: 'reports/user-session-info-detail/:id/edit',
    title: 'Edit User Session Info Detail',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./user-session-info-detail/user-session-info-detail-form.component').then((m) => m.UserSessionInfoDetailFormComponent),
  },
];
