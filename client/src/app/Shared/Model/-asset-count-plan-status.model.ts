// Generated from WebApi/Controllers/AssetCountPlanStatusController.cs + Domain entity.

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

export interface GetAllAssetCountPlanStatusParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssetCountPlanStatus {
  id: number;
}

export interface CreateAssetCountPlanStatus {
  id: number;
}

export interface AssetCountPlanStatusPayload {
}

export interface AssetCountPlanStatus extends AssetCountPlanStatusPayload {
  id: number;
  isDeleted: boolean;
}

