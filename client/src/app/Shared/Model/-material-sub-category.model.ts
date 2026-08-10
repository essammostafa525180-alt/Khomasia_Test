// Generated from WebApi/Controllers/MaterialSubCategoryController.cs + Domain entity.

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

export interface GetAllMaterialSubCategoryParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface MaterialSubCategory {
  id: number;
}

export interface CreateMaterialSubCategory {
  id: number;
}

export interface MaterialSubCategoryPayload {
}

export interface MaterialSubCategory extends MaterialSubCategoryPayload {
  id: number;
  isDeleted: boolean;
}

