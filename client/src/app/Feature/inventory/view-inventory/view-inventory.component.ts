import { AfterViewInit, Component, ViewChild, Inject } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { EXPORT_BUTTONS } from '../../../Shared/constants/ExportType.const';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { ExportColumn } from '../../../Shared/Model/ExportColumn';
import { SharedService } from '../../../core/services/shared.service';
import { NotificationService } from '../../../core/services/notification.service';
import { FormViewModeService } from '../../../core/services/form-view-mode.service';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmDialogComponent } from '../../../Shared/Components/confirm-dialog/confirm-dialog.component';
import { FormInventoryComponent } from '../form-inventory/form-inventory.component';
import { MatCheckbox } from "@angular/material/checkbox";
import { MatIcon } from "@angular/material/icon";
import { MatTooltip } from "@angular/material/tooltip";
import { AutocompleteComponent } from "../../../Shared/Components/autocomplete/autoComplete.component";
import { InventoryItem } from '../../../Shared/Model/inventory-item.model';
import { AhmedService } from '../../../core/services/ahmed.service';
import { MatFormFieldModule } from "@angular/material/form-field";
import { AccordionComponent } from "../../../Shared/Components/accordion/accordion.component";
import { TranslatePipe } from '@ngx-translate/core';
import { CommonModule } from '@angular/common';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';
import { ApiResponse, PagedResultModel } from '../../../core/Models/BaseModel/paged-result.model';

@Component({
  selector: 'app-view-inventory',
  imports: [MATERIAL_IMPORTS,MatCheckbox, MatIcon,CommonModule, MatPaginator, MatTooltip, AutocompleteComponent, MatFormFieldModule, AccordionComponent,TranslatePipe],
  templateUrl: './view-inventory.component.html',
  styleUrl: './view-inventory.component.css'
})
export class ViewInventoryComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  readonly exportButtons = EXPORT_BUTTONS;

  pageSize = 10;
 modelFilter : InventoryItem={} as InventoryItem;

  dataSource = new MatTableDataSource<InventoryItem>([]);
  selection = new SelectionModel<InventoryItem>(true, []);

  displayedColumns: string[] = ['select', 'id', 'name', 'nameAr', 'actions'];

  exportColumns: ExportColumn[] = [
    { key: 'id', label: 'ID' },
    { key: 'name', label: 'Name' },
    { key: 'nameAr', label: 'Name (Ar)' },
  ];


  constructor(
   protected inventoryItemService: AhmedService,
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

  loadData(): void {
    this.inventoryItemService.getAll<ApiResponse<PagedResultModel<InventoryItem>>>().subscribe((data) => {
      this.dataSource.data = data.data.items;
      this.selection.clear();
    });
  }

onSearch(): void {
  const query: Partial<InventoryItem> = {};

    query.name = this.modelFilter.name?.trim();
    query.nameAr = this.modelFilter.nameAr?.trim();

  console.log(query);
  if (Object.keys(query).length === 0) {
    return;
  }

  this.inventoryItemService.searchCriteria<InventoryItem[]>(query).subscribe((data) => {
    this.dataSource.data = data;
  });
}

  onSelectedAutoComplete(selectedItem: InventoryItem): void {
    this.modelFilter.nameAr = selectedItem.nameAr;
    console.log('Selected Employee/Item:', selectedItem);
  }

  onReset(): void {
    this.modelFilter = {} as InventoryItem;
    this.loadData();
  }

  onNew(): void {
    if (this.viewMode.isDialog()) {
      this.openForm({ mode: 'create' });
      return;
    }
    this.router.navigate(['/inventory/new']);
  }

  onEdit(row: InventoryItem): void {
    if (this.viewMode.isDialog()) {
      this.openForm({ mode: 'edit', item: row });
      return;
    }
    this.router.navigate(['/inventory', row.id, 'edit']);
  }

  onDelete(row: InventoryItem): void {
    this.dialog
      .open(ConfirmDialogComponent, {
        width: '400px',
        data: { title: 'Delete Inventory Item', message: `Delete "${row.name}"? This action cannot be undone.` },
      })
      .afterClosed()
      .subscribe((confirmed) => {
        if (!confirmed) return;
        this.inventoryItemService.delete(row.id).subscribe(() => {
          this.notification.success('Inventory item deleted.');
          this.loadData();
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

  checkboxLabel(row?: InventoryItem): string {
    if (!row) return `${this.isAllSelected() ? 'deselect' : 'select'} all`;
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row`;
  }

  private openForm(data: { mode: 'create' | 'edit'; item?: InventoryItem }): void {
    this.dialog
      .open(FormInventoryComponent, { width: '720px', data })
      .afterClosed()
      .subscribe((saved) => {
        if (saved) this.loadData();
      });
  }
}
