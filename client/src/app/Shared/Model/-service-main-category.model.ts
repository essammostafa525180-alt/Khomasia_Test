// Generated from WebApi/Controllers/ServiceMainCategoryController.cs + Domain entity.

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

export interface GetAllServiceMainCategoryParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface ServiceMainCategory {
  id: number;
}

export interface CreateServiceMainCategory {
  id: number;
}

export interface ServiceMainCategoryPayload {
}

export interface ServiceMainCategory extends ServiceMainCategoryPayload {
  id: number;
  isDeleted: boolean;
}

