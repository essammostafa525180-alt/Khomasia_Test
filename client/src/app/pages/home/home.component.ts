import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LinkPanelData } from '../../Shared/link-panel/link-panel.model';
import { LinkPanelComponent } from '../../Shared/link-panel/link-panel.component';
import { PageHeaderComponent } from '../../Shared/page-header/page-header.component';

@Component({
  selector: 'app-home',
  standalone: true,

  imports: [
    CommonModule,
    LinkPanelComponent,
    PageHeaderComponent
  ],

  templateUrl: './home.component.html',
  styleUrl: './home.component.css',

  host: {
    style: 'display: contents'
  }
})
export class HomeComponent {

  panels: LinkPanelData[] = [

    // =====================================================
    // INVENTORY MANAGEMENT
    // =====================================================

    {
      title: 'Inventory Management',
      icon: 'bi-box-seam',

      links: [
        {
          label: 'Item Card',
          link: '/inventory/item-card',
          icon: 'bi-card-text'
        },
        {
          label: 'Inventory Item Balance',
          link: '/inventory/item-balance',
          icon: 'bi-bar-chart-line'
        },
        {
          label: 'Stock Count Adjustment',
          link: '/inventory/stock-count-adjustment',
          icon: 'bi-clipboard-check'
        },
        {
          label: 'Item Stock',
          link: '/inventory/item-stock',
          icon: 'bi-boxes'
        }
      ]
    },


    // =====================================================
    // INVENTORY TRANSACTIONS
    // =====================================================

    {
      title: 'Inventory Transactions',
      icon: 'bi-arrow-left-right',

      links: [
        {
          label: 'Material Request',
          link: '/inventory/issue-request',
          icon: 'bi-file-earmark-text'
        },
        {
          label: 'Issue out',
          link: '/inventory/issue-out',
          icon: 'bi-box-arrow-up'
        },
        {
          label: 'Inventory Item Return',
          link: '/inventory/item-return',
          icon: 'bi-arrow-return-left'
        },
        {
          label: 'Inventory Transfer',
          link: '/inventory/transfer',
          icon: 'bi-arrow-left-right'
        }
      ]
    },


    // =====================================================
    // VENDOR ORDER
    // =====================================================

    {
      title: 'Vendor Order',
      icon: 'bi-cart-check',

      links: [
        {
          label: 'GRN Quality',
          link: '/inventory/grn-quality',
          icon: 'bi-check2-square'
        },
        {
          label: 'Goods Received Note',
          link: '/inventory/grn',
          icon: 'bi-receipt'
        },
        {
          label: 'Supplier Return',
          link: '/inventory/supplier-return',
          icon: 'bi-arrow-counterclockwise'
        }
      ]
    },


    // =====================================================
    // STOCK COUNT
    // =====================================================

    {
      title: 'Stock Count',
      icon: 'bi-clipboard-check',

      links: [
        {
          label: 'Stock Count Adjustment',
          link: '/inventory/stock-count-adjustment',
          icon: 'bi-clipboard-data'
        },
        {
          label: 'Stock Count List',
          link: '/inventory/stock-count-list',
          icon: 'bi-list-check'
        }
      ]
    },


    // =====================================================
    // ADMINISTRATION
    // =====================================================

    {
      title: 'Administration',
      icon: 'bi-gear',

      links: [
        {
          label: 'Administration',
          link: '/administration',
          icon: 'bi-gear'
        }
      ]
    },


    // =====================================================
    // PROCUREMENT
    // =====================================================

    {
      title: 'Procurement',
      icon: 'bi-cart',

      links: [
        {
          label: 'Procurement',
          link: '/procurement',
          icon: 'bi-cart'
        }
      ]
    },


    // =====================================================
    // REPORTS
    // =====================================================

    {
      title: 'Reports',
      icon: 'bi-bar-chart',

      links: [
        {
          label: 'Reports',
          link: '/reports',
          icon: 'bi-bar-chart'
        }
      ]
    }

  ];
}