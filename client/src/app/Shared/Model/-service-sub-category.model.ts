// Generated from WebApi/Controllers/ServiceSubCategoryController.cs + Domain entity.

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

export interface GetAllServiceSubCategoryParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface ServiceSubCategory {
  id: number;
}

export interface CreateServiceSubCategory {
  id: number;
}

export interface ServiceSubCategoryPayload {
}

export interface ServiceSubCategory extends ServiceSubCategoryPayload {
  id: number;
  isDeleted: boolean;
}

