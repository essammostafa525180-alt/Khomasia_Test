// Generated from WebApi/Controllers/FactoryController.cs + Domain entity.

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

export interface GetAllFactoryParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Factory {
  id: number;
  code?: string | null;
  description?: string | null;
  address?: string | null;
  name: string;
  nameAr?: string | null;
}

export interface CreateFactory {
  id: number;
  code?: string | null;
  description?: string | null;
  address?: string | null;
  name: string;
  nameAr?: string | null;
}

export interface FactoryPayload {
  code?: string | null;
  description?: string | null;
  address?: string | null;
  name: string;
  nameAr?: string | null;
}

export interface Factory extends FactoryPayload {
  id: number;
  isDeleted: boolean;
}

