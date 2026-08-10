// Generated from WebApi/Controllers/EngineSizeController.cs + Domain entity.

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

export interface GetAllEngineSizeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface EngineSize {
  id: number;
}

export interface CreateEngineSize {
  id: number;
}

export interface EngineSizePayload {
}

export interface EngineSize extends EngineSizePayload {
  id: number;
  isDeleted: boolean;
}

