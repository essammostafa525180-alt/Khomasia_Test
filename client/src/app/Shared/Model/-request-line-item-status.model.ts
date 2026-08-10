// Generated from WebApi/Controllers/RequestLineItemStatusController.cs + Domain entity.

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

export interface GetAllRequestLineItemStatusParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface RequestLineItemStatus {
  id: number;
}

export interface CreateRequestLineItemStatus {
  id: number;
}

export interface RequestLineItemStatusPayload {
}

export interface RequestLineItemStatus extends RequestLineItemStatusPayload {
  id: number;
  isDeleted: boolean;
}

