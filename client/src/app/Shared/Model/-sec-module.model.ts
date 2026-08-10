// Generated from WebApi/Controllers/SecModuleController.cs + Domain entity.

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

export interface GetAllSecModuleParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface SecModule {
  id: number;
}

export interface CreateSecModule {
  id: number;
}

export interface SecModulePayload {
}

export interface SecModule extends SecModulePayload {
  id: number;
  isDeleted: boolean;
}

