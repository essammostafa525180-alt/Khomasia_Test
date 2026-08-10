// Generated from WebApi/Controllers/SecPropertyController.cs + Domain entity.

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

export interface GetAllSecPropertyParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface SecProperty {
  id: number;
}

export interface CreateSecProperty {
  id: number;
}

export interface SecPropertyPayload {
}

export interface SecProperty extends SecPropertyPayload {
  id: number;
  isDeleted: boolean;
}

