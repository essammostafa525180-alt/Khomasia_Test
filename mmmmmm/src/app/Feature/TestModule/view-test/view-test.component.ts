import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { TestModel } from '../../../core/Models/TestModel/test.model';
import { exportTypeConst } from '../../../Shared/constants/ExportType.const';
import { ExportColumn } from '../../../Shared/Model/ExportColumn';
import { ExportButton } from '../../../Shared/Model/ExportButton';
import { SharedService } from '../../../core/services/shared.service';
import { AccordionItem } from '../../../Shared/Model/AccordionItem';
import { MATERIAL_IMPORTS } from '../../../Shared/materail-imports';

@Component({
  selector: 'app-view-test',
  imports: [MATERIAL_IMPORTS],
  templateUrl: './view-test.component.html',
  styleUrl: './view-test.component.css'
})
export class ViewTestComponent implements OnInit, AfterViewInit {

@ViewChild(MatPaginator) paginator!: MatPaginator;

  pageSize = 10;

  constructor(private shardService: SharedService) {}
  dataSource = new MatTableDataSource<TestModel>([]);
  selection = new SelectionModel<TestModel>(true, []);

  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  toggleAllRows() {
    if (this.isAllSelected()) {
      this.selection.clear();
      return;
    }

    this.selection.select(...this.dataSource.data);
  }

  checkboxLabel(row?: TestModel ): string {
    if (!row) {
      return `${this.isAllSelected() ? 'deselect' : 'select'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.id + 1}`;
  }

  
  accordionItem: AccordionItem = {
    title: 'PAGES.FILTER', icon: 'filter_list',
  };



  exportColumns: ExportColumn[] = [
    { key: 'farmId', label: 'Farm ID' },
    { key: 'farmName', label: 'Farm Name' },
    { key: 'locationRegion', label: 'Location Region' },
    { key: 'gpsLatitude', label: 'GPS Latitude' },
    { key: 'gpsLongitude', label: 'GPS Longitude' },
    { key: 'status', label: 'Status' },
  ];

  exportButtons: ExportButton[] = [
    { type: exportTypeConst.PDF,  icon: 'picture_as_pdf' },
    { type: exportTypeConst.CSV, icon: 'description' },
    { type: exportTypeConst.PRINT, icon: 'print' },
    { type: exportTypeConst.COPY, icon: 'content_copy' },
  ];

  displayedColumns: string[] = [
    'select','id', 'name', 
  ];

  ngOnInit(): void {
    this.dataSource.data = this.test;
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }


  test: TestModel[] = [
    {
      id: 2,
      name: 'احمد',
    },
    {
      id: 2,
      name: 'احمد',
    },
    {
      id: 2,
      name: 'احمد',
    },
    {
      id: 2,
      name: 'احمد',
    },
  ];


  onExport(type: string): void {
    this.shardService.export(this.test, this.exportColumns, type);
  }

  onPageChange(event: any): void {
    this.pageSize = event.pageSize;
  }

  onNewMaterialRequest(): void {}


}
