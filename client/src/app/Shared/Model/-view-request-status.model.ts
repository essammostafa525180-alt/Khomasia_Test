// Generated from WebApi/Controllers/ViewRequestStatusController.cs + Domain entity.

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

export interface GetAllViewRequestStatusParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface ViewRequestStatus {
  id: number;
}

export interface CreateViewRequestStatus {
  id: number;
}

export interface ViewRequestStatusPayload {
}

export interface ViewRequestStatus extends ViewRequestStatusPayload {
  id: number;
  isDeleted: boolean;
}

