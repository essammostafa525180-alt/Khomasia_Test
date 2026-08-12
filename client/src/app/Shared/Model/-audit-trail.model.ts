// Generated from WebApi/Controllers/AuditTrailController.cs + Domain entity.

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

export interface GetAllAuditTrailParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AuditTrail {
  id: number;
  tableName?: string | null;
  action?: string | null;
  executedAt?: Date | null;
  userId?: number | null;
  entityId?: number | null;
  clientComputerName?: string | null;
  clientIp?: string | null;
  parentAuditTrailId?: number | null;
  parentAuditTrail?: any | null;
  user?: any | null;
}

export interface CreateAuditTrail {
  id: number;
  tableName?: string | null;
  action?: string | null;
  executedAt?: Date | null;
  userId?: number | null;
  entityId?: number | null;
  clientComputerName?: string | null;
  clientIp?: string | null;
  parentAuditTrailId?: number | null;
  parentAuditTrail?: any | null;
  user?: any | null;
}

export interface AuditTrailPayload {
  tableName?: string | null;
  action?: string | null;
  executedAt?: Date | null;
  userId?: number | null;
  entityId?: number | null;
  clientComputerName?: string | null;
  clientIp?: string | null;
  parentAuditTrailId?: number | null;
  parentAuditTrail?: any | null;
  user?: any | null;
}

export interface AuditTrail extends AuditTrailPayload {
  id: number;
  isDeleted: boolean;
}

