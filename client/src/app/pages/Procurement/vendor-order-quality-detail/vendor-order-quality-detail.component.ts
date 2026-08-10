import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { SelectionModel } from '@angular/cdk/collections';
import { VendorOrderQualityDetail } from '../../../Shared/Model/-vendor-order-quality-detail.model';
import { VendorOrderQualityDetailService } from './vendor-order-quality-detail.service';
import { SharedService } from '../../../core/services/shared.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormViewModeService } from '../../../core/services/form-view-mode.service';
import { ExportColumn } from '../../../Shared/Model/ExportColumn';
import { EXPORT_BUTTONS } from '../../../Shared/constants/ExportType.const';
import { VendorOrderQualityDetailFormComponent } from './vendor-order-quality-detail-form.component';
import { ConfirmDialogComponent } from '../../../Shared/Components/confirm-dialog/confirm-dialog.component';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

@Component({
  selector: 'app-view-vendor-order-quality-detail',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './vendor-order-quality-detail.component.html',
  styleUrl: './vendor-order-quality-detail.component.css',
})
export class ViewVendorOrderQualityDetailComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  readonly exportButtons = EXPORT_BUTTONS;

  pageSize = 10;
  searchText = '';

  dataSource = new MatTableDataSource<VendorOrderQualityDetail>([]);
  selection = new SelectionModel<VendorOrderQualityDetail>(true, []);

  displayedColumns: string[] = ['select', 'id', 'receivedQuantity', 'landedCost', 'actions'];

  exportColumns: ExportColumn[] = [
    { key: 'id', label: 'ID' },
    { key: 'receivedQuantity', label: 'Received Quantity' },
    { key: 'landedCost', label: 'Landed Cost' },
  ];

  constructor(
    public service: VendorOrderQualityDetailService,
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
     this.service.getAll<VendorOrderQualityDetail[]>().subscribe((data) => {
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
     this.router.navigate(['/procurement/vendor-order-quality-detail/new']);
   }

   onEdit(row: VendorOrderQualityDetail): void {
     if (this.viewMode.isDialog()) {
       this.openForm({ mode: 'edit', item: row });
       return;
     }
     this.router.navigate(['/procurement/vendor-order-quality-detail', row.id, 'edit']);
   }

   onDelete(row: VendorOrderQualityDetail): void {
     this.dialog
       .open(ConfirmDialogComponent, {
         width: '400px',
         data: { title: 'Delete Vendor Order Quality Detail', message: 'Delete "' + row.id + '"? This action sets the record inactive (soft delete).' },
       })
       .afterClosed()
       .subscribe((confirmed) => {
         if (!confirmed) return;
         this.service.softDelete(row.id).subscribe({
           next: () => {
             this.notification.success('Vendor Order Quality Detail removed (soft delete).');
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

  checkboxLabel(row?: VendorOrderQualityDetail): string {
    if (!row) return `${this.isAllSelected() ? 'deselect' : 'select'} all`;
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row`;
  }

  private openForm(data: { mode: 'create' | 'edit'; item?: VendorOrderQualityDetail }): void {
    this.dialog
      .open(VendorOrderQualityDetailFormComponent, { width: '720px', panelClass: 'crud-dialog', data })
      .afterClosed()
      .subscribe((saved) => {
        if (saved) this.loadData();
      });
  }
}
