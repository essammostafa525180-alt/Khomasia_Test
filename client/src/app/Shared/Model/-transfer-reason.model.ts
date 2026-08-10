// Generated from WebApi/Controllers/TransferReasonController.cs + Domain entity.

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

export interface GetAllTransferReasonParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface TransferReason {
  id: number;
}

export interface CreateTransferReason {
  id: number;
}

export interface TransferReasonPayload {
}

export interface TransferReason extends TransferReasonPayload {
  id: number;
  isDeleted: boolean;
}

