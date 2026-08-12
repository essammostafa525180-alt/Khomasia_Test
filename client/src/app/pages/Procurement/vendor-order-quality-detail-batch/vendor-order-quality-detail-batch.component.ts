import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { SelectionModel } from '@angular/cdk/collections';
import { VendorOrderQualityDetailBatch } from '../../../Shared/Model/-vendor-order-quality-detail-batch.model';
import { VendorOrderQualityDetailBatchService } from './vendor-order-quality-detail-batch.service';
import { SharedService } from '../../../core/services/shared.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormViewModeService } from '../../../core/services/form-view-mode.service';
import { ExportColumn } from '../../../Shared/Model/ExportColumn';
import { EXPORT_BUTTONS } from '../../../Shared/constants/ExportType.const';
import { VendorOrderQualityDetailBatchFormComponent } from './vendor-order-quality-detail-batch-form.component';
import { ConfirmDialogComponent } from '../../../Shared/Components/confirm-dialog/confirm-dialog.component';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

@Component({
  selector: 'app-view-vendor-order-quality-detail-batch',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './vendor-order-quality-detail-batch.component.html',
  styleUrl: './vendor-order-quality-detail-batch.component.css',
})
export class ViewVendorOrderQualityDetailBatchComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  readonly exportButtons = EXPORT_BUTTONS;

  pageSize = 10;
  searchText = '';

  dataSource = new MatTableDataSource<VendorOrderQualityDetailBatch>([]);
  selection = new SelectionModel<VendorOrderQualityDetailBatch>(true, []);

  displayedColumns: string[] = ['select', 'id', 'batchNumber', 'quantity', 'expiryDate', 'productionDate', 'actions'];

  exportColumns: ExportColumn[] = [
    { key: 'id', label: 'ID' },
    { key: 'batchNumber', label: 'Batch Number' },
    { key: 'quantity', label: 'Quantity' },
    { key: 'expiryDate', label: 'Expiry Date' },
    { key: 'productionDate', label: 'Production Date' },
  ];

  constructor(
    public service: VendorOrderQualityDetailBatchService,
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
     this.service.getAll<VendorOrderQualityDetailBatch[]>().subscribe((data) => {
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
     this.router.navigate(['/procurement/vendor-order-quality-detail-batch/new']);
   }

   onEdit(row: VendorOrderQualityDetailBatch): void {
     if (this.viewMode.isDialog()) {
       this.openForm({ mode: 'edit', item: row });
       return;
     }
     this.router.navigate(['/procurement/vendor-order-quality-detail-batch', row.id, 'edit']);
   }

   onDelete(row: VendorOrderQualityDetailBatch): void {
     this.dialog
       .open(ConfirmDialogComponent, {
         width: '400px',
         data: { title: 'Delete Vendor Order Quality Detail Batch', message: 'Delete "' + (row.batchNumber ?? row.id) + '"? This action sets the record inactive (soft delete).' },
       })
       .afterClosed()
       .subscribe((confirmed) => {
         if (!confirmed) return;
         this.service.softDelete(row.id).subscribe({
           next: () => {
             this.notification.success('Vendor Order Quality Detail Batch removed (soft delete).');
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

  checkboxLabel(row?: VendorOrderQualityDetailBatch): string {
    if (!row) return `${this.isAllSelected() ? 'deselect' : 'select'} all`;
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row`;
  }

  private openForm(data: { mode: 'create' | 'edit'; item?: VendorOrderQualityDetailBatch }): void {
    this.dialog
      .open(VendorOrderQualityDetailBatchFormComponent, { width: '720px', panelClass: 'crud-dialog', data })
      .afterClosed()
      .subscribe((saved) => {
        if (saved) this.loadData();
      });
  }
}
