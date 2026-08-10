// Generated from WebApi/Controllers/AuditTrailDetailController.cs + Domain entity.

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

export interface GetAllAuditTrailDetailParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AuditTrailDetail {
  id: number;
  auditTrailId?: number | null;
  property?: string | null;
  oldValue?: string | null;
  newValue?: string | null;
  referenceTable?: string | null;
  auditTrail?: any | null;
}

export interface CreateAuditTrailDetail {
  id: number;
  auditTrailId?: number | null;
  property?: string | null;
  oldValue?: string | null;
  newValue?: string | null;
  referenceTable?: string | null;
  auditTrail?: any | null;
}

export interface AuditTrailDetailPayload {
  auditTrailId?: number | null;
  property?: string | null;
  oldValue?: string | null;
  newValue?: string | null;
  referenceTable?: string | null;
  auditTrail?: any | null;
}

export interface AuditTrailDetail extends AuditTrailDetailPayload {
  id: number;
  isDeleted: boolean;
}

