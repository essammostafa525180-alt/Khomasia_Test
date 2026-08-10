// Generated from WebApi/Controllers/AssetItemScrapController.cs + Domain entity.

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

export interface GetAllAssetItemScrapParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssetItemScrap {
  id: number;
  assetItemFk?: number | null;
  code?: string | null;
  assetItemMoveFk?: number | null;
  assetItemMaintenanceFk?: number | null;
  assetScrapStatusFk?: number | null;
  approvalStatusFk?: number | null;
  soldAmount?: number | null;
  actionDate?: Date | null;
  approvalStatusFkNavigation?: any | null;
  assetItemFkNavigation?: any | null;
  assetItemMaintenanceFkNavigation?: any | null;
  assetItemMoveFkNavigation?: any | null;
  assetScrapStatusFkNavigation?: any | null;
}

export interface CreateAssetItemScrap {
  id: number;
  assetItemFk?: number | null;
  code?: string | null;
  assetItemMoveFk?: number | null;
  assetItemMaintenanceFk?: number | null;
  assetScrapStatusFk?: number | null;
  approvalStatusFk?: number | null;
  soldAmount?: number | null;
  actionDate?: Date | null;
  approvalStatusFkNavigation?: any | null;
  assetItemFkNavigation?: any | null;
  assetItemMaintenanceFkNavigation?: any | null;
  assetItemMoveFkNavigation?: any | null;
  assetScrapStatusFkNavigation?: any | null;
}

export interface AssetItemScrapPayload {
  assetItemFk?: number | null;
  code?: string | null;
  assetItemMoveFk?: number | null;
  assetItemMaintenanceFk?: number | null;
  assetScrapStatusFk?: number | null;
  approvalStatusFk?: number | null;
  soldAmount?: number | null;
  actionDate?: Date | null;
  approvalStatusFkNavigation?: any | null;
  assetItemFkNavigation?: any | null;
  assetItemMaintenanceFkNavigation?: any | null;
  assetItemMoveFkNavigation?: any | null;
  assetScrapStatusFkNavigation?: any | null;
}

export interface AssetItemScrap extends AssetItemScrapPayload {
  id: number;
  isDeleted: boolean;
}

