import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { environment } from '../../../environments/environment';
import {
  ApiResult,
  GetAllInventoryItemsParams,
  InventoryItem,
  InventoryItemPayload,
  PagedResult
} from '../../Shared/Model/inventory-item.model';
@Injectable({ providedIn: 'root' })
export class InventoryItemService {
  private readonly http = inject(HttpClient);
  private readonly baseUrl = `${environment.apiUrl}/api/v1/InventoryItem`;

  getAll(
    params: GetAllInventoryItemsParams = {}
  ): Observable<PagedResult<InventoryItem>> {
    let httpParams = new HttpParams()
      .set('PageNumber', params.pageNumber ?? 1)
      .set('PageSize', params.pageSize ?? 100);

    if (params.searchText?.trim()) {
      httpParams = httpParams.set('SearchText', params.searchText.trim());
    }

    return this.http
      .get<ApiResult<PagedResult<InventoryItem>>>(`${this.baseUrl}/get-all`, {
        params: httpParams
      })
      .pipe(
        map((result) => this.unwrap(result)),
        catchError((error) => this.handleError(error))
      );
  }

  search(searchText: string): Observable<PagedResult<InventoryItem>> {
    return this.getAll({ searchText });
  }

  getById(id: number): Observable<InventoryItem> {
    return this.http
      .get<ApiResult<InventoryItem>>(`${this.baseUrl}/get-by-id/${id}`)
      .pipe(
        map((result) => this.unwrap(result)),
        catchError((error) => this.handleError(error))
      );
  }

  create(payload: InventoryItemPayload): Observable<number> {
    return this.http
      .post<ApiResult<number>>(`${this.baseUrl}/create`, payload)
      .pipe(
        map((result) => this.unwrap(result)),
        catchError((error) => this.handleError(error))
      );
  }

  update(id: number, payload: InventoryItemPayload): Observable<void> {
    return this.http
      .put<ApiResult<null>>(`${this.baseUrl}/update/${id}`, payload)
      .pipe(
        map((result) => {
          this.unwrap(result);
        }),
        catchError((error) => this.handleError(error))
      );
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/delete/${id}`).pipe(
      catchError((error) => this.handleError(error))
    );
  }

  private unwrap<T>(result: ApiResult<T>): T {
    if (!result.isSuccess) {
      throw new Error(result.errorMessage ?? 'Unexpected error');
    }
    return result.data;
  }

  private handleError(error: unknown): Observable<never> {
    const message =
      error instanceof Error
        ? error.message
        : (error as { message?: string })?.message ?? 'Unexpected error';
    return throwError(() => new Error(message));
  }
}
