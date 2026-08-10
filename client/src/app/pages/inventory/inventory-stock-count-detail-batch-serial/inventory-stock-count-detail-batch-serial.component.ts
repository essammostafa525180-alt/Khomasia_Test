import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { SelectionModel } from '@angular/cdk/collections';
import { InventoryStockCountDetailBatchSerial } from '../../../Shared/Model/-inventory-stock-count-detail-batch-serial.model';
import { InventoryStockCountDetailBatchSerialService } from './inventory-stock-count-detail-batch-serial.service';
import { SharedService } from '../../../core/services/shared.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormViewModeService } from '../../../core/services/form-view-mode.service';
import { ExportColumn } from '../../../Shared/Model/ExportColumn';
import { EXPORT_BUTTONS } from '../../../Shared/constants/ExportType.const';
import { InventoryStockCountDetailBatchSerialFormComponent } from './inventory-stock-count-detail-batch-serial-form.component';
import { ConfirmDialogComponent } from '../../../Shared/Components/confirm-dialog/confirm-dialog.component';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

@Component({
  selector: 'app-view-inventory-stock-count-detail-batch-serial',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './inventory-stock-count-detail-batch-serial.component.html',
  styleUrl: './inventory-stock-count-detail-batch-serial.component.css',
})
export class ViewInventoryStockCountDetailBatchSerialComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  readonly exportButtons = EXPORT_BUTTONS;

  pageSize = 10;
  searchText = '';

  dataSource = new MatTableDataSource<InventoryStockCountDetailBatchSerial>([]);
  selection = new SelectionModel<InventoryStockCountDetailBatchSerial>(true, []);

  displayedColumns: string[] = ['select', 'id', 'isNew', 'isSerialExist', 'actions'];

  exportColumns: ExportColumn[] = [
    { key: 'id', label: 'ID' },
    { key: 'isNew', label: 'Is New' },
    { key: 'isSerialExist', label: 'Is Serial Exist' },
  ];

  constructor(
    public service: InventoryStockCountDetailBatchSerialService,
    private sharedService: SharedService,
    private notification: NotificationService,
    private viewMode: FormViewModeService,
    private router: Router,
    private dialog: MatDialog,
  ) {}

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.loadData();
  }

   loadData(): void {
     this.service.getAll<InventoryStockCountDetailBatchSerial[]>().subscribe((data) => {
       this.dataSource.data = (data || []).filter((r: any) => r?.isDeleted !== true && r?.IsDeleted !== true);
       this.selection.clear();
     });
   }

   onSearch(): void {
     this.dataSource.filter = this.searchText.trim().toLowerCase();
   }

   onReset(): void {
     this.searchText = '';
     this.dataSource.filter = '';
   }

   onNew(): void {
     if (this.viewMode.isDialog()) {
       this.openForm({ mode: 'create' });
       return;
     }
     this.router.navigate(['/inventory/inventory-stock-count-detail-batch-serial/new']);
   }

   onEdit(row: InventoryStockCountDetailBatchSerial): void {
     if (this.viewMode.isDialog()) {
       this.openForm({ mode: 'edit', item: row });
       return;
     }
     this.router.navigate(['/inventory/inventory-stock-count-detail-batch-serial', row.id, 'edit']);
   }

   onDelete(row: InventoryStockCountDetailBatchSerial): void {
     this.dialog
       .open(ConfirmDialogComponent, {
         width: '400px',
         data: { title: 'Delete Inventory Stock Count Detail Batch Serial', message: 'Delete "' + row.id + '"? This action sets the record inactive (soft delete).' },
       })
       .afterClosed()
       .subscribe((confirmed) => {
         if (!confirmed) return;
         this.service.softDelete(row.id).subscribe({
           next: () => {
             this.notification.success('Inventory Stock Count Detail Batch Serial removed (soft delete).');
             this.loadData();
           },
         });
       });
   }

  onExport(type: string): void {
    const rows = this.selection.selected.length ? this.selection.selected : this.dataSource.filteredData;
    this.sharedService.export(rows, this.exportColumns, type);
  }

  onPageChange(event: PageEvent): void {
    this.pageSize = event.pageSize;
  }

  isAllSelected(): boolean {
    return (
      this.selection.selected.length === this.dataSource.filteredData.length &&
      this.dataSource.filteredData.length > 0
    );
  }

  toggleAllRows(): void {
    if (this.isAllSelected()) {
      this.selection.clear();
    } else {
      this.selection.select(...this.dataSource.filteredData);
    }
  }

  checkboxLabel(row?: InventoryStockCountDetailBatchSerial): string {
    if (!row) return `${this.isAllSelected() ? 'deselect' : 'select'} all`;
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row`;
  }

  private openForm(data: { mode: 'create' | 'edit'; item?: InventoryStockCountDetailBatchSerial }): void {
    this.dialog
      .open(InventoryStockCountDetailBatchSerialFormComponent, { width: '720px', panelClass: 'crud-dialog', data })
      .afterClosed()
      .subscribe((saved) => {
        if (saved) this.loadData();
      });
  }
}
