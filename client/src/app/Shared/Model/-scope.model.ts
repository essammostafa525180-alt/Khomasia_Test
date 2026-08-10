// Generated from WebApi/Controllers/ScopeController.cs + Domain entity.

export interface ApiResult<T> {
  isSuccess: boolean;
  data: T;
  errorMessage: string | null;
}

export interface PagedResult<T> {
  items: T[];
  currentPage: number;
  itemsPerPage: number;
  totalItems: number;
  totalPages: number;
  nextPage: boolean;
}

export interface GetAllScopeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Scope {
  id: number;
}

export interface CreateScope {
  id: number;
}

export interface ScopePayload {
}

export interface Scope extends ScopePayload {
  id: number;
  isDeleted: boolean;
}

