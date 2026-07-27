import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, TransferState, makeStateKey, Inject, PLATFORM_ID } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { catchError, map, Observable, of, take } from 'rxjs';
import { ApiResponse } from '../Model/BaseModel/api-response';
import { PagedResult } from '../Model/BaseModel/paged-result';
import { AuthorDetials } from '../Model/Book/author-detials';
import { BookDetailsWithBabsResponse } from '../Model/Book/book-details-with-babs-response';
import { Navigation } from '../Model/BaseModel/navigation';
import { PaginationParams } from '../Model/BaseModel/PaginationParams';
import { NarratorListResponse } from '../Model/Narrators/narrator-list-response';
import { ClassificationWithBookSharhListResponse } from '../Model/Sharh/ClassificationWithBookSharhListResponse';
import { SharhClassifacationResponse } from '../Model/Sharh/SharhClassifacationResponse';
import { BabListResponse } from '../Model/Babs/bab-list-response';
import { PartitionsData } from '../Model/Partition/partitions-data';
import { ClassificationDetails, ClassificationSummary } from '../Model/Classification/classification-summary';
import { NarratorDetailsResponse } from '../Model/Narrators/narrator-details-response';
import { SharhBabListResponse } from '../Model/Sharh/sharh-bab-list-response';
import { HadithCollection } from '../Model/Hadith/hadith-collection';
import { HadithContantResponse } from '../Model/Hadith/hadith-contant-response';
import { HadithTranslation } from '../Model/Hadith/hadith-translation';
import { BookSharhListResponse } from '../Model/Sharh/book-sharh-list-response';
import { HadithSharhResponse } from '../Model/Sharh/hadith-sharh-response';
import { Classification } from '../Model/Classification/classification';
import { TakhreejContantListResponse } from '../Model/Takhreej/takhreej-contant-list-response';
import { ContactMessage } from '../Model/ContactUs/contact-message';

import { OtherBookSharhHadithResponse } from '../Model/Sharh/other-book-sharh-hadith-content';
import { HadithListResponse } from '../Model/Hadith/hadith-list-response';
import { SearchResult } from '../Model/Hadith/search-result';


import { isPlatformServer } from '@angular/common';
import { BookSummary } from '../Model/Book/book-summary';
import { HadithMeta } from '../Model/Hadith/hadith-meta';
import { SharhBookMeta } from '../Model/Sharh/sharh-book-meta';

@Injectable({
  providedIn: 'root'
})
export class HadithService {

  constructor(
    private _httpClient: HttpClient,
    private transferState: TransferState,
    @Inject(PLATFORM_ID) private platformId: Object
  ) { }

private getWithTransferState<T>(keyName: string, apiCall: Observable<T>): Observable<T> {
  const key = makeStateKey<T>(keyName);

  if (this.transferState.hasKey(key)) {
    const data = this.transferState.get(key, null as any);
    this.transferState.remove(key);
    return of(data).pipe(take(1));
  }

  return apiCall.pipe(
    take(1),
    map(response => {
      if (isPlatformServer(this.platformId)) {
        this.transferState.set(key, response);
      }
      return response;
    }),
    catchError(err => {
      console.error(`[SSR] API Error for key "${keyName}":`, err.message || err);
      throw err;
    })
  );
}

  // --- Partitions (الأقسام) ---

  /** جلب كل الأقسام الرئيسية */
  getAllPartitions(): Observable<ApiResponse<PartitionsData>> {
    const apiCall = this._httpClient.get<ApiResponse<PartitionsData>>(
      `${environment.baseUrl}Partitions/get-all`);
    return this.getWithTransferState('all-partitions', apiCall);
  }

  // --- Hadith Collections (المجلدات) ---

  /** جلب المجلدات الخاصة بقسم معين */
  getHadithCollectionsByPartition(partitionId: number): Observable<ApiResponse<PagedResult<HadithCollection>>> {
    const apiCall = this._httpClient.get<ApiResponse<PagedResult<HadithCollection>>>(
      `${environment.baseUrl}HadithCollections/get-all-by-partitionId/${partitionId}`
    );
    return this.getWithTransferState(`collections-partition-${partitionId}`, apiCall);
  }

