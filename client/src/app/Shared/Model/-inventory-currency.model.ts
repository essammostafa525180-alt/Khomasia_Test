// Generated from WebApi/Controllers/InventoryCurrencyController.cs + Domain entity.

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

export interface GetAllInventoryCurrencyParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryCurrency {
  id: number;
}

export interface CreateInventoryCurrency {
  id: number;
}

export interface InventoryCurrencyPayload {
}

export interface InventoryCurrency extends InventoryCurrencyPayload {
  id: number;
  isDeleted: boolean;
}

