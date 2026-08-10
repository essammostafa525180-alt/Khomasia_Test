// Generated from WebApi/Controllers/PoserviceTypeController.cs + Domain entity.

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

export interface GetAllPoserviceTypeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface PoserviceType {
  id: number;
}

export interface CreatePoserviceType {
  id: number;
}

export interface PoserviceTypePayload {
}

export interface PoserviceType extends PoserviceTypePayload {
  id: number;
  isDeleted: boolean;
}

