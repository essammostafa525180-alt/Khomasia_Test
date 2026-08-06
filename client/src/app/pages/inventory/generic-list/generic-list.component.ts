import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { PageHeaderComponent } from '../../../shared/page-header/page-header.component';
import { DataGridComponent } from '../../../shared/data-grid/data-grid.component';
import { BreadcrumbItem } from '../../../shared/page-header/breadcrumb-item.model';
import { GridColumn } from '../../../shared/data-grid/data-grid/grid-column.model';
import { PdfExportService } from '../../../services/pdf-export.service';

@Component({
  selector: 'app-generic-list',
  standalone: true,
  imports: [CommonModule, PageHeaderComponent, DataGridComponent],
  template: `
    <app-page-header [title]="pageTitle" [breadcrumbs]="breadcrumbs"></app-page-header>
    <app-data-grid
      [columns]="columns"
      [data]="data"
      (add)="onAdd()"
      (view)="onView($event)"
      (edit)="onEdit($event)"
      (delete)="onDelete($event)"
      (exportPdf)="onExportPdf()"
      (print)="onPrint()"
    ></app-data-grid>
  `,
  host: { style: 'display: contents' }
})
export class GenericListComponent implements OnInit {
  pageTitle = '';
  breadcrumbs: BreadcrumbItem[] = [];
  columns: GridColumn[] = [];
  data: any[] = [];

  constructor(private route: ActivatedRoute, private pdfService: PdfExportService) {}

  ngOnInit(): void {
    const d = this.route.snapshot.data;
    this.pageTitle = d['titleKey'];
    this.breadcrumbs = [
      { label: 'MENU.INVENTORY', link: '/inventory' },
      { label: d['parentKey'] ?? d['titleKey'], link: '/inventory' },
      { label: d['titleKey'] }
    ];
    this.columns = d['columns'] ?? [
      { key: 'code', label: 'GRID.ITEM_NUMBER' },
      { key: 'name', label: 'GRID.ITEM_NAME_EN' },
      { key: 'date', label: 'GRID.DATE' },
      { key: 'status', label: 'GRID.STATUS' },
    ];
    this.data = [];
  }

  onAdd(): void { console.log('Add'); }
  onView(row: any): void { console.log('View', row); }
  onEdit(row: any): void { console.log('Edit', row); }
  onDelete(row: any): void {
    this.data = this.data.filter(r => r !== row);
  }
  onPrint(): void { window.print(); }
  onExportPdf(): void {
    this.pdfService.exportTableToPdf(
      this.pageTitle,
      this.columns.map(c => c.label),
      this.data.map(r => this.columns.map(c => r[c.key])),
      'export.pdf'
    );
  }
}