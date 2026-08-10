import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { SelectionModel } from '@angular/cdk/collections';
import { AssetItem } from '../../../Shared/Model/-asset-item.model';
import { AssetItemService } from './asset-item.service';
import { SharedService } from '../../../core/services/shared.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormViewModeService } from '../../../core/services/form-view-mode.service';
import { ExportColumn } from '../../../Shared/Model/ExportColumn';
import { EXPORT_BUTTONS } from '../../../Shared/constants/ExportType.const';
import { AssetItemFormComponent } from './asset-item-form.component';
import { ConfirmDialogComponent } from '../../../Shared/Components/confirm-dialog/confirm-dialog.component';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

@Component({
  selector: 'app-view-asset-item',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './asset-item.component.html',
  styleUrl: './asset-item.component.css',
})
export class ViewAssetItemComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  readonly exportButtons = EXPORT_BUTTONS;

  pageSize = 10;
  searchText = '';

  dataSource = new MatTableDataSource<AssetItem>([]);
  selection = new SelectionModel<AssetItem>(true, []);

  displayedColumns: string[] = ['select', 'id', 'purchaseValue', 'moveDate', 'isOperational', 'depreciationRate', 'depreciationDuration', 'fixedAssetAccountCode', 'actions'];

  exportColumns: ExportColumn[] = [
    { key: 'id', label: 'ID' },
    { key: 'purchaseValue', label: 'Purchase Value' },
    { key: 'moveDate', label: 'Move Date' },
    { key: 'isOperational', label: 'Is Operational' },
    { key: 'depreciationRate', label: 'Depreciation Rate' },
    { key: 'depreciationDuration', label: 'Depreciation Duration' },
    { key: 'fixedAssetAccountCode', label: 'Fixed Asset Account Code' },
  ];

  constructor(
    public service: AssetItemService,
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
     this.service.getAll<AssetItem[]>().subscribe((data) => {
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
     this.router.navigate(['/inventory/asset-item/new']);
   }

   onEdit(row: AssetItem): void {
     if (this.viewMode.isDialog()) {
       this.openForm({ mode: 'edit', item: row });
       return;
     }
     this.router.navigate(['/inventory/asset-item', row.id, 'edit']);
   }

   onDelete(row: AssetItem): void {
     this.dialog
       .open(ConfirmDialogComponent, {
         width: '400px',
         data: { title: 'Delete Asset Item', message: 'Delete "' + (row.fixedAssetAccountCode ?? row.id) + '"? This action sets the record inactive (soft delete).' },
       })
       .afterClosed()
       .subscribe((confirmed) => {
         if (!confirmed) return;
         this.service.softDelete(row.id).subscribe({
           next: () => {
             this.notification.success('Asset Item removed (soft delete).');
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

  checkboxLabel(row?: AssetItem): string {
    if (!row) return `${this.isAllSelected() ? 'deselect' : 'select'} all`;
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row`;
  }

  private openForm(data: { mode: 'create' | 'edit'; item?: AssetItem }): void {
    this.dialog
      .open(AssetItemFormComponent, { width: '720px', panelClass: 'crud-dialog', data })
      .afterClosed()
      .subscribe((saved) => {
        if (saved) this.loadData();
      });
  }
}
