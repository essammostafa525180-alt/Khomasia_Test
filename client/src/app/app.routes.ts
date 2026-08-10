import { Routes } from '@angular/router';
import { MainLayoutComponent } from './core/layout/main-layout/main-layout.component';
import { administrationRoutes } from './pages/Administration/administration.routes';
import { procurementRoutes } from './pages/Procurement/procurement.routes';
import { inventoryExtraRoutes } from './pages/inventory/inventory-extra.routes';
import { reportsRoutes } from './pages/Reports/reports.routes';
import { otherRoutes } from './pages/Other/other.routes';

export const routes: Routes = [
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },

      // ---- Test ----
      {
        path: 'test',
        title: 'Test Operations',
        loadComponent: () =>
          import('./Feature/TestModule/view-test/view-test.component').then(
            (m) => m.ViewTestComponent
          ),
      },

      // ---- Country ----
      {
        path: 'country',
        title: 'Countries',
        loadComponent: () =>
          import('./Feature/CountryModule/view-country/view-country.component').then(
            (m) => m.ViewCountryComponent
          ),
      },
      {
        path: 'country/new',
        title: 'New Country',
        data: { mode: 'create' },
        loadComponent: () =>
          import('./Feature/CountryModule/country-form/country-form.component').then(
            (m) => m.CountryFormComponent
          ),
      },
      {
        path: 'country/:id/edit',
        title: 'Edit Country',
        data: { mode: 'edit' },
        loadComponent: () =>
          import('./Feature/CountryModule/country-form/country-form.component').then(
            (m) => m.CountryFormComponent
          ),
      },

      // ---- City ----
      {
        path: 'city',
        title: 'Cities',
        loadComponent: () =>
          import('./Feature/CityModule/view-city/view-city.component').then(
            (m) => m.ViewCityComponent
          ),
      },
      {
        path: 'city/new',
        title: 'New City',
        data: { mode: 'create' },
        loadComponent: () =>
          import('./Feature/CityModule/city-form/city-form.component').then(
            (m) => m.CityFormComponent
          ),
      },
      {
        path: 'city/:id/edit',
        title: 'Edit City',
        data: { mode: 'edit' },
        loadComponent: () =>
          import('./Feature/CityModule/city-form/city-form.component').then(
            (m) => m.CityFormComponent
          ),
      },

      // ---- Dashboard / Home ----
      {
        path: 'dashboard',
        title: 'Dashboard',
        loadComponent: () =>
          import('./pages/dashboard/dashboard.component').then((m) => m.DashboardComponent),
      },
      {
        path: 'home',
        title: 'Home',
        loadComponent: () =>
          import('./pages/home/home.component').then((m) => m.HomeComponent),
      },

      // ---- Inventory Hub ----
      {
        path: 'inventory',
        title: 'Inventory',
        loadComponent: () =>
          import('./pages/inventory-hub/inventory-hub.component').then(
            (m) => m.InventoryHubComponent
          ),
      },

      // ---- Inventory Management ----
      {
        path: 'inventory/asset-name',
        title: 'Asset Name',
        loadComponent: () =>
          import('./pages/inventory/asset-name/asset-name.component').then(
            (m) => m.ViewAssetNameComponent
          ),
      },
      {
        path: 'inventory/asset-name/new',
        title: 'New Asset Name',
        data: { mode: 'create' },
        loadComponent: () =>
          import('./pages/inventory/asset-name/asset-name-form.component').then(
            (m) => m.AssetFormComponent
          ),
      },
      {
        path: 'inventory/asset-name/:id/edit',
        title: 'Edit Asset Name',
        data: { mode: 'edit' },
        loadComponent: () =>
          import('./pages/inventory/asset-name/asset-name-form.component').then(
            (m) => m.AssetFormComponent
          ),
      },
      {
        path: 'inventory/item-card',
        title: 'Item Card',
        loadComponent: () =>
          import('./pages/inventory/item-card/item-card.component').then(
            (m) => m.ViewItemCardComponent
          ),
      },
      {
        path: 'inventory/item-card/new',
        title: 'New Item Card',
        data: { mode: 'create' },
        loadComponent: () =>
          import('./pages/inventory/item-card/item-card-form.component').then(
            (m) => m.InventoryItemFormComponent
          ),
      },
      {
        path: 'inventory/item-card/:id/edit',
        title: 'Edit Item Card',
        data: { mode: 'edit' },
        loadComponent: () =>
          import('./pages/inventory/item-card/item-card-form.component').then(
            (m) => m.InventoryItemFormComponent
          ),
      },
      {
        path: 'inventory/item-balance',
        title: 'Item Balance',
        loadComponent: () =>
          import('./pages/inventory/item-balance/item-balance.component').then(
            (m) => m.ViewItemBalanceComponent
          ),
      },
      {
        path: 'inventory/item-balance/new',
        title: 'New Item Balance',
        data: { mode: 'create' },
        loadComponent: () =>
          import('./pages/inventory/item-balance/item-balance-form.component').then(
            (m) => m.InventoryItemLocationBatchSerialFormComponent
          ),
      },
      {
        path: 'inventory/item-balance/:id/edit',
        title: 'Edit Item Balance',
        data: { mode: 'edit' },
        loadComponent: () =>
          import('./pages/inventory/item-balance/item-balance-form.component').then(
            (m) => m.InventoryItemLocationBatchSerialFormComponent
          ),
      },
      {
        path: 'inventory/item-stock',
        title: 'Item Stock',
        loadComponent: () =>
          import('./pages/inventory/item-stock/item-stock.component').then(
            (m) => m.ViewItemStockComponent
          ),
      },
      {
        path: 'inventory/item-stock/new',
        title: 'New Item Stock',
        data: { mode: 'create' },
        loadComponent: () =>
          import('./pages/inventory/item-stock/item-stock-form.component').then(
            (m) => m.InventoryItemSerialFormComponent
          ),
      },
      {
        path: 'inventory/item-stock/:id/edit',
        title: 'Edit Item Stock',
        data: { mode: 'edit' },
        loadComponent: () =>
          import('./pages/inventory/item-stock/item-stock-form.component').then(
            (m) => m.InventoryItemSerialFormComponent
          ),
      },
      {
        path: 'inventory/asset-move',
        title: 'Asset Item Move',
        loadComponent: () =>
          import('./pages/inventory/asset-move/asset-move.component').then(
            (m) => m.ViewAssetMoveComponent
          ),
      },
      {
        path: 'inventory/asset-move/new',
        title: 'New Asset Move',
        data: { mode: 'create' },
        loadComponent: () =>
          import('./pages/inventory/asset-move/asset-move-form.component').then(
            (m) => m.AssetItemMoveFormComponent
          ),
      },
      {
        path: 'inventory/asset-move/:id/edit',
        title: 'Edit Asset Move',
        data: { mode: 'edit' },
        loadComponent: () =>
          import('./pages/inventory/asset-move/asset-move-form.component').then(
            (m) => m.AssetItemMoveFormComponent
          ),
      },

      // ---- Inventory Transactions ----
      {
        path: 'inventory/issue-request',
        title: 'Issue Request',
        loadComponent: () =>
          import('./pages/inventory/material-request/material-request.component').then(
            (m) => m.ViewMaterialRequestComponent
          ),
      },
      {
        path: 'inventory/issue-request/new',
        title: 'New Issue Request',
        data: { mode: 'create' },
        loadComponent: () =>
          import('./pages/inventory/material-request/material-request-form.component').then(
            (m) => m.InventroyItemRequestWithdrawFormComponent
          ),
      },
      {
        path: 'inventory/issue-request/:id/edit',
        title: 'Edit Issue Request',
        data: { mode: 'edit' },
        loadComponent: () =>
          import('./pages/inventory/material-request/material-request-form.component').then(
            (m) => m.InventroyItemRequestWithdrawFormComponent
          ),
      },
      {
        path: 'inventory/asset-issue-request',
        title: 'Asset Issue Request',
        loadComponent: () =>
          import('./pages/inventory/asset-issue-request/asset-issue-request.component').then(
            (m) => m.ViewAssetIssueRequestComponent
          ),
      },
      {
        path: 'inventory/asset-issue-request/new',
        title: 'New Asset Issue Request',
        data: { mode: 'create' },
        loadComponent: () =>
          import('./pages/inventory/asset-issue-request/asset-issue-request-form.component').then(
            (m) => m.AssetCountIssueFormComponent
          ),
      },
      {
        path: 'inventory/asset-issue-request/:id/edit',
        title: 'Edit Asset Issue Request',
        data: { mode: 'edit' },
        loadComponent: () =>
          import('./pages/inventory/asset-issue-request/asset-issue-request-form.component').then(
            (m) => m.AssetCountIssueFormComponent
          ),
      },
      {
        path: 'inventory/issue-out',
        title: 'Issue Out',
        loadComponent: () =>
          import('./pages/inventory/issue-out/issue-out.component').then(
            (m) => m.ViewIssueOutComponent
          ),
      },
      {
        path: 'inventory/issue-out/new',
        title: 'New Issue Out',
        data: { mode: 'create' },
        loadComponent: () =>
          import('./pages/inventory/issue-out/issue-out-form.component').then(
            (m) => m.InventroyItemRequestWithdrawFormComponent
          ),
      },
      {
        path: 'inventory/issue-out/:id/edit',
        title: 'Edit Issue Out',
        data: { mode: 'edit' },
        loadComponent: () =>
          import('./pages/inventory/issue-out/issue-out-form.component').then(
            (m) => m.InventroyItemRequestWithdrawFormComponent
          ),
      },
      {
        path: 'inventory/item-return',
        title: 'Item Return',
        loadComponent: () =>
          import('./pages/inventory/item-return/item-return.component').then(
            (m) => m.ViewItemReturnComponent
          ),
      },
      {
        path: 'inventory/item-return/new',
        title: 'New Item Return',
        data: { mode: 'create' },
        loadComponent: () =>
          import('./pages/inventory/item-return/item-return-form.component').then(
            (m) => m.InventoryItemReturnFormComponent
          ),
      },
      {
        path: 'inventory/item-return/:id/edit',
        title: 'Edit Item Return',
        data: { mode: 'edit' },
        loadComponent: () =>
          import('./pages/inventory/item-return/item-return-form.component').then(
            (m) => m.InventoryItemReturnFormComponent
          ),
      },
      {
        path: 'inventory/transfer',
        title: 'Transfer',
        loadComponent: () =>
          import('./pages/inventory/transfer/transfer.component').then(
            (m) => m.ViewTransferComponent
          ),
      },
      {
        path: 'inventory/transfer/new',
        title: 'New Transfer',
        data: { mode: 'create' },
        loadComponent: () =>
          import('./pages/inventory/transfer/transfer-form.component').then(
            (m) => m.InventoryTransfereFormComponent
          ),
      },
      {
        path: 'inventory/transfer/:id/edit',
        title: 'Edit Transfer',
        data: { mode: 'edit' },
        loadComponent: () =>
          import('./pages/inventory/transfer/transfer-form.component').then(
            (m) => m.InventoryTransfereFormComponent
          ),
      },

      // ---- Vendor Order ----
      {
        path: 'inventory/grn-quality',
        title: 'GRN Quality',
        loadComponent: () =>
          import('./pages/inventory/grn-quality/grn-quality.component').then(
            (m) => m.ViewGrnQualityComponent
          ),
      },
      {
        path: 'inventory/grn-quality/new',
        title: 'New GRN Quality',
        data: { mode: 'create' },
        loadComponent: () =>
          import('./pages/inventory/grn-quality/grn-quality-form.component').then(
            (m) => m.VendorOrderQualityFormComponent
          ),
      },
      {
        path: 'inventory/grn-quality/:id/edit',
        title: 'Edit GRN Quality',
        data: { mode: 'edit' },
        loadComponent: () =>
          import('./pages/inventory/grn-quality/grn-quality-form.component').then(
            (m) => m.VendorOrderQualityFormComponent
          ),
      },
      {
        path: 'inventory/grn',
        title: 'GRN',
        loadComponent: () =>
          import('./pages/inventory/grn/grn.component').then(
            (m) => m.ViewGrnComponent
          ),
      },
      {
        path: 'inventory/grn/new',
        title: 'New GRN',
        data: { mode: 'create' },
        loadComponent: () =>
          import('./pages/inventory/grn/grn-form.component').then(
            (m) => m.VendorOrderReceiveFormComponent
          ),
      },
      {
        path: 'inventory/grn/:id/edit',
        title: 'Edit GRN',
        data: { mode: 'edit' },
        loadComponent: () =>
          import('./pages/inventory/grn/grn-form.component').then(
            (m) => m.VendorOrderReceiveFormComponent
          ),
      },
      {
        path: 'inventory/supplier-return',
        title: 'Supplier Return',
        loadComponent: () =>
          import('./pages/inventory/supplier-return/supplier-return.component').then(
            (m) => m.ViewSupplierReturnComponent
          ),
      },
      {
        path: 'inventory/supplier-return/new',
        title: 'New Supplier Return',
        data: { mode: 'create' },
        loadComponent: () =>
          import('./pages/inventory/supplier-return/supplier-return-form.component').then(
            (m) => m.VendorReturnFormComponent
          ),
      },
      {
        path: 'inventory/supplier-return/:id/edit',
        title: 'Edit Supplier Return',
        data: { mode: 'edit' },
        loadComponent: () =>
          import('./pages/inventory/supplier-return/supplier-return-form.component').then(
            (m) => m.VendorReturnFormComponent
          ),
      },

      // ---- Stock Count ----
      {
        path: 'inventory/stock-count-adjustment',
        title: 'Stock Count Adjustment',
        loadComponent: () =>
          import('./pages/inventory/stock-count-adjustment/stock-count-adjustment.component').then(
            (m) => m.ViewStockCountAdjustmentComponent
          ),
      },
      {
        path: 'inventory/stock-count-adjustment/new',
        title: 'New Stock Count Adjustment',
        data: { mode: 'create' },
        loadComponent: () =>
          import('./pages/inventory/stock-count-adjustment/stock-count-adjustment-form.component').then(
            (m) => m.InventoryStockCountFormComponent
          ),
      },
      {
        path: 'inventory/stock-count-adjustment/:id/edit',
        title: 'Edit Stock Count Adjustment',
        data: { mode: 'edit' },
        loadComponent: () =>
          import('./pages/inventory/stock-count-adjustment/stock-count-adjustment-form.component').then(
            (m) => m.InventoryStockCountFormComponent
          ),
      },
      {
        path: 'inventory/stock-count-list',
        title: 'Stock Count List',
        loadComponent: () =>
          import('./pages/inventory/stock-count-list/stock-count-list.component').then(
            (m) => m.ViewStockCountListComponent
          ),
      },
      {
        path: 'inventory/stock-count-list/new',
        title: 'New Stock Count List',
        data: { mode: 'create' },
        loadComponent: () =>
          import('./pages/inventory/stock-count-list/stock-count-list-form.component').then(
            (m) => m.InventoryStockCountFormComponent
          ),
      },
      {
        path: 'inventory/stock-count-list/:id/edit',
        title: 'Edit Stock Count List',
        data: { mode: 'edit' },
        loadComponent: () =>
          import('./pages/inventory/stock-count-list/stock-count-list-form.component').then(
            (m) => m.InventoryStockCountFormComponent
          ),
      },

      // ---- Administration / Procurement / Reports ----
      {
        path: 'administration',
        title: 'Administration',
        data: { titleKey: 'MENU.ADMINISTRATION', parentKey: 'MENU.INVENTORY' },
        loadComponent: () =>
          import('./pages/inventory/generic-list/generic-list.component').then(
            (m) => m.GenericListComponent
          ),
      },
      {
        path: 'procurement',
        title: 'Procurement',
        data: { titleKey: 'MENU.PROCUREMENT', parentKey: 'MENU.INVENTORY' },
        loadComponent: () =>
          import('./pages/inventory/generic-list/generic-list.component').then(
            (m) => m.GenericListComponent
          ),
      },
      {
        path: 'reports',
        title: 'Reports',
        loadComponent: () =>
          import('./pages/reports/reports.component').then((m) => m.ReportsComponent),
      },

      // ---- Procurement / Vendor Order ----
      {
        path: 'procurement/purchase-request',
        title: 'Purchase Request',
        loadComponent: () =>
          import('./pages/Procurement/purchase-request/purchase-request.component').then(
            (m) => m.ViewPurchaseRequestComponent
          ),
      },
      {
        path: 'procurement/purchase-request/new',
        title: 'New Purchase Request',
        data: { mode: 'create' },
        loadComponent: () =>
          import('./pages/Procurement/purchase-request/purchase-request.component').then(
            (m) => m.ViewPurchaseRequestComponent
          ),
      },
      {
        path: 'procurement/purchase-request/:id/edit',
        title: 'Edit Purchase Request',
        data: { mode: 'edit' },
        loadComponent: () =>
          import('./pages/Procurement/purchase-request/purchase-request.component').then(
            (m) => m.ViewPurchaseRequestComponent
          ),
      },
      {
        path: 'procurement/purchase-request-assign',
        title: 'Purchase Request Assign',
        loadComponent: () =>
          import('./pages/Procurement/purchase-request-assign/purchase-request-assign.component').then(
            (m) => m.ViewPurchaseRequestAssignComponent
          ),
      },
      {
        path: 'procurement/request-for-quotation',
        title: 'Request For Quotation',
        loadComponent: () =>
          import('./pages/Procurement/request-for-quotation/request-for-quotation.component').then(
            (m) => m.ViewRequestForQuotationComponent
          ),
      },
      {
        path: 'procurement/delivery-order',
        title: 'Delivery Order',
        loadComponent: () =>
          import('./pages/Procurement/delivery-order/delivery-order.component').then(
            (m) => m.ViewDeliveryOrderComponent
          ),
      },
      {
        path: 'procurement/purchase-order',
        title: 'Purchase Order',
        loadComponent: () =>
          import('./pages/Procurement/purchase-order/purchase-order.component').then(
            (m) => m.ViewPurchaseOrderComponent
          ),
      },
      {
        path: 'procurement/supplier-order-variance',
        title: 'Supplier Order Variance',
        loadComponent: () =>
          import('./pages/Procurement/supplier-order-variance/supplier-order-variance.component').then(
            (m) => m.ViewSupplierOrderVarianceComponent
          ),
      },
      {
        path: 'procurement/purchase-order-consumable',
        title: 'Purchase Order Consumable',
        loadComponent: () =>
          import('./pages/Procurement/purchase-order-consumable/purchase-order-consumable.component').then(
            (m) => m.ViewPurchaseOrderConsumableComponent
          ),
      },

      // ---- Generated Administration pages ----
      ...administrationRoutes,

      // ---- Generated Procurement pages ----
      ...procurementRoutes,

      // ---- Generated Inventory entities ----
      ...inventoryExtraRoutes,

      // ---- Generated Reports ----
      ...reportsRoutes,

      // ---- Generated Other entities ----
      ...otherRoutes,

      { path: '**', redirectTo: 'dashboard' },
    ],
  },
];