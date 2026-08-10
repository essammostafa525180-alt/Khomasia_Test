// Generated from WebApi/Controllers/AssetItemMaintenanceController.cs + Domain entity.

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

export interface GetAllAssetItemMaintenanceParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssetItemMaintenance {
  id: number;
  assetItemFk?: number | null;
  code?: string | null;
  assetItemMoveFk?: number | null;
  assetMaintenanceStatusFk?: number | null;
  assetItemFkNavigation?: any | null;
  assetItemMoveFkNavigation?: any | null;
  assetMaintenanceStatusFkNavigation?: any | null;
}

export interface CreateAssetItemMaintenance {
  id: number;
  assetItemFk?: number | null;
  code?: string | null;
  assetItemMoveFk?: number | null;
  assetMaintenanceStatusFk?: number | null;
  assetItemFkNavigation?: any | null;
  assetItemMoveFkNavigation?: any | null;
  assetMaintenanceStatusFkNavigation?: any | null;
}

export interface AssetItemMaintenancePayload {
  assetItemFk?: number | null;
  code?: string | null;
  assetItemMoveFk?: number | null;
  assetMaintenanceStatusFk?: number | null;
  assetItemFkNavigation?: any | null;
  assetItemMoveFkNavigation?: any | null;
  assetMaintenanceStatusFkNavigation?: any | null;
}

export interface AssetItemMaintenance extends AssetItemMaintenancePayload {
  id: number;
  isDeleted: boolean;
}

