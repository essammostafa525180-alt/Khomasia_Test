// Generated from WebApi/Controllers/TransferStatusController.cs + Domain entity.

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

export interface GetAllTransferStatusParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface TransferStatus {
  id: number;
}

export interface CreateTransferStatus {
  id: number;
}

export interface TransferStatusPayload {
}

export interface TransferStatus extends TransferStatusPayload {
  id: number;
  isDeleted: boolean;
}

