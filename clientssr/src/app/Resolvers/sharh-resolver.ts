import { catchError, map } from 'rxjs/operators';
import { SharhBookMeta } from '../Model/Sharh/sharh-book-meta';
import { SharhBabListResponse } from '../Model/Sharh/sharh-bab-list-response';
import { ResolveFn } from '@angular/router';
import { HadithService } from '../Services/hadith.service';
import { inject } from '@angular/core';
import { ApiResponse } from '../Model/BaseModel/api-response';
import { forkJoin, of } from 'rxjs';

export interface SharhResolvedData {
  bookMeta: SharhBookMeta | null;
  babSharhList: SharhBabListResponse[];
}

export const sharhResolver: ResolveFn<SharhResolvedData> = (route, state) => {
  const service = inject(HadithService);

  const bookId = Number(route.paramMap.get('id'));
  const babId = route.paramMap.get('babId') ? Number(route.paramMap.get('babId')) : null;

  const bookMeta$ = service.getSharhBookMeta(bookId).pipe(
    map((res: ApiResponse<SharhBookMeta>) => (res.isSuccess ? res.data : null)),
    catchError(() => of(null))
  );

  const babSharh$ = babId
    ? service.getAllBabSharh(bookId, babId).pipe(
        map((res: ApiResponse<SharhBabListResponse[]>) => (res.isSuccess && res.data ? res.data : [])),
        catchError(() => of([]))
      )
    : of([]);


  return forkJoin({ bookMeta: bookMeta$, babSharhList: babSharh$ }).pipe(
    map(result => ({
      bookMeta: result.bookMeta,
      babSharhList: result.babSharhList
    }))
  );
};