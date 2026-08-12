// Generated from WebApi/Controllers/AssetsTypeController.cs + Domain entity.

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

export interface GetAllAssetsTypeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssetsType {
  id: number;
}

export interface CreateAssetsType {
  id: number;
}

export interface AssetsTypePayload {
}

export interface AssetsType extends AssetsTypePayload {
  id: number;
  isDeleted: boolean;
}

