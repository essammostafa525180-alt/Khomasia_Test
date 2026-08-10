// Generated from WebApi/Controllers/ServiceController.cs + Domain entity.

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

export interface GetAllServiceParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Service {
  id: number;
  code?: string | null;
  name?: string | null;
  nameAr?: string | null;
  serviceTypeFk?: number | null;
  serviceMainCategoryFk?: number | null;
  serviceCategoryFk?: number | null;
  serviceSubCategoryFk?: number | null;
  serviceCategoryFkNavigation?: any | null;
  serviceMainCategoryFkNavigation?: any | null;
  serviceSubCategoryFkNavigation?: any | null;
}

export interface CreateService {
  id: number;
  code?: string | null;
  name?: string | null;
  nameAr?: string | null;
  serviceTypeFk?: number | null;
  serviceMainCategoryFk?: number | null;
  serviceCategoryFk?: number | null;
  serviceSubCategoryFk?: number | null;
  serviceCategoryFkNavigation?: any | null;
  serviceMainCategoryFkNavigation?: any | null;
  serviceSubCategoryFkNavigation?: any | null;
}

export interface ServicePayload {
  code?: string | null;
  name?: string | null;
  nameAr?: string | null;
  serviceTypeFk?: number | null;
  serviceMainCategoryFk?: number | null;
  serviceCategoryFk?: number | null;
  serviceSubCategoryFk?: number | null;
  serviceCategoryFkNavigation?: any | null;
  serviceMainCategoryFkNavigation?: any | null;
  serviceSubCategoryFkNavigation?: any | null;
}

export interface Service extends ServicePayload {
  id: number;
  isDeleted: boolean;
}

