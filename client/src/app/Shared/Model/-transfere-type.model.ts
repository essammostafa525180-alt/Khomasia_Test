// Generated from WebApi/Controllers/TransfereTypeController.cs + Domain entity.

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

export interface GetAllTransfereTypeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface TransfereType {
  id: number;
}

export interface CreateTransfereType {
  id: number;
}

export interface TransfereTypePayload {
}

export interface TransfereType extends TransfereTypePayload {
  id: number;
  isDeleted: boolean;
}

