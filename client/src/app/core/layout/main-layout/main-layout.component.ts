import { Component, inject } from '@angular/core';
import { Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { MatButtonToggleChange } from '@angular/material/button-toggle';
import { AccordionItem } from '../../../Shared/Model/AccordionItem';
import { FormViewMode } from '../../../Shared/Model/FormViewMode';
import { FormViewModeService } from '../../services/form-view-mode.service';
import { FooterComponent } from '../footer/footer.component';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';
import { ThemeService } from '../../services/theme.service';
import { I18nService } from '../../services/i18n.service';

/** A single sidebar entry (flat link). */
interface NavLink {
  label: string;
  path: string;
  icon?: string;
}

/** A sidebar accordion group and the routes it contains. */
interface NavGroup extends AccordionItem {
  links?: NavLink[];
  children?: NavGroup[];
}

/** A sidebar row — either an accordion group or a flat link. */
export type SidebarItem = (NavLink & { kind: 'link' }) | (NavGroup & { kind: 'group' });

/** Mobile breakpoint — keep in sync with the media query in main-layout.component.css. */
const MOBILE_QUERY = '(max-width: 760px)';

@Component({
  selector: 'app-main-layout',
  imports: [
    MATERIAL_IMPORTS,
    RouterLink,
    RouterOutlet,
    RouterLinkActive,
    FooterComponent,
  ],
  templateUrl: './main-layout.component.html',
  styleUrl: './main-layout.component.css',
})
export class MainLayoutComponent {
  readonly viewMode = inject(FormViewModeService);
  readonly themeService = inject(ThemeService);
  readonly i18n = inject(I18nService);
  private readonly router = inject(Router);

  themeMenuOpen = false;

  /** Sidebar menu — the single source of truth for the side menu. */
  sidebar: SidebarItem[] = [
    { kind: 'link', label: 'MENU.HOME', path: '/home', icon: 'home' },
    {
      kind: 'group',
      title: 'MENU.INVENTORY',
      icon: 'inventory_2',
      children: [
        {
          title: 'MENU.INVENTORY_MANAGEMENT',
          icon: 'grid_view',
          links: [
            { label: 'MENU.ASSET_NAME', path: '/inventory/asset-name', icon: 'sell' },
            { label: 'MENU.ITEM_CARD', path: '/inventory/item-card', icon: 'description' },
            { label: 'MENU.ITEM_BALANCE', path: '/inventory/item-balance', icon: 'assignment' },
            { label: 'MENU.STOCK', path: '/inventory/item-stock', icon: 'category' },
            { label: 'MENU.ASSET_MOVE', path: '/inventory/asset-move', icon: 'swap_horiz' },
          ],
        },
        {
          title: 'MENU.INVENTORY_TRANSACTIONS',
          icon: 'swap_horiz',
          links: [
            { label: 'MENU.ISSUE_REQUEST', path: '/inventory/issue-request', icon: 'note_add' },
            { label: 'MENU.ASSET_ISSUE_REQUEST', path: '/inventory/asset-issue-request', icon: 'note_add' },
            { label: 'MENU.ISSUE_OUT', path: '/inventory/issue-out', icon: 'upload' },
            { label: 'MENU.INVENTORY_ITEM_RETURN', path: '/inventory/item-return', icon: 'undo' },
            { label: 'MENU.TRANSFER', path: '/inventory/transfer', icon: 'swap_horiz' },
          ],
        },
        {
          title: 'MENU.VENDOR_ORDER',
          icon: 'local_shipping',
          links: [
            { label: 'MENU.GRN_QUALITY', path: '/inventory/grn-quality', icon: 'fact_check' },
            { label: 'MENU.GRN', path: '/inventory/grn', icon: 'receipt_long' },
            { label: 'MENU.SUPPLIER_RETURN', path: '/inventory/supplier-return', icon: 'replay' },
          ],
        },
        {
          title: 'MENU.STOCK_COUNT',
          icon: 'fact_check',
          links: [
            { label: 'MENU.STOCK_COUNT_ADJUST', path: '/inventory/stock-count-adjustment', icon: 'tune' },
            { label: 'MENU.STOCK_COUNT_LIST', path: '/inventory/stock-count-list', icon: 'checklist' },
          ],
        },
      ],
    },
    {
      kind: 'group',
      title: 'MENU.ADMINISTRATION',
      icon: 'settings',
      children: [
        {
          title: 'MENU.ADMIN_GENERAL',
          icon: 'business',
          links: [
            { label: 'MENU.INVENTORY_CURRENCY', path: '/inventory/inventory-currency', icon: 'currency_exchange' },
            { label: 'MENU.INVENTORY_YEAR', path: '/inventory/inventory-year', icon: 'calendar_month' },
            { label: 'MENU.COUNTRY', path: '/country', icon: 'public' },
            { label: 'MENU.STATE', path: '/other/state', icon: 'map' },
            { label: 'MENU.CITY', path: '/city', icon: 'location_on' },
            { label: 'MENU.COMPANY', path: '/administration/company', icon: 'business' },
            { label: 'MENU.PROJECT', path: '/other/project', icon: 'view_kanban' },
          ],
        },
        {
          title: 'MENU.ADMIN_APPROVALS',
          icon: 'account_tree',
          links: [
            { label: 'MENU.APPROVAL_SCREEN', path: '/administration/approval-screen', icon: 'desktop_windows' },
            { label: 'MENU.APPROVAL_STATUS', path: '/administration/approval-status', icon: 'check_circle' },
            { label: 'MENU.APPROVAL_MATRIX', path: '/administration/approval-matrix', icon: 'account_tree' },
            { label: 'MENU.APPROVAL_MATRIX_RANGE', path: '/administration/approval-matrix-range', icon: 'open_in_full' },
            { label: 'MENU.APPROVAL_MATRIX_CONFIG', path: '/administration/approval-matrix-config', icon: 'tune' },
          ],
        },
        {
          title: 'MENU.PROC_VENDORS',
          icon: 'local_shipping',
          links: [
            { label: 'MENU.VENDOR_STATUS', path: '/procurement/vendor-status', icon: 'check_box' },
            { label: 'MENU.RANK', path: '/administration/rank', icon: 'star' },
            { label: 'MENU.VENDOR_SPECIALIZATION', path: '/procurement/vendor-specialization', icon: 'workspace_premium' },
            { label: 'MENU.VENDOR_EVALUATION_CRITERION', path: '/procurement/vendor-evaluation-criterion', icon: 'assignment' },
            { label: 'MENU.VENDOR', path: '/procurement/vendor', icon: 'badge' },
          ],
        },
        {
          title: 'MENU.INV_ASSET_MGMT',
          icon: 'category',
          links: [
            { label: 'MENU.ASSETS_GROUP', path: '/inventory/assets-group', icon: 'collections' },
            { label: 'MENU.ASSET_STATUS', path: '/inventory/asset-status', icon: 'verified' },
            { label: 'MENU.INSURANCE_VENDOR', path: '/procurement/insurance-vendor', icon: 'verified_user' },
            { label: 'MENU.MANUFACTURE', path: '/inventory/manufacture', icon: 'build' },
          ],
        },
        {
          title: 'MENU.INV_STORES_LOCATIONS',
          icon: 'settings_suggest',
          links: [
            { label: 'MENU.ISLE', path: '/inventory/isle', icon: 'signpost' },
            { label: 'MENU.RACK', path: '/inventory/rack', icon: 'storage' },
            { label: 'MENU.SHELF', path: '/inventory/shelf', icon: 'shelves' },
            { label: 'MENU.ITEM_TYPE', path: '/inventory/item-type', icon: 'sell' },
            { label: 'MENU.ITEM_EXPIRY_TYPE', path: '/inventory/item-expiry-type', icon: 'hourglass_top' },
            { label: 'MENU.UNIT_OF_MEASURE', path: '/inventory/unit-of-measure', icon: 'straighten' },
            { label: 'MENU.VENDOR_ORDER_STATUS', path: '/procurement/vendor-order-status', icon: 'task_alt' },
            { label: 'MENU.VENDOR_ORDER_TYPE', path: '/procurement/vendor-order-type', icon: 'description' },
            { label: 'MENU.ITEM_REQUEST_STATUS', path: '/inventory/item-request-status', icon: 'hourglass_top' },
            { label: 'MENU.TRANSFER_REASON', path: '/inventory/transfer-reason', icon: 'chat' },
            { label: 'MENU.REQUEST_LINE_ITEM_STATUS', path: '/procurement/request-line-item-status', icon: 'checklist' },
            { label: 'MENU.ORDER_LINE_ITEM_STATUS', path: '/procurement/order-line-item-status', icon: 'checklist' },
            { label: 'MENU.RETURN_STATUS', path: '/inventory/return-status', icon: 'replay' },
            { label: 'MENU.MATERIAL_GROUP', path: '/inventory/material-group', icon: 'folder' },
            { label: 'MENU.MATERIAL_CATEGORY', path: '/inventory/material-category', icon: 'folder' },
            { label: 'MENU.MATERIAL_SUB_CATEGORY', path: '/inventory/material-sub-category', icon: 'folder_open' },
            { label: 'MENU.STOCK_COUNT_PLAN_TYPE', path: '/inventory/stock-count-plan-type', icon: 'playlist_add' },
            { label: 'MENU.STOCK_COUNT_PLAN_STATUS', path: '/inventory/stock-count-plan-status', icon: 'assignment_turned_in' },
            { label: 'MENU.TRANSFER_TYPE', path: '/inventory/transfere-type', icon: 'swap_horiz' },
            { label: 'MENU.RETURN_REASON', path: '/inventory/return-reason', icon: 'chat' },
            { label: 'MENU.TRANSFER_STATUS', path: '/inventory/transfer-status', icon: 'check_box' },
            { label: 'MENU.WORKER_TYPE', path: '/other/worker-type', icon: 'badge' },
          ],
        },
      ],
    },
    
    {
      kind: 'group',
      title: 'MENU.PROCUREMENT',
      icon: 'shopping_cart',
      children: [
        {
          title: 'MENU.VENDOR_ORDER',
          icon: 'local_shipping',
          links: [
            { label: 'MENU.PURCHASE_REQUEST', path: '/procurement/purchase-request', icon: 'description' },
            { label: 'MENU.PURCHASE_REQUEST_ASSIGN', path: '/procurement/purchase-request-assign', icon: 'assignment' },
            { label: 'MENU.REQUEST_FOR_QUOTATION', path: '/procurement/request-for-quotation', icon: 'request_quote' },
            { label: 'MENU.DELIVERY_ORDER', path: '/procurement/delivery-order', icon: 'local_shipping' },
            { label: 'MENU.PURCHASE_ORDER', path: '/procurement/purchase-order', icon: 'shopping_cart' },
            { label: 'MENU.SUPPLIER_ORDER_VARIANCE', path: '/procurement/supplier-order-variance', icon: 'compare_arrows' },
            { label: 'MENU.PURCHASE_ORDER_CONSUMABLE', path: '/procurement/purchase-order-consumable', icon: 'inventory_2' },
          ],
        },
      ],
    },
    { kind: 'link', label: 'MENU.REPORTS', path: '/reports', icon: 'bar_chart' },
  ];

  /** Sidebar starts collapsed on mobile, expanded on wider screens. */
  sidebarOpen = !this.isMobile();

  /** True when the current URL is inside the group, so it opens on load/refresh. */
  isGroupActive(group: NavGroup): boolean {
    const paths = [
      ...(group.links ?? []).map((link) => link.path),
      ...(group.children ?? []).flatMap((child) => (child.links ?? []).map((link) => link.path)),
    ];
    return paths.some((path) => this.router.url.startsWith(path));
  }

  toggleSidebar(): void {
    this.sidebarOpen = !this.sidebarOpen;
  }

  /** On mobile the sidebar overlays the content, so close it once a link is used. */
  closeSidebarOnMobile(): void {
    if (this.isMobile()) this.sidebarOpen = false;
  }

  private isMobile(): boolean {
    return window.matchMedia(MOBILE_QUERY).matches;
  }

  onViewModeChange(event: MatButtonToggleChange): void {
    this.viewMode.set(event.value as FormViewMode);
  }

  selectTheme(themeId: string): void {
    this.themeService.setTheme(themeId);
  }

  setLang(lang: 'en' | 'ar'): void {
    this.i18n.setLang(lang);
  }
}
