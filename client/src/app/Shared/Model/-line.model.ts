// Generated from WebApi/Controllers/LineController.cs + Domain entity.

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

export interface GetAllLineParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Line {
  id: number;
}

export interface CreateLine {
  id: number;
}

export interface LinePayload {
}

export interface Line extends LinePayload {
  id: number;
  isDeleted: boolean;
}

