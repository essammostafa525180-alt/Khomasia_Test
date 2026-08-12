// Generated from WebApi/Controllers/SecUserModuleController.cs + Domain entity.

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

export interface GetAllSecUserModuleParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface SecUserModule {
  id: number;
  userId: number;
  secModuleId: number;
  isAllowed?: boolean | null;
  secModule?: any | null;
  user?: any | null;
}

export interface CreateSecUserModule {
  id: number;
  userId: number;
  secModuleId: number;
  isAllowed?: boolean | null;
  secModule?: any | null;
  user?: any | null;
}

export interface SecUserModulePayload {
  userId: number;
  secModuleId: number;
  isAllowed?: boolean | null;
  secModule?: any | null;
  user?: any | null;
}

export interface SecUserModule extends SecUserModulePayload {
  id: number;
  isDeleted: boolean;
}

