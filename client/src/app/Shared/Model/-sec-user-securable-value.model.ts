// Generated from WebApi/Controllers/SecUserSecurableValueController.cs + Domain entity.

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

export interface GetAllSecUserSecurableValueParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface SecUserSecurableValue {
  id: number;
  value?: string | null;
  secUserPropertyId?: number | null;
  secUserProperty?: any | null;
}

export interface CreateSecUserSecurableValue {
  id: number;
  value?: string | null;
  secUserPropertyId?: number | null;
  secUserProperty?: any | null;
}

export interface SecUserSecurableValuePayload {
  value?: string | null;
  secUserPropertyId?: number | null;
  secUserProperty?: any | null;
}

export interface SecUserSecurableValue extends SecUserSecurableValuePayload {
  id: number;
  isDeleted: boolean;
}

