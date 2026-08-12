// Generated from WebApi/Controllers/SecRoleModuleController.cs + Domain entity.

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

export interface GetAllSecRoleModuleParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface SecRoleModule {
  id: number;
  secRoleId: number;
  secModuleId: number;
  isAllowed?: boolean | null;
  secModule?: any | null;
  secRole?: any | null;
}

export interface CreateSecRoleModule {
  id: number;
  secRoleId: number;
  secModuleId: number;
  isAllowed?: boolean | null;
  secModule?: any | null;
  secRole?: any | null;
}

export interface SecRoleModulePayload {
  secRoleId: number;
  secModuleId: number;
  isAllowed?: boolean | null;
  secModule?: any | null;
  secRole?: any | null;
}

export interface SecRoleModule extends SecRoleModulePayload {
  id: number;
  isDeleted: boolean;
}

