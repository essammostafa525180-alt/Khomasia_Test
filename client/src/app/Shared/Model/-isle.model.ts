// Generated from WebApi/Controllers/IsleController.cs + Domain entity.

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

export interface GetAllIsleParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Isle {
  id: number;
}

export interface CreateIsle {
  id: number;
}

export interface IslePayload {
}

export interface Isle extends IslePayload {
  id: number;
  isDeleted: boolean;
}

