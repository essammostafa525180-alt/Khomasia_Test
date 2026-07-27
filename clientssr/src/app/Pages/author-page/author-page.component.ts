import { CommonModule } from '@angular/common';
import { Component, Inject, OnInit, inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { HadithService } from '../../Services/hadith.service';
import { AuthorDetials } from '../../Model/Book/author-detials';
import { LineBreakPipe } from '../../Pipe/line-break-pipe';

@Component({
  selector: 'app-author-page',
  imports: [CommonModule, MatDialogModule,LineBreakPipe],
  templateUrl: './author-page.component.html',
  styleUrl: './author-page.component.css'
})
export class AuthorPageComponent implements OnInit {
  AuthorDetails: AuthorDetials = {} as AuthorDetials;
  activeTab: string = 'book';

  private service = inject(HadithService);

  constructor(@Inject(MAT_DIALOG_DATA) public data: any) {}

  ngOnInit(): void {
    this.service.getClassificationAuthorDetailsById(this.data.authorId).subscribe({
      next: (response) => {
        this.AuthorDetails = response.data;
      }
    });
  }

  setTab(tab: string): void {
    this.activeTab = tab;
  }
}