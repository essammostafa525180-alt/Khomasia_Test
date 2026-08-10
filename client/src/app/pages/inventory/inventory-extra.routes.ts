import { Routes } from '@angular/router';

// Auto-generated routes for the 108 inventory pages.
// Regenerate with:  node generate-crud-routes.js

export const inventoryExtraRoutes: Routes = [
  {
    path: 'inventory/annual-stock-count',
    title: 'Annual Stock Count',
    loadComponent: () =>
      import('./annual-stock-count/annual-stock-count.component').then((m) => m.ViewAnnualStockCountComponent),
  },
  {
    path: 'inventory/annual-stock-count/new',
    title: 'New Annual Stock Count',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./annual-stock-count/annual-stock-count-form.component').then((m) => m.AnnualStockCountFormComponent),
  },
  {
    path: 'inventory/annual-stock-count/:id/edit',
    title: 'Edit Annual Stock Count',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./annual-stock-count/annual-stock-count-form.component').then((m) => m.AnnualStockCountFormComponent),
  },
  {
    path: 'inventory/annual-stock-count-item-merge',
    title: 'Annual Stock Count Item Merge',
    loadComponent: () =>
      import('./annual-stock-count-item-merge/annual-stock-count-item-merge.component').then((m) => m.ViewAnnualStockCountItemMergeComponent),
  },
  {
    path: 'inventory/annual-stock-count-item-merge/new',
    title: 'New Annual Stock Count Item Merge',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./annual-stock-count-item-merge/annual-stock-count-item-merge-form.component').then((m) => m.AnnualStockCountItemMergeFormComponent),
  },
  {
    path: 'inventory/annual-stock-count-item-merge/:id/edit',
    title: 'Edit Annual Stock Count Item Merge',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./annual-stock-count-item-merge/annual-stock-count-item-merge-form.component').then((m) => m.AnnualStockCountItemMergeFormComponent),
  },
  {
    path: 'inventory/annual-stock-count-item-quantity',
    title: 'Annual Stock Count Item Quantity',
    loadComponent: () =>
      import('./annual-stock-count-item-quantity/annual-stock-count-item-quantity.component').then((m) => m.ViewAnnualStockCountItemQuantityComponent),
  },
  {
    path: 'inventory/annual-stock-count-item-quantity/new',
    title: 'New Annual Stock Count Item Quantity',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./annual-stock-count-item-quantity/annual-stock-count-item-quantity-form.component').then((m) => m.AnnualStockCountItemQuantityFormComponent),
  },
  {
    path: 'inventory/annual-stock-count-item-quantity/:id/edit',
    title: 'Edit Annual Stock Count Item Quantity',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./annual-stock-count-item-quantity/annual-stock-count-item-quantity-form.component').then((m) => m.AnnualStockCountItemQuantityFormComponent),
  },
  {
    path: 'inventory/asset',
    title: 'Asset',
    loadComponent: () =>
      import('./asset/asset.component').then((m) => m.ViewAssetComponent),
  },
  {
    path: 'inventory/asset/new',
    title: 'New Asset',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./asset/asset-form.component').then((m) => m.AssetEntityFormComponent),
  },
  {
    path: 'inventory/asset/:id/edit',
    title: 'Edit Asset',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./asset/asset-form.component').then((m) => m.AssetEntityFormComponent),
  },
  {
    path: 'inventory/asset-attachment',
    title: 'Asset Attachment',
    loadComponent: () =>
      import('./asset-attachment/asset-attachment.component').then((m) => m.ViewAssetAttachmentComponent),
  },
  {
    path: 'inventory/asset-attachment/new',
    title: 'New Asset Attachment',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./asset-attachment/asset-attachment-form.component').then((m) => m.AssetAttachmentFormComponent),
  },
  {
    path: 'inventory/asset-attachment/:id/edit',
    title: 'Edit Asset Attachment',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./asset-attachment/asset-attachment-form.component').then((m) => m.AssetAttachmentFormComponent),
  },
  {
    path: 'inventory/asset-commissioning',
    title: 'Asset Commissioning',
    loadComponent: () =>
      import('./asset-commissioning/asset-commissioning.component').then((m) => m.ViewAssetCommissioningComponent),
  },
  {
    path: 'inventory/asset-commissioning/new',
    title: 'New Asset Commissioning',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./asset-commissioning/asset-commissioning-form.component').then((m) => m.AssetCommissioningFormComponent),
  },
  {
    path: 'inventory/asset-commissioning/:id/edit',
    title: 'Edit Asset Commissioning',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./asset-commissioning/asset-commissioning-form.component').then((m) => m.AssetCommissioningFormComponent),
  },
  {
    path: 'inventory/asset-compline',
    title: 'Asset Compline',
    loadComponent: () =>
      import('./asset-compline/asset-compline.component').then((m) => m.ViewAssetComplineComponent),
  },
  {
    path: 'inventory/asset-compline/new',
    title: 'New Asset Compline',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./asset-compline/asset-compline-form.component').then((m) => m.AssetComplineFormComponent),
  },
  {
    path: 'inventory/asset-compline/:id/edit',
    title: 'Edit Asset Compline',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./asset-compline/asset-compline-form.component').then((m) => m.AssetComplineFormComponent),
  },
  {
    path: 'inventory/asset-component',
    title: 'Asset Component',
    loadComponent: () =>
      import('./asset-component/asset-component.component').then((m) => m.ViewAssetComponentComponent),
  },
  {
    path: 'inventory/asset-component/new',
    title: 'New Asset Component',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./asset-component/asset-component-form.component').then((m) => m.AssetComponentFormComponent),
  },
  {
    path: 'inventory/asset-component/:id/edit',
    title: 'Edit Asset Component',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./asset-component/asset-component-form.component').then((m) => m.AssetComponentFormComponent),
  },
  {
    path: 'inventory/asset-count',
    title: 'Asset Count',
    loadComponent: () =>
      import('./asset-count/asset-count.component').then((m) => m.ViewAssetCountComponent),
  },
  {
    path: 'inventory/asset-count/new',
    title: 'New Asset Count',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./asset-count/asset-count-form.component').then((m) => m.AssetCountFormComponent),
  },
  {
    path: 'inventory/asset-count/:id/edit',
    title: 'Edit Asset Count',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./asset-count/asset-count-form.component').then((m) => m.AssetCountFormComponent),
  },
  {
    path: 'inventory/asset-count-detail',
    title: 'Asset Count Detail',
    loadComponent: () =>
      import('./asset-count-detail/asset-count-detail.component').then((m) => m.ViewAssetCountDetailComponent),
  },
  {
    path: 'inventory/asset-count-detail/new',
    title: 'New Asset Count Detail',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./asset-count-detail/asset-count-detail-form.component').then((m) => m.AssetCountDetailFormComponent),
  },
  {
    path: 'inventory/asset-count-detail/:id/edit',
    title: 'Edit Asset Count Detail',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./asset-count-detail/asset-count-detail-form.component').then((m) => m.AssetCountDetailFormComponent),
  },
  {
    path: 'inventory/asset-count-issue',
    title: 'Asset Count Issue',
    loadComponent: () =>
      import('./asset-count-issue/asset-count-issue.component').then((m) => m.ViewAssetCountIssueComponent),
  },
  {
    path: 'inventory/asset-count-issue/new',
    title: 'New Asset Count Issue',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./asset-count-issue/asset-count-issue-form.component').then((m) => m.AssetCountIssueEntityFormComponent),
  },
  {
    path: 'inventory/asset-count-issue/:id/edit',
    title: 'Edit Asset Count Issue',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./asset-count-issue/asset-count-issue-form.component').then((m) => m.AssetCountIssueEntityFormComponent),
  },
  {
    path: 'inventory/asset-count-issue-status',
    title: 'Asset Count Issue Status',
    loadComponent: () =>
      import('./asset-count-issue-status/asset-count-issue-status.component').then((m) => m.ViewAssetCountIssueStatusComponent),
  },
  {
    path: 'inventory/asset-count-issue-status/new',
    title: 'New Asset Count Issue Status',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./asset-count-issue-status/asset-count-issue-status-form.component').then((m) => m.AssetCountIssueStatusFormComponent),
  },
  {
    path: 'inventory/asset-count-issue-status/:id/edit',
    title: 'Edit Asset Count Issue Status',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./asset-count-issue-status/asset-count-issue-status-form.component').then((m) => m.AssetCountIssueStatusFormComponent),
  },
  {
    path: 'inventory/asset-count-plan',
    title: 'Asset Count Plan',
    loadComponent: () =>
      import('./asset-count-plan/asset-count-plan.component').then((m) => m.ViewAssetCountPlanComponent),
  },
  {
    path: 'inventory/asset-count-plan/new',
    title: 'New Asset Count Plan',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./asset-count-plan/asset-count-plan-form.component').then((m) => m.AssetCountPlanFormComponent),
  },
  {
    path: 'inventory/asset-count-plan/:id/edit',
    title: 'Edit Asset Count Plan',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./asset-count-plan/asset-count-plan-form.component').then((m) => m.AssetCountPlanFormComponent),
  },
  {
    path: 'inventory/asset-count-plan-detail',
    title: 'Asset Count Plan Detail',
    loadComponent: () =>
      import('./asset-count-plan-detail/asset-count-plan-detail.component').then((m) => m.ViewAssetCountPlanDetailComponent),
  },
  {
    path: 'inventory/asset-count-plan-detail/new',
    title: 'New Asset Count Plan Detail',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./asset-count-plan-detail/asset-count-plan-detail-form.component').then((m) => m.AssetCountPlanDetailFormComponent),
  },
  {
    path: 'inventory/asset-count-plan-detail/:id/edit',
    title: 'Edit Asset Count Plan Detail',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./asset-count-plan-detail/asset-count-plan-detail-form.component').then((m) => m.AssetCountPlanDetailFormComponent),
  },
  {
    path: 'inventory/asset-count-plan-status',
    title: 'Asset Count Plan Status',
    loadComponent: () =>
      import('./asset-count-plan-status/asset-count-plan-status.component').then((m) => m.ViewAssetCountPlanStatusComponent),
  },
  {
    path: 'inventory/asset-count-plan-status/new',
    title: 'New Asset Count Plan Status',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./asset-count-plan-status/asset-count-plan-status-form.component').then((m) => m.AssetCountPlanStatusFormComponent),
  },
  {
    path: 'inventory/asset-count-plan-status/:id/edit',
    title: 'Edit Asset Count Plan Status',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./asset-count-plan-status/asset-count-plan-status-form.component').then((m) => m.AssetCountPlanStatusFormComponent),
  },
  {
    path: 'inventory/asset-count-plan-type',
    title: 'Asset Count Plan Type',
    loadComponent: () =>
      import('./asset-count-plan-type/asset-count-plan-type.component').then((m) => m.ViewAssetCountPlanTypeComponent),
  },
  {
    path: 'inventory/asset-count-plan-type/new',
    title: 'New Asset Count Plan Type',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./asset-count-plan-type/asset-count-plan-type-form.component').then((m) => m.AssetCountPlanTypeFormComponent),
  },
  {
    path: 'inventory/asset-count-plan-type/:id/edit',
    title: 'Edit Asset Count Plan Type',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./asset-count-plan-type/asset-count-plan-type-form.component').then((m) => m.AssetCountPlanTypeFormComponent),
  },
  {
    path: 'inventory/asset-count-status',
    title: 'Asset Count Status',
    loadComponent: () =>
      import('./asset-count-status/asset-count-status.component').then((m) => m.ViewAssetCountStatusComponent),
  },
  {
    path: 'inventory/asset-count-status/new',
    title: 'New Asset Count Status',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./asset-count-status/asset-count-status-form.component').then((m) => m.AssetCountStatusFormComponent),
  },
  {
    path: 'inventory/asset-count-status/:id/edit',
    title: 'Edit Asset Count Status',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./asset-count-status/asset-count-status-form.component').then((m) => m.AssetCountStatusFormComponent),
  },
  {
    path: 'inventory/asset-disposed',
    title: 'Asset Disposed',
    loadComponent: () =>
      import('./asset-disposed/asset-disposed.component').then((m) => m.ViewAssetDisposedComponent),
  },
  {
    path: 'inventory/asset-disposed/new',
    title: 'New Asset Disposed',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./asset-disposed/asset-disposed-form.component').then((m) => m.AssetDisposedFormComponent),
  },
  {
    path: 'inventory/asset-disposed/:id/edit',
    title: 'Edit Asset Disposed',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./asset-disposed/asset-disposed-form.component').then((m) => m.AssetDisposedFormComponent),
  },
  {
    path: 'inventory/asset-functionality',
    title: 'Asset Functionality',
    loadComponent: () =>
      import('./asset-functionality/asset-functionality.component').then((m) => m.ViewAssetFunctionalityComponent),
  },
  {
    path: 'inventory/asset-functionality/new',
    title: 'New Asset Functionality',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./asset-functionality/asset-functionality-form.component').then((m) => m.AssetFunctionalityFormComponent),
  },
  {
    path: 'inventory/asset-functionality/:id/edit',
    title: 'Edit Asset Functionality',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./asset-functionality/asset-functionality-form.component').then((m) => m.AssetFunctionalityFormComponent),
  },
  {
    path: 'inventory/asset-item',
    title: 'Asset Item',
    loadComponent: () =>
      import('./asset-item/asset-item.component').then((m) => m.ViewAssetItemComponent),
  },
  {
    path: 'inventory/asset-item/new',
    title: 'New Asset Item',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./asset-item/asset-item-form.component').then((m) => m.AssetItemFormComponent),
  },
  {
    path: 'inventory/asset-item/:id/edit',
    title: 'Edit Asset Item',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./asset-item/asset-item-form.component').then((m) => m.AssetItemFormComponent),
  },
  {
    path: 'inventory/asset-item-attachment',
    title: 'Asset Item Attachment',
    loadComponent: () =>
      import('./asset-item-attachment/asset-item-attachment.component').then((m) => m.ViewAssetItemAttachmentComponent),
  },
  {
    path: 'inventory/asset-item-attachment/new',
    title: 'New Asset Item Attachment',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./asset-item-attachment/asset-item-attachment-form.component').then((m) => m.AssetItemAttachmentFormComponent),
  },
  {
    path: 'inventory/asset-item-attachment/:id/edit',
    title: 'Edit Asset Item Attachment',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./asset-item-attachment/asset-item-attachment-form.component').then((m) => m.AssetItemAttachmentFormComponent),
  },
  {
    path: 'inventory/asset-item-maintenance',
    title: 'Asset Item Maintenance',
    loadComponent: () =>
      import('./asset-item-maintenance/asset-item-maintenance.component').then((m) => m.ViewAssetItemMaintenanceComponent),
  },
  {
    path: 'inventory/asset-item-maintenance/new',
    title: 'New Asset Item Maintenance',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./asset-item-maintenance/asset-item-maintenance-form.component').then((m) => m.AssetItemMaintenanceFormComponent),
  },
  {
    path: 'inventory/asset-item-maintenance/:id/edit',
    title: 'Edit Asset Item Maintenance',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./asset-item-maintenance/asset-item-maintenance-form.component').then((m) => m.AssetItemMaintenanceFormComponent),
  },
  {
    path: 'inventory/asset-item-move',
    title: 'Asset Item Move',
    loadComponent: () =>
      import('./asset-item-move/asset-item-move.component').then((m) => m.ViewAssetItemMoveComponent),
  },
  {
    path: 'inventory/asset-item-move/new',
    title: 'New Asset Item Move',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./asset-item-move/asset-item-move-form.component').then((m) => m.AssetItemMoveEntityFormComponent),
  },
  {
    path: 'inventory/asset-item-move/:id/edit',
    title: 'Edit Asset Item Move',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./asset-item-move/asset-item-move-form.component').then((m) => m.AssetItemMoveEntityFormComponent),
  },
  {
    path: 'inventory/asset-item-scrap',
    title: 'Asset Item Scrap',
    loadComponent: () =>
      import('./asset-item-scrap/asset-item-scrap.component').then((m) => m.ViewAssetItemScrapComponent),
  },
  {
    path: 'inventory/asset-item-scrap/new',
    title: 'New Asset Item Scrap',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./asset-item-scrap/asset-item-scrap-form.component').then((m) => m.AssetItemScrapFormComponent),
  },
  {
    path: 'inventory/asset-item-scrap/:id/edit',
    title: 'Edit Asset Item Scrap',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./asset-item-scrap/asset-item-scrap-form.component').then((m) => m.AssetItemScrapFormComponent),
  },
  {
    path: 'inventory/asset-maintenance-status',
    title: 'Asset Maintenance Status',
    loadComponent: () =>
      import('./asset-maintenance-status/asset-maintenance-status.component').then((m) => m.ViewAssetMaintenanceStatusComponent),
  },
  {
    path: 'inventory/asset-maintenance-status/new',
    title: 'New Asset Maintenance Status',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./asset-maintenance-status/asset-maintenance-status-form.component').then((m) => m.AssetMaintenanceStatusFormComponent),
  },
  {
    path: 'inventory/asset-maintenance-status/:id/edit',
    title: 'Edit Asset Maintenance Status',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./asset-maintenance-status/asset-maintenance-status-form.component').then((m) => m.AssetMaintenanceStatusFormComponent),
  },
  {
    path: 'inventory/asset-move-type',
    title: 'Asset Move Type',
    loadComponent: () =>
      import('./asset-move-type/asset-move-type.component').then((m) => m.ViewAssetMoveTypeComponent),
  },
  {
    path: 'inventory/asset-move-type/new',
    title: 'New Asset Move Type',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./asset-move-type/asset-move-type-form.component').then((m) => m.AssetMoveTypeFormComponent),
  },
  {
    path: 'inventory/asset-move-type/:id/edit',
    title: 'Edit Asset Move Type',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./asset-move-type/asset-move-type-form.component').then((m) => m.AssetMoveTypeFormComponent),
  },
  {
    path: 'inventory/asset-scrap-status',
    title: 'Asset Scrap Status',
    loadComponent: () =>
      import('./asset-scrap-status/asset-scrap-status.component').then((m) => m.ViewAssetScrapStatusComponent),
  },
  {
    path: 'inventory/asset-scrap-status/new',
    title: 'New Asset Scrap Status',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./asset-scrap-status/asset-scrap-status-form.component').then((m) => m.AssetScrapStatusFormComponent),
  },
  {
    path: 'inventory/asset-scrap-status/:id/edit',
    title: 'Edit Asset Scrap Status',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./asset-scrap-status/asset-scrap-status-form.component').then((m) => m.AssetScrapStatusFormComponent),
  },
  {
    path: 'inventory/asset-status',
    title: 'Asset Status',
    loadComponent: () =>
      import('./asset-status/asset-status.component').then((m) => m.ViewAssetStatusComponent),
  },
  {
    path: 'inventory/asset-status/new',
    title: 'New Asset Status',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./asset-status/asset-status-form.component').then((m) => m.AssetStatusFormComponent),
  },
  {
    path: 'inventory/asset-status/:id/edit',
    title: 'Edit Asset Status',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./asset-status/asset-status-form.component').then((m) => m.AssetStatusFormComponent),
  },
  {
    path: 'inventory/asset-warranty-status',
    title: 'Asset Warranty Status',
    loadComponent: () =>
      import('./asset-warranty-status/asset-warranty-status.component').then((m) => m.ViewAssetWarrantyStatusComponent),
  },
  {
    path: 'inventory/asset-warranty-status/new',
    title: 'New Asset Warranty Status',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./asset-warranty-status/asset-warranty-status-form.component').then((m) => m.AssetWarrantyStatusFormComponent),
  },
  {
    path: 'inventory/asset-warranty-status/:id/edit',
    title: 'Edit Asset Warranty Status',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./asset-warranty-status/asset-warranty-status-form.component').then((m) => m.AssetWarrantyStatusFormComponent),
  },
  {
    path: 'inventory/assets-group',
    title: 'Assets Group',
    loadComponent: () =>
      import('./assets-group/assets-group.component').then((m) => m.ViewAssetsGroupComponent),
  },
  {
    path: 'inventory/assets-group/new',
    title: 'New Assets Group',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./assets-group/assets-group-form.component').then((m) => m.AssetsGroupFormComponent),
  },
  {
    path: 'inventory/assets-group/:id/edit',
    title: 'Edit Assets Group',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./assets-group/assets-group-form.component').then((m) => m.AssetsGroupFormComponent),
  },
  {
    path: 'inventory/assets-type',
    title: 'Assets Type',
    loadComponent: () =>
      import('./assets-type/assets-type.component').then((m) => m.ViewAssetsTypeComponent),
  },
  {
    path: 'inventory/assets-type/new',
    title: 'New Assets Type',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./assets-type/assets-type-form.component').then((m) => m.AssetsTypeFormComponent),
  },
  {
    path: 'inventory/assets-type/:id/edit',
    title: 'Edit Assets Type',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./assets-type/assets-type-form.component').then((m) => m.AssetsTypeFormComponent),
  },
  {
    path: 'inventory/chemical-group',
    title: 'Chemical Group',
    loadComponent: () =>
      import('./chemical-group/chemical-group.component').then((m) => m.ViewChemicalGroupComponent),
  },
  {
    path: 'inventory/chemical-group/new',
    title: 'New Chemical Group',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./chemical-group/chemical-group-form.component').then((m) => m.ChemicalGroupFormComponent),
  },
  {
    path: 'inventory/chemical-group/:id/edit',
    title: 'Edit Chemical Group',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./chemical-group/chemical-group-form.component').then((m) => m.ChemicalGroupFormComponent),
  },
  {
    path: 'inventory/equipment-code',
    title: 'Equipment Code',
    loadComponent: () =>
      import('./equipment-code/equipment-code.component').then((m) => m.ViewEquipmentCodeComponent),
  },
  {
    path: 'inventory/equipment-code/new',
    title: 'New Equipment Code',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./equipment-code/equipment-code-form.component').then((m) => m.EquipmentCodeFormComponent),
  },
  {
    path: 'inventory/equipment-code/:id/edit',
    title: 'Edit Equipment Code',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./equipment-code/equipment-code-form.component').then((m) => m.EquipmentCodeFormComponent),
  },
  {
    path: 'inventory/inventory-currency',
    title: 'Inventory Currency',
    loadComponent: () =>
      import('./inventory-currency/inventory-currency.component').then((m) => m.ViewInventoryCurrencyComponent),
  },
  {
    path: 'inventory/inventory-currency/new',
    title: 'New Inventory Currency',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-currency/inventory-currency-form.component').then((m) => m.InventoryCurrencyFormComponent),
  },
  {
    path: 'inventory/inventory-currency/:id/edit',
    title: 'Edit Inventory Currency',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-currency/inventory-currency-form.component').then((m) => m.InventoryCurrencyFormComponent),
  },
  {
    path: 'inventory/inventory-item-asset',
    title: 'Inventory Item Asset',
    loadComponent: () =>
      import('./inventory-item-asset/inventory-item-asset.component').then((m) => m.ViewInventoryItemAssetComponent),
  },
  {
    path: 'inventory/inventory-item-asset/new',
    title: 'New Inventory Item Asset',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-item-asset/inventory-item-asset-form.component').then((m) => m.InventoryItemAssetFormComponent),
  },
  {
    path: 'inventory/inventory-item-asset/:id/edit',
    title: 'Edit Inventory Item Asset',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-item-asset/inventory-item-asset-form.component').then((m) => m.InventoryItemAssetFormComponent),
  },
  {
    path: 'inventory/inventory-item-budget',
    title: 'Inventory Item Budget',
    loadComponent: () =>
      import('./inventory-item-budget/inventory-item-budget.component').then((m) => m.ViewInventoryItemBudgetComponent),
  },
  {
    path: 'inventory/inventory-item-budget/new',
    title: 'New Inventory Item Budget',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-item-budget/inventory-item-budget-form.component').then((m) => m.InventoryItemBudgetFormComponent),
  },
  {
    path: 'inventory/inventory-item-budget/:id/edit',
    title: 'Edit Inventory Item Budget',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-item-budget/inventory-item-budget-form.component').then((m) => m.InventoryItemBudgetFormComponent),
  },
  {
    path: 'inventory/inventory-item-budget-detail',
    title: 'Inventory Item Budget Detail',
    loadComponent: () =>
      import('./inventory-item-budget-detail/inventory-item-budget-detail.component').then((m) => m.ViewInventoryItemBudgetDetailComponent),
  },
  {
    path: 'inventory/inventory-item-budget-detail/new',
    title: 'New Inventory Item Budget Detail',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-item-budget-detail/inventory-item-budget-detail-form.component').then((m) => m.InventoryItemBudgetDetailFormComponent),
  },
  {
    path: 'inventory/inventory-item-budget-detail/:id/edit',
    title: 'Edit Inventory Item Budget Detail',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-item-budget-detail/inventory-item-budget-detail-form.component').then((m) => m.InventoryItemBudgetDetailFormComponent),
  },
  {
    path: 'inventory/inventory-item-cost',
    title: 'Inventory Item Cost',
    loadComponent: () =>
      import('./inventory-item-cost/inventory-item-cost.component').then((m) => m.ViewInventoryItemCostComponent),
  },
  {
    path: 'inventory/inventory-item-cost/new',
    title: 'New Inventory Item Cost',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-item-cost/inventory-item-cost-form.component').then((m) => m.InventoryItemCostFormComponent),
  },
  {
    path: 'inventory/inventory-item-cost/:id/edit',
    title: 'Edit Inventory Item Cost',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-item-cost/inventory-item-cost-form.component').then((m) => m.InventoryItemCostFormComponent),
  },
  {
    path: 'inventory/inventory-item-equivalent-sp',
    title: 'Inventory Item Equivalent Sp',
    loadComponent: () =>
      import('./inventory-item-equivalent-sp/inventory-item-equivalent-sp.component').then((m) => m.ViewInventoryItemEquivalentSpComponent),
  },
  {
    path: 'inventory/inventory-item-equivalent-sp/new',
    title: 'New Inventory Item Equivalent Sp',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-item-equivalent-sp/inventory-item-equivalent-sp-form.component').then((m) => m.InventoryItemEquivalentSpFormComponent),
  },
  {
    path: 'inventory/inventory-item-equivalent-sp/:id/edit',
    title: 'Edit Inventory Item Equivalent Sp',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-item-equivalent-sp/inventory-item-equivalent-sp-form.component').then((m) => m.InventoryItemEquivalentSpFormComponent),
  },
  {
    path: 'inventory/inventory-item-location',
    title: 'Inventory Item Location',
    loadComponent: () =>
      import('./inventory-item-location/inventory-item-location.component').then((m) => m.ViewInventoryItemLocationComponent),
  },
  {
    path: 'inventory/inventory-item-location/new',
    title: 'New Inventory Item Location',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-item-location/inventory-item-location-form.component').then((m) => m.InventoryItemLocationFormComponent),
  },
  {
    path: 'inventory/inventory-item-location/:id/edit',
    title: 'Edit Inventory Item Location',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-item-location/inventory-item-location-form.component').then((m) => m.InventoryItemLocationFormComponent),
  },
  {
    path: 'inventory/inventory-item-location-batch',
    title: 'Inventory Item Location Batch',
    loadComponent: () =>
      import('./inventory-item-location-batch/inventory-item-location-batch.component').then((m) => m.ViewInventoryItemLocationBatchComponent),
  },
  {
    path: 'inventory/inventory-item-location-batch/new',
    title: 'New Inventory Item Location Batch',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-item-location-batch/inventory-item-location-batch-form.component').then((m) => m.InventoryItemLocationBatchFormComponent),
  },
  {
    path: 'inventory/inventory-item-location-batch/:id/edit',
    title: 'Edit Inventory Item Location Batch',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-item-location-batch/inventory-item-location-batch-form.component').then((m) => m.InventoryItemLocationBatchFormComponent),
  },
  {
    path: 'inventory/inventory-item-location-batch-serial',
    title: 'Inventory Item Location Batch Serial',
    loadComponent: () =>
      import('./inventory-item-location-batch-serial/inventory-item-location-batch-serial.component').then((m) => m.ViewInventoryItemLocationBatchSerialComponent),
  },
  {
    path: 'inventory/inventory-item-location-batch-serial/new',
    title: 'New Inventory Item Location Batch Serial',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-item-location-batch-serial/inventory-item-location-batch-serial-form.component').then((m) => m.InventoryItemLocationBatchSerialEntityFormComponent),
  },
  {
    path: 'inventory/inventory-item-location-batch-serial/:id/edit',
    title: 'Edit Inventory Item Location Batch Serial',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-item-location-batch-serial/inventory-item-location-batch-serial-form.component').then((m) => m.InventoryItemLocationBatchSerialEntityFormComponent),
  },
  {
    path: 'inventory/inventory-item-location-detail',
    title: 'Inventory Item Location Detail',
    loadComponent: () =>
      import('./inventory-item-location-detail/inventory-item-location-detail.component').then((m) => m.ViewInventoryItemLocationDetailComponent),
  },
  {
    path: 'inventory/inventory-item-location-detail/new',
    title: 'New Inventory Item Location Detail',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-item-location-detail/inventory-item-location-detail-form.component').then((m) => m.InventoryItemLocationDetailFormComponent),
  },
  {
    path: 'inventory/inventory-item-location-detail/:id/edit',
    title: 'Edit Inventory Item Location Detail',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-item-location-detail/inventory-item-location-detail-form.component').then((m) => m.InventoryItemLocationDetailFormComponent),
  },
  {
    path: 'inventory/inventory-item-return',
    title: 'Inventory Item Return',
    loadComponent: () =>
      import('./inventory-item-return/inventory-item-return.component').then((m) => m.ViewInventoryItemReturnComponent),
  },
  {
    path: 'inventory/inventory-item-return/new',
    title: 'New Inventory Item Return',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-item-return/inventory-item-return-form.component').then((m) => m.InventoryItemReturnEntityFormComponent),
  },
  {
    path: 'inventory/inventory-item-return/:id/edit',
    title: 'Edit Inventory Item Return',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-item-return/inventory-item-return-form.component').then((m) => m.InventoryItemReturnEntityFormComponent),
  },
  {
    path: 'inventory/inventory-item-return-attachment',
    title: 'Inventory Item Return Attachment',
    loadComponent: () =>
      import('./inventory-item-return-attachment/inventory-item-return-attachment.component').then((m) => m.ViewInventoryItemReturnAttachmentComponent),
  },
  {
    path: 'inventory/inventory-item-return-attachment/new',
    title: 'New Inventory Item Return Attachment',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-item-return-attachment/inventory-item-return-attachment-form.component').then((m) => m.InventoryItemReturnAttachmentFormComponent),
  },
  {
    path: 'inventory/inventory-item-return-attachment/:id/edit',
    title: 'Edit Inventory Item Return Attachment',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-item-return-attachment/inventory-item-return-attachment-form.component').then((m) => m.InventoryItemReturnAttachmentFormComponent),
  },
  {
    path: 'inventory/inventory-item-return-batch',
    title: 'Inventory Item Return Batch',
    loadComponent: () =>
      import('./inventory-item-return-batch/inventory-item-return-batch.component').then((m) => m.ViewInventoryItemReturnBatchComponent),
  },
  {
    path: 'inventory/inventory-item-return-batch/new',
    title: 'New Inventory Item Return Batch',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-item-return-batch/inventory-item-return-batch-form.component').then((m) => m.InventoryItemReturnBatchFormComponent),
  },
  {
    path: 'inventory/inventory-item-return-batch/:id/edit',
    title: 'Edit Inventory Item Return Batch',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-item-return-batch/inventory-item-return-batch-form.component').then((m) => m.InventoryItemReturnBatchFormComponent),
  },
  {
    path: 'inventory/inventory-item-return-batch-serial',
    title: 'Inventory Item Return Batch Serial',
    loadComponent: () =>
      import('./inventory-item-return-batch-serial/inventory-item-return-batch-serial.component').then((m) => m.ViewInventoryItemReturnBatchSerialComponent),
  },
  {
    path: 'inventory/inventory-item-return-batch-serial/new',
    title: 'New Inventory Item Return Batch Serial',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-item-return-batch-serial/inventory-item-return-batch-serial-form.component').then((m) => m.InventoryItemReturnBatchSerialFormComponent),
  },
  {
    path: 'inventory/inventory-item-return-batch-serial/:id/edit',
    title: 'Edit Inventory Item Return Batch Serial',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-item-return-batch-serial/inventory-item-return-batch-serial-form.component').then((m) => m.InventoryItemReturnBatchSerialFormComponent),
  },
  {
    path: 'inventory/inventory-item-return-detail',
    title: 'Inventory Item Return Detail',
    loadComponent: () =>
      import('./inventory-item-return-detail/inventory-item-return-detail.component').then((m) => m.ViewInventoryItemReturnDetailComponent),
  },
  {
    path: 'inventory/inventory-item-return-detail/new',
    title: 'New Inventory Item Return Detail',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-item-return-detail/inventory-item-return-detail-form.component').then((m) => m.InventoryItemReturnDetailFormComponent),
  },
  {
    path: 'inventory/inventory-item-return-detail/:id/edit',
    title: 'Edit Inventory Item Return Detail',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-item-return-detail/inventory-item-return-detail-form.component').then((m) => m.InventoryItemReturnDetailFormComponent),
  },
  {
    path: 'inventory/inventory-item-return-serial',
    title: 'Inventory Item Return Serial',
    loadComponent: () =>
      import('./inventory-item-return-serial/inventory-item-return-serial.component').then((m) => m.ViewInventoryItemReturnSerialComponent),
  },
  {
    path: 'inventory/inventory-item-return-serial/new',
    title: 'New Inventory Item Return Serial',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-item-return-serial/inventory-item-return-serial-form.component').then((m) => m.InventoryItemReturnSerialFormComponent),
  },
  {
    path: 'inventory/inventory-item-return-serial/:id/edit',
    title: 'Edit Inventory Item Return Serial',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-item-return-serial/inventory-item-return-serial-form.component').then((m) => m.InventoryItemReturnSerialFormComponent),
  },
  {
    path: 'inventory/inventory-item-serial',
    title: 'Inventory Item Serial',
    loadComponent: () =>
      import('./inventory-item-serial/inventory-item-serial.component').then((m) => m.ViewInventoryItemSerialComponent),
  },
  {
    path: 'inventory/inventory-item-serial/new',
    title: 'New Inventory Item Serial',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-item-serial/inventory-item-serial-form.component').then((m) => m.InventoryItemSerialEntityFormComponent),
  },
  {
    path: 'inventory/inventory-item-serial/:id/edit',
    title: 'Edit Inventory Item Serial',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-item-serial/inventory-item-serial-form.component').then((m) => m.InventoryItemSerialEntityFormComponent),
  },
  {
    path: 'inventory/inventory-item-serial-status',
    title: 'Inventory Item Serial Status',
    loadComponent: () =>
      import('./inventory-item-serial-status/inventory-item-serial-status.component').then((m) => m.ViewInventoryItemSerialStatusComponent),
  },
  {
    path: 'inventory/inventory-item-serial-status/new',
    title: 'New Inventory Item Serial Status',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-item-serial-status/inventory-item-serial-status-form.component').then((m) => m.InventoryItemSerialStatusFormComponent),
  },
  {
    path: 'inventory/inventory-item-serial-status/:id/edit',
    title: 'Edit Inventory Item Serial Status',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-item-serial-status/inventory-item-serial-status-form.component').then((m) => m.InventoryItemSerialStatusFormComponent),
  },
  {
    path: 'inventory/inventory-item-status',
    title: 'Inventory Item Status',
    loadComponent: () =>
      import('./inventory-item-status/inventory-item-status.component').then((m) => m.ViewInventoryItemStatusComponent),
  },
  {
    path: 'inventory/inventory-item-status/new',
    title: 'New Inventory Item Status',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-item-status/inventory-item-status-form.component').then((m) => m.InventoryItemStatusFormComponent),
  },
  {
    path: 'inventory/inventory-item-status/:id/edit',
    title: 'Edit Inventory Item Status',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-item-status/inventory-item-status-form.component').then((m) => m.InventoryItemStatusFormComponent),
  },
  {
    path: 'inventory/inventory-item-transaction-type',
    title: 'Inventory Item Transaction Type',
    loadComponent: () =>
      import('./inventory-item-transaction-type/inventory-item-transaction-type.component').then((m) => m.ViewInventoryItemTransactionTypeComponent),
  },
  {
    path: 'inventory/inventory-item-transaction-type/new',
    title: 'New Inventory Item Transaction Type',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-item-transaction-type/inventory-item-transaction-type-form.component').then((m) => m.InventoryItemTransactionTypeFormComponent),
  },
  {
    path: 'inventory/inventory-item-transaction-type/:id/edit',
    title: 'Edit Inventory Item Transaction Type',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-item-transaction-type/inventory-item-transaction-type-form.component').then((m) => m.InventoryItemTransactionTypeFormComponent),
  },
  {
    path: 'inventory/inventory-item-trasnsaction-type',
    title: 'Inventory Item Trasnsaction Type',
    loadComponent: () =>
      import('./inventory-item-trasnsaction-type/inventory-item-trasnsaction-type.component').then((m) => m.ViewInventoryItemTrasnsactionTypeComponent),
  },
  {
    path: 'inventory/inventory-item-trasnsaction-type/new',
    title: 'New Inventory Item Trasnsaction Type',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-item-trasnsaction-type/inventory-item-trasnsaction-type-form.component').then((m) => m.InventoryItemTrasnsactionTypeFormComponent),
  },
  {
    path: 'inventory/inventory-item-trasnsaction-type/:id/edit',
    title: 'Edit Inventory Item Trasnsaction Type',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-item-trasnsaction-type/inventory-item-trasnsaction-type-form.component').then((m) => m.InventoryItemTrasnsactionTypeFormComponent),
  },
  {
    path: 'inventory/inventory-item-uo-m',
    title: 'Inventory Item Uo M',
    loadComponent: () =>
      import('./inventory-item-uo-m/inventory-item-uo-m.component').then((m) => m.ViewInventoryItemUoMComponent),
  },
  {
    path: 'inventory/inventory-item-uo-m/new',
    title: 'New Inventory Item Uo M',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-item-uo-m/inventory-item-uo-m-form.component').then((m) => m.InventoryItemUoMFormComponent),
  },
  {
    path: 'inventory/inventory-item-uo-m/:id/edit',
    title: 'Edit Inventory Item Uo M',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-item-uo-m/inventory-item-uo-m-form.component').then((m) => m.InventoryItemUoMFormComponent),
  },
  {
    path: 'inventory/inventory-stock-count',
    title: 'Inventory Stock Count',
    loadComponent: () =>
      import('./inventory-stock-count/inventory-stock-count.component').then((m) => m.ViewInventoryStockCountComponent),
  },
  {
    path: 'inventory/inventory-stock-count/new',
    title: 'New Inventory Stock Count',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-stock-count/inventory-stock-count-form.component').then((m) => m.InventoryStockCountEntityFormComponent),
  },
  {
    path: 'inventory/inventory-stock-count/:id/edit',
    title: 'Edit Inventory Stock Count',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-stock-count/inventory-stock-count-form.component').then((m) => m.InventoryStockCountEntityFormComponent),
  },
  {
    path: 'inventory/inventory-stock-count-detail',
    title: 'Inventory Stock Count Detail',
    loadComponent: () =>
      import('./inventory-stock-count-detail/inventory-stock-count-detail.component').then((m) => m.ViewInventoryStockCountDetailComponent),
  },
  {
    path: 'inventory/inventory-stock-count-detail/new',
    title: 'New Inventory Stock Count Detail',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-stock-count-detail/inventory-stock-count-detail-form.component').then((m) => m.InventoryStockCountDetailFormComponent),
  },
  {
    path: 'inventory/inventory-stock-count-detail/:id/edit',
    title: 'Edit Inventory Stock Count Detail',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-stock-count-detail/inventory-stock-count-detail-form.component').then((m) => m.InventoryStockCountDetailFormComponent),
  },
  {
    path: 'inventory/inventory-stock-count-detail-batch',
    title: 'Inventory Stock Count Detail Batch',
    loadComponent: () =>
      import('./inventory-stock-count-detail-batch/inventory-stock-count-detail-batch.component').then((m) => m.ViewInventoryStockCountDetailBatchComponent),
  },
  {
    path: 'inventory/inventory-stock-count-detail-batch/new',
    title: 'New Inventory Stock Count Detail Batch',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-stock-count-detail-batch/inventory-stock-count-detail-batch-form.component').then((m) => m.InventoryStockCountDetailBatchFormComponent),
  },
  {
    path: 'inventory/inventory-stock-count-detail-batch/:id/edit',
    title: 'Edit Inventory Stock Count Detail Batch',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-stock-count-detail-batch/inventory-stock-count-detail-batch-form.component').then((m) => m.InventoryStockCountDetailBatchFormComponent),
  },
  {
    path: 'inventory/inventory-stock-count-detail-batch-serial',
    title: 'Inventory Stock Count Detail Batch Serial',
    loadComponent: () =>
      import('./inventory-stock-count-detail-batch-serial/inventory-stock-count-detail-batch-serial.component').then((m) => m.ViewInventoryStockCountDetailBatchSerialComponent),
  },
  {
    path: 'inventory/inventory-stock-count-detail-batch-serial/new',
    title: 'New Inventory Stock Count Detail Batch Serial',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-stock-count-detail-batch-serial/inventory-stock-count-detail-batch-serial-form.component').then((m) => m.InventoryStockCountDetailBatchSerialFormComponent),
  },
  {
    path: 'inventory/inventory-stock-count-detail-batch-serial/:id/edit',
    title: 'Edit Inventory Stock Count Detail Batch Serial',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-stock-count-detail-batch-serial/inventory-stock-count-detail-batch-serial-form.component').then((m) => m.InventoryStockCountDetailBatchSerialFormComponent),
  },
  {
    path: 'inventory/inventory-stock-count-plan',
    title: 'Inventory Stock Count Plan',
    loadComponent: () =>
      import('./inventory-stock-count-plan/inventory-stock-count-plan.component').then((m) => m.ViewInventoryStockCountPlanComponent),
  },
  {
    path: 'inventory/inventory-stock-count-plan/new',
    title: 'New Inventory Stock Count Plan',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-stock-count-plan/inventory-stock-count-plan-form.component').then((m) => m.InventoryStockCountPlanFormComponent),
  },
  {
    path: 'inventory/inventory-stock-count-plan/:id/edit',
    title: 'Edit Inventory Stock Count Plan',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-stock-count-plan/inventory-stock-count-plan-form.component').then((m) => m.InventoryStockCountPlanFormComponent),
  },
  {
    path: 'inventory/inventory-stock-count-plan-detail',
    title: 'Inventory Stock Count Plan Detail',
    loadComponent: () =>
      import('./inventory-stock-count-plan-detail/inventory-stock-count-plan-detail.component').then((m) => m.ViewInventoryStockCountPlanDetailComponent),
  },
  {
    path: 'inventory/inventory-stock-count-plan-detail/new',
    title: 'New Inventory Stock Count Plan Detail',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-stock-count-plan-detail/inventory-stock-count-plan-detail-form.component').then((m) => m.InventoryStockCountPlanDetailFormComponent),
  },
  {
    path: 'inventory/inventory-stock-count-plan-detail/:id/edit',
    title: 'Edit Inventory Stock Count Plan Detail',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-stock-count-plan-detail/inventory-stock-count-plan-detail-form.component').then((m) => m.InventoryStockCountPlanDetailFormComponent),
  },
  {
    path: 'inventory/inventory-stock-count-status',
    title: 'Inventory Stock Count Status',
    loadComponent: () =>
      import('./inventory-stock-count-status/inventory-stock-count-status.component').then((m) => m.ViewInventoryStockCountStatusComponent),
  },
  {
    path: 'inventory/inventory-stock-count-status/new',
    title: 'New Inventory Stock Count Status',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-stock-count-status/inventory-stock-count-status-form.component').then((m) => m.InventoryStockCountStatusFormComponent),
  },
  {
    path: 'inventory/inventory-stock-count-status/:id/edit',
    title: 'Edit Inventory Stock Count Status',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-stock-count-status/inventory-stock-count-status-form.component').then((m) => m.InventoryStockCountStatusFormComponent),
  },
  {
    path: 'inventory/inventory-transfere',
    title: 'Inventory Transfere',
    loadComponent: () =>
      import('./inventory-transfere/inventory-transfere.component').then((m) => m.ViewInventoryTransfereComponent),
  },
  {
    path: 'inventory/inventory-transfere/new',
    title: 'New Inventory Transfere',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-transfere/inventory-transfere-form.component').then((m) => m.InventoryTransfereEntityFormComponent),
  },
  {
    path: 'inventory/inventory-transfere/:id/edit',
    title: 'Edit Inventory Transfere',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-transfere/inventory-transfere-form.component').then((m) => m.InventoryTransfereEntityFormComponent),
  },
  {
    path: 'inventory/inventory-transfere-attachment',
    title: 'Inventory Transfere Attachment',
    loadComponent: () =>
      import('./inventory-transfere-attachment/inventory-transfere-attachment.component').then((m) => m.ViewInventoryTransfereAttachmentComponent),
  },
  {
    path: 'inventory/inventory-transfere-attachment/new',
    title: 'New Inventory Transfere Attachment',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-transfere-attachment/inventory-transfere-attachment-form.component').then((m) => m.InventoryTransfereAttachmentFormComponent),
  },
  {
    path: 'inventory/inventory-transfere-attachment/:id/edit',
    title: 'Edit Inventory Transfere Attachment',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-transfere-attachment/inventory-transfere-attachment-form.component').then((m) => m.InventoryTransfereAttachmentFormComponent),
  },
  {
    path: 'inventory/inventory-transfere-detail',
    title: 'Inventory Transfere Detail',
    loadComponent: () =>
      import('./inventory-transfere-detail/inventory-transfere-detail.component').then((m) => m.ViewInventoryTransfereDetailComponent),
  },
  {
    path: 'inventory/inventory-transfere-detail/new',
    title: 'New Inventory Transfere Detail',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-transfere-detail/inventory-transfere-detail-form.component').then((m) => m.InventoryTransfereDetailFormComponent),
  },
  {
    path: 'inventory/inventory-transfere-detail/:id/edit',
    title: 'Edit Inventory Transfere Detail',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-transfere-detail/inventory-transfere-detail-form.component').then((m) => m.InventoryTransfereDetailFormComponent),
  },
  {
    path: 'inventory/inventory-transfere-detail-batch',
    title: 'Inventory Transfere Detail Batch',
    loadComponent: () =>
      import('./inventory-transfere-detail-batch/inventory-transfere-detail-batch.component').then((m) => m.ViewInventoryTransfereDetailBatchComponent),
  },
  {
    path: 'inventory/inventory-transfere-detail-batch/new',
    title: 'New Inventory Transfere Detail Batch',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-transfere-detail-batch/inventory-transfere-detail-batch-form.component').then((m) => m.InventoryTransfereDetailBatchFormComponent),
  },
  {
    path: 'inventory/inventory-transfere-detail-batch/:id/edit',
    title: 'Edit Inventory Transfere Detail Batch',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-transfere-detail-batch/inventory-transfere-detail-batch-form.component').then((m) => m.InventoryTransfereDetailBatchFormComponent),
  },
  {
    path: 'inventory/inventory-transfere-detail-batch-serial',
    title: 'Inventory Transfere Detail Batch Serial',
    loadComponent: () =>
      import('./inventory-transfere-detail-batch-serial/inventory-transfere-detail-batch-serial.component').then((m) => m.ViewInventoryTransfereDetailBatchSerialComponent),
  },
  {
    path: 'inventory/inventory-transfere-detail-batch-serial/new',
    title: 'New Inventory Transfere Detail Batch Serial',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-transfere-detail-batch-serial/inventory-transfere-detail-batch-serial-form.component').then((m) => m.InventoryTransfereDetailBatchSerialFormComponent),
  },
  {
    path: 'inventory/inventory-transfere-detail-batch-serial/:id/edit',
    title: 'Edit Inventory Transfere Detail Batch Serial',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-transfere-detail-batch-serial/inventory-transfere-detail-batch-serial-form.component').then((m) => m.InventoryTransfereDetailBatchSerialFormComponent),
  },
  {
    path: 'inventory/inventory-transfere-serial',
    title: 'Inventory Transfere Serial',
    loadComponent: () =>
      import('./inventory-transfere-serial/inventory-transfere-serial.component').then((m) => m.ViewInventoryTransfereSerialComponent),
  },
  {
    path: 'inventory/inventory-transfere-serial/new',
    title: 'New Inventory Transfere Serial',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-transfere-serial/inventory-transfere-serial-form.component').then((m) => m.InventoryTransfereSerialFormComponent),
  },
  {
    path: 'inventory/inventory-transfere-serial/:id/edit',
    title: 'Edit Inventory Transfere Serial',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-transfere-serial/inventory-transfere-serial-form.component').then((m) => m.InventoryTransfereSerialFormComponent),
  },
  {
    path: 'inventory/inventory-year',
    title: 'Inventory Year',
    loadComponent: () =>
      import('./inventory-year/inventory-year.component').then((m) => m.ViewInventoryYearComponent),
  },
  {
    path: 'inventory/inventory-year/new',
    title: 'New Inventory Year',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventory-year/inventory-year-form.component').then((m) => m.InventoryYearFormComponent),
  },
  {
    path: 'inventory/inventory-year/:id/edit',
    title: 'Edit Inventory Year',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventory-year/inventory-year-form.component').then((m) => m.InventoryYearFormComponent),
  },
  {
    path: 'inventory/inventroy-item-request-withdraw',
    title: 'Inventroy Item Request Withdraw',
    loadComponent: () =>
      import('./inventroy-item-request-withdraw/inventroy-item-request-withdraw.component').then((m) => m.ViewInventroyItemRequestWithdrawComponent),
  },
  {
    path: 'inventory/inventroy-item-request-withdraw/new',
    title: 'New Inventroy Item Request Withdraw',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventroy-item-request-withdraw/inventroy-item-request-withdraw-form.component').then((m) => m.InventroyItemRequestWithdrawEntityFormComponent),
  },
  {
    path: 'inventory/inventroy-item-request-withdraw/:id/edit',
    title: 'Edit Inventroy Item Request Withdraw',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventroy-item-request-withdraw/inventroy-item-request-withdraw-form.component').then((m) => m.InventroyItemRequestWithdrawEntityFormComponent),
  },
  {
    path: 'inventory/inventroy-item-request-withdraw-attachment',
    title: 'Inventroy Item Request Withdraw Attachment',
    loadComponent: () =>
      import('./inventroy-item-request-withdraw-attachment/inventroy-item-request-withdraw-attachment.component').then((m) => m.ViewInventroyItemRequestWithdrawAttachmentComponent),
  },
  {
    path: 'inventory/inventroy-item-request-withdraw-attachment/new',
    title: 'New Inventroy Item Request Withdraw Attachment',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventroy-item-request-withdraw-attachment/inventroy-item-request-withdraw-attachment-form.component').then((m) => m.InventroyItemRequestWithdrawAttachmentFormComponent),
  },
  {
    path: 'inventory/inventroy-item-request-withdraw-attachment/:id/edit',
    title: 'Edit Inventroy Item Request Withdraw Attachment',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventroy-item-request-withdraw-attachment/inventroy-item-request-withdraw-attachment-form.component').then((m) => m.InventroyItemRequestWithdrawAttachmentFormComponent),
  },
  {
    path: 'inventory/inventroy-item-request-withdraw-detail',
    title: 'Inventroy Item Request Withdraw Detail',
    loadComponent: () =>
      import('./inventroy-item-request-withdraw-detail/inventroy-item-request-withdraw-detail.component').then((m) => m.ViewInventroyItemRequestWithdrawDetailComponent),
  },
  {
    path: 'inventory/inventroy-item-request-withdraw-detail/new',
    title: 'New Inventroy Item Request Withdraw Detail',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./inventroy-item-request-withdraw-detail/inventroy-item-request-withdraw-detail-form.component').then((m) => m.InventroyItemRequestWithdrawDetailFormComponent),
  },
  {
    path: 'inventory/inventroy-item-request-withdraw-detail/:id/edit',
    title: 'Edit Inventroy Item Request Withdraw Detail',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./inventroy-item-request-withdraw-detail/inventroy-item-request-withdraw-detail-form.component').then((m) => m.InventroyItemRequestWithdrawDetailFormComponent),
  },
  {
    path: 'inventory/isle',
    title: 'Isle',
    loadComponent: () =>
      import('./isle/isle.component').then((m) => m.ViewIsleComponent),
  },
  {
    path: 'inventory/isle/new',
    title: 'New Isle',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./isle/isle-form.component').then((m) => m.IsleFormComponent),
  },
  {
    path: 'inventory/isle/:id/edit',
    title: 'Edit Isle',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./isle/isle-form.component').then((m) => m.IsleFormComponent),
  },
  {
    path: 'inventory/item-balance-status',
    title: 'Item Balance Status',
    loadComponent: () =>
      import('./item-balance-status/item-balance-status.component').then((m) => m.ViewItemBalanceStatusComponent),
  },
  {
    path: 'inventory/item-balance-status/new',
    title: 'New Item Balance Status',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./item-balance-status/item-balance-status-form.component').then((m) => m.ItemBalanceStatusFormComponent),
  },
  {
    path: 'inventory/item-balance-status/:id/edit',
    title: 'Edit Item Balance Status',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./item-balance-status/item-balance-status-form.component').then((m) => m.ItemBalanceStatusFormComponent),
  },
  {
    path: 'inventory/item-expiry-type',
    title: 'Item Expiry Type',
    loadComponent: () =>
      import('./item-expiry-type/item-expiry-type.component').then((m) => m.ViewItemExpiryTypeComponent),
  },
  {
    path: 'inventory/item-expiry-type/new',
    title: 'New Item Expiry Type',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./item-expiry-type/item-expiry-type-form.component').then((m) => m.ItemExpiryTypeFormComponent),
  },
  {
    path: 'inventory/item-expiry-type/:id/edit',
    title: 'Edit Item Expiry Type',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./item-expiry-type/item-expiry-type-form.component').then((m) => m.ItemExpiryTypeFormComponent),
  },
  {
    path: 'inventory/item-quantity-type',
    title: 'Item Quantity Type',
    loadComponent: () =>
      import('./item-quantity-type/item-quantity-type.component').then((m) => m.ViewItemQuantityTypeComponent),
  },
  {
    path: 'inventory/item-quantity-type/new',
    title: 'New Item Quantity Type',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./item-quantity-type/item-quantity-type-form.component').then((m) => m.ItemQuantityTypeFormComponent),
  },
  {
    path: 'inventory/item-quantity-type/:id/edit',
    title: 'Edit Item Quantity Type',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./item-quantity-type/item-quantity-type-form.component').then((m) => m.ItemQuantityTypeFormComponent),
  },
  {
    path: 'inventory/item-request-status',
    title: 'Item Request Status',
    loadComponent: () =>
      import('./item-request-status/item-request-status.component').then((m) => m.ViewItemRequestStatusComponent),
  },
  {
    path: 'inventory/item-request-status/new',
    title: 'New Item Request Status',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./item-request-status/item-request-status-form.component').then((m) => m.ItemRequestStatusFormComponent),
  },
  {
    path: 'inventory/item-request-status/:id/edit',
    title: 'Edit Item Request Status',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./item-request-status/item-request-status-form.component').then((m) => m.ItemRequestStatusFormComponent),
  },
  {
    path: 'inventory/item-type',
    title: 'Item Type',
    loadComponent: () =>
      import('./item-type/item-type.component').then((m) => m.ViewItemTypeComponent),
  },
  {
    path: 'inventory/item-type/new',
    title: 'New Item Type',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./item-type/item-type-form.component').then((m) => m.ItemTypeFormComponent),
  },
  {
    path: 'inventory/item-type/:id/edit',
    title: 'Edit Item Type',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./item-type/item-type-form.component').then((m) => m.ItemTypeFormComponent),
  },
  {
    path: 'inventory/location',
    title: 'Location',
    loadComponent: () =>
      import('./location/location.component').then((m) => m.ViewLocationComponent),
  },
  {
    path: 'inventory/location/new',
    title: 'New Location',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./location/location-form.component').then((m) => m.LocationFormComponent),
  },
  {
    path: 'inventory/location/:id/edit',
    title: 'Edit Location',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./location/location-form.component').then((m) => m.LocationFormComponent),
  },
  {
    path: 'inventory/manufacture',
    title: 'Manufacture',
    loadComponent: () =>
      import('./manufacture/manufacture.component').then((m) => m.ViewManufactureComponent),
  },
  {
    path: 'inventory/manufacture/new',
    title: 'New Manufacture',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./manufacture/manufacture-form.component').then((m) => m.ManufactureFormComponent),
  },
  {
    path: 'inventory/manufacture/:id/edit',
    title: 'Edit Manufacture',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./manufacture/manufacture-form.component').then((m) => m.ManufactureFormComponent),
  },
  {
    path: 'inventory/material-category',
    title: 'Material Category',
    loadComponent: () =>
      import('./material-category/material-category.component').then((m) => m.ViewMaterialCategoryComponent),
  },
  {
    path: 'inventory/material-category/new',
    title: 'New Material Category',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./material-category/material-category-form.component').then((m) => m.MaterialCategoryFormComponent),
  },
  {
    path: 'inventory/material-category/:id/edit',
    title: 'Edit Material Category',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./material-category/material-category-form.component').then((m) => m.MaterialCategoryFormComponent),
  },
  {
    path: 'inventory/material-group',
    title: 'Material Group',
    loadComponent: () =>
      import('./material-group/material-group.component').then((m) => m.ViewMaterialGroupComponent),
  },
  {
    path: 'inventory/material-group/new',
    title: 'New Material Group',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./material-group/material-group-form.component').then((m) => m.MaterialGroupFormComponent),
  },
  {
    path: 'inventory/material-group/:id/edit',
    title: 'Edit Material Group',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./material-group/material-group-form.component').then((m) => m.MaterialGroupFormComponent),
  },
  {
    path: 'inventory/material-sub-category',
    title: 'Material Sub Category',
    loadComponent: () =>
      import('./material-sub-category/material-sub-category.component').then((m) => m.ViewMaterialSubCategoryComponent),
  },
  {
    path: 'inventory/material-sub-category/new',
    title: 'New Material Sub Category',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./material-sub-category/material-sub-category-form.component').then((m) => m.MaterialSubCategoryFormComponent),
  },
  {
    path: 'inventory/material-sub-category/:id/edit',
    title: 'Edit Material Sub Category',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./material-sub-category/material-sub-category-form.component').then((m) => m.MaterialSubCategoryFormComponent),
  },
  {
    path: 'inventory/partitions',
    title: 'Partitions',
    loadComponent: () =>
      import('./partitions/partitions.component').then((m) => m.ViewPartitionsComponent),
  },
  {
    path: 'inventory/partitions/new',
    title: 'New Partitions',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./partitions/partitions-form.component').then((m) => m.PartitionsFormComponent),
  },
  {
    path: 'inventory/partitions/:id/edit',
    title: 'Edit Partitions',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./partitions/partitions-form.component').then((m) => m.PartitionsFormComponent),
  },
  {
    path: 'inventory/possession-type',
    title: 'Possession Type',
    loadComponent: () =>
      import('./possession-type/possession-type.component').then((m) => m.ViewPossessionTypeComponent),
  },
  {
    path: 'inventory/possession-type/new',
    title: 'New Possession Type',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./possession-type/possession-type-form.component').then((m) => m.PossessionTypeFormComponent),
  },
  {
    path: 'inventory/possession-type/:id/edit',
    title: 'Edit Possession Type',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./possession-type/possession-type-form.component').then((m) => m.PossessionTypeFormComponent),
  },
  {
    path: 'inventory/rack',
    title: 'Rack',
    loadComponent: () =>
      import('./rack/rack.component').then((m) => m.ViewRackComponent),
  },
  {
    path: 'inventory/rack/new',
    title: 'New Rack',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./rack/rack-form.component').then((m) => m.RackFormComponent),
  },
  {
    path: 'inventory/rack/:id/edit',
    title: 'Edit Rack',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./rack/rack-form.component').then((m) => m.RackFormComponent),
  },
  {
    path: 'inventory/request-withdraw-serial',
    title: 'Request Withdraw Serial',
    loadComponent: () =>
      import('./request-withdraw-serial/request-withdraw-serial.component').then((m) => m.ViewRequestWithdrawSerialComponent),
  },
  {
    path: 'inventory/request-withdraw-serial/new',
    title: 'New Request Withdraw Serial',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./request-withdraw-serial/request-withdraw-serial-form.component').then((m) => m.RequestWithdrawSerialFormComponent),
  },
  {
    path: 'inventory/request-withdraw-serial/:id/edit',
    title: 'Edit Request Withdraw Serial',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./request-withdraw-serial/request-withdraw-serial-form.component').then((m) => m.RequestWithdrawSerialFormComponent),
  },
  {
    path: 'inventory/return-reason',
    title: 'Return Reason',
    loadComponent: () =>
      import('./return-reason/return-reason.component').then((m) => m.ViewReturnReasonComponent),
  },
  {
    path: 'inventory/return-reason/new',
    title: 'New Return Reason',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./return-reason/return-reason-form.component').then((m) => m.ReturnReasonFormComponent),
  },
  {
    path: 'inventory/return-reason/:id/edit',
    title: 'Edit Return Reason',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./return-reason/return-reason-form.component').then((m) => m.ReturnReasonFormComponent),
  },
  {
    path: 'inventory/return-status',
    title: 'Return Status',
    loadComponent: () =>
      import('./return-status/return-status.component').then((m) => m.ViewReturnStatusComponent),
  },
  {
    path: 'inventory/return-status/new',
    title: 'New Return Status',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./return-status/return-status-form.component').then((m) => m.ReturnStatusFormComponent),
  },
  {
    path: 'inventory/return-status/:id/edit',
    title: 'Edit Return Status',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./return-status/return-status-form.component').then((m) => m.ReturnStatusFormComponent),
  },
  {
    path: 'inventory/rw-delivered-batch',
    title: 'Rw Delivered Batch',
    loadComponent: () =>
      import('./rw-delivered-batch/rw-delivered-batch.component').then((m) => m.ViewRwDeliveredBatchComponent),
  },
  {
    path: 'inventory/rw-delivered-batch/new',
    title: 'New Rw Delivered Batch',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./rw-delivered-batch/rw-delivered-batch-form.component').then((m) => m.RwDeliveredBatchFormComponent),
  },
  {
    path: 'inventory/rw-delivered-batch/:id/edit',
    title: 'Edit Rw Delivered Batch',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./rw-delivered-batch/rw-delivered-batch-form.component').then((m) => m.RwDeliveredBatchFormComponent),
  },
  {
    path: 'inventory/rw-delivered-quantity',
    title: 'Rw Delivered Quantity',
    loadComponent: () =>
      import('./rw-delivered-quantity/rw-delivered-quantity.component').then((m) => m.ViewRwDeliveredQuantityComponent),
  },
  {
    path: 'inventory/rw-delivered-quantity/new',
    title: 'New Rw Delivered Quantity',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./rw-delivered-quantity/rw-delivered-quantity-form.component').then((m) => m.RwDeliveredQuantityFormComponent),
  },
  {
    path: 'inventory/rw-delivered-quantity/:id/edit',
    title: 'Edit Rw Delivered Quantity',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./rw-delivered-quantity/rw-delivered-quantity-form.component').then((m) => m.RwDeliveredQuantityFormComponent),
  },
  {
    path: 'inventory/rw-delivered-serial',
    title: 'Rw Delivered Serial',
    loadComponent: () =>
      import('./rw-delivered-serial/rw-delivered-serial.component').then((m) => m.ViewRwDeliveredSerialComponent),
  },
  {
    path: 'inventory/rw-delivered-serial/new',
    title: 'New Rw Delivered Serial',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./rw-delivered-serial/rw-delivered-serial-form.component').then((m) => m.RwDeliveredSerialFormComponent),
  },
  {
    path: 'inventory/rw-delivered-serial/:id/edit',
    title: 'Edit Rw Delivered Serial',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./rw-delivered-serial/rw-delivered-serial-form.component').then((m) => m.RwDeliveredSerialFormComponent),
  },
  {
    path: 'inventory/rw-picked-batch',
    title: 'Rw Picked Batch',
    loadComponent: () =>
      import('./rw-picked-batch/rw-picked-batch.component').then((m) => m.ViewRwPickedBatchComponent),
  },
  {
    path: 'inventory/rw-picked-batch/new',
    title: 'New Rw Picked Batch',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./rw-picked-batch/rw-picked-batch-form.component').then((m) => m.RwPickedBatchFormComponent),
  },
  {
    path: 'inventory/rw-picked-batch/:id/edit',
    title: 'Edit Rw Picked Batch',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./rw-picked-batch/rw-picked-batch-form.component').then((m) => m.RwPickedBatchFormComponent),
  },
  {
    path: 'inventory/rw-picked-quantity',
    title: 'Rw Picked Quantity',
    loadComponent: () =>
      import('./rw-picked-quantity/rw-picked-quantity.component').then((m) => m.ViewRwPickedQuantityComponent),
  },
  {
    path: 'inventory/rw-picked-quantity/new',
    title: 'New Rw Picked Quantity',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./rw-picked-quantity/rw-picked-quantity-form.component').then((m) => m.RwPickedQuantityFormComponent),
  },
  {
    path: 'inventory/rw-picked-quantity/:id/edit',
    title: 'Edit Rw Picked Quantity',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./rw-picked-quantity/rw-picked-quantity-form.component').then((m) => m.RwPickedQuantityFormComponent),
  },
  {
    path: 'inventory/rw-picked-serial',
    title: 'Rw Picked Serial',
    loadComponent: () =>
      import('./rw-picked-serial/rw-picked-serial.component').then((m) => m.ViewRwPickedSerialComponent),
  },
  {
    path: 'inventory/rw-picked-serial/new',
    title: 'New Rw Picked Serial',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./rw-picked-serial/rw-picked-serial-form.component').then((m) => m.RwPickedSerialFormComponent),
  },
  {
    path: 'inventory/rw-picked-serial/:id/edit',
    title: 'Edit Rw Picked Serial',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./rw-picked-serial/rw-picked-serial-form.component').then((m) => m.RwPickedSerialFormComponent),
  },
  {
    path: 'inventory/shelf',
    title: 'Shelf',
    loadComponent: () =>
      import('./shelf/shelf.component').then((m) => m.ViewShelfComponent),
  },
  {
    path: 'inventory/shelf/new',
    title: 'New Shelf',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./shelf/shelf-form.component').then((m) => m.ShelfFormComponent),
  },
  {
    path: 'inventory/shelf/:id/edit',
    title: 'Edit Shelf',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./shelf/shelf-form.component').then((m) => m.ShelfFormComponent),
  },
  {
    path: 'inventory/spare-part-group',
    title: 'Spare Part Group',
    loadComponent: () =>
      import('./spare-part-group/spare-part-group.component').then((m) => m.ViewSparePartGroupComponent),
  },
  {
    path: 'inventory/spare-part-group/new',
    title: 'New Spare Part Group',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./spare-part-group/spare-part-group-form.component').then((m) => m.SparePartGroupFormComponent),
  },
  {
    path: 'inventory/spare-part-group/:id/edit',
    title: 'Edit Spare Part Group',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./spare-part-group/spare-part-group-form.component').then((m) => m.SparePartGroupFormComponent),
  },
  {
    path: 'inventory/stock-count-plan-status',
    title: 'Stock Count Plan Status',
    loadComponent: () =>
      import('./stock-count-plan-status/stock-count-plan-status.component').then((m) => m.ViewStockCountPlanStatusComponent),
  },
  {
    path: 'inventory/stock-count-plan-status/new',
    title: 'New Stock Count Plan Status',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./stock-count-plan-status/stock-count-plan-status-form.component').then((m) => m.StockCountPlanStatusFormComponent),
  },
  {
    path: 'inventory/stock-count-plan-status/:id/edit',
    title: 'Edit Stock Count Plan Status',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./stock-count-plan-status/stock-count-plan-status-form.component').then((m) => m.StockCountPlanStatusFormComponent),
  },
  {
    path: 'inventory/stock-count-plan-type',
    title: 'Stock Count Plan Type',
    loadComponent: () =>
      import('./stock-count-plan-type/stock-count-plan-type.component').then((m) => m.ViewStockCountPlanTypeComponent),
  },
  {
    path: 'inventory/stock-count-plan-type/new',
    title: 'New Stock Count Plan Type',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./stock-count-plan-type/stock-count-plan-type-form.component').then((m) => m.StockCountPlanTypeFormComponent),
  },
  {
    path: 'inventory/stock-count-plan-type/:id/edit',
    title: 'Edit Stock Count Plan Type',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./stock-count-plan-type/stock-count-plan-type-form.component').then((m) => m.StockCountPlanTypeFormComponent),
  },
  {
    path: 'inventory/store',
    title: 'Store',
    loadComponent: () =>
      import('./store/store.component').then((m) => m.ViewStoreComponent),
  },
  {
    path: 'inventory/store/new',
    title: 'New Store',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./store/store-form.component').then((m) => m.StoreFormComponent),
  },
  {
    path: 'inventory/store/:id/edit',
    title: 'Edit Store',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./store/store-form.component').then((m) => m.StoreFormComponent),
  },
  {
    path: 'inventory/store-keeper',
    title: 'Store Keeper',
    loadComponent: () =>
      import('./store-keeper/store-keeper.component').then((m) => m.ViewStoreKeeperComponent),
  },
  {
    path: 'inventory/store-keeper/new',
    title: 'New Store Keeper',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./store-keeper/store-keeper-form.component').then((m) => m.StoreKeeperFormComponent),
  },
  {
    path: 'inventory/store-keeper/:id/edit',
    title: 'Edit Store Keeper',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./store-keeper/store-keeper-form.component').then((m) => m.StoreKeeperFormComponent),
  },
  {
    path: 'inventory/store-sequence',
    title: 'Store Sequence',
    loadComponent: () =>
      import('./store-sequence/store-sequence.component').then((m) => m.ViewStoreSequenceComponent),
  },
  {
    path: 'inventory/store-sequence/new',
    title: 'New Store Sequence',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./store-sequence/store-sequence-form.component').then((m) => m.StoreSequenceFormComponent),
  },
  {
    path: 'inventory/store-sequence/:id/edit',
    title: 'Edit Store Sequence',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./store-sequence/store-sequence-form.component').then((m) => m.StoreSequenceFormComponent),
  },
  {
    path: 'inventory/tools-type',
    title: 'Tools Type',
    loadComponent: () =>
      import('./tools-type/tools-type.component').then((m) => m.ViewToolsTypeComponent),
  },
  {
    path: 'inventory/tools-type/new',
    title: 'New Tools Type',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./tools-type/tools-type-form.component').then((m) => m.ToolsTypeFormComponent),
  },
  {
    path: 'inventory/tools-type/:id/edit',
    title: 'Edit Tools Type',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./tools-type/tools-type-form.component').then((m) => m.ToolsTypeFormComponent),
  },
  {
    path: 'inventory/transfer-reason',
    title: 'Transfer Reason',
    loadComponent: () =>
      import('./transfer-reason/transfer-reason.component').then((m) => m.ViewTransferReasonComponent),
  },
  {
    path: 'inventory/transfer-reason/new',
    title: 'New Transfer Reason',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./transfer-reason/transfer-reason-form.component').then((m) => m.TransferReasonFormComponent),
  },
  {
    path: 'inventory/transfer-reason/:id/edit',
    title: 'Edit Transfer Reason',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./transfer-reason/transfer-reason-form.component').then((m) => m.TransferReasonFormComponent),
  },
  {
    path: 'inventory/transfer-status',
    title: 'Transfer Status',
    loadComponent: () =>
      import('./transfer-status/transfer-status.component').then((m) => m.ViewTransferStatusComponent),
  },
  {
    path: 'inventory/transfer-status/new',
    title: 'New Transfer Status',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./transfer-status/transfer-status-form.component').then((m) => m.TransferStatusFormComponent),
  },
  {
    path: 'inventory/transfer-status/:id/edit',
    title: 'Edit Transfer Status',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./transfer-status/transfer-status-form.component').then((m) => m.TransferStatusFormComponent),
  },
  {
    path: 'inventory/transfere-type',
    title: 'Transfere Type',
    loadComponent: () =>
      import('./transfere-type/transfere-type.component').then((m) => m.ViewTransfereTypeComponent),
  },
  {
    path: 'inventory/transfere-type/new',
    title: 'New Transfere Type',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./transfere-type/transfere-type-form.component').then((m) => m.TransfereTypeFormComponent),
  },
  {
    path: 'inventory/transfere-type/:id/edit',
    title: 'Edit Transfere Type',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./transfere-type/transfere-type-form.component').then((m) => m.TransfereTypeFormComponent),
  },
  {
    path: 'inventory/unit-of-measure',
    title: 'Unit Of Measure',
    loadComponent: () =>
      import('./unit-of-measure/unit-of-measure.component').then((m) => m.ViewUnitOfMeasureComponent),
  },
  {
    path: 'inventory/unit-of-measure/new',
    title: 'New Unit Of Measure',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./unit-of-measure/unit-of-measure-form.component').then((m) => m.UnitOfMeasureFormComponent),
  },
  {
    path: 'inventory/unit-of-measure/:id/edit',
    title: 'Edit Unit Of Measure',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./unit-of-measure/unit-of-measure-form.component').then((m) => m.UnitOfMeasureFormComponent),
  },
  {
    path: 'inventory/warranty-status',
    title: 'Warranty Status',
    loadComponent: () =>
      import('./warranty-status/warranty-status.component').then((m) => m.ViewWarrantyStatusComponent),
  },
  {
    path: 'inventory/warranty-status/new',
    title: 'New Warranty Status',
    data: { mode: 'create' },
    loadComponent: () =>
      import('./warranty-status/warranty-status-form.component').then((m) => m.WarrantyStatusFormComponent),
  },
  {
    path: 'inventory/warranty-status/:id/edit',
    title: 'Edit Warranty Status',
    data: { mode: 'edit' },
    loadComponent: () =>
      import('./warranty-status/warranty-status-form.component').then((m) => m.WarrantyStatusFormComponent),
  },
];
