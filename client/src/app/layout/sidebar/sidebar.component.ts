import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { SidebarMenuItemComponent } from '../sidebar-menu-item/sidebar-menu-item.component';
import { MenuItem } from './sidebar.model';

@Component({
  selector: 'app-sidebar',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterLink, SidebarMenuItemComponent],
  templateUrl: './sidebar.component.html',
  host: { style: 'display: contents' }
})
export class SidebarComponent {
  searchTerm = '';

menu: MenuItem[] = [
  { label: 'MENU.HOME', link: '/home', icon: 'bi-house' },
  {
    label: 'MENU.INVENTORY', icon: 'bi-box-seam',
    children: [
      {
        label: 'MENU.INVENTORY_MANAGEMENT', icon: 'bi-grid',
        children: [
          { label: 'MENU.ASSET_NAME', link: '/inventory/asset-name', icon: 'bi-tag' },
          { label: 'MENU.ITEM_CARD', link: '/inventory/item-card', icon: 'bi-card-text' },
          { label: 'MENU.ITEM_BALANCE', link: '/inventory/item-balance', icon: 'bi-clipboard-data' },
          { label: 'MENU.STOCK', link: '/inventory/item-stock', icon: 'bi-boxes' },
          { label: 'MENU.ASSET_MOVE', link: '/inventory/asset-move', icon: 'bi-arrow-left-right' },
        ]
      },
      {
        label: 'MENU.INVENTORY_TRANSACTIONS', icon: 'bi-arrow-left-right',
        children: [
          { label: 'MENU.ISSUE_REQUEST', link: '/inventory/issue-request', icon: 'bi-file-earmark-plus' },
          { label: 'MENU.ASSET_ISSUE_REQUEST', link: '/inventory/asset-issue-request', icon: 'bi-file-earmark-plus' },
          { label: 'MENU.ISSUE_OUT', link: '/inventory/issue-out', icon: 'bi-box-arrow-up' },
          { label: 'MENU.ITEM_RETURN', link: '/inventory/item-return', icon: 'bi-arrow-return-left' },
          { label: 'MENU.TRANSFER', link: '/inventory/transfer', icon: 'bi-arrow-left-right' },
        ]
      },
      {
        label: 'MENU.VENDOR_ORDER', icon: 'bi-truck',
        children: [
          { label: 'MENU.GRN_QUALITY', link: '/inventory/grn-quality', icon: 'bi-patch-check' },
          { label: 'MENU.GRN', link: '/inventory/grn', icon: 'bi-receipt' },
          { label: 'MENU.SUPPLIER_RETURN', link: '/inventory/supplier-return', icon: 'bi-arrow-counterclockwise' },
        ]
      },
      {
        label: 'MENU.STOCK_COUNT', icon: 'bi-clipboard-check',
        children: [
          { label: 'MENU.STOCK_COUNT_ADJUST', link: '/inventory/stock-count-adjustment', icon: 'bi-sliders' },
          { label: 'MENU.STOCK_COUNT_LIST', link: '/inventory/stock-count-list', icon: 'bi-list-check' },
        ]
      },
    ]
  },
  { label: 'MENU.ADMINISTRATION', link: '/administration', icon: 'bi-gear' },
  { label: 'MENU.PROCUREMENT', link: '/procurement', icon: 'bi-cart' },
  { label: 'MENU.REPORTS', link: '/reports', icon: 'bi-bar-chart' },
];
  get filteredMenu(): MenuItem[] {
    return this.menu; // ممكن نضيف فلترة تانية لاحقًا لو احتجت
  }
}