// Generated from WebApi/Controllers/BabsController.cs + Domain entity.

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

export interface GetAllBabsParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Babs {
  id: number;
}

export interface CreateBabs {
  id: number;
}

export interface BabsPayload {
}

export interface Babs extends BabsPayload {
  id: number;
  isDeleted: boolean;
}

