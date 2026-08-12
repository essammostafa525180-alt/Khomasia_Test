import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { SelectionModel } from '@angular/cdk/collections';
import { InventroyItemRequestWithdrawAttachment } from '../../../Shared/Model/-inventroy-item-request-withdraw-attachment.model';
import { InventroyItemRequestWithdrawAttachmentService } from './inventroy-item-request-withdraw-attachment.service';
import { SharedService } from '../../../core/services/shared.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormViewModeService } from '../../../core/services/form-view-mode.service';
import { ExportColumn } from '../../../Shared/Model/ExportColumn';
import { EXPORT_BUTTONS } from '../../../Shared/constants/ExportType.const';
import { InventroyItemRequestWithdrawAttachmentFormComponent } from './inventroy-item-request-withdraw-attachment-form.component';
import { ConfirmDialogComponent } from '../../../Shared/Components/confirm-dialog/confirm-dialog.component';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

@Component({
  selector: 'app-view-inventroy-item-request-withdraw-attachment',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './inventroy-item-request-withdraw-attachment.component.html',
  styleUrl: './inventroy-item-request-withdraw-attachment.component.css',
})
export class ViewInventroyItemRequestWithdrawAttachmentComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  readonly exportButtons = EXPORT_BUTTONS;

  pageSize = 10;
  searchText = '';

  dataSource = new MatTableDataSource<InventroyItemRequestWithdrawAttachment>([]);
  selection = new SelectionModel<InventroyItemRequestWithdrawAttachment>(true, []);

  displayedColumns: string[] = ['select', 'id', 'attachmentId', 'attachmentName', 'description', 'actions'];

  exportColumns: ExportColumn[] = [
    { key: 'id', label: 'ID' },
    { key: 'attachmentId', label: 'Attachment' },
    { key: 'attachmentName', label: 'Attachment Name' },
    { key: 'description', label: 'Description' },
  ];

  constructor(
    public service: InventroyItemRequestWithdrawAttachmentService,
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
     this.service.getAll<InventroyItemRequestWithdrawAttachment[]>().subscribe((data) => {
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
     this.router.navigate(['/inventory/inventroy-item-request-withdraw-attachment/new']);
   }

   onEdit(row: InventroyItemRequestWithdrawAttachment): void {
     if (this.viewMode.isDialog()) {
       this.openForm({ mode: 'edit', item: row });
       return;
     }
     this.router.navigate(['/inventory/inventroy-item-request-withdraw-attachment', row.id, 'edit']);
   }

   onDelete(row: InventroyItemRequestWithdrawAttachment): void {
     this.dialog
       .open(ConfirmDialogComponent, {
         width: '400px',
         data: { title: 'Delete Inventroy Item Request Withdraw Attachment', message: 'Delete "' + (row.attachmentName ?? row.id) + '"? This action sets the record inactive (soft delete).' },
       })
       .afterClosed()
       .subscribe((confirmed) => {
         if (!confirmed) return;
         this.service.softDelete(row.id).subscribe({
           next: () => {
             this.notification.success('Inventroy Item Request Withdraw Attachment removed (soft delete).');
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

  checkboxLabel(row?: InventroyItemRequestWithdrawAttachment): string {
    if (!row) return `${this.isAllSelected() ? 'deselect' : 'select'} all`;
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row`;
  }

  private openForm(data: { mode: 'create' | 'edit'; item?: InventroyItemRequestWithdrawAttachment }): void {
    this.dialog
      .open(InventroyItemRequestWithdrawAttachmentFormComponent, { width: '720px', panelClass: 'crud-dialog', data })
      .afterClosed()
      .subscribe((saved) => {
        if (saved) this.loadData();
      });
  }
}
