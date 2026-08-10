// Generated from WebApi/Controllers/ReturnReasonController.cs + Domain entity.

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

export interface GetAllReturnReasonParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface ReturnReason {
  id: number;
}

export interface CreateReturnReason {
  id: number;
}

export interface ReturnReasonPayload {
}

export interface ReturnReason extends ReturnReasonPayload {
  id: number;
  isDeleted: boolean;
}

