// Generated from WebApi/Controllers/ApprovalMatrixConfigDetailController.cs + Domain entity.

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

export interface GetAllApprovalMatrixConfigDetailParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface ApprovalMatrixConfigDetail {
  id: number;
  approvalMatrixConfigFk?: number | null;
  approvalMatrixRangeFk?: number | null;
  stepNo: number;
  stepName?: string | null;
  stepNameAr?: string | null;
  userFk?: number | null;
  email?: string | null;
  approvalMatrixConfigFkNavigation?: any | null;
  approvalMatrixRangeFkNavigation?: any | null;
  userFkNavigation?: any | null;
}

export interface CreateApprovalMatrixConfigDetail {
  id: number;
  approvalMatrixConfigFk?: number | null;
  approvalMatrixRangeFk?: number | null;
  stepNo: number;
  stepName?: string | null;
  stepNameAr?: string | null;
  userFk?: number | null;
  email?: string | null;
  approvalMatrixConfigFkNavigation?: any | null;
  approvalMatrixRangeFkNavigation?: any | null;
  userFkNavigation?: any | null;
}

export interface ApprovalMatrixConfigDetailPayload {
  approvalMatrixConfigFk?: number | null;
  approvalMatrixRangeFk?: number | null;
  stepNo: number;
  stepName?: string | null;
  stepNameAr?: string | null;
  userFk?: number | null;
  email?: string | null;
  approvalMatrixConfigFkNavigation?: any | null;
  approvalMatrixRangeFkNavigation?: any | null;
  userFkNavigation?: any | null;
}

export interface ApprovalMatrixConfigDetail extends ApprovalMatrixConfigDetailPayload {
  id: number;
  isDeleted: boolean;
}

