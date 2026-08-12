// Generated from WebApi/Controllers/SecRoleSecurableValueController.cs + Domain entity.

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

export interface GetAllSecRoleSecurableValueParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface SecRoleSecurableValue {
  id: number;
  value?: string | null;
  secRolePropertyId?: number | null;
  secRoleProperty?: any | null;
}

export interface CreateSecRoleSecurableValue {
  id: number;
  value?: string | null;
  secRolePropertyId?: number | null;
  secRoleProperty?: any | null;
}

export interface SecRoleSecurableValuePayload {
  value?: string | null;
  secRolePropertyId?: number | null;
  secRoleProperty?: any | null;
}

export interface SecRoleSecurableValue extends SecRoleSecurableValuePayload {
  id: number;
  isDeleted: boolean;
}

