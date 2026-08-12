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

/** A sidebar accordion group and the routes it contains. */
interface NavGroup extends AccordionItem {
  links: { label: string; path: string }[];
}

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

  /** Add a menu entry by adding it here — the sidebar renders from this list. */
  navGroups: NavGroup[] = [
    {
      title: 'NAV.MASTER_DATA',
      icon: 'dns',
      links: [{ label: 'NAV.TEST', path: '/test' }],
    },
    {
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
    return group.links.some((link) => this.router.url.startsWith(link.path));
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
