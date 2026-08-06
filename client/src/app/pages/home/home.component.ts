import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LinkPanelComponent } from '../../shared/link-panel/link-panel.component';
import { PageHeaderComponent } from '../../shared/page-header/page-header.component';
import { LinkPanelData } from '../../shared/link-panel/link-panel.model';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, LinkPanelComponent, PageHeaderComponent],
  template: `
    <app-page-header title="MENU.HOME" [breadcrumbs]="[{ label: 'MENU.HOME' }]"></app-page-header>
    <div class="row g-3">
      <div class="col-lg-3 col-md-6" *ngFor="let panel of panels">
        <app-link-panel [title]="panel.title" [icon]="panel.icon" [links]="panel.links"></app-link-panel>
      </div>
    </div>
  `,
  host: { style: 'display: contents' }
})
export class HomeComponent {
  panels: (LinkPanelData & { icon: string })[] = [
    {
      title: 'MENU.INVENTORY',
      icon: 'bi-box-seam',
      links: [
        { label: 'MENU.ITEM_CARD', link: '/inventory/item-card', icon: 'bi-card-text' },
        { label: 'MENU.ISSUE_OUT', link: '/inventory/issue-out', icon: 'bi-box-arrow-up' },
        { label: 'MENU.GRN', link: '/inventory/grn', icon: 'bi-receipt' },
        { label: 'MENU.STOCK_COUNT', link: '/inventory/stock-count-list', icon: 'bi-clipboard-check' },
      ]
    },
    {
      title: 'MENU.ADMINISTRATION',
      icon: 'bi-gear',
      links: [
        { label: 'MENU.ADMINISTRATION', link: '/administration', icon: 'bi-gear' },
      ]
    },
    {
      title: 'MENU.PROCUREMENT',
      icon: 'bi-cart',
      links: [
        { label: 'MENU.PROCUREMENT', link: '/procurement', icon: 'bi-cart' },
      ]
    },
    {
      title: 'MENU.REPORTS',
      icon: 'bi-bar-chart',
      links: [
        { label: 'MENU.REPORTS', link: '/reports', icon: 'bi-bar-chart' },
      ]
    },
  ];
}