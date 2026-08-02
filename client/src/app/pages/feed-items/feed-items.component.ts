import { Component } from '@angular/core';
import { DataGridComponent } from '../../shared/data-grid/data-grid.component';
import { GridColumn } from '../../shared/data-grid/data-grid/grid-column.model';
import { PageHeaderComponent } from '../../shared/page-header/page-header.component';
import { BreadcrumbItem } from '../../shared/page-header/breadcrumb-item.model';

interface FeedItem {
  itemNumber: string;
  itemName: string;
  category: string;
  quantity: number;
  unit: string;
}

@Component({
  selector: 'app-feed-items',
  standalone: true,
  imports: [DataGridComponent,PageHeaderComponent],
  template: `
    <app-data-grid
      title="أصناف الأعلاف"
      [columns]="columns" 
      [data]="items"
      (add)="onAdd()"
      (view)="onView($event)"
      (edit)="onEdit($event)"
      (delete)="onDelete($event)"
      (exportPdf)="onExportPdf()"
    ></app-data-grid>
        <app-page-header title="بطاقة الصنف" [breadcrumbs]="breadcrumbs"></app-page-header>

  `,
  host: { style: 'display: contents' }
})
export class FeedItemsComponent {
  breadcrumbs: BreadcrumbItem[] = [
    { label: 'المخزون', link: '/inventory' },
    { label: 'بطاقة الصنف' } // آخر عنصر من غير link = الصفحة الحالية
  ];
  columns: GridColumn[] = [
    { key: 'itemNumber', label: 'رقم الصنف' },
    { key: 'itemName', label: 'اسم الصنف' },
    { key: 'category', label: 'الفئة' },
    { key: 'quantity', label: 'الكمية' },
    { key: 'unit', label: 'الوحدة' },
  ];

  items: FeedItem[] = [
    { itemNumber: 'F001', itemName: 'علف نمو', category: 'دواجن', quantity: 500, unit: 'كيس' },
    { itemNumber: 'F002', itemName: 'علف بادئ', category: 'كتاكيت', quantity: 300, unit: 'كيس' },
  ];

  onAdd(): void { /* افتح modal أو انتقل لصفحة إضافة */ }
  onView(item: FeedItem): void { console.log('عرض', item); }
  onEdit(item: FeedItem): void { console.log('تعديل', item); }
  onDelete(item: FeedItem): void {
    this.items = this.items.filter(i => i !== item);
  }
  onExportPdf(): void { /* استخدم PdfExportService اللي عملناه قبل كده */ }
}