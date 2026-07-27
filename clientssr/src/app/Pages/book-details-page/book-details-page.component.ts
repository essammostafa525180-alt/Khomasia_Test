import { Component, OnInit, DestroyRef, inject } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { MatTooltipModule } from '@angular/material/tooltip';

// Components
import { BookTemplateComponent } from '../../Components/book-template/book-template.component';
import { EmptyStateComponent } from '../../Components/empty-state/empty-state.component';
import { IslamicPaginationComponent, PaginationEvent } from '../../Components/islamic-pagination/islamic-pagination.component';
import { AuthorPageComponent } from '../author-page/author-page.component';

// Models
import { BookSummary } from '../../Model/Book/book-summary';
import { PagedResult } from '../../Model/BaseModel/paged-result';
import { ClassificationDetails } from '../../Model/Classification/classification-summary';
// Services
import { SeoService } from '../../Services/seo.service';

@Component({
  selector: 'app-book-details-page',
  imports: [
    RouterLink,
    MatDialogModule,
    MatTooltipModule,
    BookTemplateComponent,
    EmptyStateComponent,
    IslamicPaginationComponent,
  ],
  templateUrl: './book-details-page.component.html',
  styleUrl: './book-details-page.component.css',
})
export class BookDetailsPageComponent implements OnInit {

  // --- State ---
  classification!: ClassificationDetails;
  books: BookSummary[] = [];
  pagedResult!: PagedResult<BookSummary>;

  // --- DI ---
  private readonly route      = inject(ActivatedRoute);
  private readonly router     = inject(Router);
  private readonly seo        = inject(SeoService);
  private readonly dialog     = inject(MatDialog);
  private readonly destroyRef = inject(DestroyRef);

  ngOnInit(): void {
    // Re-runs automatically on every query param change (SSR re-renders each URL)
    this.route.data
      .pipe(takeUntilDestroyed(this.destroyRef))
      .subscribe((data) => this.applyResolvedData(data['classificationData']));
  }

  // --- Template Handlers ---

  onPageChange(event: PaginationEvent): void {
    this.navigateTo({ page: event.page, pageSize: event.pageSize });
  }
  
  onPageSizeChange(event: PaginationEvent): void {
    this.navigateTo({ page: 1, pageSize: event.pageSize });
  }
  
    private navigateTo(params: { page: number; pageSize: number }): void {
      this.router.navigate([], {
        relativeTo: this.route,
        queryParams: params,
        queryParamsHandling: 'merge',
      });
    }

  openAuthorProfile(authorId: number): void {
    this.dialog.open(AuthorPageComponent, {
      width: '90vw',
      maxWidth: '800px',
      maxHeight: '90vh',
      panelClass: 'auther-dialog',
      data: { authorId },
    });
  }

  private applyResolvedData(resolved: any): void {
    if (!resolved) return;

    const { classificationRes, booksRes } = resolved;

    if (classificationRes?.isSuccess) {
      this.classification = classificationRes.data;
      this.updateSeo();
    }

    if (booksRes?.isSuccess) {
      const data       = booksRes.data;
      this.pagedResult = data;
      this.books       = [...(data.items ?? [])].sort(
        (a, b) => a.classificationIndex - b.classificationIndex
      );
    }
  }


  private updateSeo(): void {
    const name = this.classification.name!;

    this.seo.updateSeoData(
      name,
      `تصفح كتب ${name} بموسوعة جامع السنة وشروحها.`,
      `${name}, كتب السنة, شروح الحديث`
    );

    this.seo.setStructuredData({
      '@context': 'https://schema.org',
      '@type': 'CollectionPage',
      name,
      description: `مجموعة كتب ${name} في جامع السنة`,
      mainEntity: {
        '@type': 'ItemList',
        itemListElement: this.books.map((book, i) => ({
          '@type': 'ListItem',
          position: i + 1,
          name: book.name,
        })),
      },
    });
  }
}