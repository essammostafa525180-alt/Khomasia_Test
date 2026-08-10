// Generated from WebApi/Controllers/ShelfController.cs + Domain entity.

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

export interface GetAllShelfParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Shelf {
  id: number;
}

export interface CreateShelf {
  id: number;
}

export interface ShelfPayload {
}

export interface Shelf extends ShelfPayload {
  id: number;
  isDeleted: boolean;
}

