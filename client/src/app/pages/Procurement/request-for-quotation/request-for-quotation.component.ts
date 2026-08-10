import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { SelectionModel } from '@angular/cdk/collections';
import { SharedService } from '../../../core/services/shared.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormViewModeService } from '../../../core/services/form-view-mode.service';
import { ExportColumn } from '../../../Shared/Model/ExportColumn';
import { EXPORT_BUTTONS } from '../../../Shared/constants/ExportType.const';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

@Component({
  selector: 'app-view-request-for-quotation',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './request-for-quotation.component.html',
  styleUrl: './request-for-quotation.component.css',
})
export class ViewRequestForQuotationComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  readonly exportButtons = EXPORT_BUTTONS;

  pageSize = 10;
  searchText = '';

  dataSource = new MatTableDataSource<any>([]);
  selection = new SelectionModel<any>(true, []);

  displayedColumns: string[] = ['select', 'id', 'actions'];

  exportColumns: ExportColumn[] = [
    { key: 'id', label: 'ID' },
  ];

  constructor(
    private sharedService: SharedService,
    private notification: NotificationService,
    private viewMode: FormViewModeService,
    private router: Router,
    private dialog: MatDialog,
  ) {}

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  onSearch(): void {
    this.dataSource.filter = this.searchText.trim().toLowerCase();
  }

  onReset(): void {
    this.searchText = '';
    this.dataSource.filter = '';
  }

  onNew(): void {
    this.router.navigate(['/procurement/request-for-quotation/new']);
  }

  onEdit(row: any): void {
    this.router.navigate(['/procurement/request-for-quotation', row.id, 'edit']);
  }

  onExport(type: string): void {
    const rows = this.selection.selected.length ? this.selection.selected : this.dataSource.filteredData;
    this.sharedService.export(rows, this.exportColumns, type);
  }

  onPageChange(event: PageEvent): void {
    this.pageSize = event.pageSize;
  }

  isAllSelected(): boolean {
    return this.selection.selected.length === this.dataSource.filteredData.length && this.dataSource.filteredData.length > 0;
  }

  toggleAllRows(): void {
    if (this.isAllSelected()) { this.selection.clear(); } else { this.selection.select(...this.dataSource.filteredData); }
  }

  checkboxLabel(row?: any): string {
    if (!row) return `${this.isAllSelected() ? 'deselect' : 'select'} all`;
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row`;
  }
}
