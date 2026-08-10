// Generated from WebApi/Controllers/StockCountPlanStatusController.cs + Domain entity.

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

export interface GetAllStockCountPlanStatusParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface StockCountPlanStatus {
  id: number;
}

export interface CreateStockCountPlanStatus {
  id: number;
}

export interface StockCountPlanStatusPayload {
}

export interface StockCountPlanStatus extends StockCountPlanStatusPayload {
  id: number;
  isDeleted: boolean;
}

