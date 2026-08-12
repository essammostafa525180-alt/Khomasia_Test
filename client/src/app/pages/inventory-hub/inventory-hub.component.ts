import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LinkPanelComponent } from '../../Shared/link-panel/link-panel.component';
import { PageHeaderComponent } from '../../Shared/page-header/page-header.component';
import { LinkPanelData } from '../../Shared/link-panel/link-panel.model';

@Component({
  selector: 'app-inventory-hub',
  standalone: true,
  imports: [CommonModule, LinkPanelComponent, PageHeaderComponent],
  template: `
    <app-page-header title="MENU.INVENTORY" [breadcrumbs]="[{ label: 'MENU.INVENTORY' }]"></app-page-header>
    <div class="row g-3">
      <div class="col-lg-3 col-md-6" *ngFor="let panel of panels">
<app-link-panel
  [title]="panel.title"
  [icon]="panel.icon"
  [links]="panel.links ?? []">
</app-link-panel>
      </div>
    </div>
  `,
  host: { style: 'display: contents' }
})
export class InventoryHubComponent {
  panels: (LinkPanelData & { icon: string })[] = [
    {
      title: 'MENU.INVENTORY_MANAGEMENT',
      icon: 'bi-grid',
      links: [
        { label: 'MENU.ITEM_CARD', link: '/inventory/item-card', icon: 'bi-card-text' },
        { label: 'MENU.ITEM_BALANCE', link: '/inventory/item-balance', icon: 'bi-clipboard-data' },
        { label: 'MENU.STOCK_COUNT_ADJUST', link: '/inventory/stock-count-adjustment', icon: 'bi-sliders' },
        { label: 'MENU.STOCK', link: '/inventory/item-stock', icon: 'bi-boxes' },
      ]
    },
    {
      title: 'MENU.INVENTORY_TRANSACTIONS',
      icon: 'bi-arrow-left-right',
      links: [
        { label: 'MENU.ISSUE_REQUEST', link: '/inventory/issue-request', icon: 'bi-file-earmark-plus' },
        { label: 'MENU.ISSUE_OUT', link: '/inventory/issue-out', icon: 'bi-box-arrow-up' },
        { label: 'MENU.ITEM_RETURN', link: '/inventory/item-return', icon: 'bi-arrow-return-left' },
        { label: 'MENU.TRANSFER', link: '/inventory/transfer', icon: 'bi-arrow-left-right' },
      ]
    },
    {
      title: 'MENU.VENDOR_ORDER',
      icon: 'bi-truck',
      links: [
        { label: 'MENU.GRN_QUALITY', link: '/inventory/grn-quality', icon: 'bi-patch-check' },
        { label: 'MENU.GRN', link: '/inventory/grn', icon: 'bi-receipt' },
        { label: 'MENU.SUPPLIER_RETURN', link: '/inventory/supplier-return', icon: 'bi-arrow-counterclockwise' },
      ]
    },
    {
      title: 'MENU.STOCK_COUNT',
      icon: 'bi-clipboard-check',
      links: [
        { label: 'MENU.STOCK_COUNT_ADJUST', link: '/inventory/stock-count-adjustment', icon: 'bi-sliders' },
        { label: 'MENU.STOCK_COUNT_LIST', link: '/inventory/stock-count-list', icon: 'bi-list-check' },
      ]
    },
  ];
}