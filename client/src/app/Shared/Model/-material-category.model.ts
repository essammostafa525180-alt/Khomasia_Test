// Generated from WebApi/Controllers/MaterialCategoryController.cs + Domain entity.

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

export interface GetAllMaterialCategoryParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface MaterialCategory {
  id: number;
}

export interface CreateMaterialCategory {
  id: number;
}

export interface MaterialCategoryPayload {
}

export interface MaterialCategory extends MaterialCategoryPayload {
  id: number;
  isDeleted: boolean;
}

