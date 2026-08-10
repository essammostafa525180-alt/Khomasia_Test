// Generated from WebApi/Controllers/ApprovalMatrixConfigController.cs + Domain entity.

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

export interface GetAllApprovalMatrixConfigParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface ApprovalMatrixConfig {
  id: number;
  screenFk?: number | null;
  companyFk?: number | null;
  projectFk?: number | null;
  scopeFk?: number | null;
  serviceMainCategoryFk?: number | null;
  locationFk?: number | null;
  companyFkNavigation?: any | null;
  locationFkNavigation?: any | null;
  projectFkNavigation?: any | null;
  scopeFkNavigation?: any | null;
  screenFkNavigation?: any | null;
  serviceMainCategoryFkNavigation?: any | null;
}

export interface CreateApprovalMatrixConfig {
  id: number;
  screenFk?: number | null;
  companyFk?: number | null;
  projectFk?: number | null;
  scopeFk?: number | null;
  serviceMainCategoryFk?: number | null;
  locationFk?: number | null;
  companyFkNavigation?: any | null;
  locationFkNavigation?: any | null;
  projectFkNavigation?: any | null;
  scopeFkNavigation?: any | null;
  screenFkNavigation?: any | null;
  serviceMainCategoryFkNavigation?: any | null;
}

export interface ApprovalMatrixConfigPayload {
  screenFk?: number | null;
  companyFk?: number | null;
  projectFk?: number | null;
  scopeFk?: number | null;
  serviceMainCategoryFk?: number | null;
  locationFk?: number | null;
  companyFkNavigation?: any | null;
  locationFkNavigation?: any | null;
  projectFkNavigation?: any | null;
  scopeFkNavigation?: any | null;
  screenFkNavigation?: any | null;
  serviceMainCategoryFkNavigation?: any | null;
}

export interface ApprovalMatrixConfig extends ApprovalMatrixConfigPayload {
  id: number;
  isDeleted: boolean;
}

