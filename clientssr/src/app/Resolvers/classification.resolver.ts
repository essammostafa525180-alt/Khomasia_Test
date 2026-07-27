import { inject } from '@angular/core';
import { ResolveFn } from '@angular/router';
import { forkJoin } from 'rxjs';

import { HadithService } from '../Services/hadith.service';
import { PaginationParams } from '../Model/BaseModel/PaginationParams';
import { ApiResponse } from '../Model/BaseModel/api-response';
import { BookSummary } from '../Model/Book/book-summary';
import { PagedResult } from '../Model/BaseModel/paged-result';
import { ClassificationDetails } from '../Model/Classification/classification-summary';

export const classificationResolver: ResolveFn<{
  classificationRes: ApiResponse<ClassificationDetails>;
  booksRes: ApiResponse<PagedResult<BookSummary>>;
}> = (route) => {
  const hadithService = inject(HadithService);

  const id       = Number(route.paramMap.get('id'));
  const page     = Number(route.queryParamMap.get('page'))     || 1;  // ← جديد
  const pageSize = Number(route.queryParamMap.get('pageSize')) || 10; // ← جديد

  return forkJoin({
    classificationRes: hadithService.getClassificationById(id),
    booksRes: hadithService.getBooksByClassification(id, new PaginationParams(page, pageSize)), // ← جديد
  });
};