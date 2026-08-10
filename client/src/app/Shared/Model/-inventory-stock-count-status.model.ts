// Generated from WebApi/Controllers/InventoryStockCountStatusController.cs + Domain entity.

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

export interface GetAllInventoryStockCountStatusParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryStockCountStatus {
  id: number;
}

export interface CreateInventoryStockCountStatus {
  id: number;
}

export interface InventoryStockCountStatusPayload {
}

export interface InventoryStockCountStatus extends InventoryStockCountStatusPayload {
  id: number;
  isDeleted: boolean;
}

