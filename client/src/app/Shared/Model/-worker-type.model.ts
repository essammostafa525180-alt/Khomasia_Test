// Generated from WebApi/Controllers/WorkerTypeController.cs + Domain entity.

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

export interface GetAllWorkerTypeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface WorkerType {
  id: number;
}

export interface CreateWorkerType {
  id: number;
}

export interface WorkerTypePayload {
}

export interface WorkerType extends WorkerTypePayload {
  id: number;
  isDeleted: boolean;
}

