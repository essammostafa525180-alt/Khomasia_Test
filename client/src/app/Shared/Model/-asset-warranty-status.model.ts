// Generated from WebApi/Controllers/AssetWarrantyStatusController.cs + Domain entity.

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

export interface GetAllAssetWarrantyStatusParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssetWarrantyStatus {
  id: number;
}

export interface CreateAssetWarrantyStatus {
  id: number;
}

export interface AssetWarrantyStatusPayload {
}

export interface AssetWarrantyStatus extends AssetWarrantyStatusPayload {
  id: number;
  isDeleted: boolean;
}

