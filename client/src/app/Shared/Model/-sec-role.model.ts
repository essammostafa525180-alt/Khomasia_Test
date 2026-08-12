// Generated from WebApi/Controllers/SecRoleController.cs + Domain entity.

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

export interface GetAllSecRoleParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface SecRole {
  id: number;
  roleId: number;
  roleName?: string | null;
  isAdmin?: boolean | null;
  roleNameAr?: string | null;
  singleSession?: boolean | null;
}

export interface CreateSecRole {
  id: number;
  roleId: number;
  roleName?: string | null;
  isAdmin?: boolean | null;
  roleNameAr?: string | null;
  singleSession?: boolean | null;
}

export interface SecRolePayload {
  roleId: number;
  roleName?: string | null;
  isAdmin?: boolean | null;
  roleNameAr?: string | null;
  singleSession?: boolean | null;
}

export interface SecRole extends SecRolePayload {
  id: number;
  isDeleted: boolean;
}

