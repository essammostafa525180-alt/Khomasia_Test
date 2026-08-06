import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslatePipe } from '@ngx-translate/core';
import { GridColumn } from './data-grid/grid-column.model';

@Component({
  selector: 'app-data-grid',
  standalone: true,
  imports: [CommonModule, TranslatePipe],
  templateUrl: './data-grid.component.html',
  styleUrl: './data-grid.component.css'
})
export class DataGridComponent {
  @Input() title = '';
  @Input() columns: GridColumn[] = [];
  @Input() data: any[] = [];

  @Output() add = new EventEmitter<void>();
  @Output() view = new EventEmitter<any>();
  @Output() edit = new EventEmitter<any>();
  @Output() delete = new EventEmitter<any>();
  @Output() searchChanged = new EventEmitter<string>();
  @Output() exportPdf = new EventEmitter<void>();
  @Output() exportExcel = new EventEmitter<void>();
  @Output() exportWord = new EventEmitter<void>();
  @Output() print = new EventEmitter<void>();

  onAdd(): void {
    this.add.emit();
  }

  onView(row: any): void {
    this.view.emit(row);
  }

  onEdit(row: any): void {
    this.edit.emit(row);
  }

  onDelete(row: any): void {
    this.delete.emit(row);
  }

  onSearchInput(event: Event): void {
    this.searchChanged.emit((event.target as HTMLInputElement).value);
  }
}
