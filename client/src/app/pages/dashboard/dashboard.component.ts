// import { Component } from '@angular/core';
// import { DataGridComponent } from '../../shared/data-grid/data-grid.component';
// import { GridColumn } from '../../shared/data-grid/data-grid/grid-column.model';

// interface FeedItem {
//   itemNumber: string;
//   itemName: string;
//   category: string;
//   quantity: number;
//   unit: string;
// }

// @Component({
//   selector: 'app-dashboard',
//   standalone: true,
//   imports: [DataGridComponent],
//   template: `
//     <app-data-grid
//       title="أصناف الأعلاف"
//       [columns]="columns"
//       [data]="items"
//       (add)="onAdd()"
//       (view)="onView($event)"
//       (edit)="onEdit($event)"
//       (delete)="onDelete($event)"
//     ></app-data-grid>
//   `,
//   host: { style: 'display: contents' }
// })
// export class DashboardComponent {
//   columns: GridColumn[] = [
//     { key: 'itemNumber', label: 'رقم الصنف' },
//     { key: 'itemName', label: 'اسم الصنف' },
//     { key: 'category', label: 'الفئة' },
//     { key: 'quantity', label: 'الكمية' },
//     { key: 'unit', label: 'الوحدة' },
//   ];

//   items: FeedItem[] = [
//     { itemNumber: 'F001', itemName: 'علف نمو', category: 'دواجن', quantity: 500, unit: 'كيس' },
//     { itemNumber: 'F002', itemName: 'علف بادئ', category: 'كتاكيت', quantity: 300, unit: 'كيس' },
//   ];

//   onAdd(): void { console.log('إضافة'); }
//   onView(item: FeedItem): void { console.log('عرض', item); }
//   onEdit(item: FeedItem): void { console.log('تعديل', item); }
//   onDelete(item: FeedItem): void {
//     this.items = this.items.filter(i => i !== item);
//   }
// }




// import { Component } from '@angular/core';
// import { StatBoxComponent } from '../../shared/stat-box/stat-box.component';
// import { LineChartComponent } from '../../shared/line-chart/line-chart.component';

// @Component({
//   selector: 'app-dashboard',
//   standalone: true,
//   imports: [StatBoxComponent, LineChartComponent],
//   template: `
//     <div class="row">
//       <div class="col-lg-3 col-6">
//         <app-stat-box value="1,250" label="إجمالي الأصناف" icon="bi-box-seam" color="primary"></app-stat-box>
//       </div>
//       <div class="col-lg-3 col-6">
//         <app-stat-box value="85" label="أصناف منخفضة المخزون" icon="bi-exclamation-triangle" color="danger"></app-stat-box>
//       </div>
//       <div class="col-lg-3 col-6">
//         <app-stat-box value="320" label="أوامر شراء هذا الشهر" icon="bi-cart-check" color="success"></app-stat-box>
//       </div>
//       <div class="col-lg-3 col-6">
//         <app-stat-box value="45" label="موردين نشطين" icon="bi-truck" color="warning"></app-stat-box>
//       </div>
//     </div>

//     <div class="row mt-3">
//       <div class="col-lg-8">
//         <app-line-chart
//           title="حركة المخزون (كميات الوارد والمنصرف)"
//           [labels]="months"
//           [dataset1]="incoming"
//           dataset1Label="وارد"
//           [dataset2]="outgoing"
//           dataset2Label="منصرف"
//         ></app-line-chart>
//       </div>
//     </div>
//   `,
//   host: { style: 'display: contents' }
// })
// export class DashboardComponent {
//   months = ['يناير', 'فبراير', 'مارس', 'أبريل', 'مايو', 'يونيو'];
//   incoming = [65, 78, 80, 75, 60, 90];
//   outgoing = [40, 45, 60, 40, 65, 55];
// }







import { Component } from '@angular/core';
import { StatBoxComponent } from '../../Shared/stat-box/stat-box.component';
import { LineChartComponent } from '../../Shared/line-chart/line-chart.component';
import { TopItemsComponent } from '../../Shared/top-items/top-items.component';
import { DonutChartComponent } from '../../Shared/donut-chart/donut-chart.component';
import { TopItem } from '../../Shared/top-items/top-items.model';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [StatBoxComponent, LineChartComponent, TopItemsComponent, DonutChartComponent],
  template: `
    <div class="row">
      <div class="col-lg-3 col-6">
        <app-stat-box value="1,250" label="إجمالي الأصناف" icon="bi-box-seam" color="primary"></app-stat-box>
      </div>
      <div class="col-lg-3 col-6">
        <app-stat-box value="85" label="أصناف منخفضة المخزون" icon="bi-exclamation-triangle" color="danger"></app-stat-box>
      </div>
      <div class="col-lg-3 col-6">
        <app-stat-box value="320" label="أوامر شراء هذا الشهر" icon="bi-cart-check" color="success"></app-stat-box>
      </div>
      <div class="col-lg-3 col-6">
        <app-stat-box value="45" label="موردين نشطين" icon="bi-truck" color="warning"></app-stat-box>
      </div>
    </div>

    <div class="row mt-3">
      <div class="col-lg-8">
        <app-line-chart
          title="حركة المخزون (كميات الوارد والمنصرف)"
          [labels]="months"
          [dataset1]="incoming"
          dataset1Label="وارد"
          [dataset2]="outgoing"
          dataset2Label="منصرف"
        ></app-line-chart>
      </div>
      <div class="col-lg-4">
        <app-top-items title="الأصناف الأكثر استهلاكًا" [items]="topItems"></app-top-items>
      </div>
    </div>

    <div class="row mt-3">
      <div class="col-lg-4">
        <app-donut-chart title="توزيع المخزون حسب الفئة" [labels]="categoryLabels" [values]="categoryValues"></app-donut-chart>
      </div>
    </div>
  `,
  host: { style: 'display: contents' }
})
export class DashboardComponent {
  months = ['يناير', 'فبراير', 'مارس', 'أبريل', 'مايو', 'يونيو'];
  incoming = [65, 78, 80, 75, 60, 90];
  outgoing = [40, 45, 60, 40, 65, 55];

  topItems: TopItem[] = [
    { name: 'علف نمو دواجن', quantity: 3200, unit: 'كيس' },
    { name: 'علف بادئ كتاكيت', quantity: 2100, unit: 'كيس' },
    { name: 'ذرة صفراء', quantity: 1800, unit: 'طن' },
    { name: 'فول صويا', quantity: 1450, unit: 'طن' },
    { name: 'بريمكس فيتامينات', quantity: 600, unit: 'كيس' },
  ];

  categoryLabels = ['أعلاف دواجن', 'أعلاف كتاكيت', 'مواد خام', 'إضافات'];
  categoryValues = [45, 25, 20, 10];
}