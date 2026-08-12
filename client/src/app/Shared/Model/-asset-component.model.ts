// Generated from WebApi/Controllers/AssetComponentController.cs + Domain entity.

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

export interface GetAllAssetComponentParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssetComponent {
  id: number;
  assetFk?: number | null;
  componentFk?: number | null;
  assetFkNavigation?: any | null;
  componentFkNavigation?: any | null;
}

export interface CreateAssetComponent {
  id: number;
  assetFk?: number | null;
  componentFk?: number | null;
  assetFkNavigation?: any | null;
  componentFkNavigation?: any | null;
}

export interface AssetComponentPayload {
  assetFk?: number | null;
  componentFk?: number | null;
  assetFkNavigation?: any | null;
  componentFkNavigation?: any | null;
}

export interface AssetComponent extends AssetComponentPayload {
  id: number;
  isDeleted: boolean;
}

