// Generated from WebApi/Controllers/LocationController.cs + Domain entity.

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

export interface GetAllLocationParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Location {
  id: number;
}

export interface CreateLocation {
  id: number;
}

export interface LocationPayload {
}

export interface Location extends LocationPayload {
  id: number;
  isDeleted: boolean;
}

