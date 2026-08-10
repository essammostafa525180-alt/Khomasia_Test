import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { SelectionModel } from '@angular/cdk/collections';
import { InventoryTransfereDetailBatch } from '../../../Shared/Model/-inventory-transfere-detail-batch.model';
import { InventoryTransfereDetailBatchService } from './inventory-transfere-detail-batch.service';
import { SharedService } from '../../../core/services/shared.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormViewModeService } from '../../../core/services/form-view-mode.service';
import { ExportColumn } from '../../../Shared/Model/ExportColumn';
import { EXPORT_BUTTONS } from '../../../Shared/constants/ExportType.const';
import { InventoryTransfereDetailBatchFormComponent } from './inventory-transfere-detail-batch-form.component';
import { ConfirmDialogComponent } from '../../../Shared/Components/confirm-dialog/confirm-dialog.component';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

@Component({
  selector: 'app-view-inventory-transfere-detail-batch',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './inventory-transfere-detail-batch.component.html',
  styleUrl: './inventory-transfere-detail-batch.component.css',
})
export class ViewInventoryTransfereDetailBatchComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  readonly exportButtons = EXPORT_BUTTONS;

  pageSize = 10;
  searchText = '';

  dataSource = new MatTableDataSource<InventoryTransfereDetailBatch>([]);
  selection = new SelectionModel<InventoryTransfereDetailBatch>(true, []);

  displayedColumns: string[] = ['select', 'id', 'newBatchNumber', 'qunatity', 'expiryDate', 'actions'];

  exportColumns: ExportColumn[] = [
    { key: 'id', label: 'ID' },
    { key: 'newBatchNumber', label: 'New Batch Number' },
    { key: 'qunatity', label: 'Qunatity' },
    { key: 'expiryDate', label: 'Expiry Date' },
  ];

  constructor(
    public service: InventoryTransfereDetailBatchService,
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
     this.service.getAll<InventoryTransfereDetailBatch[]>().subscribe((data) => {
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
     this.router.navigate(['/inventory/inventory-transfere-detail-batch/new']);
   }

   onEdit(row: InventoryTransfereDetailBatch): void {
     if (this.viewMode.isDialog()) {
       this.openForm({ mode: 'edit', item: row });
       return;
     }
     this.router.navigate(['/inventory/inventory-transfere-detail-batch', row.id, 'edit']);
   }

   onDelete(row: InventoryTransfereDetailBatch): void {
     this.dialog
       .open(ConfirmDialogComponent, {
         width: '400px',
         data: { title: 'Delete Inventory Transfere Detail Batch', message: 'Delete "' + (row.newBatchNumber ?? row.id) + '"? This action sets the record inactive (soft delete).' },
       })
       .afterClosed()
       .subscribe((confirmed) => {
         if (!confirmed) return;
         this.service.softDelete(row.id).subscribe({
           next: () => {
             this.notification.success('Inventory Transfere Detail Batch removed (soft delete).');
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

  checkboxLabel(row?: InventoryTransfereDetailBatch): string {
    if (!row) return `${this.isAllSelected() ? 'deselect' : 'select'} all`;
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row`;
  }

  private openForm(data: { mode: 'create' | 'edit'; item?: InventoryTransfereDetailBatch }): void {
    this.dialog
      .open(InventoryTransfereDetailBatchFormComponent, { width: '720px', panelClass: 'crud-dialog', data })
      .afterClosed()
      .subscribe((saved) => {
        if (saved) this.loadData();
      });
  }
}
