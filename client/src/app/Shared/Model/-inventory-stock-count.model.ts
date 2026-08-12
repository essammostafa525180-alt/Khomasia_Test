// Generated from WebApi/Controllers/InventoryStockCountController.cs + Domain entity.

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

export interface GetAllInventoryStockCountParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryStockCount {
  id: number;
}

export interface CreateInventoryStockCount {
  id: number;
}

export interface InventoryStockCountPayload {
}

export interface InventoryStockCount extends InventoryStockCountPayload {
  id: number;
  isDeleted: boolean;
}

