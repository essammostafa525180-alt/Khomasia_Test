// Generated from WebApi/Controllers/CostCenterController.cs + Domain entity.

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

export interface GetAllCostCenterParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface CostCenter {
  id: number;
}

export interface CreateCostCenter {
  id: number;
}

export interface CostCenterPayload {
}

export interface CostCenter extends CostCenterPayload {
  id: number;
  isDeleted: boolean;
}

