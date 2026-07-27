import { inject } from '@angular/core';
import { ResolveFn, ActivatedRouteSnapshot } from '@angular/router';
import { HadithService } from '../Services/hadith.service';

export const narratorsResolver: ResolveFn<any> = (route: ActivatedRouteSnapshot) => {
    const service = inject(HadithService);
    
    const pageNumber = Number(route.queryParamMap.get('pageNumber')) || 1;
    const pageSize   = Number(route.queryParamMap.get('pageSize')) || 10;
    const letter     = route.queryParamMap.get('letter') || '';

    return service.getAllNarrator({ pageNumber, pageSize }, letter);
};
