// Generated from WebApi/Controllers/SecUserPropertyController.cs + Domain entity.

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

export interface GetAllSecUserPropertyParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface SecUserProperty {
  id: number;
  userId?: number | null;
  propertyId?: number | null;
  mode?: number | null;
  property?: any | null;
  user?: any | null;
}

export interface CreateSecUserProperty {
  id: number;
  userId?: number | null;
  propertyId?: number | null;
  mode?: number | null;
  property?: any | null;
  user?: any | null;
}

export interface SecUserPropertyPayload {
  userId?: number | null;
  propertyId?: number | null;
  mode?: number | null;
  property?: any | null;
  user?: any | null;
}

export interface SecUserProperty extends SecUserPropertyPayload {
  id: number;
  isDeleted: boolean;
}

