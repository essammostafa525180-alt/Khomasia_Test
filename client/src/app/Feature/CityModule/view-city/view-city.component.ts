import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { SelectionModel } from '@angular/cdk/collections';
import { CityModel } from '../../../core/Models/CityModel/city.model';
import { CityService } from '../../../core/services/city.service';
import { SharedService } from '../../../core/services/shared.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormViewModeService } from '../../../core/services/form-view-mode.service';
import { ExportColumn } from '../../../Shared/Model/ExportColumn';
import { EXPORT_BUTTONS } from '../../../Shared/constants/ExportType.const';
import { CityFormComponent } from '../city-form/city-form.component';
import { ConfirmDialogComponent } from '../../../Shared/Components/confirm-dialog/confirm-dialog.component';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

@Component({
  selector: 'app-view-city',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './view-city.component.html',
  styleUrl: './view-city.component.css',
})
export class ViewCityComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  readonly exportButtons = EXPORT_BUTTONS;

  pageSize = 10;
  filterName = '';
  filterCountry = '';

  dataSource = new MatTableDataSource<CityModel>([]);
  selection = new SelectionModel<CityModel>(true, []);

  displayedColumns: string[] = ['select', 'id', 'name', 'countryName', 'actions'];

  exportColumns: ExportColumn[] = [
    { key: 'id', label: 'ID' },
    { key: 'name', label: 'City Name' },
    { key: 'countryName', label: 'Country' },
  ];

  constructor(
    private cityService: CityService,
    private sharedService: SharedService,
    private notification: NotificationService,
    private viewMode: FormViewModeService,
    private router: Router,
    private dialog: MatDialog
  ) {}

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.filterPredicate = this.buildFilterPredicate();
    this.loadData();
  }

   loadData(): void {
     this.cityService.getAll<CityModel[]>().subscribe((data) => {
       this.dataSource.data = (data || []).filter((r: any) => r?.isDeleted !== true && r?.IsDeleted !== true);
       this.selection.clear();
     });
   }

  private buildFilterPredicate() {
    return (row: CityModel, filter: string): boolean => {
      const parts = filter.split('|');
      const cityQ = (parts[0] ?? '').toLowerCase();
      const countryQ = (parts[1] ?? '').toLowerCase();
      return (
        row.name.toLowerCase().includes(cityQ) &&
        (row.countryName ?? '').toLowerCase().includes(countryQ)
      );
    };
  }

onSearch(): void {
  const query: Partial<CityModel> = {};

  if (this.filterName.trim()) {
    query.name = this.filterName.trim();
  }
  if (this.filterCountry.trim()) {
    query.countryName = this.filterCountry.trim();
  }

  if (Object.keys(query).length === 0) {
    return;
  }


  this.cityService.searchCriteria<CityModel[]>(query).subscribe((data) => {
    this.dataSource.data = data;
  });
}

  onReset(): void {
    this.filterName = '';
    this.filterCountry = '';
    this.dataSource.filter = '';
  }

  onNew(): void {
    if (this.viewMode.isDialog()) {
      this.openForm({ mode: 'create' });
      return;
    }
    this.router.navigate(['/city/new']);
  }

  onEdit(row: CityModel): void {
    if (this.viewMode.isDialog()) {
      this.openForm({ mode: 'edit', item: row });
      return;
    }
    this.router.navigate(['/city', row.id, 'edit']);
  }

  onDelete(row: CityModel): void {
    this.dialog
      .open(ConfirmDialogComponent, {
        width: '400px',
        data: { title: 'Delete City', message: `Delete "${row.name}"? This action sets the record inactive (soft delete).` },
       })
       .afterClosed()
       .subscribe((confirmed) => {
         if (!confirmed) return;
         this.cityService.softDelete(row.id).subscribe({
           next: () => {
             this.notification.success('City removed (soft delete).');
             this.loadData();
           },
           error: () => this.notification.error('Could not delete this city.'),
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

  checkboxLabel(row?: CityModel): string {
    if (!row) return `${this.isAllSelected() ? 'deselect' : 'select'} all`;
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row`;
  }

  private openForm(data: { mode: 'create' | 'edit'; item?: CityModel }): void {
    this.dialog
      .open(CityFormComponent, { width: '720px', data })
      .afterClosed()
      .subscribe((saved) => {
        if (saved) this.loadData();
      });
  }
}
