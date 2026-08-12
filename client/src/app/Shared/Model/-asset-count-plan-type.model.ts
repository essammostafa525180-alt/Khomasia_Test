// Generated from WebApi/Controllers/AssetCountPlanTypeController.cs + Domain entity.

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

export interface GetAllAssetCountPlanTypeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssetCountPlanType {
  id: number;
}

export interface CreateAssetCountPlanType {
  id: number;
}

export interface AssetCountPlanTypePayload {
}

export interface AssetCountPlanType extends AssetCountPlanTypePayload {
  id: number;
  isDeleted: boolean;
}

