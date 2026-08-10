// Generated from WebApi/Controllers/AssetsGroupController.cs + Domain entity.

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

export interface GetAllAssetsGroupParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssetsGroup {
  id: number;
}

export interface CreateAssetsGroup {
  id: number;
}

export interface AssetsGroupPayload {
}

export interface AssetsGroup extends AssetsGroupPayload {
  id: number;
  isDeleted: boolean;
}

