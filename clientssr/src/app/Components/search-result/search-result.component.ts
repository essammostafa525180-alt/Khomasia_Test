import { Component, OnInit, OnDestroy, Inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { RouterLink } from '@angular/router';
import { HadithCardComponent } from "../hadith-card/hadith-card.component";
import { BookTemplateComponent } from "../book-template/book-template.component";
import { SearchResult } from '../../Model/Hadith/search-result';
import { HadithService } from '../../Services/hadith.service';
import { SharedService } from '../../Services/shared.service';
import { CommonModule } from '@angular/common';
import { Subscription } from 'rxjs';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { PaginationParams } from '../../Model/BaseModel/PaginationParams';
import { PagedResult } from '../../Model/BaseModel/paged-result';
import { ApiResponse } from '../../Model/BaseModel/api-response';

@Component({
    selector: 'app-search-result',
    imports: [RouterLink, HadithCardComponent, BookTemplateComponent, CommonModule, MatPaginatorModule],
    templateUrl: './search-result.component.html',
    styleUrl: './search-result.component.css'
})
export class SearchResultComponent {
  results: ApiResponse<PagedResult<SearchResult>> = {} as ApiResponse<PagedResult<SearchResult>>;
  isLoading = false;

  // Pagination properties
  pagination = new PaginationParams(1, 10);
  totalItems: number = 0;

  private searchSub?: Subscription;

  constructor(
    private hadithService: HadithService,
    private sharedService: SharedService,
    @Inject(PLATFORM_ID) private platformId: Object
  ) { }

  ngOnInit() {
    this.searchSub = this.sharedService.searchParams$.subscribe(params => {
      if (params && params.query.trim()) {
        this.pagination.pageNumber = 1; // Reset to first page on new search
        this.performSearch(params.query, params.classificationId);
      } else {
        this.results = {} as ApiResponse<PagedResult<SearchResult>>;
      }
    });
  }

  ngOnDestroy() {
    this.searchSub?.unsubscribe();
  }

  performSearch(query: string, classificationId: number | null) {
    this.isLoading = true;
    this.hadithService.searchHadiths(query, classificationId, this.pagination).subscribe({
      next: (res: ApiResponse<PagedResult<SearchResult>>) => {
        if (res.isSuccess && res.data) {
          this.results = res;
          this.totalItems = res.data.totalItems;
        }
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Search error:', err);
        this.isLoading = false;
      }
    });
  }

  onPageChange(event: PageEvent) {
    this.pagination.pageNumber = event.pageIndex + 1;
    this.pagination.pageSize = event.pageSize;
    const params = this.sharedService.getSearchParamsValue();
    if (params) {
      this.performSearch(params.query, params.classificationId);
      window.scrollTo({ top: 0, behavior: 'smooth' });
    }
  }
}
