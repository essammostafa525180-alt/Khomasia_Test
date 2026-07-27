import { Component, Input, Output, EventEmitter } from '@angular/core';

export interface PaginationEvent {
  page: number;
  pageSize: number;
}

@Component({
  selector: 'app-islamic-pagination',
  templateUrl: './islamic-pagination.component.html',
  styleUrl: './islamic-pagination.component.css'
})
export class IslamicPaginationComponent {
  @Input() currentPage = 1;
  @Input() totalPages = 1;
  @Input() totalItems = 0;
  @Input() pageSize = 10;
  @Input() isLoading = false;
  @Input() pageSizeOptions: number[] = [5, 10, 15, 20, 25, 50];

  @Output() pageChange = new EventEmitter<PaginationEvent>();
  @Output() pageSizeChange = new EventEmitter<PaginationEvent>();

  get pages(): number[] {
    const pages: number[] = [];
    const maxVisible = 5;
    let start = Math.max(1, this.currentPage - Math.floor(maxVisible / 2));
    let end = Math.min(this.totalPages, start + maxVisible - 1);

    if (end - start + 1 < maxVisible) {
      start = Math.max(1, end - maxVisible + 1);
    }

    for (let i = start; i <= end; i++) {
      pages.push(i);
    }
    return pages;
  }

  goToPage(page: number): void {
    if (page < 1 || page > this.totalPages || page === this.currentPage) return;
    this.pageChange.emit({ page, pageSize: this.pageSize });
  }

  onPageSizeChange(event: Event): void {
    const select = event.target as HTMLSelectElement;
    const newSize = Number(select.value);
    if (newSize === this.pageSize) return;
    this.pageSize = newSize;
    // Reset to page 1 when page size changes
    this.pageSizeChange.emit({ page: 1, pageSize: newSize });
  }
}
