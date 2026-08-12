// Generated from WebApi/Controllers/AssetMaintenanceStatusController.cs + Domain entity.

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

export interface GetAllAssetMaintenanceStatusParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssetMaintenanceStatus {
  id: number;
}

export interface CreateAssetMaintenanceStatus {
  id: number;
}

export interface AssetMaintenanceStatusPayload {
}

export interface AssetMaintenanceStatus extends AssetMaintenanceStatusPayload {
  id: number;
  isDeleted: boolean;
}

