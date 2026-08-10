// Generated from WebApi/Controllers/SysKeyValueController.cs + Domain entity.

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

export interface GetAllSysKeyValueParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface SysKeyValue {
  id: number;
}

export interface CreateSysKeyValue {
  id: number;
}

export interface SysKeyValuePayload {
}

export interface SysKeyValue extends SysKeyValuePayload {
  id: number;
  isDeleted: boolean;
}

