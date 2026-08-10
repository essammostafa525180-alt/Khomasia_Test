// Generated from WebApi/Controllers/ItemRequestStatusController.cs + Domain entity.

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

export interface GetAllItemRequestStatusParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface ItemRequestStatus {
  id: number;
}

export interface CreateItemRequestStatus {
  id: number;
}

export interface ItemRequestStatusPayload {
}

export interface ItemRequestStatus extends ItemRequestStatusPayload {
  id: number;
  isDeleted: boolean;
}

