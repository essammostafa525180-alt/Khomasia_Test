// Generated from WebApi/Controllers/OwnershipController.cs + Domain entity.

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

export interface GetAllOwnershipParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Ownership {
  id: number;
}

export interface CreateOwnership {
  id: number;
}

export interface OwnershipPayload {
}

export interface Ownership extends OwnershipPayload {
  id: number;
  isDeleted: boolean;
}