  /** جلب بيانات مجلد معين بواسطة المعرف */
  getHadithCollection(id: number): Observable<ApiResponse<HadithCollection>> {
    const apiCall = this._httpClient.get<ApiResponse<HadithCollection>>(
      `${environment.baseUrl}HadithCollections/get-by-id/${id}`
    );
    return this.getWithTransferState(`collection-${id}`, apiCall);
  }

  // --- Classifications (التصنيفات) ---

  /** جلب التصنيفات والكتب الخاصة بها */
  getClassificationWithBooks(id: number): Observable<any> {
    return this._httpClient.get<any>(
      `${environment.baseUrl}${id}/classifications`);
  }
  getClassificationById(id: number): Observable<ApiResponse<ClassificationDetails>> {
    const apiCall = this._httpClient.get<any>(
      `${environment.baseUrl}Classifications/${id}`);
       return this.getWithTransferState(`classification-${id}`, apiCall);
  }
  getBooksByClassification(
    classificationId: number, 
    pagination?: PaginationParams
  ): Observable<ApiResponse<PagedResult<BookSummary>>> {
    
    let params = new HttpParams()
      .set('classificationId', classificationId);

    if (pagination) {
      params = params
        .set('pageNumber', pagination.pageNumber)
        .set('pageSize', pagination.pageSize);
    }

  const url = `${environment.baseUrl}Books/ByClassification`;
  const apiCall = this._httpClient.get<any>(url, { params });

  const pageKey = pagination ? `-p${pagination.pageNumber}` : '';
  return this.getWithTransferState(
    `Books-ClassificationById-${classificationId}${pageKey}`, 
    apiCall
  );
}

  /** جلب كل التصنيفات المتاحة */
  getAllClassification(): Observable<ApiResponse<PagedResult<Classification>>> {
    const apiCall = this._httpClient.get<ApiResponse<PagedResult<Classification>>>(
      `${environment.baseUrl}Classifications/get-all`);
    return this.getWithTransferState('all-classifications', apiCall);
  }

  /** جلب ملخص بيانات تصنيف معين */
  getClassificationSummary(classificationId: number): Observable<ApiResponse<ClassificationSummary>> {
    const apiCall = this._httpClient.get<ApiResponse<ClassificationSummary>>(
      `${environment.baseUrl}Classifications/get-by-id/${classificationId}`
    );
    return this.getWithTransferState(`classification-summary-${classificationId}`, apiCall);
  }

  /** جلب بيانات مؤلف التصنيف */
getClassificationAuthorDetailsById(id: number): Observable<ApiResponse<AuthorDetials>> {
  const apiCall = this._httpClient.get<ApiResponse<AuthorDetials>>(
    `${environment.baseUrl}classifications/get-auther-info-by-id/${id}`
  );
  // ✅ ضيف TransferState
  return this.getWithTransferState(`author-details-${id}`, apiCall);
}


  /** جلب تفاصيل الكتاب مع قائمة أبوابه */
  getBookDetailsWithBabs(bookId: number) {
    const apiCall = this._httpClient.get<ApiResponse<Navigation<BookDetailsWithBabsResponse>>>(
      `${environment.baseUrl}Books/get-details-with-babs/${bookId}`
    );
    return this.getWithTransferState(`book-details-${bookId}`, apiCall);
  }

