// Generated from WebApi/Controllers/AssetCountStatusController.cs + Domain entity.

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

export interface GetAllAssetCountStatusParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssetCountStatus {
  id: number;
}

export interface CreateAssetCountStatus {
  id: number;
}

export interface AssetCountStatusPayload {
}

export interface AssetCountStatus extends AssetCountStatusPayload {
  id: number;
  isDeleted: boolean;
}

