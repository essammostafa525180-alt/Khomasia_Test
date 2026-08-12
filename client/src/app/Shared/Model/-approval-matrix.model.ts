// Generated from WebApi/Controllers/ApprovalMatrixController.cs + Domain entity.

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

export interface GetAllApprovalMatrixParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface ApprovalMatrix {
  id: number;
  screenFk?: number | null;
  entityId?: number | null;
  approvalMatrixConfigFk?: number | null;
  approvalStatusFk: number;
  approvalDate?: Date | null;
  approvalMatrixConfigFkNavigation?: any | null;
  approvalStatusFkNavigation?: any | null;
  entity?: any | null;
  entity1?: any | null;
  entity2?: any | null;
  entity3?: any | null;
  entityNavigation?: any | null;
  screenFkNavigation?: any | null;
}

export interface CreateApprovalMatrix {
  id: number;
  screenFk?: number | null;
  entityId?: number | null;
  approvalMatrixConfigFk?: number | null;
  approvalStatusFk: number;
  approvalDate?: Date | null;
  approvalMatrixConfigFkNavigation?: any | null;
  approvalStatusFkNavigation?: any | null;
  entity?: any | null;
  entity1?: any | null;
  entity2?: any | null;
  entity3?: any | null;
  entityNavigation?: any | null;
  screenFkNavigation?: any | null;
}

export interface ApprovalMatrixPayload {
  screenFk?: number | null;
  entityId?: number | null;
  approvalMatrixConfigFk?: number | null;
  approvalStatusFk: number;
  approvalDate?: Date | null;
  approvalMatrixConfigFkNavigation?: any | null;
  approvalStatusFkNavigation?: any | null;
  entity?: any | null;
  entity1?: any | null;
  entity2?: any | null;
  entity3?: any | null;
  entityNavigation?: any | null;
  screenFkNavigation?: any | null;
}

export interface ApprovalMatrix extends ApprovalMatrixPayload {
  id: number;
  isDeleted: boolean;
}

