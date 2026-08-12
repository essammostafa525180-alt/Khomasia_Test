// Generated from WebApi/Controllers/PoserviceAssetController.cs + Domain entity.

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

export interface GetAllPoserviceAssetParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface PoserviceAsset {
  id: number;
  poserviceFk: number;
  contractServiceId: number;
  contractAssetId: number;
  assetId: number;
  assetCode?: string | null;
  assetDescription?: string | null;
  assetDescriptionAr?: string | null;
  poserviceFkNavigation?: any | null;
}

export interface CreatePoserviceAsset {
  id: number;
  poserviceFk: number;
  contractServiceId: number;
  contractAssetId: number;
  assetId: number;
  assetCode?: string | null;
  assetDescription?: string | null;
  assetDescriptionAr?: string | null;
  poserviceFkNavigation?: any | null;
}

export interface PoserviceAssetPayload {
  poserviceFk: number;
  contractServiceId: number;
  contractAssetId: number;
  assetId: number;
  assetCode?: string | null;
  assetDescription?: string | null;
  assetDescriptionAr?: string | null;
  poserviceFkNavigation?: any | null;
}

export interface PoserviceAsset extends PoserviceAssetPayload {
  id: number;
  isDeleted: boolean;
}

