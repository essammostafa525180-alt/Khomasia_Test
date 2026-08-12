// Generated from WebApi/Controllers/PoserviceTermsAndConditionController.cs + Domain entity.

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

export interface GetAllPoserviceTermsAndConditionParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface PoserviceTermsAndCondition {
  id: number;
  poserviceFk?: number | null;
  termsAndConditionFk?: number | null;
  description?: string | null;
  isActive1: boolean;
  termsAndConditionFkNavigation?: any | null;
}

export interface CreatePoserviceTermsAndCondition {
  id: number;
  poserviceFk?: number | null;
  termsAndConditionFk?: number | null;
  description?: string | null;
  isActive1: boolean;
  termsAndConditionFkNavigation?: any | null;
}

export interface PoserviceTermsAndConditionPayload {
  poserviceFk?: number | null;
  termsAndConditionFk?: number | null;
  description?: string | null;
  isActive1: boolean;
  termsAndConditionFkNavigation?: any | null;
}

export interface PoserviceTermsAndCondition extends PoserviceTermsAndConditionPayload {
  id: number;
  isDeleted: boolean;
}

