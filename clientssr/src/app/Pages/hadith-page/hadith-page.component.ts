import { Component, OnInit, OnDestroy, AfterViewInit, inject, input } from '@angular/core';
import { toObservable } from '@angular/core/rxjs-interop';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { Router, ActivatedRoute, RouterLink } from '@angular/router';
import { HadithCardComponent } from "../../Components/hadith-card/hadith-card.component";
import { BreadcrumbComponent, BreadcrumbItem } from '../../Components/breadcrumb/breadcrumb.component';
import { EmptyStateComponent } from '../../Components/empty-state/empty-state.component';
import { PageBackgroundComponent } from '../../Components/page-background/page-background.component';
import { IslamicPaginationComponent, PaginationEvent } from '../../Components/islamic-pagination/islamic-pagination.component';
import { MatTooltipModule } from '@angular/material/tooltip';
import { SharedService } from '../../Services/shared.service';
import { SeoService } from '../../Services/seo.service';
import { HadithMeta } from '../../Model/Hadith/hadith-meta';
import { HadithListResponse } from '../../Model/Hadith/hadith-list-response';
import { PagedResult } from '../../Model/BaseModel/paged-result';
import { Navigation } from '../../Model/BaseModel/navigation';

@Component({
    selector: 'app-hadith-page',
    imports: [
    HadithCardComponent,
    MatTooltipModule,
    BreadcrumbComponent,
    EmptyStateComponent,
    PageBackgroundComponent,
    IslamicPaginationComponent,
    RouterLink
],
    templateUrl: './hadith-page.component.html',
    styleUrl: './hadith-page.component.css'
})
export class HadithPageComponent {

    private router = inject(Router);
    private route  = inject(ActivatedRoute);
    private shared = inject(SharedService);
    private seo    = inject(SeoService);

    hadithMeta    :  Navigation<HadithMeta> | null = null;
    pagingHadith  : PagedResult<HadithListResponse> | null = null;
    breadcrumbItems: BreadcrumbItem[]                      = [];

    // ✅ بدل OnInit + subscribe + destroy$
    readonly hadithData = this.route.data.subscribe(({ hadithData }) => {
        if (hadithData?.meta?.isSuccess && hadithData?.hadithsData?.isSuccess) {
            this.setMeta(hadithData.meta.data);
        this.pagingHadith = hadithData.hadithsData.data;
        }
    });

    // --- Private ---

    private setMeta(meta: Navigation<HadithMeta>): void {
        this.hadithMeta = meta;

        this.seo.updateSeoData(
            meta.data.babName || '',
            `تصفح أحاديث ${meta.data.babName} من كتاب ${meta.data.bookName}`
        );

        this.breadcrumbItems = [
            { label: meta.data.classificationName || '', link: ['/classification', meta.data.classificationId] },
            { label: meta.data.bookName           || '', link: ['/book', meta.data.bookId, 'babs']              },
            { label: meta.data.babName            || ''                                                    }
        ];
    }

    // --- Public ---

    onPageChange({ page, pageSize }: PaginationEvent): void {
        this.router.navigate([], {
            relativeTo         : this.route,
            queryParamsHandling: 'merge',
            queryParams        : { page, pageSize }
        });
    }

    goBack(): void {
        this.shared.goBack();
    }
}











// import { Component, OnInit, OnDestroy, AfterViewInit } from '@angular/core';
// import { Subject } from 'rxjs';
// import { takeUntil } from 'rxjs/operators';
// import { HadithCardComponent } from "../../Components/hadith-card/hadith-card.component";
// import { BreadcrumbComponent, BreadcrumbItem } from '../../Components/breadcrumb/breadcrumb.component';
// import { EmptyStateComponent } from '../../Components/empty-state/empty-state.component';
// import { PageBackgroundComponent } from '../../Components/page-background/page-background.component';
// import { IslamicPaginationComponent, PaginationEvent } from '../../Components/islamic-pagination/islamic-pagination.component';
// import { MatTooltipModule } from '@angular/material/tooltip';
// import { ActivatedRoute, Router } from '@angular/router';
// import { SharedService } from '../../Services/shared.service';
// import { SeoService } from '../../Services/seo.service';
// import { HadithMeta } from '../../Model/Hadith/hadith-meta';
// import { HadithListResponse } from '../../Model/Hadith/hadith-list-response';
// import { PagedResult } from '../../Model/BaseModel/paged-result';

// @Component({
//     selector: 'app-hadith-page',
//     imports: [
//         HadithCardComponent,
//         MatTooltipModule,
//         BreadcrumbComponent,
//         EmptyStateComponent,
//         PageBackgroundComponent,
//         IslamicPaginationComponent
//     ],
//     templateUrl: './hadith-page.component.html',
//     styleUrl: './hadith-page.component.css'
// })
// export class HadithPageComponent implements OnInit, AfterViewInit, OnDestroy {

//     hadithMeta    : HadithMeta | null                     = null;
//     pagingHadith  : PagedResult<HadithListResponse> | null = null;
//     breadcrumbItems: BreadcrumbItem[]                     = [];

//     private currentFragment: string | null = null;
//     private destroy$ = new Subject<void>();

//     constructor(
//         private router : Router,
//         private route  : ActivatedRoute,
//         private shared : SharedService,
//         private seo    : SeoService
//     ) { }

//     ngOnInit(): void {
//         this.route.data
//             .pipe(takeUntil(this.destroy$))
//             .subscribe(({ hadithData }) => {
//                 if (hadithData?.meta?.isSuccess && hadithData?.hadithsData?.isSuccess) {
//                     this.handleHadithResponse(
//                         hadithData.meta.data,
//                         hadithData.hadithsData.data
//                     );
//                 }
//             });
//     }

//     ngAfterViewInit(): void {
//         this.route.fragment
//             .pipe(takeUntil(this.destroy$))
//             .subscribe(fragment => {
//                 this.currentFragment = fragment;
//                 this.scrollToFragment();
//             });
//     }

//     ngOnDestroy(): void {
//         this.destroy$.next();
//         this.destroy$.complete();
//     }


//     private handleHadithResponse(
//         meta       : HadithMeta,
//         hadithsData: PagedResult<HadithListResponse>
//     ): void {
//         if (!meta || !hadithsData) return;

//         this.hadithMeta   = meta;
//         this.pagingHadith = hadithsData;

//         this.seo.updateSeoData(
//             meta.babName || '',
//             `تصفح أحاديث ${meta.babName} من كتاب ${meta.bookName}`
//         );

//         this.breadcrumbItems = [
//             { label: meta.classificationName || '', link: ['/classification', meta.classificationId] },
//             { label: meta.bookName           || '', link: ['/book', meta.bookId, 'babs'] },
//             { label: meta.babName            || '' }
//         ];

//         this.scrollToFragment();
//     }

//     private scrollToFragment(): void {
//         if (this.currentFragment && (this.pagingHadith?.items?.length ?? 0) > 0) {
//             this.shared.scrollToElement(this.currentFragment);
//         }
//     }


//     onPageChange(event: PaginationEvent): void {
//         this.router.navigate([], {
//             relativeTo         : this.route,
//             queryParamsHandling: 'merge',  
//             queryParams        : {
//                 page    : event.page,
//                 pageSize: event.pageSize
//             }
//         });
//     }

//     goBack(): void {
//         this.shared.goBack();
//     }
// }