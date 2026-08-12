// Generated from WebApi/Controllers/PdarequestsLogController.cs + Domain entity.

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

export interface GetAllPdarequestsLogParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface PdarequestsLog {
  id: number;
  requestFk?: number | null;
  assignedToFk?: number | null;
  isChanged?: boolean | null;
  pdarequestType?: string | null;
}

export interface CreatePdarequestsLog {
  id: number;
  requestFk?: number | null;
  assignedToFk?: number | null;
  isChanged?: boolean | null;
  pdarequestType?: string | null;
}

export interface PdarequestsLogPayload {
  requestFk?: number | null;
  assignedToFk?: number | null;
  isChanged?: boolean | null;
  pdarequestType?: string | null;
}

export interface PdarequestsLog extends PdarequestsLogPayload {
  id: number;
  isDeleted: boolean;
}

