// Generated from WebApi/Controllers/AssetScrapStatusController.cs + Domain entity.

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

export interface GetAllAssetScrapStatusParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssetScrapStatus {
  id: number;
}

export interface CreateAssetScrapStatus {
  id: number;
}

export interface AssetScrapStatusPayload {
}

export interface AssetScrapStatus extends AssetScrapStatusPayload {
  id: number;
  isDeleted: boolean;
}

