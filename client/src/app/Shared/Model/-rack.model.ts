// Generated from WebApi/Controllers/RackController.cs + Domain entity.

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

export interface GetAllRackParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Rack {
  id: number;
}

export interface CreateRack {
  id: number;
}

export interface RackPayload {
}

export interface Rack extends RackPayload {
  id: number;
  isDeleted: boolean;
}

