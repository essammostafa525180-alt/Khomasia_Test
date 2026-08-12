// Generated from WebApi/Controllers/PoserviceDetailController.cs + Domain entity.

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

export interface GetAllPoserviceDetailParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface PoserviceDetail {
  id: number;
  poserviceFk?: number | null;
  serviceTypeFk?: number | null;
  serviceMainCategoryFk?: number | null;
  serviceCategoryFk?: number | null;
  serviceSubCategoryFk?: number | null;
  serviceFk?: number | null;
  quantity?: number | null;
  costPerService?: number | null;
  totalCost?: number | null;
  contractServiceId?: number | null;
  poserviceFkNavigation?: any | null;
  serviceCategoryFkNavigation?: any | null;
  serviceFkNavigation?: any | null;
  serviceMainCategoryFkNavigation?: any | null;
  serviceSubCategoryFkNavigation?: any | null;
  serviceTypeFkNavigation?: any | null;
}

export interface CreatePoserviceDetail {
  id: number;
  poserviceFk?: number | null;
  serviceTypeFk?: number | null;
  serviceMainCategoryFk?: number | null;
  serviceCategoryFk?: number | null;
  serviceSubCategoryFk?: number | null;
  serviceFk?: number | null;
  quantity?: number | null;
  costPerService?: number | null;
  totalCost?: number | null;
  contractServiceId?: number | null;
  poserviceFkNavigation?: any | null;
  serviceCategoryFkNavigation?: any | null;
  serviceFkNavigation?: any | null;
  serviceMainCategoryFkNavigation?: any | null;
  serviceSubCategoryFkNavigation?: any | null;
  serviceTypeFkNavigation?: any | null;
}

export interface PoserviceDetailPayload {
  poserviceFk?: number | null;
  serviceTypeFk?: number | null;
  serviceMainCategoryFk?: number | null;
  serviceCategoryFk?: number | null;
  serviceSubCategoryFk?: number | null;
  serviceFk?: number | null;
  quantity?: number | null;
  costPerService?: number | null;
  totalCost?: number | null;
  contractServiceId?: number | null;
  poserviceFkNavigation?: any | null;
  serviceCategoryFkNavigation?: any | null;
  serviceFkNavigation?: any | null;
  serviceMainCategoryFkNavigation?: any | null;
  serviceSubCategoryFkNavigation?: any | null;
  serviceTypeFkNavigation?: any | null;
}

export interface PoserviceDetail extends PoserviceDetailPayload {
  id: number;
  isDeleted: boolean;
}

