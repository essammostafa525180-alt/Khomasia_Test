// Generated from WebApi/Controllers/CommissionConditionController.cs + Domain entity.

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

export interface GetAllCommissionConditionParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface CommissionCondition {
  id: number;
}

export interface CreateCommissionCondition {
  id: number;
}

export interface CommissionConditionPayload {
}

export interface CommissionCondition extends CommissionConditionPayload {
  id: number;
  isDeleted: boolean;
}

