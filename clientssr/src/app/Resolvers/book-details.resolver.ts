import { inject } from '@angular/core';
import { ResolveFn } from '@angular/router';
import { HadithService } from '../Services/hadith.service';
import { ApiResponse } from '../Model/BaseModel/api-response';
import { BookDetailsWithBabsResponse } from '../Model/Book/book-details-with-babs-response';
import { Navigation } from '../Model/BaseModel/navigation';

export const bookDetailsResolver: ResolveFn<ApiResponse<Navigation<BookDetailsWithBabsResponse>>> = (route) => {
  const id = Number(route.paramMap.get('id'));

  return inject(HadithService).getBookDetailsWithBabs(id);
};