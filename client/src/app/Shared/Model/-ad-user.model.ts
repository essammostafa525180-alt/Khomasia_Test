// Generated from WebApi/Controllers/AdUserController.cs + Domain entity.

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

export interface GetAllAdUserParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AdUser {
  id: number;
  adAccount?: string | null;
  mail?: string | null;
}

export interface CreateAdUser {
  id: number;
  adAccount?: string | null;
  mail?: string | null;
}

export interface AdUserPayload {
  adAccount?: string | null;
  mail?: string | null;
}

export interface AdUser extends AdUserPayload {
  id: number;
  isDeleted: boolean;
}

