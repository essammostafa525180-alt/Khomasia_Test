// Generated from WebApi/Controllers/AssetCountDetailController.cs + Domain entity.

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

export interface GetAllAssetCountDetailParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssetCountDetail {
  id: number;
  assetCountFk?: number | null;
  assetFk?: number | null;
  assetCountStatusFk?: number | null;
  notes?: string | null;
  assetCountFkNavigation?: any | null;
  assetCountStatusFkNavigation?: any | null;
  assetFkNavigation?: any | null;
}

export interface CreateAssetCountDetail {
  id: number;
  assetCountFk?: number | null;
  assetFk?: number | null;
  assetCountStatusFk?: number | null;
  notes?: string | null;
  assetCountFkNavigation?: any | null;
  assetCountStatusFkNavigation?: any | null;
  assetFkNavigation?: any | null;
}

export interface AssetCountDetailPayload {
  assetCountFk?: number | null;
  assetFk?: number | null;
  assetCountStatusFk?: number | null;
  notes?: string | null;
  assetCountFkNavigation?: any | null;
  assetCountStatusFkNavigation?: any | null;
  assetFkNavigation?: any | null;
}

export interface AssetCountDetail extends AssetCountDetailPayload {
  id: number;
  isDeleted: boolean;
}

