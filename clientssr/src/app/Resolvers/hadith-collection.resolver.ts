import { inject } from '@angular/core';
import { ResolveFn } from '@angular/router';
import { HadithService } from '../Services/hadith.service';
import { ApiResponse } from '../Model/BaseModel/api-response';
import { HadithCollection } from '../Model/Hadith/hadith-collection';

export const hadithCollectionResolver: ResolveFn<ApiResponse<HadithCollection>> = (route, state) => {
  const service = inject(HadithService);
  const collectionId = Number(route.paramMap.get('collectionId'));
  return service.getHadithCollection(collectionId);
};
