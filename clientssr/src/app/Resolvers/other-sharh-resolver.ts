import { inject } from '@angular/core';
import { ResolveFn } from '@angular/router';
import { forkJoin } from 'rxjs';
import { HadithService } from '../Services/hadith.service';
import { ApiResponse } from '../Model/BaseModel/api-response';
import { OtherBookSharhHadithResponse } from '../Model/Sharh/other-book-sharh-hadith-content';
import { HadithListResponse } from '../Model/Hadith/hadith-list-response';

export interface OtherSharhResolvedData {
  otherBookSharh: ApiResponse<OtherBookSharhHadithResponse[]>;
  hadith: ApiResponse<HadithListResponse>;
}

export const otherSharhResolver: ResolveFn<OtherSharhResolvedData> = (route, state) => {
  const service = inject(HadithService);
  const id = Number(route.paramMap.get('id'));
  return forkJoin({
    otherBookSharh: service.getOtherBookSharh(id),
    hadith: service.getHadithById(id)
  });
};