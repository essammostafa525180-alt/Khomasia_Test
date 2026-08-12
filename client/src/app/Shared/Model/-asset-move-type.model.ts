// Generated from WebApi/Controllers/AssetMoveTypeController.cs + Domain entity.

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

export interface GetAllAssetMoveTypeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssetMoveType {
  id: number;
}

export interface CreateAssetMoveType {
  id: number;
}

export interface AssetMoveTypePayload {
}

export interface AssetMoveType extends AssetMoveTypePayload {
  id: number;
  isDeleted: boolean;
}

