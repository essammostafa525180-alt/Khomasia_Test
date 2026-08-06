import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Configurations, ModuleEndpoints } from '../../Configurations/config';
import { LookUpItemModel } from '../Models/BaseModel/look-up-item.model';


/**
 * Shared CRUD calls for a module. Not injectable on its own: concrete
 * services extend it and pass their own endpoint map to super().
 */
@Injectable()
export abstract class BaseService<TEntity, TResponse> {

  constructor(protected http: HttpClient, protected endPoints: ModuleEndpoints) { }

  getAll<TResult = TResponse>(): Observable<TResult> {
    return this.http.get<TResult>(Configurations.build(this.endPoints.GetAll));
  }

  getById<TResult = TResponse>(id: number): Observable<TResult> {
    return this.http.get<TResult>(Configurations.build(this.endPoints.GetById(id)));
  }

  create<TResult = TResponse>(model: TEntity): Observable<TResult> {
    return this.http.post<TResult>(Configurations.build(this.endPoints.Create), model);
  }

  update<TResult = TResponse>(id: number, model: TEntity): Observable<TResult> {
    return this.http.put<TResult>(Configurations.build(this.endPoints.Update(id)), model);
  }

  delete<TResult = TResponse>(id: number): Observable<TResult> {
    return this.http.delete<TResult>(Configurations.build(this.endPoints.Delete(id)));
  }


searchCriteria<TResult = TResponse>(query: Partial<TEntity>): Observable<TResult> {
  if (!this.endPoints.Search) {
    throw new Error(`[BaseService] Search endpoint is not defined.`);
  }
  let params = new HttpParams();
  Object.entries(query).forEach(([key, value]) => {
    if (value !== null && value !== undefined && value !== '') {
      params = params.set(key, String(value));
    }
  });
  return this.http.get<TResult>(
    Configurations.build(this.endPoints.Search), { params }
  );
}

  lookUp<TResult = LookUpItemModel>(): Observable<TResult> {
    if (!this.endPoints.LookUp) {
      throw new Error(`[BaseService] LookUp endpoint is not defined.`);
    }
    return this.http.get<TResult>(Configurations.build(this.endPoints.LookUp));
  }

searchLookUp<TResult = LookUpItemModel>(query: Partial<TEntity> | string): Observable<TResult> {
  if (!this.endPoints.SearchLookUp) {
    throw new Error(`[BaseService] SearchLookUp endpoint is not defined.`);
  }

  let params = new HttpParams();
  if (typeof query === 'string') {
    params = params.set('query', query);
  } else if (query && typeof query === 'object') {
    Object.entries(query).forEach(([key, value]) => {
      if (value !== null && value !== undefined && value !== '') {
        params = params.set(key, String(value));
      }
    });
  }

  return this.http.get<TResult>(
    Configurations.build(this.endPoints.SearchLookUp),
    { params: params }
  );
}

}