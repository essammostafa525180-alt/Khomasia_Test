// Generated from WebApi/Controllers/StoreKeeperController.cs + Domain entity.

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

export interface GetAllStoreKeeperParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface StoreKeeper {
  id: number;
}

export interface CreateStoreKeeper {
  id: number;
}

export interface StoreKeeperPayload {
}

export interface StoreKeeper extends StoreKeeperPayload {
  id: number;
  isDeleted: boolean;
}

