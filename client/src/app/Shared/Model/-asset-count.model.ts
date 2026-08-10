// Generated from WebApi/Controllers/AssetCountController.cs + Domain entity.

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

export interface GetAllAssetCountParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssetCount {
  id: number;
  assetCountNumber?: string | null;
  assetTakerUserFk?: number | null;
  countDate?: Date | null;
  zoneFk?: number | null;
  assetCountPlanFk?: number | null;
  assetCountPlanFkNavigation?: any | null;
  zoneFkNavigation?: any | null;
}

export interface CreateAssetCount {
  id: number;
  assetCountNumber?: string | null;
  assetTakerUserFk?: number | null;
  countDate?: Date | null;
  zoneFk?: number | null;
  assetCountPlanFk?: number | null;
  assetCountPlanFkNavigation?: any | null;
  zoneFkNavigation?: any | null;
}

export interface AssetCountPayload {
  assetCountNumber?: string | null;
  assetTakerUserFk?: number | null;
  countDate?: Date | null;
  zoneFk?: number | null;
  assetCountPlanFk?: number | null;
  assetCountPlanFkNavigation?: any | null;
  zoneFkNavigation?: any | null;
}

export interface AssetCount extends AssetCountPayload {
  id: number;
  isDeleted: boolean;
}

