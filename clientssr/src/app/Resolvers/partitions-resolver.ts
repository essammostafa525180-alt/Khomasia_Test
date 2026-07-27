import { inject } from '@angular/core';
import { ActivatedRouteSnapshot, ResolveFn, RouterStateSnapshot } from '@angular/router';
import { HadithService } from '../Services/hadith.service';
import { ApiResponse } from '../Model/BaseModel/api-response';
import { PagedResult } from '../Model/BaseModel/paged-result';
import { Classification } from '../Model/Classification/classification';
import { Observable } from 'rxjs';

export const partitionsResolver: ResolveFn<ApiResponse<PagedResult<Classification>>> = (route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<ApiResponse<PagedResult<Classification>>> => {
  const service = inject(HadithService);
  return service.getAllClassification();
};
