// Generated from WebApi/Controllers/AssetCountPlanDetailController.cs + Domain entity.

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

export interface GetAllAssetCountPlanDetailParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssetCountPlanDetail {
  id: number;
  assetCountPlanFk?: number | null;
  zoneFk?: number | null;
  assignedToUserFk?: number | null;
  assetCountPlanFkNavigation?: any | null;
  zoneFkNavigation?: any | null;
}

export interface CreateAssetCountPlanDetail {
  id: number;
  assetCountPlanFk?: number | null;
  zoneFk?: number | null;
  assignedToUserFk?: number | null;
  assetCountPlanFkNavigation?: any | null;
  zoneFkNavigation?: any | null;
}

export interface AssetCountPlanDetailPayload {
  assetCountPlanFk?: number | null;
  zoneFk?: number | null;
  assignedToUserFk?: number | null;
  assetCountPlanFkNavigation?: any | null;
  zoneFkNavigation?: any | null;
}

export interface AssetCountPlanDetail extends AssetCountPlanDetailPayload {
  id: number;
  isDeleted: boolean;
}

