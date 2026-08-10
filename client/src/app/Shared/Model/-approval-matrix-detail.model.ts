// Generated from WebApi/Controllers/ApprovalMatrixDetailController.cs + Domain entity.

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

export interface GetAllApprovalMatrixDetailParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface ApprovalMatrixDetail {
  id: number;
  approvalMatrixFk?: number | null;
  approvalMatrixConfigDetailFk?: number | null;
  approvalStatusFk: number;
  approvalDate?: Date | null;
  userFk?: number | null;
  email?: string | null;
  approvalMatrixConfigDetailFkNavigation?: any | null;
  approvalMatrixFkNavigation?: any | null;
  approvalStatusFkNavigation?: any | null;
  userFkNavigation?: any | null;
}

export interface CreateApprovalMatrixDetail {
  id: number;
  approvalMatrixFk?: number | null;
  approvalMatrixConfigDetailFk?: number | null;
  approvalStatusFk: number;
  approvalDate?: Date | null;
  userFk?: number | null;
  email?: string | null;
  approvalMatrixConfigDetailFkNavigation?: any | null;
  approvalMatrixFkNavigation?: any | null;
  approvalStatusFkNavigation?: any | null;
  userFkNavigation?: any | null;
}

export interface ApprovalMatrixDetailPayload {
  approvalMatrixFk?: number | null;
  approvalMatrixConfigDetailFk?: number | null;
  approvalStatusFk: number;
  approvalDate?: Date | null;
  userFk?: number | null;
  email?: string | null;
  approvalMatrixConfigDetailFkNavigation?: any | null;
  approvalMatrixFkNavigation?: any | null;
  approvalStatusFkNavigation?: any | null;
  userFkNavigation?: any | null;
}

export interface ApprovalMatrixDetail extends ApprovalMatrixDetailPayload {
  id: number;
  isDeleted: boolean;
}

