import { Component, OnInit } from '@angular/core';
import {NgxPaginationModule} from 'ngx-pagination';
import { HadithService } from '../../Services/hadith.service';
import { PaginationParams } from '../../Model/BaseModel/PaginationParams';
import { NarratorListResponse } from '../../Model/Narrators/narrator-list-response';
import { PagedResult } from '../../Model/BaseModel/paged-result';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { NarratorsDetailsPageComponent } from '../narrators-details-page/narrators-details-page.component';
import { IslamicPaginationComponent, PaginationEvent } from "../../Components/islamic-pagination/islamic-pagination.component";


@Component({
    selector: 'app-narrators-page',
    imports: [NgxPaginationModule, MatPaginatorModule, IslamicPaginationComponent],
    templateUrl: './narrators-page.component.html',
    styleUrl: './narrators-page.component.css'
})
export class NarratorsPageComponent implements OnInit {

  pageResulat: PagedResult<NarratorListResponse> = {} as PagedResult<NarratorListResponse>;
  pagination = new PaginationParams(); 

  constructor(
    public dialog: MatDialog,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.route.data.subscribe(data => {
      if (data['narratorsData'] && data['narratorsData'].data) {
        this.pageResulat = data['narratorsData'].data;
      }
    });

    this.route.queryParams.subscribe(params => {
      this.pagination.pageNumber = Number(params['pageNumber']) || 1;
      this.pagination.pageSize = Number(params['pageSize']) || 10;
      this.activeLetter = params['letter'] || 'الكل';
    });
  }
  
  letters: string[] = [
    'الكل','أ','إ','آ','ا','ب','ت','ث','ج','ح','خ','د','ذ','ر','ز','س','ش',
    'ص','ض','ط','ظ','ع','غ','ف','ق','ك','ل','م','ن','ه','و','ي'
  ];
  
  activeLetter: string = 'الكل';

  onPageChange(event: PaginationEvent) {
    const pageNumber = event.page; 
    const pageSize = event.pageSize;
    const letter = this.activeLetter === 'الكل' ? '' : this.activeLetter;

    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: { pageNumber, pageSize, letter: letter || null },
      queryParamsHandling: 'merge'
    });
  }
   
    

  setLetter(letter: string) {
    const activeLetter = letter === 'الكل' ? '' : letter;
    
    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: { pageNumber: 1, letter: activeLetter || null },
      queryParamsHandling: 'merge'
    });
  }

  
RawiProfile(id :number) {
  this.dialog.open(NarratorsDetailsPageComponent, {
    width: '90vw',
    maxWidth: '800px',
    height: 'auto',
    panelClass: 'rawi-dialog',
     data: { narratorId: id }
  });
}

}