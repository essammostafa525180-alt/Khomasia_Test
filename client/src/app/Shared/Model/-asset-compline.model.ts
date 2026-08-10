// Generated from WebApi/Controllers/AssetComplineController.cs + Domain entity.

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

export interface GetAllAssetComplineParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssetCompline {
  id: number;
  name?: string | null;
  nameAr?: string | null;
}

export interface CreateAssetCompline {
  id: number;
  name?: string | null;
  nameAr?: string | null;
}

export interface AssetComplinePayload {
  name?: string | null;
  nameAr?: string | null;
}

export interface AssetCompline extends AssetComplinePayload {
  id: number;
  isDeleted: boolean;
}

