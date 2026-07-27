import { inject } from '@angular/core';
import { ResolveFn, ActivatedRouteSnapshot } from '@angular/router';
import { forkJoin } from 'rxjs';
import { HadithService } from '../Services/hadith.service';

export const hadithResolver: ResolveFn<any> = (route: ActivatedRouteSnapshot) => {
    const service = inject(HadithService);
    
    const babId      = Number(route.paramMap.get('id'))  || 0;
    const pageNumber = Number(route.queryParamMap.get('page'))     || 1;
    const pageSize   = Number(route.queryParamMap.get('pageSize')) || 10;

    return forkJoin({
        meta       : service.getHadithMeta(babId),
        hadithsData: service.getHadithsByBabId(babId, { pageNumber, pageSize })
    });
};