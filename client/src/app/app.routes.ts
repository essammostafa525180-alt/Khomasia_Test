import { Routes } from '@angular/router';
import { MainLayoutComponent } from './core/layout/main-layout/main-layout.component';

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
        data: { titleKey: 'MENU.ASSET_NAME', parentKey: 'MENU.INVENTORY_MANAGEMENT' },
        loadComponent: () =>
          import('./pages/inventory/generic-list/generic-list.component').then(
            (m) => m.GenericListComponent
          ),
      },
      {
        path: 'inventory/item-card',
        title: 'Item Card',
        loadComponent: () =>
          import('./Feature/inventory/view-inventory/view-inventory.component').then(
            (m) => m.ViewInventoryComponent
          ),
      },
      {
        path: 'inventory/item-balance',
        title: 'Item Balance',
        loadComponent: () =>
          import('./pages/inventory/item-balance/item-balance.component').then(
            (m) => m.ItemBalanceComponent
          ),
      },
      {
        path: 'inventory/item-stock',
        title: 'Item Stock',
        loadComponent: () =>
          import('./pages/inventory/item-stock/item-stock.component').then(
            (m) => m.ItemStockComponent
          ),
      },
      {
        path: 'inventory/asset-move',
        title: 'Asset Item Move',
        data: { titleKey: 'MENU.ASSET_MOVE', parentKey: 'MENU.INVENTORY_MANAGEMENT' },
        loadComponent: () =>
          import('./pages/inventory/generic-list/generic-list.component').then(
            (m) => m.GenericListComponent
          ),
      },

      // ---- Inventory Transactions ----
      {
        path: 'inventory/issue-request',
        title: 'Issue Request',
        loadComponent: () =>
          import('./pages/inventory/material-request/material-request.component').then(
            (m) => m.MaterialRequestComponent
          ),
      },
      {
        path: 'inventory/asset-issue-request',
        title: 'Asset Issue Request',
        data: { titleKey: 'MENU.ASSET_ISSUE_REQUEST', parentKey: 'MENU.INVENTORY_TRANSACTIONS' },
        loadComponent: () =>
          import('./pages/inventory/generic-list/generic-list.component').then(
            (m) => m.GenericListComponent
          ),
      },
      {
        path: 'inventory/issue-out',
        title: 'Issue Out',
        loadComponent: () =>
          import('./pages/inventory/issue-out/issue-out.component').then(
            (m) => m.IssueOutComponent
          ),
      },
      {
        path: 'inventory/item-return',
        title: 'Item Return',
        loadComponent: () =>
          import('./pages/inventory/item-return/item-return.component').then(
            (m) => m.ItemReturnComponent
          ),
      },
      {
        path: 'inventory/transfer',
        title: 'Transfer',
        loadComponent: () =>
          import('./pages/inventory/transfer/transfer.component').then(
            (m) => m.TransferComponent
          ),
      },

      // ---- Vendor Order ----
      {
        path: 'inventory/grn-quality',
        title: 'GRN Quality',
        loadComponent: () =>
          import('./pages/inventory/grn-quality/grn-quality.component').then(
            (m) => m.GrnQualityComponent
          ),
      },
      {
        path: 'inventory/grn',
        title: 'GRN',
        loadComponent: () =>
          import('./pages/inventory/grn/grn.component').then((m) => m.GrnComponent),
      },
      {
        path: 'inventory/supplier-return',
        title: 'Supplier Return',
        loadComponent: () =>
          import('./pages/inventory/supplier-return/supplier-return.component').then(
            (m) => m.SupplierReturnComponent
          ),
      },

      // ---- Stock Count ----
      {
        path: 'inventory/stock-count-adjustment',
        title: 'Stock Count Adjustment',
        loadComponent: () =>
          import('./pages/inventory/stock-count-adjustment/stock-count-adjustment.component').then(
            (m) => m.StockCountAdjustmentComponent
          ),
      },
      {
        path: 'inventory/stock-count-list',
        title: 'Stock Count List',
        loadComponent: () =>
          import('./pages/inventory/stock-count-list/stock-count-list.component').then(
            (m) => m.StockCountListComponent
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

      { path: '**', redirectTo: 'dashboard' },
    ],
  },
];