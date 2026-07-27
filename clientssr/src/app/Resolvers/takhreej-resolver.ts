import { inject } from '@angular/core';
import { ResolveFn } from '@angular/router';
import { HadithService } from '../Services/hadith.service';
import { ApiResponse } from '../Model/BaseModel/api-response';
import { PagedResult } from '../Model/BaseModel/paged-result';
import { TakhreejContantListResponse } from '../Model/Takhreej/takhreej-contant-list-response';

export const takhreejResolver: ResolveFn<ApiResponse<PagedResult<TakhreejContantListResponse>>> = (route, state) => {
  const service = inject(HadithService);
  const id = Number(route.paramMap.get('id'));
  return service.getTakhreejList(id);
};