// Generated from WebApi/Controllers/StoreSequenceController.cs + Domain entity.

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

export interface GetAllStoreSequenceParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface StoreSequence {
  id: number;
}

export interface CreateStoreSequence {
  id: number;
}

export interface StoreSequencePayload {
}

export interface StoreSequence extends StoreSequencePayload {
  id: number;
  isDeleted: boolean;
}

