import { inject } from '@angular/core';
import { ResolveFn } from '@angular/router';
import { HadithService } from '../Services/hadith.service';
import { ApiResponse } from '../Model/BaseModel/api-response';
import { PagedResult } from '../Model/BaseModel/paged-result';
import { HadithCollection } from '../Model/Hadith/hadith-collection';

export const partitionCollectionsResolver: ResolveFn<ApiResponse<PagedResult<HadithCollection>>> = (route) => {
  const partitionId = Number(route.paramMap.get('partitionId'));
  return inject(HadithService).getHadithCollectionsByPartition(partitionId);
};
