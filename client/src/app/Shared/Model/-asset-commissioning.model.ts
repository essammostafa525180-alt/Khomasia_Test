// Generated from WebApi/Controllers/AssetCommissioningController.cs + Domain entity.

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

export interface GetAllAssetCommissioningParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssetCommissioning {
  id: number;
  assetFk?: number | null;
  commissionConditionFk?: number | null;
  assetFunctionalityFk?: number | null;
  assetComplineFk?: number | null;
  subSectionFk?: number | null;
  assetComplineFkNavigation?: any | null;
  assetFkNavigation?: any | null;
  assetFunctionalityFkNavigation?: any | null;
  commissionConditionFkNavigation?: any | null;
  subSectionFkNavigation?: any | null;
}

export interface CreateAssetCommissioning {
  id: number;
  assetFk?: number | null;
  commissionConditionFk?: number | null;
  assetFunctionalityFk?: number | null;
  assetComplineFk?: number | null;
  subSectionFk?: number | null;
  assetComplineFkNavigation?: any | null;
  assetFkNavigation?: any | null;
  assetFunctionalityFkNavigation?: any | null;
  commissionConditionFkNavigation?: any | null;
  subSectionFkNavigation?: any | null;
}

export interface AssetCommissioningPayload {
  assetFk?: number | null;
  commissionConditionFk?: number | null;
  assetFunctionalityFk?: number | null;
  assetComplineFk?: number | null;
  subSectionFk?: number | null;
  assetComplineFkNavigation?: any | null;
  assetFkNavigation?: any | null;
  assetFunctionalityFkNavigation?: any | null;
  commissionConditionFkNavigation?: any | null;
  subSectionFkNavigation?: any | null;
}

export interface AssetCommissioning extends AssetCommissioningPayload {
  id: number;
  isDeleted: boolean;
}

