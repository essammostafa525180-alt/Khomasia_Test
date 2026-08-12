import { Routes } from '@angular/router';

// Auto-generated routes for the 44 Other pages.
// Regenerate with:  node generate-crud-routes.js

export const otherRoutes: Routes = [
  {
    path: 'other/air-filter-type',
    title: 'Air Filter Type',
    loadComponent: () =>
      import('./air-filter-type/air-filter-type.component').then((m) => m.ViewAirFilterTypeComponent),
  },
  {
    path: 'other/air-filter-type/new',
    title: 'New Air Filter Type',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./air-filter-type/air-filter-type-form.component').then((m) => m.AirFilterTypeFormComponent),
  },
  {
    path: 'other/air-filter-type/:id/edit',
    title: 'Edit Air Filter Type',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./air-filter-type/air-filter-type-form.component').then((m) => m.AirFilterTypeFormComponent),
  },
  
  {
    path: 'other/battery-type',
    title: 'Battery Type',
    loadComponent: () =>
      import('./battery-type/battery-type.component').then((m) => m.ViewBatteryTypeComponent),
  },
  {
    path: 'other/battery-type/new',
    title: 'New Battery Type',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./battery-type/battery-type-form.component').then((m) => m.BatteryTypeFormComponent),
  },
  {
    path: 'other/battery-type/:id/edit',
    title: 'Edit Battery Type',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./battery-type/battery-type-form.component').then((m) => m.BatteryTypeFormComponent),
  },
  {
    path: 'other/commission-condition',
    title: 'Commission Condition',
    loadComponent: () =>
      import('./commission-condition/commission-condition.component').then((m) => m.ViewCommissionConditionComponent),
  },
  {
    path: 'other/commission-condition/new',
    title: 'New Commission Condition',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./commission-condition/commission-condition-form.component').then((m) => m.CommissionConditionFormComponent),
  },
  {
    path: 'other/commission-condition/:id/edit',
    title: 'Edit Commission Condition',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./commission-condition/commission-condition-form.component').then((m) => m.CommissionConditionFormComponent),
  },
  {
    path: 'other/cost-center',
    title: 'Cost Center',
    loadComponent: () =>
      import('./cost-center/cost-center.component').then((m) => m.ViewCostCenterComponent),
  },
  {
    path: 'other/cost-center/new',
    title: 'New Cost Center',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./cost-center/cost-center-form.component').then((m) => m.CostCenterFormComponent),
  },
  {
    path: 'other/cost-center/:id/edit',
    title: 'Edit Cost Center',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./cost-center/cost-center-form.component').then((m) => m.CostCenterFormComponent),
  },
  {
    path: 'other/customer',
    title: 'Customer',
    loadComponent: () =>
      import('./customer/customer.component').then((m) => m.ViewCustomerComponent),
  },
  {
    path: 'other/customer/new',
    title: 'New Customer',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./customer/customer-form.component').then((m) => m.CustomerFormComponent),
  },
  {
    path: 'other/customer/:id/edit',
    title: 'Edit Customer',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./customer/customer-form.component').then((m) => m.CustomerFormComponent),
  },
  {
    path: 'other/engine-size',
    title: 'Engine Size',
    loadComponent: () =>
      import('./engine-size/engine-size.component').then((m) => m.ViewEngineSizeComponent),
  },
  {
    path: 'other/engine-size/new',
    title: 'New Engine Size',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./engine-size/engine-size-form.component').then((m) => m.EngineSizeFormComponent),
  },
  {
    path: 'other/engine-size/:id/edit',
    title: 'Edit Engine Size',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./engine-size/engine-size-form.component').then((m) => m.EngineSizeFormComponent),
  },
  {
    path: 'other/expense',
    title: 'Expense',
    loadComponent: () =>
      import('./expense/expense.component').then((m) => m.ViewExpenseComponent),
  },
  {
    path: 'other/expense/new',
    title: 'New Expense',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./expense/expense-form.component').then((m) => m.ExpenseFormComponent),
  },
  {
    path: 'other/expense/:id/edit',
    title: 'Edit Expense',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./expense/expense-form.component').then((m) => m.ExpenseFormComponent),
  },
  {
    path: 'other/factory',
    title: 'Factory',
    loadComponent: () =>
      import('./factory/factory.component').then((m) => m.ViewFactoryComponent),
  },
  {
    path: 'other/factory/new',
    title: 'New Factory',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./factory/factory-form.component').then((m) => m.FactoryFormComponent),
  },
  {
    path: 'other/factory/:id/edit',
    title: 'Edit Factory',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./factory/factory-form.component').then((m) => m.FactoryFormComponent),
  },
  {
    path: 'other/factory-line',
    title: 'Factory Line',
    loadComponent: () =>
      import('./factory-line/factory-line.component').then((m) => m.ViewFactoryLineComponent),
  },
  {
    path: 'other/factory-line/new',
    title: 'New Factory Line',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./factory-line/factory-line-form.component').then((m) => m.FactoryLineFormComponent),
  },
  {
    path: 'other/factory-line/:id/edit',
    title: 'Edit Factory Line',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./factory-line/factory-line-form.component').then((m) => m.FactoryLineFormComponent),
  },
  {
    path: 'other/line',
    title: 'Line',
    loadComponent: () =>
      import('./line/line.component').then((m) => m.ViewLineComponent),
  },
  {
    path: 'other/line/new',
    title: 'New Line',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./line/line-form.component').then((m) => m.LineFormComponent),
  },
  {
    path: 'other/line/:id/edit',
    title: 'Edit Line',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./line/line-form.component').then((m) => m.LineFormComponent),
  },
  {
    path: 'other/narrators',
    title: 'Narrators',
    loadComponent: () =>
      import('./narrators/narrators.component').then((m) => m.ViewNarratorsComponent),
  },
  {
    path: 'other/narrators/new',
    title: 'New Narrators',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./narrators/narrators-form.component').then((m) => m.NarratorsFormComponent),
  },
  {
    path: 'other/narrators/:id/edit',
    title: 'Edit Narrators',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./narrators/narrators-form.component').then((m) => m.NarratorsFormComponent),
  },
  {
    path: 'other/oil',
    title: 'Oil',
    loadComponent: () =>
      import('./oil/oil.component').then((m) => m.ViewOilComponent),
  },
  {
    path: 'other/oil/new',
    title: 'New Oil',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./oil/oil-form.component').then((m) => m.OilFormComponent),
  },
  {
    path: 'other/oil/:id/edit',
    title: 'Edit Oil',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./oil/oil-form.component').then((m) => m.OilFormComponent),
  },
  {
    path: 'other/ownership',
    title: 'Ownership',
    loadComponent: () =>
      import('./ownership/ownership.component').then((m) => m.ViewOwnershipComponent),
  },
  {
    path: 'other/ownership/new',
    title: 'New Ownership',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./ownership/ownership-form.component').then((m) => m.OwnershipFormComponent),
  },
  {
    path: 'other/ownership/:id/edit',
    title: 'Edit Ownership',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./ownership/ownership-form.component').then((m) => m.OwnershipFormComponent),
  },
  {
    path: 'other/project',
    title: 'Project',
    loadComponent: () =>
      import('./project/project.component').then((m) => m.ViewProjectComponent),
  },
  {
    path: 'other/project/new',
    title: 'New Project',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./project/project-form.component').then((m) => m.ProjectFormComponent),
  },
  {
    path: 'other/project/:id/edit',
    title: 'Edit Project',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./project/project-form.component').then((m) => m.ProjectFormComponent),
  },
  {
    path: 'other/section',
    title: 'Section',
    loadComponent: () =>
      import('./section/section.component').then((m) => m.ViewSectionComponent),
  },
  {
    path: 'other/section/new',
    title: 'New Section',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./section/section-form.component').then((m) => m.SectionFormComponent),
  },
  {
    path: 'other/section/:id/edit',
    title: 'Edit Section',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./section/section-form.component').then((m) => m.SectionFormComponent),
  },
  {
    path: 'other/sector',
    title: 'Sector',
    loadComponent: () =>
      import('./sector/sector.component').then((m) => m.ViewSectorComponent),
  },
  {
    path: 'other/sector/new',
    title: 'New Sector',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./sector/sector-form.component').then((m) => m.SectorFormComponent),
  },
  {
    path: 'other/sector/:id/edit',
    title: 'Edit Sector',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./sector/sector-form.component').then((m) => m.SectorFormComponent),
  },
  {
    path: 'other/service',
    title: 'Service',
    loadComponent: () =>
      import('./service/service.component').then((m) => m.ViewServiceComponent),
  },
  {
    path: 'other/service/new',
    title: 'New Service',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./service/service-form.component').then((m) => m.ServiceFormComponent),
  },
  {
    path: 'other/service/:id/edit',
    title: 'Edit Service',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./service/service-form.component').then((m) => m.ServiceFormComponent),
  },
  {
    path: 'other/service-category',
    title: 'Service Category',
    loadComponent: () =>
      import('./service-category/service-category.component').then((m) => m.ViewServiceCategoryComponent),
  },
  {
    path: 'other/service-category/new',
    title: 'New Service Category',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./service-category/service-category-form.component').then((m) => m.ServiceCategoryFormComponent),
  },
  {
    path: 'other/service-category/:id/edit',
    title: 'Edit Service Category',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./service-category/service-category-form.component').then((m) => m.ServiceCategoryFormComponent),
  },
  {
    path: 'other/service-main-category',
    title: 'Service Main Category',
    loadComponent: () =>
      import('./service-main-category/service-main-category.component').then((m) => m.ViewServiceMainCategoryComponent),
  },
  {
    path: 'other/service-main-category/new',
    title: 'New Service Main Category',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./service-main-category/service-main-category-form.component').then((m) => m.ServiceMainCategoryFormComponent),
  },
  {
    path: 'other/service-main-category/:id/edit',
    title: 'Edit Service Main Category',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./service-main-category/service-main-category-form.component').then((m) => m.ServiceMainCategoryFormComponent),
  },
  {
    path: 'other/service-sub-category',
    title: 'Service Sub Category',
    loadComponent: () =>
      import('./service-sub-category/service-sub-category.component').then((m) => m.ViewServiceSubCategoryComponent),
  },
  {
    path: 'other/service-sub-category/new',
    title: 'New Service Sub Category',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./service-sub-category/service-sub-category-form.component').then((m) => m.ServiceSubCategoryFormComponent),
  },
  {
    path: 'other/service-sub-category/:id/edit',
    title: 'Edit Service Sub Category',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./service-sub-category/service-sub-category-form.component').then((m) => m.ServiceSubCategoryFormComponent),
  },
  {
    path: 'other/service-type',
    title: 'Service Type',
    loadComponent: () =>
      import('./service-type/service-type.component').then((m) => m.ViewServiceTypeComponent),
  },
  {
    path: 'other/service-type/new',
    title: 'New Service Type',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./service-type/service-type-form.component').then((m) => m.ServiceTypeFormComponent),
  },
  {
    path: 'other/service-type/:id/edit',
    title: 'Edit Service Type',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./service-type/service-type-form.component').then((m) => m.ServiceTypeFormComponent),
  },
  {
    path: 'other/state',
    title: 'State',
    loadComponent: () =>
      import('./state/state.component').then((m) => m.ViewStateComponent),
  },
  {
    path: 'other/state/new',
    title: 'New State',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./state/state-form.component').then((m) => m.StateFormComponent),
  },
  {
    path: 'other/state/:id/edit',
    title: 'Edit State',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./state/state-form.component').then((m) => m.StateFormComponent),
  },
  {
    path: 'other/sub-section',
    title: 'Sub Section',
    loadComponent: () =>
      import('./sub-section/sub-section.component').then((m) => m.ViewSubSectionComponent),
  },
  {
    path: 'other/sub-section/new',
    title: 'New Sub Section',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./sub-section/sub-section-form.component').then((m) => m.SubSectionFormComponent),
  },
  {
    path: 'other/sub-section/:id/edit',
    title: 'Edit Sub Section',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./sub-section/sub-section-form.component').then((m) => m.SubSectionFormComponent),
  },
  {
    path: 'other/transmission-type',
    title: 'Transmission Type',
    loadComponent: () =>
      import('./transmission-type/transmission-type.component').then((m) => m.ViewTransmissionTypeComponent),
  },
  {
    path: 'other/transmission-type/new',
    title: 'New Transmission Type',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./transmission-type/transmission-type-form.component').then((m) => m.TransmissionTypeFormComponent),
  },
  {
    path: 'other/transmission-type/:id/edit',
    title: 'Edit Transmission Type',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./transmission-type/transmission-type-form.component').then((m) => m.TransmissionTypeFormComponent),
  },
  {
    path: 'other/vehicle',
    title: 'Vehicle',
    loadComponent: () =>
      import('./vehicle/vehicle.component').then((m) => m.ViewVehicleComponent),
  },
  {
    path: 'other/vehicle/new',
    title: 'New Vehicle',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vehicle/vehicle-form.component').then((m) => m.VehicleFormComponent),
  },
  {
    path: 'other/vehicle/:id/edit',
    title: 'Edit Vehicle',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vehicle/vehicle-form.component').then((m) => m.VehicleFormComponent),
  },
  {
    path: 'other/vehicle-brand',
    title: 'Vehicle Brand',
    loadComponent: () =>
      import('./vehicle-brand/vehicle-brand.component').then((m) => m.ViewVehicleBrandComponent),
  },
  {
    path: 'other/vehicle-brand/new',
    title: 'New Vehicle Brand',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vehicle-brand/vehicle-brand-form.component').then((m) => m.VehicleBrandFormComponent),
  },
  {
    path: 'other/vehicle-brand/:id/edit',
    title: 'Edit Vehicle Brand',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vehicle-brand/vehicle-brand-form.component').then((m) => m.VehicleBrandFormComponent),
  },
  {
    path: 'other/vehicle-color',
    title: 'Vehicle Color',
    loadComponent: () =>
      import('./vehicle-color/vehicle-color.component').then((m) => m.ViewVehicleColorComponent),
  },
  {
    path: 'other/vehicle-color/new',
    title: 'New Vehicle Color',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vehicle-color/vehicle-color-form.component').then((m) => m.VehicleColorFormComponent),
  },
  {
    path: 'other/vehicle-color/:id/edit',
    title: 'Edit Vehicle Color',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vehicle-color/vehicle-color-form.component').then((m) => m.VehicleColorFormComponent),
  },
  {
    path: 'other/vehicle-model',
    title: 'Vehicle Model',
    loadComponent: () =>
      import('./vehicle-model/vehicle-model.component').then((m) => m.ViewVehicleModelComponent),
  },
  {
    path: 'other/vehicle-model/new',
    title: 'New Vehicle Model',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vehicle-model/vehicle-model-form.component').then((m) => m.VehicleModelFormComponent),
  },
  {
    path: 'other/vehicle-model/:id/edit',
    title: 'Edit Vehicle Model',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vehicle-model/vehicle-model-form.component').then((m) => m.VehicleModelFormComponent),
  },
  {
    path: 'other/vehicle-option',
    title: 'Vehicle Option',
    loadComponent: () =>
      import('./vehicle-option/vehicle-option.component').then((m) => m.ViewVehicleOptionComponent),
  },
  {
    path: 'other/vehicle-option/new',
    title: 'New Vehicle Option',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vehicle-option/vehicle-option-form.component').then((m) => m.VehicleOptionFormComponent),
  },
  {
    path: 'other/vehicle-option/:id/edit',
    title: 'Edit Vehicle Option',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vehicle-option/vehicle-option-form.component').then((m) => m.VehicleOptionFormComponent),
  },
  {
    path: 'other/vehicle-status',
    title: 'Vehicle Status',
    loadComponent: () =>
      import('./vehicle-status/vehicle-status.component').then((m) => m.ViewVehicleStatusComponent),
  },
  {
    path: 'other/vehicle-status/new',
    title: 'New Vehicle Status',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vehicle-status/vehicle-status-form.component').then((m) => m.VehicleStatusFormComponent),
  },
  {
    path: 'other/vehicle-status/:id/edit',
    title: 'Edit Vehicle Status',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vehicle-status/vehicle-status-form.component').then((m) => m.VehicleStatusFormComponent),
  },
  {
    path: 'other/vehicle-type',
    title: 'Vehicle Type',
    loadComponent: () =>
      import('./vehicle-type/vehicle-type.component').then((m) => m.ViewVehicleTypeComponent),
  },
  {
    path: 'other/vehicle-type/new',
    title: 'New Vehicle Type',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./vehicle-type/vehicle-type-form.component').then((m) => m.VehicleTypeFormComponent),
  },
  {
    path: 'other/vehicle-type/:id/edit',
    title: 'Edit Vehicle Type',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./vehicle-type/vehicle-type-form.component').then((m) => m.VehicleTypeFormComponent),
  },
  {
    path: 'other/view-request-status',
    title: 'View Request Status',
    loadComponent: () =>
      import('./view-request-status/view-request-status.component').then((m) => m.ViewViewRequestStatusComponent),
  },
  {
    path: 'other/view-request-status/new',
    title: 'New View Request Status',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./view-request-status/view-request-status-form.component').then((m) => m.ViewRequestStatusFormComponent),
  },
  {
    path: 'other/view-request-status/:id/edit',
    title: 'Edit View Request Status',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./view-request-status/view-request-status-form.component').then((m) => m.ViewRequestStatusFormComponent),
  },
  {
    path: 'other/visit',
    title: 'Visit',
    loadComponent: () =>
      import('./visit/visit.component').then((m) => m.ViewVisitComponent),
  },
  {
    path: 'other/visit/new',
    title: 'New Visit',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./visit/visit-form.component').then((m) => m.VisitFormComponent),
  },
  {
    path: 'other/visit/:id/edit',
    title: 'Edit Visit',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./visit/visit-form.component').then((m) => m.VisitFormComponent),
  },
  {
    path: 'other/worker-type',
    title: 'Worker Type',
    loadComponent: () =>
      import('./worker-type/worker-type.component').then((m) => m.ViewWorkerTypeComponent),
  },
  {
    path: 'other/worker-type/new',
    title: 'New Worker Type',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./worker-type/worker-type-form.component').then((m) => m.WorkerTypeFormComponent),
  },
  {
    path: 'other/worker-type/:id/edit',
    title: 'Edit Worker Type',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./worker-type/worker-type-form.component').then((m) => m.WorkerTypeFormComponent),
  },
  {
    path: 'other/ws-last-sync-table',
    title: 'Ws Last Sync Table',
    loadComponent: () =>
      import('./ws-last-sync-table/ws-last-sync-table.component').then((m) => m.ViewWsLastSyncTableComponent),
  },
  {
    path: 'other/ws-last-sync-table/new',
    title: 'New Ws Last Sync Table',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./ws-last-sync-table/ws-last-sync-table-form.component').then((m) => m.WsLastSyncTableFormComponent),
  },
  {
    path: 'other/ws-last-sync-table/:id/edit',
    title: 'Edit Ws Last Sync Table',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./ws-last-sync-table/ws-last-sync-table-form.component').then((m) => m.WsLastSyncTableFormComponent),
  },
  {
    path: 'other/zone',
    title: 'Zone',
    loadComponent: () =>
      import('./zone/zone.component').then((m) => m.ViewZoneComponent),
  },
  {
    path: 'other/zone/new',
    title: 'New Zone',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./zone/zone-form.component').then((m) => m.ZoneFormComponent),
  },
  {
    path: 'other/zone/:id/edit',
    title: 'Edit Zone',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./zone/zone-form.component').then((m) => m.ZoneFormComponent),
  },
  {
    path: 'other/zone-status',
    title: 'Zone Status',
    loadComponent: () =>
      import('./zone-status/zone-status.component').then((m) => m.ViewZoneStatusComponent),
  },
  {
    path: 'other/zone-status/new',
    title: 'New Zone Status',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./zone-status/zone-status-form.component').then((m) => m.ZoneStatusFormComponent),
  },
  {
    path: 'other/zone-status/:id/edit',
    title: 'Edit Zone Status',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./zone-status/zone-status-form.component').then((m) => m.ZoneStatusFormComponent),
  },
];
