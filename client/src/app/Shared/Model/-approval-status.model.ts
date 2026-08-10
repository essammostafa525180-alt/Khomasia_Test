// Generated from WebApi/Controllers/ApprovalStatusController.cs + Domain entity.

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

export interface GetAllApprovalStatusParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface ApprovalStatus {
  id: number;
}

export interface CreateApprovalStatus {
  id: number;
}

export interface ApprovalStatusPayload {
}

export interface ApprovalStatus extends ApprovalStatusPayload {
  id: number;
  isDeleted: boolean;
}

