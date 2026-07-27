import { Component, OnInit } from '@angular/core';
import { HadithService } from '../../Services/hadith.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiResponse } from '../../Model/BaseModel/api-response';
import { BabListResponse } from '../../Model/Babs/bab-list-response';
import { PagedResult } from '../../Model/BaseModel/paged-result';
import { SharhBabListResponse } from '../../Model/Sharh/sharh-bab-list-response';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';
import { BidiModule } from "@angular/cdk/bidi";
import { HighlightTextPipe } from '../../Pipe/highlight-text.pipe';
import { SharhBookMeta } from '../../Model/Sharh/sharh-book-meta';
import { BookSummary } from '../../Model/Book/book-summary';
import { CommonModule } from '@angular/common';
import { SharhResolvedData } from '../../Resolvers/sharh-resolver';

@Component({
  selector: 'app-sharh-book-details-page',
  standalone: true,
  imports: [BidiModule, HighlightTextPipe, CommonModule],
  templateUrl: './sharh-book-details-page.component.html',
  styleUrl: './sharh-book-details-page.component.css'
})
export class SharhBookDetailsPageComponent implements OnInit {

  bookId!: number;
  activeBabId: number | null = null;

  sharhBookMeta: SharhBookMeta | null = null;
  booksList: BookSummary[] = [];
  babsMap: { [bookId: number]: BabListResponse[] } = {};
  BabSharhList: SharhBabListResponse[] = [];

  pageSize = 10;
  currentPage = 1;
  reminder: number = 0;

  activeBookId: number | null = null;
  activeBookName: string = '';
  activeBab: BabListResponse | null = null;

  constructor(
    private service: HadithService,
    private route: ActivatedRoute,
    private router: Router,
    private sanitizer: DomSanitizer
  ) { }

  getSharhHtml(html: string): SafeHtml {
    return this.sanitizer.bypassSecurityTrustHtml(html);
  }

  ngOnInit(): void {

    this.route.data.subscribe(data => {
      const resolved = data['sharhData'] as SharhResolvedData;
      this.sharhBookMeta = resolved.bookMeta;
      this.BabSharhList = resolved.babSharhList;

      if (this.sharhBookMeta) {
        this.loadBooksForClassification(this.sharhBookMeta.classificationId);
      }
    });

    this.route.paramMap.subscribe(params => {
      this.bookId = Number(params.get('id'));
      this.activeBabId = params.get('babId') ? Number(params.get('babId')) : null;

      if (this.activeBabId && this.bookId) {
        this.loadBabsForBook(this.bookId);
      }
    });
  }

  updateReminder(): number {
    const total = this.sharhBookMeta?.bookCount ?? 0;
    this.reminder = Math.max(total - this.currentPage * this.pageSize, 0);
    return this.reminder;
  }

  loadPreviousBooks(): void {
    if (this.currentPage > 1) {
      this.currentPage--;
      this.updateReminder();
      this.loadBooksForClassification(this.sharhBookMeta?.classificationId ?? 0);
    }
  }

  loadMoreBooks(): void {
    const total = this.sharhBookMeta?.bookCount ?? 0;
    if (this.currentPage * this.pageSize < total) {
      this.currentPage++;
      this.updateReminder();
      this.loadBooksForClassification(this.sharhBookMeta?.classificationId ?? 0);
    }
  }

  loadBooksForClassification(classificationId: number) {
    this.service.getBooksByClassification(classificationId, { pageNumber: this.currentPage, pageSize: this.pageSize }).subscribe({
      next: (res: ApiResponse<PagedResult<BookSummary>>) => {
        if (res.isSuccess && res.data && res.data.items) {
          this.booksList = res.data.items;
        }
      }
    });
  }

  toggleBook(bookId: number) {
    if (this.activeBookId === bookId) {
      this.activeBookId = null;
      this.activeBookName = '';
      return;
    }
    this.activeBookId = bookId;
    const book = this.booksList.find(b => b.id === bookId);
    if (book) {
      this.activeBookName = book.name || '';
    }
    if (!this.babsMap[bookId]) {
      this.loadBabsForBook(bookId);
    }
  }

  loadBabsForBook(bookId: number) {
    this.service.getAllBabsByBookId(bookId).subscribe({
      next: (res: ApiResponse<PagedResult<BabListResponse>>) => {
        if (res.isSuccess && res.data && res.data.items) {
          this.babsMap[bookId] = res.data.items;
        }
      }
    });
  }

  openBab(bab: BabListResponse) {
    this.activeBab = bab;
    this.router.navigate(['.', { babId: bab.id }], {
      relativeTo: this.route,
      queryParamsHandling: 'preserve'
    }).then(() => {
      document.getElementById('reader')?.scrollIntoView({ behavior: 'smooth', block: 'start' });
    });
  }

}