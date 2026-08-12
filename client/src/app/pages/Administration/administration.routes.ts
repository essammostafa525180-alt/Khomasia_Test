import { Routes } from '@angular/router';

// Auto-generated routes for the 60 Administration pages.
// Regenerate with:  node generate-crud-routes.js

export const administrationRoutes: Routes = [
  {
    path: 'administration/ad-user',
    title: 'Ad User',
    loadComponent: () =>
      import('./ad-user/ad-user.component').then((m) => m.ViewAdUserComponent),
  },
  {
    path: 'administration/ad-user/new',
    title: 'New Ad User',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./ad-user/ad-user-form.component').then((m) => m.AdUserFormComponent),
  },
  {
    path: 'administration/ad-user/:id/edit',
    title: 'Edit Ad User',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./ad-user/ad-user-form.component').then((m) => m.AdUserFormComponent),
  },
  {
    path: 'administration/allowed-company',
    title: 'Allowed Company',
    loadComponent: () =>
      import('./allowed-company/allowed-company.component').then((m) => m.ViewAllowedCompanyComponent),
  },
  {
    path: 'administration/allowed-company/new',
    title: 'New Allowed Company',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./allowed-company/allowed-company-form.component').then((m) => m.AllowedCompanyFormComponent),
  },
  {
    path: 'administration/allowed-company/:id/edit',
    title: 'Edit Allowed Company',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./allowed-company/allowed-company-form.component').then((m) => m.AllowedCompanyFormComponent),
  },
  {
    path: 'administration/approval-matrix',
    title: 'Approval Matrix',
    loadComponent: () =>
      import('./approval-matrix/approval-matrix.component').then((m) => m.ViewApprovalMatrixComponent),
  },
  {
    path: 'administration/approval-matrix/new',
    title: 'New Approval Matrix',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./approval-matrix/approval-matrix-form.component').then((m) => m.ApprovalMatrixFormComponent),
  },
  {
    path: 'administration/approval-matrix/:id/edit',
    title: 'Edit Approval Matrix',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./approval-matrix/approval-matrix-form.component').then((m) => m.ApprovalMatrixFormComponent),
  },
  {
    path: 'administration/approval-matrix-config',
    title: 'Approval Matrix Config',
    loadComponent: () =>
      import('./approval-matrix-config/approval-matrix-config.component').then((m) => m.ViewApprovalMatrixConfigComponent),
  },
  {
    path: 'administration/approval-matrix-config/new',
    title: 'New Approval Matrix Config',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./approval-matrix-config/approval-matrix-config-form.component').then((m) => m.ApprovalMatrixConfigFormComponent),
  },
  {
    path: 'administration/approval-matrix-config/:id/edit',
    title: 'Edit Approval Matrix Config',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./approval-matrix-config/approval-matrix-config-form.component').then((m) => m.ApprovalMatrixConfigFormComponent),
  },
  {
    path: 'administration/approval-matrix-config-detail',
    title: 'Approval Matrix Config Detail',
    loadComponent: () =>
      import('./approval-matrix-config-detail/approval-matrix-config-detail.component').then((m) => m.ViewApprovalMatrixConfigDetailComponent),
  },
  {
    path: 'administration/approval-matrix-config-detail/new',
    title: 'New Approval Matrix Config Detail',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./approval-matrix-config-detail/approval-matrix-config-detail-form.component').then((m) => m.ApprovalMatrixConfigDetailFormComponent),
  },
  {
    path: 'administration/approval-matrix-config-detail/:id/edit',
    title: 'Edit Approval Matrix Config Detail',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./approval-matrix-config-detail/approval-matrix-config-detail-form.component').then((m) => m.ApprovalMatrixConfigDetailFormComponent),
  },
  {
    path: 'administration/approval-matrix-detail',
    title: 'Approval Matrix Detail',
    loadComponent: () =>
      import('./approval-matrix-detail/approval-matrix-detail.component').then((m) => m.ViewApprovalMatrixDetailComponent),
  },
  {
    path: 'administration/approval-matrix-detail/new',
    title: 'New Approval Matrix Detail',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./approval-matrix-detail/approval-matrix-detail-form.component').then((m) => m.ApprovalMatrixDetailFormComponent),
  },
  {
    path: 'administration/approval-matrix-detail/:id/edit',
    title: 'Edit Approval Matrix Detail',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./approval-matrix-detail/approval-matrix-detail-form.component').then((m) => m.ApprovalMatrixDetailFormComponent),
  },
  {
    path: 'administration/approval-matrix-range',
    title: 'Approval Matrix Range',
    loadComponent: () =>
      import('./approval-matrix-range/approval-matrix-range.component').then((m) => m.ViewApprovalMatrixRangeComponent),
  },
  {
    path: 'administration/approval-matrix-range/new',
    title: 'New Approval Matrix Range',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./approval-matrix-range/approval-matrix-range-form.component').then((m) => m.ApprovalMatrixRangeFormComponent),
  },
  {
    path: 'administration/approval-matrix-range/:id/edit',
    title: 'Edit Approval Matrix Range',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./approval-matrix-range/approval-matrix-range-form.component').then((m) => m.ApprovalMatrixRangeFormComponent),
  },
  {
    path: 'administration/approval-screen',
    title: 'Approval Screen',
    loadComponent: () =>
      import('./approval-screen/approval-screen.component').then((m) => m.ViewApprovalScreenComponent),
  },
  {
    path: 'administration/approval-screen/new',
    title: 'New Approval Screen',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./approval-screen/approval-screen-form.component').then((m) => m.ApprovalScreenFormComponent),
  },
  {
    path: 'administration/approval-screen/:id/edit',
    title: 'Edit Approval Screen',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./approval-screen/approval-screen-form.component').then((m) => m.ApprovalScreenFormComponent),
  },
  {
    path: 'administration/approval-status',
    title: 'Approval Status',
    loadComponent: () =>
      import('./approval-status/approval-status.component').then((m) => m.ViewApprovalStatusComponent),
  },
  {
    path: 'administration/approval-status/new',
    title: 'New Approval Status',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./approval-status/approval-status-form.component').then((m) => m.ApprovalStatusFormComponent),
  },
  {
    path: 'administration/approval-status/:id/edit',
    title: 'Edit Approval Status',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./approval-status/approval-status-form.component').then((m) => m.ApprovalStatusFormComponent),
  },
  {
    path: 'administration/assign-asset-type-to-asset-group',
    title: 'Assign Asset Type To Asset Group',
    loadComponent: () =>
      import('./assign-asset-type-to-asset-group/assign-asset-type-to-asset-group.component').then((m) => m.ViewAssignAssetTypeToAssetGroupComponent),
  },
  {
    path: 'administration/assign-asset-type-to-asset-group/new',
    title: 'New Assign Asset Type To Asset Group',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./assign-asset-type-to-asset-group/assign-asset-type-to-asset-group-form.component').then((m) => m.AssignAssetTypeToAssetGroupFormComponent),
  },
  {
    path: 'administration/assign-asset-type-to-asset-group/:id/edit',
    title: 'Edit Assign Asset Type To Asset Group',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./assign-asset-type-to-asset-group/assign-asset-type-to-asset-group-form.component').then((m) => m.AssignAssetTypeToAssetGroupFormComponent),
  },
  {
    path: 'administration/assign-cost-center-to-sector',
    title: 'Assign Cost Center To Sector',
    loadComponent: () =>
      import('./assign-cost-center-to-sector/assign-cost-center-to-sector.component').then((m) => m.ViewAssignCostCenterToSectorComponent),
  },
  {
    path: 'administration/assign-cost-center-to-sector/new',
    title: 'New Assign Cost Center To Sector',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./assign-cost-center-to-sector/assign-cost-center-to-sector-form.component').then((m) => m.AssignCostCenterToSectorFormComponent),
  },
  {
    path: 'administration/assign-cost-center-to-sector/:id/edit',
    title: 'Edit Assign Cost Center To Sector',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./assign-cost-center-to-sector/assign-cost-center-to-sector-form.component').then((m) => m.AssignCostCenterToSectorFormComponent),
  },
  {
    path: 'administration/assign-site-section',
    title: 'Assign Site Section',
    loadComponent: () =>
      import('./assign-site-section/assign-site-section.component').then((m) => m.ViewAssignSiteSectionComponent),
  },
  {
    path: 'administration/assign-site-section/new',
    title: 'New Assign Site Section',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./assign-site-section/assign-site-section-form.component').then((m) => m.AssignSiteSectionFormComponent),
  },
  {
    path: 'administration/assign-site-section/:id/edit',
    title: 'Edit Assign Site Section',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./assign-site-section/assign-site-section-form.component').then((m) => m.AssignSiteSectionFormComponent),
  },
  {
    path: 'administration/assign-vendor-evaluation-criterion',
    title: 'Assign Vendor Evaluation Criterion',
    loadComponent: () =>
      import('./assign-vendor-evaluation-criterion/assign-vendor-evaluation-criterion.component').then((m) => m.ViewAssignVendorEvaluationCriterionComponent),
  },
  {
    path: 'administration/assign-vendor-evaluation-criterion/new',
    title: 'New Assign Vendor Evaluation Criterion',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./assign-vendor-evaluation-criterion/assign-vendor-evaluation-criterion-form.component').then((m) => m.AssignVendorEvaluationCriterionFormComponent),
  },
  {
    path: 'administration/assign-vendor-evaluation-criterion/:id/edit',
    title: 'Edit Assign Vendor Evaluation Criterion',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./assign-vendor-evaluation-criterion/assign-vendor-evaluation-criterion-form.component').then((m) => m.AssignVendorEvaluationCriterionFormComponent),
  },
  {
    path: 'administration/assign-vendor-specialization',
    title: 'Assign Vendor Specialization',
    loadComponent: () =>
      import('./assign-vendor-specialization/assign-vendor-specialization.component').then((m) => m.ViewAssignVendorSpecializationComponent),
  },
  {
    path: 'administration/assign-vendor-specialization/new',
    title: 'New Assign Vendor Specialization',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./assign-vendor-specialization/assign-vendor-specialization-form.component').then((m) => m.AssignVendorSpecializationFormComponent),
  },
  {
    path: 'administration/assign-vendor-specialization/:id/edit',
    title: 'Edit Assign Vendor Specialization',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./assign-vendor-specialization/assign-vendor-specialization-form.component').then((m) => m.AssignVendorSpecializationFormComponent),
  },
  {
    path: 'administration/classifications',
    title: 'Classifications',
    loadComponent: () =>
      import('./classifications/classifications.component').then((m) => m.ViewClassificationsComponent),
  },
  {
    path: 'administration/classifications/new',
    title: 'New Classifications',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./classifications/classifications-form.component').then((m) => m.ClassificationsFormComponent),
  },
  {
    path: 'administration/classifications/:id/edit',
    title: 'Edit Classifications',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./classifications/classifications-form.component').then((m) => m.ClassificationsFormComponent),
  },
  {
    path: 'administration/company',
    title: 'Company',
    loadComponent: () =>
      import('./company/company.component').then((m) => m.ViewCompanyComponent),
  },
  {
    path: 'administration/company/new',
    title: 'New Company',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./company/company-form.component').then((m) => m.CompanyFormComponent),
  },
  {
    path: 'administration/company/:id/edit',
    title: 'Edit Company',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./company/company-form.component').then((m) => m.CompanyFormComponent),
  },
  {
    path: 'administration/contact',
    title: 'Contact',
    loadComponent: () =>
      import('./contact/contact.component').then((m) => m.ViewContactComponent),
  },
  {
    path: 'administration/contact/new',
    title: 'New Contact',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./contact/contact-form.component').then((m) => m.ContactFormComponent),
  },
  {
    path: 'administration/contact/:id/edit',
    title: 'Edit Contact',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./contact/contact-form.component').then((m) => m.ContactFormComponent),
  },
  {
    path: 'administration/contact-type',
    title: 'Contact Type',
    loadComponent: () =>
      import('./contact-type/contact-type.component').then((m) => m.ViewContactTypeComponent),
  },
  {
    path: 'administration/contact-type/new',
    title: 'New Contact Type',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./contact-type/contact-type-form.component').then((m) => m.ContactTypeFormComponent),
  },
  {
    path: 'administration/contact-type/:id/edit',
    title: 'Edit Contact Type',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./contact-type/contact-type-form.component').then((m) => m.ContactTypeFormComponent),
  },
  {
    path: 'administration/contacts',
    title: 'Contacts',
    loadComponent: () =>
      import('./contacts/contacts.component').then((m) => m.ViewContactsComponent),
  },
  {
    path: 'administration/contacts/new',
    title: 'New Contacts',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./contacts/contacts-form.component').then((m) => m.ContactsFormComponent),
  },
  {
    path: 'administration/contacts/:id/edit',
    title: 'Edit Contacts',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./contacts/contacts-form.component').then((m) => m.ContactsFormComponent),
  },
  {
    path: 'administration/days-of-week',
    title: 'Days Of Week',
    loadComponent: () =>
      import('./days-of-week/days-of-week.component').then((m) => m.ViewDaysOfWeekComponent),
  },
  {
    path: 'administration/days-of-week/new',
    title: 'New Days Of Week',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./days-of-week/days-of-week-form.component').then((m) => m.DaysOfWeekFormComponent),
  },
  {
    path: 'administration/days-of-week/:id/edit',
    title: 'Edit Days Of Week',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./days-of-week/days-of-week-form.component').then((m) => m.DaysOfWeekFormComponent),
  },
  {
    path: 'administration/employee',
    title: 'Employee',
    loadComponent: () =>
      import('./employee/employee.component').then((m) => m.ViewEmployeeComponent),
  },
  {
    path: 'administration/employee/new',
    title: 'New Employee',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./employee/employee-form.component').then((m) => m.EmployeeFormComponent),
  },
  {
    path: 'administration/employee/:id/edit',
    title: 'Edit Employee',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./employee/employee-form.component').then((m) => m.EmployeeFormComponent),
  },
  {
    path: 'administration/employee-job',
    title: 'Employee Job',
    loadComponent: () =>
      import('./employee-job/employee-job.component').then((m) => m.ViewEmployeeJobComponent),
  },
  {
    path: 'administration/employee-job/new',
    title: 'New Employee Job',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./employee-job/employee-job-form.component').then((m) => m.EmployeeJobFormComponent),
  },
  {
    path: 'administration/employee-job/:id/edit',
    title: 'Edit Employee Job',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./employee-job/employee-job-form.component').then((m) => m.EmployeeJobFormComponent),
  },
  {
    path: 'administration/gender',
    title: 'Gender',
    loadComponent: () =>
      import('./gender/gender.component').then((m) => m.ViewGenderComponent),
  },
  {
    path: 'administration/gender/new',
    title: 'New Gender',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./gender/gender-form.component').then((m) => m.GenderFormComponent),
  },
  {
    path: 'administration/gender/:id/edit',
    title: 'Edit Gender',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./gender/gender-form.component').then((m) => m.GenderFormComponent),
  },
  {
    path: 'administration/language',
    title: 'Language',
    loadComponent: () =>
      import('./language/language.component').then((m) => m.ViewLanguageComponent),
  },
  {
    path: 'administration/language/new',
    title: 'New Language',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./language/language-form.component').then((m) => m.LanguageFormComponent),
  },
  {
    path: 'administration/language/:id/edit',
    title: 'Edit Language',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./language/language-form.component').then((m) => m.LanguageFormComponent),
  },
  {
    path: 'administration/module-setting',
    title: 'Module Setting',
    loadComponent: () =>
      import('./module-setting/module-setting.component').then((m) => m.ViewModuleSettingComponent),
  },
  {
    path: 'administration/module-setting/new',
    title: 'New Module Setting',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./module-setting/module-setting-form.component').then((m) => m.ModuleSettingFormComponent),
  },
  {
    path: 'administration/module-setting/:id/edit',
    title: 'Edit Module Setting',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./module-setting/module-setting-form.component').then((m) => m.ModuleSettingFormComponent),
  },
  {
    path: 'administration/notification',
    title: 'Notification',
    loadComponent: () =>
      import('./notification/notification.component').then((m) => m.ViewNotificationComponent),
  },
  {
    path: 'administration/notification/new',
    title: 'New Notification',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./notification/notification-form.component').then((m) => m.NotificationFormComponent),
  },
  {
    path: 'administration/notification/:id/edit',
    title: 'Edit Notification',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./notification/notification-form.component').then((m) => m.NotificationFormComponent),
  },
  {
    path: 'administration/notification-place-holder',
    title: 'Notification Place Holder',
    loadComponent: () =>
      import('./notification-place-holder/notification-place-holder.component').then((m) => m.ViewNotificationPlaceHolderComponent),
  },
  {
    path: 'administration/notification-place-holder/new',
    title: 'New Notification Place Holder',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./notification-place-holder/notification-place-holder-form.component').then((m) => m.NotificationPlaceHolderFormComponent),
  },
  {
    path: 'administration/notification-place-holder/:id/edit',
    title: 'Edit Notification Place Holder',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./notification-place-holder/notification-place-holder-form.component').then((m) => m.NotificationPlaceHolderFormComponent),
  },
  {
    path: 'administration/notification-state',
    title: 'Notification State',
    loadComponent: () =>
      import('./notification-state/notification-state.component').then((m) => m.ViewNotificationStateComponent),
  },
  {
    path: 'administration/notification-state/new',
    title: 'New Notification State',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./notification-state/notification-state-form.component').then((m) => m.NotificationStateFormComponent),
  },
  {
    path: 'administration/notification-state/:id/edit',
    title: 'Edit Notification State',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./notification-state/notification-state-form.component').then((m) => m.NotificationStateFormComponent),
  },
  {
    path: 'administration/notification-template',
    title: 'Notification Template',
    loadComponent: () =>
      import('./notification-template/notification-template.component').then((m) => m.ViewNotificationTemplateComponent),
  },
  {
    path: 'administration/notification-template/new',
    title: 'New Notification Template',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./notification-template/notification-template-form.component').then((m) => m.NotificationTemplateFormComponent),
  },
  {
    path: 'administration/notification-template/:id/edit',
    title: 'Edit Notification Template',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./notification-template/notification-template-form.component').then((m) => m.NotificationTemplateFormComponent),
  },
  {
    path: 'administration/notification-template-contact',
    title: 'Notification Template Contact',
    loadComponent: () =>
      import('./notification-template-contact/notification-template-contact.component').then((m) => m.ViewNotificationTemplateContactComponent),
  },
  {
    path: 'administration/notification-template-contact/new',
    title: 'New Notification Template Contact',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./notification-template-contact/notification-template-contact-form.component').then((m) => m.NotificationTemplateContactFormComponent),
  },
  {
    path: 'administration/notification-template-contact/:id/edit',
    title: 'Edit Notification Template Contact',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./notification-template-contact/notification-template-contact-form.component').then((m) => m.NotificationTemplateContactFormComponent),
  },
  {
    path: 'administration/notification-type',
    title: 'Notification Type',
    loadComponent: () =>
      import('./notification-type/notification-type.component').then((m) => m.ViewNotificationTypeComponent),
  },
  {
    path: 'administration/notification-type/new',
    title: 'New Notification Type',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./notification-type/notification-type-form.component').then((m) => m.NotificationTypeFormComponent),
  },
  {
    path: 'administration/notification-type/:id/edit',
    title: 'Edit Notification Type',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./notification-type/notification-type-form.component').then((m) => m.NotificationTypeFormComponent),
  },
  {
    path: 'administration/ou',
    title: 'Ou',
    loadComponent: () =>
      import('./ou/ou.component').then((m) => m.ViewOuComponent),
  },
  {
    path: 'administration/ou/new',
    title: 'New Ou',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./ou/ou-form.component').then((m) => m.OuFormComponent),
  },
  {
    path: 'administration/ou/:id/edit',
    title: 'Edit Ou',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./ou/ou-form.component').then((m) => m.OuFormComponent),
  },
  {
    path: 'administration/pdaassignment',
    title: 'Pdaassignment',
    loadComponent: () =>
      import('./pdaassignment/pdaassignment.component').then((m) => m.ViewPdaassignmentComponent),
  },
  {
    path: 'administration/pdaassignment/new',
    title: 'New Pdaassignment',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./pdaassignment/pdaassignment-form.component').then((m) => m.PdaassignmentFormComponent),
  },
  {
    path: 'administration/pdaassignment/:id/edit',
    title: 'Edit Pdaassignment',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./pdaassignment/pdaassignment-form.component').then((m) => m.PdaassignmentFormComponent),
  },
  {
    path: 'administration/pdadetail',
    title: 'Pdadetail',
    loadComponent: () =>
      import('./pdadetail/pdadetail.component').then((m) => m.ViewPdadetailComponent),
  },
  {
    path: 'administration/pdadetail/new',
    title: 'New Pdadetail',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./pdadetail/pdadetail-form.component').then((m) => m.PdadetailFormComponent),
  },
  {
    path: 'administration/pdadetail/:id/edit',
    title: 'Edit Pdadetail',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./pdadetail/pdadetail-form.component').then((m) => m.PdadetailFormComponent),
  },
  {
    path: 'administration/pdamodel',
    title: 'Pdamodel',
    loadComponent: () =>
      import('./pdamodel/pdamodel.component').then((m) => m.ViewPdamodelComponent),
  },
  {
    path: 'administration/pdamodel/new',
    title: 'New Pdamodel',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./pdamodel/pdamodel-form.component').then((m) => m.PdamodelFormComponent),
  },
  {
    path: 'administration/pdamodel/:id/edit',
    title: 'Edit Pdamodel',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./pdamodel/pdamodel-form.component').then((m) => m.PdamodelFormComponent),
  },
  {
    path: 'administration/pdarequests-log',
    title: 'Pdarequests Log',
    loadComponent: () =>
      import('./pdarequests-log/pdarequests-log.component').then((m) => m.ViewPdarequestsLogComponent),
  },
  {
    path: 'administration/pdarequests-log/new',
    title: 'New Pdarequests Log',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./pdarequests-log/pdarequests-log-form.component').then((m) => m.PdarequestsLogFormComponent),
  },
  {
    path: 'administration/pdarequests-log/:id/edit',
    title: 'Edit Pdarequests Log',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./pdarequests-log/pdarequests-log-form.component').then((m) => m.PdarequestsLogFormComponent),
  },
  {
    path: 'administration/pruser',
    title: 'Pruser',
    loadComponent: () =>
      import('./pruser/pruser.component').then((m) => m.ViewPruserComponent),
  },
  {
    path: 'administration/pruser/new',
    title: 'New Pruser',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./pruser/pruser-form.component').then((m) => m.PruserFormComponent),
  },
  {
    path: 'administration/pruser/:id/edit',
    title: 'Edit Pruser',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./pruser/pruser-form.component').then((m) => m.PruserFormComponent),
  },
  {
    path: 'administration/rank',
    title: 'Rank',
    loadComponent: () =>
      import('./rank/rank.component').then((m) => m.ViewRankComponent),
  },
  {
    path: 'administration/rank/new',
    title: 'New Rank',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./rank/rank-form.component').then((m) => m.RankFormComponent),
  },
  {
    path: 'administration/rank/:id/edit',
    title: 'Edit Rank',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./rank/rank-form.component').then((m) => m.RankFormComponent),
  },
  {
    path: 'administration/scope',
    title: 'Scope',
    loadComponent: () =>
      import('./scope/scope.component').then((m) => m.ViewScopeComponent),
  },
  {
    path: 'administration/scope/new',
    title: 'New Scope',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./scope/scope-form.component').then((m) => m.ScopeFormComponent),
  },
  {
    path: 'administration/scope/:id/edit',
    title: 'Edit Scope',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./scope/scope-form.component').then((m) => m.ScopeFormComponent),
  },
  {
    path: 'administration/sec-configuration',
    title: 'Sec Configuration',
    loadComponent: () =>
      import('./sec-configuration/sec-configuration.component').then((m) => m.ViewSecConfigurationComponent),
  },
  {
    path: 'administration/sec-configuration/new',
    title: 'New Sec Configuration',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./sec-configuration/sec-configuration-form.component').then((m) => m.SecConfigurationFormComponent),
  },
  {
    path: 'administration/sec-configuration/:id/edit',
    title: 'Edit Sec Configuration',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./sec-configuration/sec-configuration-form.component').then((m) => m.SecConfigurationFormComponent),
  },
  {
    path: 'administration/sec-model',
    title: 'Sec Model',
    loadComponent: () =>
      import('./sec-model/sec-model.component').then((m) => m.ViewSecModelComponent),
  },
  {
    path: 'administration/sec-model/new',
    title: 'New Sec Model',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./sec-model/sec-model-form.component').then((m) => m.SecModelFormComponent),
  },
  {
    path: 'administration/sec-model/:id/edit',
    title: 'Edit Sec Model',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./sec-model/sec-model-form.component').then((m) => m.SecModelFormComponent),
  },
  {
    path: 'administration/sec-model-attribute',
    title: 'Sec Model Attribute',
    loadComponent: () =>
      import('./sec-model-attribute/sec-model-attribute.component').then((m) => m.ViewSecModelAttributeComponent),
  },
  {
    path: 'administration/sec-model-attribute/new',
    title: 'New Sec Model Attribute',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./sec-model-attribute/sec-model-attribute-form.component').then((m) => m.SecModelAttributeFormComponent),
  },
  {
    path: 'administration/sec-model-attribute/:id/edit',
    title: 'Edit Sec Model Attribute',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./sec-model-attribute/sec-model-attribute-form.component').then((m) => m.SecModelAttributeFormComponent),
  },
  {
    path: 'administration/sec-module',
    title: 'Sec Module',
    loadComponent: () =>
      import('./sec-module/sec-module.component').then((m) => m.ViewSecModuleComponent),
  },
  {
    path: 'administration/sec-module/new',
    title: 'New Sec Module',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./sec-module/sec-module-form.component').then((m) => m.SecModuleFormComponent),
  },
  {
    path: 'administration/sec-module/:id/edit',
    title: 'Edit Sec Module',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./sec-module/sec-module-form.component').then((m) => m.SecModuleFormComponent),
  },
  {
    path: 'administration/sec-property',
    title: 'Sec Property',
    loadComponent: () =>
      import('./sec-property/sec-property.component').then((m) => m.ViewSecPropertyComponent),
  },
  {
    path: 'administration/sec-property/new',
    title: 'New Sec Property',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./sec-property/sec-property-form.component').then((m) => m.SecPropertyFormComponent),
  },
  {
    path: 'administration/sec-property/:id/edit',
    title: 'Edit Sec Property',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./sec-property/sec-property-form.component').then((m) => m.SecPropertyFormComponent),
  },
  {
    path: 'administration/sec-role',
    title: 'Sec Role',
    loadComponent: () =>
      import('./sec-role/sec-role.component').then((m) => m.ViewSecRoleComponent),
  },
  {
    path: 'administration/sec-role/new',
    title: 'New Sec Role',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./sec-role/sec-role-form.component').then((m) => m.SecRoleFormComponent),
  },
  {
    path: 'administration/sec-role/:id/edit',
    title: 'Edit Sec Role',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./sec-role/sec-role-form.component').then((m) => m.SecRoleFormComponent),
  },
  {
    path: 'administration/sec-role-model-attribute',
    title: 'Sec Role Model Attribute',
    loadComponent: () =>
      import('./sec-role-model-attribute/sec-role-model-attribute.component').then((m) => m.ViewSecRoleModelAttributeComponent),
  },
  {
    path: 'administration/sec-role-model-attribute/new',
    title: 'New Sec Role Model Attribute',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./sec-role-model-attribute/sec-role-model-attribute-form.component').then((m) => m.SecRoleModelAttributeFormComponent),
  },
  {
    path: 'administration/sec-role-model-attribute/:id/edit',
    title: 'Edit Sec Role Model Attribute',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./sec-role-model-attribute/sec-role-model-attribute-form.component').then((m) => m.SecRoleModelAttributeFormComponent),
  },
  {
    path: 'administration/sec-role-module',
    title: 'Sec Role Module',
    loadComponent: () =>
      import('./sec-role-module/sec-role-module.component').then((m) => m.ViewSecRoleModuleComponent),
  },
  {
    path: 'administration/sec-role-module/new',
    title: 'New Sec Role Module',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./sec-role-module/sec-role-module-form.component').then((m) => m.SecRoleModuleFormComponent),
  },
  {
    path: 'administration/sec-role-module/:id/edit',
    title: 'Edit Sec Role Module',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./sec-role-module/sec-role-module-form.component').then((m) => m.SecRoleModuleFormComponent),
  },
  {
    path: 'administration/sec-role-property',
    title: 'Sec Role Property',
    loadComponent: () =>
      import('./sec-role-property/sec-role-property.component').then((m) => m.ViewSecRolePropertyComponent),
  },
  {
    path: 'administration/sec-role-property/new',
    title: 'New Sec Role Property',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./sec-role-property/sec-role-property-form.component').then((m) => m.SecRolePropertyFormComponent),
  },
  {
    path: 'administration/sec-role-property/:id/edit',
    title: 'Edit Sec Role Property',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./sec-role-property/sec-role-property-form.component').then((m) => m.SecRolePropertyFormComponent),
  },
  {
    path: 'administration/sec-role-securable-value',
    title: 'Sec Role Securable Value',
    loadComponent: () =>
      import('./sec-role-securable-value/sec-role-securable-value.component').then((m) => m.ViewSecRoleSecurableValueComponent),
  },
  {
    path: 'administration/sec-role-securable-value/new',
    title: 'New Sec Role Securable Value',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./sec-role-securable-value/sec-role-securable-value-form.component').then((m) => m.SecRoleSecurableValueFormComponent),
  },
  {
    path: 'administration/sec-role-securable-value/:id/edit',
    title: 'Edit Sec Role Securable Value',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./sec-role-securable-value/sec-role-securable-value-form.component').then((m) => m.SecRoleSecurableValueFormComponent),
  },
  {
    path: 'administration/sec-role-view-action',
    title: 'Sec Role View Action',
    loadComponent: () =>
      import('./sec-role-view-action/sec-role-view-action.component').then((m) => m.ViewSecRoleViewActionComponent),
  },
  {
    path: 'administration/sec-role-view-action/new',
    title: 'New Sec Role View Action',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./sec-role-view-action/sec-role-view-action-form.component').then((m) => m.SecRoleViewActionFormComponent),
  },
  {
    path: 'administration/sec-role-view-action/:id/edit',
    title: 'Edit Sec Role View Action',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./sec-role-view-action/sec-role-view-action-form.component').then((m) => m.SecRoleViewActionFormComponent),
  },
  {
    path: 'administration/sec-user-model-atrribute',
    title: 'Sec User Model Atrribute',
    loadComponent: () =>
      import('./sec-user-model-atrribute/sec-user-model-atrribute.component').then((m) => m.ViewSecUserModelAtrributeComponent),
  },
  {
    path: 'administration/sec-user-model-atrribute/new',
    title: 'New Sec User Model Atrribute',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./sec-user-model-atrribute/sec-user-model-atrribute-form.component').then((m) => m.SecUserModelAtrributeFormComponent),
  },
  {
    path: 'administration/sec-user-model-atrribute/:id/edit',
    title: 'Edit Sec User Model Atrribute',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./sec-user-model-atrribute/sec-user-model-atrribute-form.component').then((m) => m.SecUserModelAtrributeFormComponent),
  },
  {
    path: 'administration/sec-user-module',
    title: 'Sec User Module',
    loadComponent: () =>
      import('./sec-user-module/sec-user-module.component').then((m) => m.ViewSecUserModuleComponent),
  },
  {
    path: 'administration/sec-user-module/new',
    title: 'New Sec User Module',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./sec-user-module/sec-user-module-form.component').then((m) => m.SecUserModuleFormComponent),
  },
  {
    path: 'administration/sec-user-module/:id/edit',
    title: 'Edit Sec User Module',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./sec-user-module/sec-user-module-form.component').then((m) => m.SecUserModuleFormComponent),
  },
  {
    path: 'administration/sec-user-property',
    title: 'Sec User Property',
    loadComponent: () =>
      import('./sec-user-property/sec-user-property.component').then((m) => m.ViewSecUserPropertyComponent),
  },
  {
    path: 'administration/sec-user-property/new',
    title: 'New Sec User Property',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./sec-user-property/sec-user-property-form.component').then((m) => m.SecUserPropertyFormComponent),
  },
  {
    path: 'administration/sec-user-property/:id/edit',
    title: 'Edit Sec User Property',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./sec-user-property/sec-user-property-form.component').then((m) => m.SecUserPropertyFormComponent),
  },
  {
    path: 'administration/sec-user-securable-value',
    title: 'Sec User Securable Value',
    loadComponent: () =>
      import('./sec-user-securable-value/sec-user-securable-value.component').then((m) => m.ViewSecUserSecurableValueComponent),
  },
  {
    path: 'administration/sec-user-securable-value/new',
    title: 'New Sec User Securable Value',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./sec-user-securable-value/sec-user-securable-value-form.component').then((m) => m.SecUserSecurableValueFormComponent),
  },
  {
    path: 'administration/sec-user-securable-value/:id/edit',
    title: 'Edit Sec User Securable Value',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./sec-user-securable-value/sec-user-securable-value-form.component').then((m) => m.SecUserSecurableValueFormComponent),
  },
  {
    path: 'administration/sec-user-view-action',
    title: 'Sec User View Action',
    loadComponent: () =>
      import('./sec-user-view-action/sec-user-view-action.component').then((m) => m.ViewSecUserViewActionComponent),
  },
  {
    path: 'administration/sec-user-view-action/new',
    title: 'New Sec User View Action',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./sec-user-view-action/sec-user-view-action-form.component').then((m) => m.SecUserViewActionFormComponent),
  },
  {
    path: 'administration/sec-user-view-action/:id/edit',
    title: 'Edit Sec User View Action',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./sec-user-view-action/sec-user-view-action-form.component').then((m) => m.SecUserViewActionFormComponent),
  },
  {
    path: 'administration/sec-view',
    title: 'Sec View',
    loadComponent: () =>
      import('./sec-view/sec-view.component').then((m) => m.ViewSecViewComponent),
  },
  {
    path: 'administration/sec-view/new',
    title: 'New Sec View',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./sec-view/sec-view-form.component').then((m) => m.SecViewFormComponent),
  },
  {
    path: 'administration/sec-view/:id/edit',
    title: 'Edit Sec View',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./sec-view/sec-view-form.component').then((m) => m.SecViewFormComponent),
  },
  {
    path: 'administration/sec-view-action',
    title: 'Sec View Action',
    loadComponent: () =>
      import('./sec-view-action/sec-view-action.component').then((m) => m.ViewSecViewActionComponent),
  },
  {
    path: 'administration/sec-view-action/new',
    title: 'New Sec View Action',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./sec-view-action/sec-view-action-form.component').then((m) => m.SecViewActionFormComponent),
  },
  {
    path: 'administration/sec-view-action/:id/edit',
    title: 'Edit Sec View Action',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./sec-view-action/sec-view-action-form.component').then((m) => m.SecViewActionFormComponent),
  },
  {
    path: 'administration/sitemap',
    title: 'Sitemap',
    loadComponent: () =>
      import('./sitemap/sitemap.component').then((m) => m.ViewSitemapComponent),
  },
  {
    path: 'administration/sitemap/new',
    title: 'New Sitemap',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./sitemap/sitemap-form.component').then((m) => m.SitemapFormComponent),
  },
  {
    path: 'administration/sitemap/:id/edit',
    title: 'Edit Sitemap',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./sitemap/sitemap-form.component').then((m) => m.SitemapFormComponent),
  },
  {
    path: 'administration/sys-key-value',
    title: 'Sys Key Value',
    loadComponent: () =>
      import('./sys-key-value/sys-key-value.component').then((m) => m.ViewSysKeyValueComponent),
  },
  {
    path: 'administration/sys-key-value/new',
    title: 'New Sys Key Value',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./sys-key-value/sys-key-value-form.component').then((m) => m.SysKeyValueFormComponent),
  },
  {
    path: 'administration/sys-key-value/:id/edit',
    title: 'Edit Sys Key Value',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./sys-key-value/sys-key-value-form.component').then((m) => m.SysKeyValueFormComponent),
  },
  {
    path: 'administration/user',
    title: 'User',
    loadComponent: () =>
      import('./user/user.component').then((m) => m.ViewUserComponent),
  },
  {
    path: 'administration/user/new',
    title: 'New User',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./user/user-form.component').then((m) => m.UserFormComponent),
  },
  {
    path: 'administration/user/:id/edit',
    title: 'Edit User',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./user/user-form.component').then((m) => m.UserFormComponent),
  },
];
