// Generated from WebApi/Controllers/ApprovalMatrixRangeController.cs + Domain entity.

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

export interface GetAllApprovalMatrixRangeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface ApprovalMatrixRange {
  id: number;
  name?: string | null;
  rangeFrom?: number | null;
  rangeTo?: number | null;
}

export interface CreateApprovalMatrixRange {
  id: number;
  name?: string | null;
  rangeFrom?: number | null;
  rangeTo?: number | null;
}

export interface ApprovalMatrixRangePayload {
  name?: string | null;
  rangeFrom?: number | null;
  rangeTo?: number | null;
}

export interface ApprovalMatrixRange extends ApprovalMatrixRangePayload {
  id: number;
  isDeleted: boolean;
}

