import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { SelectionModel } from '@angular/cdk/collections';
import { AssetCountPlanStatus } from '../../../Shared/Model/-asset-count-plan-status.model';
import { AssetCountPlanStatusService } from './asset-count-plan-status.service';
import { SharedService } from '../../../core/services/shared.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormViewModeService } from '../../../core/services/form-view-mode.service';
import { ExportColumn } from '../../../Shared/Model/ExportColumn';
import { EXPORT_BUTTONS } from '../../../Shared/constants/ExportType.const';
import { AssetCountPlanStatusFormComponent } from './asset-count-plan-status-form.component';
import { ConfirmDialogComponent } from '../../../Shared/Components/confirm-dialog/confirm-dialog.component';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

@Component({
  selector: 'app-view-asset-count-plan-status',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './asset-count-plan-status.component.html',
  styleUrl: './asset-count-plan-status.component.css',
})
export class ViewAssetCountPlanStatusComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  readonly exportButtons = EXPORT_BUTTONS;

  pageSize = 10;
  searchText = '';

  dataSource = new MatTableDataSource<AssetCountPlanStatus>([]);
  selection = new SelectionModel<AssetCountPlanStatus>(true, []);

  displayedColumns: string[] = ['select', 'id', 'actions'];

  exportColumns: ExportColumn[] = [
    { key: 'id', label: 'ID' },
  ];

  constructor(
    public service: AssetCountPlanStatusService,
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
     this.service.getAll<AssetCountPlanStatus[]>().subscribe((data) => {
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
     this.router.navigate(['/inventory/asset-count-plan-status/new']);
   }

   onEdit(row: AssetCountPlanStatus): void {
     if (this.viewMode.isDialog()) {
       this.openForm({ mode: 'edit', item: row });
       return;
     }
     this.router.navigate(['/inventory/asset-count-plan-status', row.id, 'edit']);
   }

   onDelete(row: AssetCountPlanStatus): void {
     this.dialog
       .open(ConfirmDialogComponent, {
         width: '400px',
         data: { title: 'Delete Asset Count Plan Status', message: 'Delete "' + row.id + '"? This action sets the record inactive (soft delete).' },
       })
       .afterClosed()
       .subscribe((confirmed) => {
         if (!confirmed) return;
         this.service.softDelete(row.id).subscribe({
           next: () => {
             this.notification.success('Asset Count Plan Status removed (soft delete).');
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

  checkboxLabel(row?: AssetCountPlanStatus): string {
    if (!row) return `${this.isAllSelected() ? 'deselect' : 'select'} all`;
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row`;
  }

  private openForm(data: { mode: 'create' | 'edit'; item?: AssetCountPlanStatus }): void {
    this.dialog
      .open(AssetCountPlanStatusFormComponent, { width: '720px', panelClass: 'crud-dialog', data })
      .afterClosed()
      .subscribe((saved) => {
        if (saved) this.loadData();
      });
  }
}
