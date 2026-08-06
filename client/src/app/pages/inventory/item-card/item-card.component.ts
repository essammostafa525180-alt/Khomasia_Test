import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { MatDialog } from '@angular/material/dialog';
import { TranslatePipe } from '@ngx-translate/core';
import { PageHeaderComponent } from '../../../shared/page-header/page-header.component';
import { DataGridComponent } from '../../../shared/data-grid/data-grid.component';
import { BreadcrumbItem } from '../../../shared/page-header/breadcrumb-item.model';
import { GridColumn } from '../../../shared/data-grid/data-grid/grid-column.model';
import { PdfExportService } from '../../../services/pdf-export.service';
import { InventoryItemService } from '../../../services/inventory-item.service';
import { ItemDialogComponent } from './item-dialog.component';
import { InventoryItem } from '../../../Shared/Model/inventory-item.model';

@Component({
  selector: 'app-item-card',
  standalone: true,
  imports: [PageHeaderComponent, DataGridComponent, TranslatePipe],
  template: `
    <app-page-header title="MENU.ITEM_CARD" [breadcrumbs]="breadcrumbs"></app-page-header>

    @if (loadError) {
      <div class="alert alert-danger" role="alert">{{ 'COMMON.LOAD_ERROR' | translate }}</div>
    }

    <app-data-grid
      [columns]="columns"
      [data]="items"
      (add)="onAdd()"
      (view)="onView($event)"
      (edit)="onEdit($event)"
      (delete)="onDelete($event)"
      (searchChanged)="onSearch($event)"
      (exportPdf)="onExportPdf()"
      (exportExcel)="onExportExcel()"
      (exportWord)="onExportWord()"
      (print)="onPrint()"
    ></app-data-grid>
  `,
  host: { style: 'display: contents' }
})
export class ItemCardComponent implements OnInit, OnDestroy {
  breadcrumbs: BreadcrumbItem[] = [
    { label: 'MENU.INVENTORY', link: '/inventory' },
    { label: 'MENU.INVENTORY_MANAGEMENT', link: '/inventory' },
    { label: 'MENU.ITEM_CARD' }
  ];

  columns: GridColumn[] = [
    { key: 'itemNumber', label: 'GRID.ITEM_NUMBER' },
    { key: 'name', label: 'GRID.ITEM_NAME_EN' },
    { key: 'nameAr', label: 'GRID.ITEM_NAME_AR' },
    { key: 'itemCode', label: 'GRID.ITEM_CODE' },
    { key: 'rfid', label: 'GRID.RFID' },
    { key: 'totalQuantity', label: 'GRID.TOTAL_QUANTITY' },
    { key: 'avgCost', label: 'GRID.AVG_COST' },
    { key: 'lastPurchasePrice', label: 'GRID.LAST_PURCHASE_PRICE' },
  ];

  items: InventoryItem[] = [];
  loadError = false;

  private readonly searchSubject = new Subject<string>();
  private searchSubscription?: { unsubscribe(): void };

  constructor(
    private itemService: InventoغryItemService,
    private pdfService: PdfExportService,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.loadItems();
    this.searchSubscription = this.searchSubject
      .pipe(debounceTime(400), distinctUntilChanged())
      .subscribe((term) => this.loadItems(term));
  }

  ngOnDestroy(): void {
    this.searchSubscription?.unsubscribe();
  }

  loadItems(searchText = ''): void {
    this.loadError = false;
    this.itemService.getAll({ pageSize: 1000, searchText }).subscribe({
      next: (result) => (this.items = result.items),
      error: () => {
        this.items = [];
        this.loadError = true;
      }
    });
  }

  onSearch(value: string): void {
    this.searchSubject.next(value);
  }

  onAdd(): void {
    this.openDialog({ mode: 'create' });
  }

  onView(item: InventoryItem): void {
    this.openDialog({ mode: 'view', item });
  }

  onEdit(item: InventoryItem): void {
    this.openDialog({ mode: 'edit', item });
  }

  onDelete(item: InventoryItem): void {
    this.itemService.delete(item.id).subscribe({
      next: () => this.loadItems(),
      error: (error) => console.error('Failed to delete item', error)
    });
  }

  private openDialog(data: { mode: 'create' | 'edit' | 'view'; item?: InventoryItem }): void {
    const dialogRef = this.dialog.open(ItemDialogComponent, {
      data,
      width: '720px'
    });

    dialogRef.afterClosed().subscribe((payload) => {
      if (!payload) return;

      if (data.mode === 'create') {
        this.itemService.create(payload).subscribe({
          next: () => this.loadItems(),
          error: (error) => console.error('Failed to create item', error)
        });
      } else if (data.mode === 'edit' && data.item) {
        this.itemService.update(data.item.id, payload).subscribe({
          next: () => this.loadItems(),
          error: (error) => console.error('Failed to update item', error)
        });
      }
    });
  }

  onExportExcel(): void {
    console.log('Export Excel - لسه هنظبطها');
  }

  onExportWord(): void {
    console.log('Export Word - لسه هنظبطها');
  }

  onPrint(): void {
    window.print();
  }

  onExportPdf(): void {
    this.pdfService.exportTableToPdf(
      'Item Card',
      this.columns.map((c) => c.label),
      this.items.map((item) => this.columns.map((c) => (item as any)[c.key])),
      'item-card.pdf'
    );
  }
}
