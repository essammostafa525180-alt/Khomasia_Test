import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { GridColumn } from './data-grid/grid-column.model';

@Component({
  selector: 'app-data-grid',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './data-grid.component.html',
  host: { style: 'display: contents' }
})
export class DataGridComponent<T extends { [key: string]: any }> {

  @Input() title: string = '';
  @Input() columns: GridColumn[] = [];
  @Input() data: T[] = [];

  @Output() add = new EventEmitter<void>();
  @Output() view = new EventEmitter<T>();
  @Output() edit = new EventEmitter<T>();
  @Output() delete = new EventEmitter<T>();
  @Output() exportExcel = new EventEmitter<void>();
  @Output() exportPdf = new EventEmitter<void>();
  @Output() print = new EventEmitter<void>();

  searchTerm: string = '';

  get filteredData(): T[] {
    if (!this.searchTerm.trim()) return this.data;
    const term = this.searchTerm.toLowerCase();
    return this.data.filter(row =>
      this.columns.some(col =>
        String(row[col.key] ?? '').toLowerCase().includes(term)
      )
    );
  }

  onDelete(row: T): void {
    if (confirm('هل أنت متأكد من الحذف؟')) {
      this.delete.emit(row);
    }
  }
}