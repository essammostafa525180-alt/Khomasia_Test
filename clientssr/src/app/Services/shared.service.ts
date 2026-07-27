import { Injectable, Type, Inject, PLATFORM_ID, NgZone } from '@angular/core';
import { Router } from '@angular/router';
import { Location, isPlatformBrowser } from '@angular/common';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject, Observable } from 'rxjs';

export interface SearchParams {
    query: string;
    classificationId: number | null;
}

@Injectable({
    providedIn: 'root'
})
export class SharedService {

    private searchParamsSubject = new BehaviorSubject<SearchParams | null>(null);
    public searchParams$ = this.searchParamsSubject.asObservable();

    private isSearchingSubject = new BehaviorSubject<boolean>(false);
    public isSearching$ = this.isSearchingSubject.asObservable();

    constructor(
        private router: Router,
        private toastr: ToastrService,
        private location: Location,
        private dialog: MatDialog,
        private ngZone: NgZone,
        @Inject(PLATFORM_ID) private platformId: Object
    ) { }

    updateSearch(params: SearchParams) {
        if (params.query.trim() || params.classificationId !== null) {
            this.searchParamsSubject.next(params);
            this.isSearchingSubject.next(true);
        } else {
            this.clearSearch();
        }
    }

    clearSearch() {
        this.searchParamsSubject.next(null);
        this.isSearchingSubject.next(false);
    }

    getSearchParamsValue(): SearchParams | null {
        return this.searchParamsSubject.value;
    }


    triggerToast(message: string, type: 'success' | 'error' | 'warning' | 'info' = 'success') {
        switch (type) {
            case 'success': this.toastr.success(message, 'تم بنجاح'); break;
            case 'error': this.toastr.error(message, 'خطأ'); break;
            case 'warning': this.toastr.warning(message, 'تنبيه'); break;
            case 'info': this.toastr.info(message, 'إفادة'); break;
        }
    }

    goToHadith(babId: number | undefined, hadithId: number | undefined) {
        if (babId && hadithId) {
            this.router.navigate(['/', 'bab', babId, 'hadith'], { fragment: 'hadith-' + hadithId });
        }
    }


    shareHadith(babId: number, hadithId: number, text: string) {
        const shareUrl = this.getHadithShareUrl(babId, hadithId);
        const shareTitle = 'الحديث ';

        if (navigator.share) {
            navigator.share({
                title: shareTitle,
                // text: text,
                url: shareUrl,
            })
        } else {
            // Fallback: Copy link to clipboard if Web Share is not supported
            navigator.clipboard.writeText(shareUrl).then(() => {
                alert('تم نسخ رابط الحديث لمشاركته');
            });
        }
    }

    /** المشاركة على فيسبوك */
    shareOnFacebook(babId: number, hadithId: number) {
        const url = this.getHadithShareUrl(babId, hadithId);
        window.open(`https://www.facebook.com/sharer/sharer.php?u=${encodeURIComponent(url)}`, '_blank', 'noopener,noreferrer');
    }

    /** المشاركة على منصة X (تويتر سابقاً) */
    shareOnX(babId: number, hadithId: number, text: string) {
        const url = this.getHadithShareUrl(babId, hadithId);
        const shareText = `الحديث : ${text}`;
        window.open(`https://twitter.com/intent/tweet?url=${encodeURIComponent(url)}&text=${encodeURIComponent(shareText)}`, '_blank', 'noopener,noreferrer');
    }

    /** توليد رابط الحديث المباشر */
    private getHadithShareUrl(babId: number, hadithId: number): string {
        return `${window.location.origin}/bab/${babId}/hadith#hadith-${hadithId}`;
    }


    openDialog<T>(component: Type<T>, data: any = null, panelClass: string = 'rawi-dialog'): MatDialogRef<T> {
        return this.dialog.open(component, {
            width: '90vw',
            maxWidth: '800px',
            height: 'auto',
            panelClass,
            data
        });
    }


    openContactDialog<T>(component: Type<T>, data: any = null): MatDialogRef<T> {
        return this.dialog.open(component, {
            width: '60vw',
            maxWidth: '500px',
            height: 'auto',
            panelClass: 'contact-dialog',
            data
        });
    }

  
    goBack() {
        this.location.back();
    }

    scrollToElement(fragment: string, delay: number = 200) {
        if (!isPlatformBrowser(this.platformId)) return;

        this.ngZone.runOutsideAngular(() => {
            setTimeout(() => {
                const element = document.getElementById(fragment);
                if (element) {
                    element.scrollIntoView({ behavior: 'smooth', block: 'start' });
                }
            }, delay);
        });
    }
}
