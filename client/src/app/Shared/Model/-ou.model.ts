// Generated from WebApi/Controllers/OuController.cs + Domain entity.

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

export interface GetAllOuParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Ou {
  id: number;
}

export interface CreateOu {
  id: number;
}

export interface OuPayload {
}

export interface Ou extends OuPayload {
  id: number;
  isDeleted: boolean;
}

