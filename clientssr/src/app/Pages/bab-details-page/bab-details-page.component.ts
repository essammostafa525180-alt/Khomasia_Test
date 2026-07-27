import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { MatTooltipModule } from '@angular/material/tooltip';
import { EmptyStateComponent } from '../../Components/empty-state/empty-state.component';
import { BookDetailsWithBabsResponse } from '../../Model/Book/book-details-with-babs-response';
import { Navigation } from '../../Model/BaseModel/navigation';
import { SeoService } from '../../Services/seo.service';

@Component({
  selector: 'app-bab-details-page',
  imports: [RouterLink, EmptyStateComponent, MatTooltipModule],
  templateUrl: './bab-details-page.component.html',
  styleUrl: './bab-details-page.component.css'
})
export class BabDetailsPageComponent implements OnInit {
  BookWithNavigation: Navigation<BookDetailsWithBabsResponse> = {} as Navigation<BookDetailsWithBabsResponse>;

  private route = inject(ActivatedRoute);
  private seo = inject(SeoService);

  ngOnInit(): void {
    this.route.data.subscribe(({ bookData }) => {
      if (bookData?.isSuccess) {
        this.handleBookResponse(bookData.data);
      }
    });
  }

  private handleBookResponse(data: Navigation<BookDetailsWithBabsResponse>): void {
    if (data?.data?.babs) {
      data.data.babs = [...data.data.babs].sort((a, b) => a.babIndex - b.babIndex);
    }
    this.BookWithNavigation = data;

    const bookName = data?.data?.name ?? '';
    this.seo.updateSeoData(
      bookName,
      `تصفح أبواب كتاب ${bookName} في جامع السنة وشروحها.`
    );
  }
}