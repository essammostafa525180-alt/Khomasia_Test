// Generated from WebApi/Controllers/AssignAssetTypeToAssetGroupController.cs + Domain entity.

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

export interface GetAllAssignAssetTypeToAssetGroupParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssignAssetTypeToAssetGroup {
  id: number;
  assetTypeFk?: number | null;
  assetGroupFk?: number | null;
  assetGroupFkNavigation?: any | null;
  assetTypeFkNavigation?: any | null;
}

export interface CreateAssignAssetTypeToAssetGroup {
  id: number;
  assetTypeFk?: number | null;
  assetGroupFk?: number | null;
  assetGroupFkNavigation?: any | null;
  assetTypeFkNavigation?: any | null;
}

export interface AssignAssetTypeToAssetGroupPayload {
  assetTypeFk?: number | null;
  assetGroupFk?: number | null;
  assetGroupFkNavigation?: any | null;
  assetTypeFkNavigation?: any | null;
}

export interface AssignAssetTypeToAssetGroup extends AssignAssetTypeToAssetGroupPayload {
  id: number;
  isDeleted: boolean;
}