  /** جلب جميع الأبواب التابعة لكتاب معين */
  getAllBabsByBookId(bookId: number) {
    return this._httpClient.get<ApiResponse<PagedResult<BabListResponse>>>(
      `${environment.baseUrl}Babs/get-all-by-bookId/${bookId}`
    );
  }
  getHadithMeta(Id: number) {
    const apiCall = this._httpClient.get<ApiResponse<Navigation<HadithMeta>>>(
      `${environment.baseUrl}Hadiths/${Id}/meta`
    );
       return this.getWithTransferState(`hadith-meta-${Id}`, apiCall);
  }
getHadithsByBabId(babId: number, pagination?: PaginationParams) {
    let params = new HttpParams()
        .set('babId', babId);

    if (pagination) {
        params = params
            .set('pageNumber', pagination.pageNumber)
            .set('pageSize', pagination.pageSize);

    }

    const apiCall = this._httpClient.get<ApiResponse<PagedResult<HadithListResponse>>>(
        `${environment.baseUrl}Hadiths`,
        { params }  
    );
       return this.getWithTransferState(`hadith-bab-page-p${pagination?.pageNumber}-s${pagination?.pageSize}`, apiCall);

}

  // --- Narrators (الرواة) ---

  /** جلب قائمة الرواة مع إمكانية البحث والفلترة بالحرف الأول */
  getAllNarrator(params: PaginationParams, letter: string | null = null): Observable<ApiResponse<PagedResult<NarratorListResponse>>> {
    const apiCall = this._httpClient.get<ApiResponse<PagedResult<NarratorListResponse>>>(
      `${environment.baseUrl}Narrators/get-all?pageNumber=${params.pageNumber}&pageSize=${params.pageSize}&letter=${letter}`);

      return this.getWithTransferState(
  `narrators-page-p${params.pageNumber}-s${params.pageSize}${letter ? '-l' + letter : ''}`,
  apiCall
);
  }

  /** جلب تفاصيل راوٍ معين */
  getNarratorDetails(id: number): Observable<ApiResponse<NarratorDetailsResponse>> {
    return this._httpClient.get<ApiResponse<NarratorDetailsResponse>>(`${environment.baseUrl}Narrators/get-by-id/${id}`);
  }

  getSharhBookMeta(bookSharhId: number): Observable<ApiResponse<SharhBookMeta>> {
  const apiCall = this._httpClient.get<ApiResponse<SharhBookMeta>>(
    `${environment.baseUrl}Sharhs/${bookSharhId}/meta`);

  return this.getWithTransferState(
    `sharh-book-meta-${bookSharhId}`,
    apiCall
  );
}

  /** جلب كل كتب الشروح التابعة لتصنيف معين */
  getAllBookSharh(classificationId: number): Observable<ApiResponse<ClassificationWithBookSharhListResponse>> {
    const apiCall = this._httpClient.get<ApiResponse<ClassificationWithBookSharhListResponse>>(
      `${environment.baseUrl}Sharhs/get-all-by-ClassificationId/${classificationId}`
    );
    return this.getWithTransferState(`book-sharh-${classificationId}`, apiCall);
  }

  /** جلب تفاصيل كتاب شرح معين */
  getBookSharhDetails(id: number): Observable<ApiResponse<SharhClassifacationResponse>> {
    return this._httpClient.get<ApiResponse<SharhClassifacationResponse>>(
      `${environment.baseUrl}Sharhs/get-by-id/${id}`);
  }

  /** جلب كل أبواب الشرح لكتاب وباب معينين */
  getAllBabSharh(bookId: number, babId: number): Observable<ApiResponse<SharhBabListResponse[]>> {
    return this._httpClient.get<ApiResponse<SharhBabListResponse[]>>(
      `${environment.baseUrl}Sharhs/${bookId}/get-all-bab/${babId}`);
  }

