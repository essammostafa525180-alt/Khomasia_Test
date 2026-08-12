// Generated from WebApi/Controllers/StoreController.cs + Domain entity.

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

export interface GetAllStoreParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Store {
  id: number;
}

export interface CreateStore {
  id: number;
}

export interface StorePayload {
}

export interface Store extends StorePayload {
  id: number;
  isDeleted: boolean;
}

