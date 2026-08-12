// Generated from WebApi/Controllers/NarratorsController.cs + Domain entity.

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

export interface GetAllNarratorsParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Narrators {
  id: number;
}

export interface CreateNarrators {
  id: number;
}

export interface NarratorsPayload {
}

export interface Narrators extends NarratorsPayload {
  id: number;
  isDeleted: boolean;
}

