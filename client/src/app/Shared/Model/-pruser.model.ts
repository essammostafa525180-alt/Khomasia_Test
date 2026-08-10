// Generated from WebApi/Controllers/PruserController.cs + Domain entity.

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

export interface GetAllPruserParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Pruser {
  id: number;
  approvalScreenFk: number;
  userFk: number;
  approvalScreenFkNavigation?: any | null;
  userFkNavigation?: any | null;
}

export interface CreatePruser {
  id: number;
  approvalScreenFk: number;
  userFk: number;
  approvalScreenFkNavigation?: any | null;
  userFkNavigation?: any | null;
}

export interface PruserPayload {
  approvalScreenFk: number;
  userFk: number;
  approvalScreenFkNavigation?: any | null;
  userFkNavigation?: any | null;
}

export interface Pruser extends PruserPayload {
  id: number;
  isDeleted: boolean;
}

