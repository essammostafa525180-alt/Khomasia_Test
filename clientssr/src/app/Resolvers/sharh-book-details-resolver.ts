import { inject } from '@angular/core';
import { ResolveFn } from '@angular/router';
import { HadithService } from '../Services/hadith.service';
import { ApiResponse } from '../Model/BaseModel/api-response';
import { SharhClassifacationResponse } from '../Model/Sharh/SharhClassifacationResponse';

export const sharhBookDetailsResolver: ResolveFn<ApiResponse<SharhClassifacationResponse>> = (route, state) => {
  const service = inject(HadithService);
  const id = Number(route.paramMap.get('id'));
  return service.getBookSharhDetails(id);
};