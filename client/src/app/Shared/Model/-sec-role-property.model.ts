// Generated from WebApi/Controllers/SecRolePropertyController.cs + Domain entity.

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

export interface GetAllSecRolePropertyParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface SecRoleProperty {
  id: number;
}

export interface CreateSecRoleProperty {
  id: number;
}

export interface SecRolePropertyPayload {
}

export interface SecRoleProperty extends SecRolePropertyPayload {
  id: number;
  isDeleted: boolean;
}

