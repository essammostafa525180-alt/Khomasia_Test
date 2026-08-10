// Generated from WebApi/Controllers/ServiceCategoryController.cs + Domain entity.

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

export interface GetAllServiceCategoryParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface ServiceCategory {
  id: number;
}

export interface CreateServiceCategory {
  id: number;
}

export interface ServiceCategoryPayload {
}

export interface ServiceCategory extends ServiceCategoryPayload {
  id: number;
  isDeleted: boolean;
}

