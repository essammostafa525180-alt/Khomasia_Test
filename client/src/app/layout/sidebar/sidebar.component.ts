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
      label: 'MENU.INVENTORY', icon: 'bi-box-seam-fill',
      children: [
        {
          label: 'MENU.INVENTORY_MANAGEMENT', icon: 'bi-grid-fill',
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
            { label: 'MENU.INVENTORY_ITEM_RETURN', link: '/inventory/item-return', icon: 'bi-arrow-return-left' },
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
          label: 'MENU.STOCK_COUNT', icon: 'bi-clipboard-check-fill',
          children: [
            { label: 'MENU.STOCK_COUNT_ADJUST', link: '/inventory/stock-count-adjustment', icon: 'bi-sliders' },
            { label: 'MENU.STOCK_COUNT_LIST', link: '/inventory/stock-count-list', icon: 'bi-list-check' },
          ]
        },
      ]
    },
    {
      label: 'MENU.ADMINISTRATION', icon: 'bi-gear-fill',
      children: [
        {
          label: 'MENU.ADMIN_GENERAL', icon: 'bi-building',
          children: [
            { label: 'MENU.INVENTORY_CURRENCY', link: '/inventory/inventory-currency', icon: 'bi-currency-exchange' },
            { label: 'MENU.INVENTORY_YEAR', link: '/inventory/inventory-year', icon: 'bi-calendar3' },
            { label: 'MENU.COUNTRY', link: '/country', icon: 'bi-globe-americas' },
            { label: 'MENU.STATE', link: '/other/state', icon: 'bi-map' },
            { label: 'MENU.CITY', link: '/city', icon: 'bi-pin-map' },
            { label: 'MENU.COMPANY', link: '/administration/company', icon: 'bi-building' },
            { label: 'MENU.PROJECT', link: '/other/project', icon: 'bi-kanban' },
          ]
        },
        {
          label: 'MENU.ADMIN_APPROVALS', icon: 'bi-diagram-2-fill',
          children: [
            { label: 'MENU.APPROVAL_SCREEN', link: '/administration/approval-screen', icon: 'bi-display' },
            { label: 'MENU.APPROVAL_STATUS', link: '/administration/approval-status', icon: 'bi-check-circle' },
            { label: 'MENU.APPROVAL_MATRIX', link: '/administration/approval-matrix', icon: 'bi-diagram-2' },
            { label: 'MENU.APPROVAL_MATRIX_RANGE', link: '/administration/approval-matrix-range', icon: 'bi-arrows-expand' },
            { label: 'MENU.APPROVAL_MATRIX_CONFIG', link: '/administration/approval-matrix-config', icon: 'bi-sliders2' },
          ]
        },
        {
          label: 'MENU.PROC_VENDORS', icon: 'bi-truck',
          children: [
            { label: 'MENU.VENDOR_STATUS', link: '/procurement/vendor-status', icon: 'bi-check2-square' },
            { label: 'MENU.RANK', link: '/administration/rank', icon: 'bi-star' },
            { label: 'MENU.VENDOR_SPECIALIZATION', link: '/procurement/vendor-specialization', icon: 'bi-award' },
            { label: 'MENU.VENDOR_EVALUATION_CRITERION', link: '/procurement/vendor-evaluation-criterion', icon: 'bi-clipboard-data' },
            { label: 'MENU.VENDOR', link: '/procurement/vendor', icon: 'bi-person-badge' },
          ]
        },
        {
          label: 'MENU.INV_ASSET_MGMT', icon: 'bi-boxes',
          children: [
            { label: 'MENU.ASSETS_GROUP', link: '/inventory/assets-group', icon: 'bi-collection' },
            { label: 'MENU.ASSET_STATUS', link: '/inventory/asset-status', icon: 'bi-check2-circle' },
            { label: 'MENU.INSURANCE_VENDOR', link: '/procurement/insurance-vendor', icon: 'bi-shield-check' },
            { label: 'MENU.MANUFACTURE', link: '/inventory/manufacture', icon: 'bi-tools' },
          ]
        },
        {
          label: 'MENU.INV_STORES_LOCATIONS', icon: 'bi-gear-wide-connected',
          children: [
            { label: 'MENU.ISLE', link: '/inventory/isle', icon: 'bi-signpost-split' },
            { label: 'MENU.RACK', link: '/inventory/rack', icon: 'bi-hdd-stack' },
            { label: 'MENU.SHELF', link: '/inventory/shelf', icon: 'bi-bookshelf' },
            { label: 'MENU.ITEM_TYPE', link: '/inventory/item-type', icon: 'bi-tags' },
            { label: 'MENU.ITEM_EXPIRY_TYPE', link: '/inventory/item-expiry-type', icon: 'bi-hourglass-split' },
            { label: 'MENU.UNIT_OF_MEASURE', link: '/inventory/unit-of-measure', icon: 'bi-rulers' },
            { label: 'MENU.VENDOR_ORDER_STATUS', link: '/procurement/vendor-order-status', icon: 'bi-check2-all' },
            { label: 'MENU.VENDOR_ORDER_TYPE', link: '/procurement/vendor-order-type', icon: 'bi-file-earmark-ruled' },
            { label: 'MENU.ITEM_REQUEST_STATUS', link: '/inventory/item-request-status', icon: 'bi-hourglass-split' },
            { label: 'MENU.TRANSFER_REASON', link: '/inventory/transfer-reason', icon: 'bi-chat-square-text' },
            { label: 'MENU.REQUEST_LINE_ITEM_STATUS', link: '/procurement/request-line-item-status', icon: 'bi-list-check' },
            { label: 'MENU.ORDER_LINE_ITEM_STATUS', link: '/procurement/order-line-item-status', icon: 'bi-list-check' },
            { label: 'MENU.RETURN_STATUS', link: '/inventory/return-status', icon: 'bi-arrow-counterclockwise' },
            { label: 'MENU.MATERIAL_GROUP', link: '/inventory/material-group', icon: 'bi-collection-fill' },
            { label: 'MENU.MATERIAL_CATEGORY', link: '/inventory/material-category', icon: 'bi-folder' },
            { label: 'MENU.MATERIAL_SUB_CATEGORY', link: '/inventory/material-sub-category', icon: 'bi-folder2-open' },
            { label: 'MENU.STOCK_COUNT_PLAN_TYPE', link: '/inventory/stock-count-plan-type', icon: 'bi-clipboard-plus' },
            { label: 'MENU.STOCK_COUNT_PLAN_STATUS', link: '/inventory/stock-count-plan-status', icon: 'bi-clipboard-check' },
            { label: 'MENU.TRANSFERE_TYPE', link: '/inventory/transfere-type', icon: 'bi-arrow-left-right' },
            { label: 'MENU.RETURN_REASON', link: '/inventory/return-reason', icon: 'bi-chat-left-text' },
            { label: 'MENU.TRANSFER_STATUS', link: '/inventory/transfer-status', icon: 'bi-check2-square' },
            { label: 'MENU.WORKER_TYPE', link: '/other/worker-type', icon: 'bi-person-workspace' },
          ]
        },
      ]
    },
    {
      label: 'MENU.PROCUREMENT', icon: 'bi-basket3-fill',
      children: [
        {
          label: 'MENU.VENDOR_ORDER', icon: 'bi-truck',
          children: [
            { label: 'MENU.PURCHASE_REQUEST', link: '/procurement/purchase-request', icon: 'bi-file-earmark-text' },
            { label: 'MENU.PURCHASE_REQUEST_ASSIGN', link: '/procurement/purchase-request-assign', icon: 'bi-clipboard-check' },
            { label: 'MENU.REQUEST_FOR_QUOTATION', link: '/procurement/request-for-quotation', icon: 'bi-question-circle' },
            { label: 'MENU.DELIVERY_ORDER', link: '/procurement/delivery-order', icon: 'bi-truck' },
            { label: 'MENU.PURCHASE_ORDER', link: '/procurement/purchase-order', icon: 'bi-cart-check' },
            { label: 'MENU.SUPPLIER_ORDER_VARIANCE', link: '/procurement/supplier-order-variance', icon: 'bi-arrow-left-right' },
            { label: 'MENU.PURCHASE_ORDER_CONSUMABLE', link: '/procurement/purchase-order-consumable', icon: 'bi-box-seam' },
          ],
        },
      ],
    },
    {
      label: 'MENU.REPORTS', icon: 'bi-file-earmark-text-fill', link: '/reports',
    },
  ];

  get filteredMenu(): MenuItem[] {
    return this.menu; 
  }
}