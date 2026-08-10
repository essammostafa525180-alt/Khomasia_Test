// Generated from WebApi/Controllers/SharhsController.cs + Domain entity.

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

export interface GetAllSharhsParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Sharhs {
  id: number;
}

export interface CreateSharhs {
  id: number;
}

export interface SharhsPayload {
}

export interface Sharhs extends SharhsPayload {
  id: number;
  isDeleted: boolean;
}

