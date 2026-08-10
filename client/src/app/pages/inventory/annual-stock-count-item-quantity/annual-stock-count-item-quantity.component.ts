import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { SelectionModel } from '@angular/cdk/collections';
import { AnnualStockCountItemQuantity } from '../../../Shared/Model/-annual-stock-count-item-quantity.model';
import { AnnualStockCountItemQuantityService } from './annual-stock-count-item-quantity.service';
import { SharedService } from '../../../core/services/shared.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormViewModeService } from '../../../core/services/form-view-mode.service';
import { ExportColumn } from '../../../Shared/Model/ExportColumn';
import { EXPORT_BUTTONS } from '../../../Shared/constants/ExportType.const';
import { AnnualStockCountItemQuantityFormComponent } from './annual-stock-count-item-quantity-form.component';
import { ConfirmDialogComponent } from '../../../Shared/Components/confirm-dialog/confirm-dialog.component';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

@Component({
  selector: 'app-view-annual-stock-count-item-quantity',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './annual-stock-count-item-quantity.component.html',
  styleUrl: './annual-stock-count-item-quantity.component.css',
})
export class ViewAnnualStockCountItemQuantityComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  readonly exportButtons = EXPORT_BUTTONS;

  pageSize = 10;
  searchText = '';

  dataSource = new MatTableDataSource<AnnualStockCountItemQuantity>([]);
  selection = new SelectionModel<AnnualStockCountItemQuantity>(true, []);

  displayedColumns: string[] = ['select', 'id', 'newName', 'currentQuantity', 'stockQuantity', 'refId', 'actions'];

  exportColumns: ExportColumn[] = [
    { key: 'id', label: 'ID' },
    { key: 'newName', label: 'New Name' },
    { key: 'currentQuantity', label: 'Current Quantity' },
    { key: 'stockQuantity', label: 'Stock Quantity' },
    { key: 'refId', label: 'Ref' },
  ];

  constructor(
    public service: AnnualStockCountItemQuantityService,
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
     this.service.getAll<AnnualStockCountItemQuantity[]>().subscribe((data) => {
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
     this.router.navigate(['/inventory/annual-stock-count-item-quantity/new']);
   }

   onEdit(row: AnnualStockCountItemQuantity): void {
     if (this.viewMode.isDialog()) {
       this.openForm({ mode: 'edit', item: row });
       return;
     }
     this.router.navigate(['/inventory/annual-stock-count-item-quantity', row.id, 'edit']);
   }

   onDelete(row: AnnualStockCountItemQuantity): void {
     this.dialog
       .open(ConfirmDialogComponent, {
         width: '400px',
         data: { title: 'Delete Annual Stock Count Item Quantity', message: 'Delete "' + (row.newName ?? row.id) + '"? This action sets the record inactive (soft delete).' },
       })
       .afterClosed()
       .subscribe((confirmed) => {
         if (!confirmed) return;
         this.service.softDelete(row.id).subscribe({
           next: () => {
             this.notification.success('Annual Stock Count Item Quantity removed (soft delete).');
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

  checkboxLabel(row?: AnnualStockCountItemQuantity): string {
    if (!row) return `${this.isAllSelected() ? 'deselect' : 'select'} all`;
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row`;
  }

  private openForm(data: { mode: 'create' | 'edit'; item?: AnnualStockCountItemQuantity }): void {
    this.dialog
      .open(AnnualStockCountItemQuantityFormComponent, { width: '720px', panelClass: 'crud-dialog', data })
      .afterClosed()
      .subscribe((saved) => {
        if (saved) this.loadData();
      });
  }
}
