import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { SelectionModel } from '@angular/cdk/collections';
import { CountryModel } from '../../../core/Models/CountryModel/country.model';
import { CountryService } from '../../../core/services/country.service';
import { SharedService } from '../../../core/services/shared.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormViewModeService } from '../../../core/services/form-view-mode.service';
import { ExportColumn } from '../../../Shared/Model/ExportColumn';
import { EXPORT_BUTTONS } from '../../../Shared/constants/ExportType.const';
import { CountryFormComponent } from '../country-form/country-form.component';
import { ConfirmDialogComponent } from '../../../Shared/Components/confirm-dialog/confirm-dialog.component';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

@Component({
  selector: 'app-view-country',
  standalone: true,
  imports: [MATERIAL_IMPORTS],
  templateUrl: './view-country.component.html',
  styleUrl: './view-country.component.css',
})
export class ViewCountryComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  readonly exportButtons = EXPORT_BUTTONS;

  pageSize = 10;
  filterName = '';
  filtercode= '';

  bindAutocomplete = (item: CountryModel): string => {
    if (!item) return '';
    if (typeof item === 'string') return item;
    return item.name;
  };

  dataSource = new MatTableDataSource<CountryModel>([]);
  selection = new SelectionModel<CountryModel>(true, []);

  displayedColumns: string[] = ['select', 'id', 'name', 'code', 'actions'];

  exportColumns: ExportColumn[] = [
    { key: 'id', label: 'ID' },
    { key: 'name', label: 'Name' },
    { key: 'code', label: 'Code' },
  ];


  constructor(
    public countryService: CountryService,
    private sharedService: SharedService,
    private notification: NotificationService,
    private viewMode: FormViewModeService,
    private router: Router,
    private dialog: MatDialog   
  ) {}

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.loadData();
    
  }
ngOnInit(): void {
      console.log("cold"+this.filtercode);

}
  
   loadData(): void {
     this.countryService.getAll<CountryModel[]>().subscribe((data) => {
       this.dataSource.data = (data || []).filter((r: any) => r?.isDeleted !== true && r?.IsDeleted !== true);
       this.selection.clear();
     });
   }

onSearch(): void {
  const query: Partial<CountryModel> = {};

  if (typeof this.filterName === 'string' && this.filterName.trim()) {
    query.name = this.filterName.trim();
  }

 if (typeof this.filtercode === 'string' && this.filtercode.trim()) {
    query.code = this.filtercode.trim();
  }

  console.log(query);
  if (Object.keys(query).length === 0) {
    return;
  }

  this.countryService.searchCriteria<CountryModel[]>(query).subscribe((data) => {
    this.dataSource.data = data;
  });
}

  onSelectedAutoComplete(selectedItem: CountryModel): void {
    this.filtercode=selectedItem.code;
    console.log('Selected Employee/Item:', selectedItem);
  }

  onReset(): void {
    this.filterName = '';
    this.filtercode = '';
    this.dataSource.filter = '';
  }

  onNew(): void {
    if (this.viewMode.isDialog()) {
      this.openForm({ mode: 'create' });
      return;
    }
    this.router.navigate(['/country/new']);
  }

  onEdit(row: CountryModel): void {
    if (this.viewMode.isDialog()) {
      this.openForm({ mode: 'edit', item: row });
      return;
    }
    this.router.navigate(['/country', row.id, 'edit']);
  }

  onDelete(row: CountryModel): void {
    this.dialog
      .open(ConfirmDialogComponent, {
        width: '400px',
         data: { title: 'Delete Country', message: `Delete "${row.name}"? This action sets the record inactive (soft delete).` },
       })
       .afterClosed()
       .subscribe((confirmed) => {
         if (!confirmed) return;
         this.countryService.softDelete(row.id).subscribe({
           next: () => {
             this.notification.success('Country removed (soft delete).');
             this.loadData();
           },
           error: () => this.notification.error('Could not delete this country.'),
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

  checkboxLabel(row?: CountryModel): string {
    if (!row) return `${this.isAllSelected() ? 'deselect' : 'select'} all`;
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row`;
  }

  private openForm(data: { mode: 'create' | 'edit'; item?: CountryModel }): void {
    this.dialog
      .open(CountryFormComponent, { width: '720px', data })
      .afterClosed()
      .subscribe((saved) => {
        if (saved) this.loadData();
      });
  }
}
