// Generated from WebApi/Controllers/AssetCountPlanController.cs + Domain entity.

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

export interface GetAllAssetCountPlanParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssetCountPlan {
  id: number;
  planNumber?: string | null;
  name?: string | null;
  nameAr?: string | null;
  assetCountPlanTypeFk?: number | null;
  assetCountPlanStatusFk?: number | null;
  planeDate?: Date | null;
  executionDate?: Date | null;
  assignedToUserFk?: number | null;
  assetCountPlanStatusFkNavigation?: any | null;
  assetCountPlanTypeFkNavigation?: any | null;
}

export interface CreateAssetCountPlan {
  id: number;
  planNumber?: string | null;
  name?: string | null;
  nameAr?: string | null;
  assetCountPlanTypeFk?: number | null;
  assetCountPlanStatusFk?: number | null;
  planeDate?: Date | null;
  executionDate?: Date | null;
  assignedToUserFk?: number | null;
  assetCountPlanStatusFkNavigation?: any | null;
  assetCountPlanTypeFkNavigation?: any | null;
}

export interface AssetCountPlanPayload {
  planNumber?: string | null;
  name?: string | null;
  nameAr?: string | null;
  assetCountPlanTypeFk?: number | null;
  assetCountPlanStatusFk?: number | null;
  planeDate?: Date | null;
  executionDate?: Date | null;
  assignedToUserFk?: number | null;
  assetCountPlanStatusFkNavigation?: any | null;
  assetCountPlanTypeFkNavigation?: any | null;
}

export interface AssetCountPlan extends AssetCountPlanPayload {
  id: number;
  isDeleted: boolean;
}

