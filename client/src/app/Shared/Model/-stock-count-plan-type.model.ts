// Generated from WebApi/Controllers/StockCountPlanTypeController.cs + Domain entity.

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

export interface GetAllStockCountPlanTypeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface StockCountPlanType {
  id: number;
}

export interface CreateStockCountPlanType {
  id: number;
}

export interface StockCountPlanTypePayload {
}

export interface StockCountPlanType extends StockCountPlanTypePayload {
  id: number;
  isDeleted: boolean;
}

