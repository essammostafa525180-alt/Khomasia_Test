// Generated from WebApi/Controllers/SecRoleViewActionController.cs + Domain entity.

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

export interface GetAllSecRoleViewActionParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface SecRoleViewAction {
  id: number;
  viewActionId: number;
  roleId: number;
  isAllow?: boolean | null;
  role?: any | null;
  viewAction?: any | null;
}

export interface CreateSecRoleViewAction {
  id: number;
  viewActionId: number;
  roleId: number;
  isAllow?: boolean | null;
  role?: any | null;
  viewAction?: any | null;
}

export interface SecRoleViewActionPayload {
  viewActionId: number;
  roleId: number;
  isAllow?: boolean | null;
  role?: any | null;
  viewAction?: any | null;
}

export interface SecRoleViewAction extends SecRoleViewActionPayload {
  id: number;
  isDeleted: boolean;
}

