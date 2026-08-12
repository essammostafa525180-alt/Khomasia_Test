// Generated from WebApi/Controllers/TermsAndConditionController.cs + Domain entity.

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

export interface GetAllTermsAndConditionParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface TermsAndCondition {
  id: number;
}

export interface CreateTermsAndCondition {
  id: number;
}

export interface TermsAndConditionPayload {
}

export interface TermsAndCondition extends TermsAndConditionPayload {
  id: number;
  isDeleted: boolean;
}

