// Generated from WebApi/Controllers/AssetFunctionalityController.cs + Domain entity.

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

export interface GetAllAssetFunctionalityParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssetFunctionality {
  id: number;
}

export interface CreateAssetFunctionality {
  id: number;
}

export interface AssetFunctionalityPayload {
}

export interface AssetFunctionality extends AssetFunctionalityPayload {
  id: number;
  isDeleted: boolean;
}

