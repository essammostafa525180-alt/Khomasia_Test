// Generated from WebApi/Controllers/MaterialGroupController.cs + Domain entity.

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

export interface GetAllMaterialGroupParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface MaterialGroup {
  id: number;
}

export interface CreateMaterialGroup {
  id: number;
}

export interface MaterialGroupPayload {
}

export interface MaterialGroup extends MaterialGroupPayload {
  id: number;
  isDeleted: boolean;
}

