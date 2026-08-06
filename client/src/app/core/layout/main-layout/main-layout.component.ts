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
}

/** A sidebar accordion group and the routes it contains. */
interface NavGroup extends AccordionItem {
  links?: NavLink[];
  children?: NavGroup[];
}

/** A sidebar row — either an accordion group or a flat link. */
type SidebarItem = (NavLink & { kind: 'link' }) | (NavGroup & { kind: 'group' });

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

  /** Ordered sidebar sections — Inventory first, then Administration,
   *  Procurement, Reports, then the remaining app entries. */
  sidebar: SidebarItem[] = [
    // 1) Inventory — accordion group with sub-groups
    {
      kind: 'group',
      title: 'MENU.INVENTORY',
      icon: 'inventory_2',
      children: [
        {
          title: 'MENU.INVENTORY_MANAGEMENT',
          icon: 'inventory',
          links: [
            { label: 'MENU.ASSET_NAME', path: '/inventory/asset-name' },
            { label: 'MENU.ITEM_CARD', path: '/inventory/item-card' },
            { label: 'MENU.ITEM_BALANCE', path: '/inventory/item-balance' },
            { label: 'MENU.STOCK', path: '/inventory/item-stock' },
            { label: 'MENU.ASSET_MOVE', path: '/inventory/asset-move' },
          ],
        },
        {
          title: 'MENU.INVENTORY_TRANSACTIONS',
          icon: 'swap_horiz',
          links: [
            { label: 'MENU.ISSUE_REQUEST', path: '/inventory/issue-request' },
            { label: 'MENU.ASSET_ISSUE_REQUEST', path: '/inventory/asset-issue-request' },
            { label: 'MENU.ISSUE_OUT', path: '/inventory/issue-out' },
            { label: 'MENU.ITEM_RETURN', path: '/inventory/item-return' },
            { label: 'MENU.TRANSFER', path: '/inventory/transfer' },
          ],
        },
        {
          title: 'MENU.VENDOR_ORDER',
          icon: 'local_shipping',
          links: [
            { label: 'MENU.GRN_QUALITY', path: '/inventory/grn-quality' },
            { label: 'MENU.GRN', path: '/inventory/grn' },
            { label: 'MENU.SUPPLIER_RETURN', path: '/inventory/supplier-return' },
          ],
        },
        {
          title: 'MENU.STOCK_COUNT',
          icon: 'fact_check',
          links: [
            { label: 'MENU.STOCK_COUNT_ADJUST', path: '/inventory/stock-count-adjustment' },
            { label: 'MENU.STOCK_COUNT_LIST', path: '/inventory/stock-count-list' },
          ],
        },
      ],
    },
    // 2) Administration
    { kind: 'link', label: 'MENU.ADMINISTRATION', path: '/administration' },
    // 3) Procurement
    { kind: 'link', label: 'MENU.PROCUREMENT', path: '/procurement' },
    // 4) Reports
    { kind: 'link', label: 'MENU.REPORTS', path: '/reports' },
    // 5) App entry points
    { kind: 'link', label: 'MENU.DASHBOARD', path: '/dashboard' },
    { kind: 'link', label: 'MENU.HOME', path: '/home' },
    // Legacy / master-data pages (rendered last)
    {
      kind: 'group',
      title: 'NAV.MASTER_DATA',
      icon: 'dns',
      links: [{ label: 'NAV.TEST', path: '/test' }],
    },
    {
      kind: 'group',
      title: 'NAV.GEOGRAPHY',
      icon: 'public',
      links: [
        { label: 'NAV.COUNTRIES', path: '/country' },
        { label: 'NAV.CITIES', path: '/city' },
      ],
    },
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
