// Generated from WebApi/Controllers/UnitOfMeasureController.cs + Domain entity.

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

export interface GetAllUnitOfMeasureParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface UnitOfMeasure {
  id: number;
}

export interface CreateUnitOfMeasure {
  id: number;
}

export interface UnitOfMeasurePayload {
}

export interface UnitOfMeasure extends UnitOfMeasurePayload {
  id: number;
  isDeleted: boolean;
}