  /** جلب شروحات حديث معين */
  getBookSharhByHadithId(hadithId: number): Observable<ApiResponse<HadithSharhResponse[]>> {
    return this._httpClient.get<ApiResponse<HadithSharhResponse[]>>(
      `${environment.baseUrl}Sharhs/get-by-HadithId/${hadithId}`);
  }
  /** جلب شروحات حديث معين */
  getHadithSharhByHadithId(bookId: number, hadithId: number): Observable<ApiResponse<HadithSharhResponse>> {
    return this._httpClient.get<ApiResponse<HadithSharhResponse>>(
      `${environment.baseUrl}Sharhs/get-by-bookId/${bookId}/hadithId/${hadithId}`);
  }
  /** جلب الشروحات المتوفرة للحديث في كتب أخرى غير الكتاب الأصلي */
  getOtherBookSharh(hadithId: number): Observable<ApiResponse<OtherBookSharhHadithResponse[]>> {
    return this._httpClient.get<ApiResponse<OtherBookSharhHadithResponse[]>>(
      `${environment.baseUrl}Sharhs/get-other-books-by-HadithId/${hadithId}`
    );
  }

  // --- Hadiths (الأحاديث) ---

  /** جلب جميع الأحاديث المدرجة تحت باب معين */
  getAllHadithByBabId(babId: number): Observable<ApiResponse<HadithContantResponse>> {
    const apiCall = this._httpClient.get<ApiResponse<HadithContantResponse>>(
      `${environment.baseUrl}Hadiths/get-all-by-babId/${babId}`);
    
    return this.getWithTransferState(`hadiths-bab-${babId}`, apiCall);
  }

  /** جلب ترجمة حديث معين بلغة محددة */
  getHadithByLang(langId: number, selId: number): Observable<ApiResponse<HadithTranslation>> {
    return this._httpClient.get<ApiResponse<HadithTranslation>>(
      `${environment.baseUrl}Hadiths/get-by-lang/${langId}/hadith/${selId}`);
  }

  /** جلب بيانات حديث معين بواسطة المعرف */
  getHadithById(hadithId: number): Observable<ApiResponse<HadithListResponse>> {
    return this._httpClient.get<ApiResponse<HadithListResponse>>(
      `${environment.baseUrl}Hadiths/get-by-id/${hadithId}`);
  }

  /** البحث عن الأحاديث بناءً على النص والتصنيف باستخدام كلاس التصفح */
  searchHadiths(hadithText: string, classificationId: number | null = null, pagination: PaginationParams): Observable<ApiResponse<PagedResult<SearchResult>>> {
    let url = `${environment.baseUrl}Hadiths/search?HadithText=${hadithText}&PageNumber=${pagination.pageNumber}&PageSize=${pagination.pageSize}`;

    if (classificationId) {
      url += `&ClassifcationId=${classificationId}`;
    }

    return this._httpClient.get<ApiResponse<PagedResult<SearchResult>>>(url);
  }

  // --- Takhreej (التخريج) ---

  /** جلب بيانات تخريج حديث معين */
  getTakhreejList(hadithId: number): Observable<ApiResponse<PagedResult<TakhreejContantListResponse>>> {
    return this._httpClient.get<ApiResponse<PagedResult<TakhreejContantListResponse>>>(
      `${environment.baseUrl}Takheejs/get-by-hadithId/${hadithId}`);
  }

  // --- Contact & Proposals (التواصل والاقتراحات) ---

  /** إرسال اقتراح تعديل أو رسالة تواصل */
  CreateProposal(data: ContactMessage): Observable<void> {
    return this._httpClient.post<void>(`${environment.baseUrl}Contacts/create`, data);
  }


  getAudio(audioUrl: string): Observable<ApiResponse<Blob>> {
    // Extract numbers (ID) from the filename if possible, otherwise use the filename
    const parts = audioUrl.split('/');
    const lastPart = parts.pop() || '';
    const fileName = lastPart.split('?')[0]; // Remove query params

    // Construct the proxy URL
    const url = `${environment.baseUrl}Hadiths/get-audio/${fileName}`;

    return this._httpClient.get(url, { responseType: 'blob' })
      .pipe(
        map(blob => ({ isSuccess: true, data: blob, errorMessage: null } as ApiResponse<Blob>)),
        catchError((err) => {
          return of({ isSuccess: false, data: new Blob(), errorMessage: 'Audio not found' } as ApiResponse<Blob>);
        })
      );
  }
}
