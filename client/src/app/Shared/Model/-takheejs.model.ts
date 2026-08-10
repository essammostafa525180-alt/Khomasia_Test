// Generated from WebApi/Controllers/TakheejsController.cs + Domain entity.

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

export interface GetAllTakheejsParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Takheejs {
  id: number;
}

export interface CreateTakheejs {
  id: number;
}

export interface TakheejsPayload {
}

export interface Takheejs extends TakheejsPayload {
  id: number;
  isDeleted: boolean;
}

