import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { ClassificationWithBookSharhListResponse } from '../../Model/Sharh/ClassificationWithBookSharhListResponse';
import { EmptyValuePipe } from '../../Pipe/empty-value.pipe';
import { BookSharhTemplateComponent } from '../../Components/book-sharh-template/book-sharh-template.component';
import { WordsLimitPipe } from '../../Pipe/words-limit.pipe';

@Component({
  selector: 'app-book-page',
  imports: [RouterLink, EmptyValuePipe, BookSharhTemplateComponent, WordsLimitPipe],
  templateUrl: './book-sharh-page.component.html',
  styleUrl: './book-sharh-page.component.css'
})
export class BookPageComponent implements OnInit {

  BookSharh: ClassificationWithBookSharhListResponse = {} as ClassificationWithBookSharhListResponse;

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.data.subscribe((data: any) => {
      this.BookSharh = data['bookSharhData'].data;
    });
  }

}