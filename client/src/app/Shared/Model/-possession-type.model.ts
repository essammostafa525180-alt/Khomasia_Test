// Generated from WebApi/Controllers/PossessionTypeController.cs + Domain entity.

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

export interface GetAllPossessionTypeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface PossessionType {
  id: number;
}

export interface CreatePossessionType {
  id: number;
}

export interface PossessionTypePayload {
}

export interface PossessionType extends PossessionTypePayload {
  id: number;
  isDeleted: boolean;
}

