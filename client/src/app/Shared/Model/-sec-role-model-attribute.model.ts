// Generated from WebApi/Controllers/SecRoleModelAttributeController.cs + Domain entity.

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

export interface GetAllSecRoleModelAttributeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface SecRoleModelAttribute {
  id: number;
}

export interface CreateSecRoleModelAttribute {
  id: number;
}

export interface SecRoleModelAttributePayload {
}

export interface SecRoleModelAttribute extends SecRoleModelAttributePayload {
  id: number;
  isDeleted: boolean;
}

