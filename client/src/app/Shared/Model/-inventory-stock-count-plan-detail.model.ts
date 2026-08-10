// Generated from WebApi/Controllers/InventoryStockCountPlanDetailController.cs + Domain entity.

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

export interface GetAllInventoryStockCountPlanDetailParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryStockCountPlanDetail {
  id: number;
}

export interface CreateInventoryStockCountPlanDetail {
  id: number;
}

export interface InventoryStockCountPlanDetailPayload {
}

export interface InventoryStockCountPlanDetail extends InventoryStockCountPlanDetailPayload {
  id: number;
  isDeleted: boolean;
}

