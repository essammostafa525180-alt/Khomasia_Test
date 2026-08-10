// Generated from WebApi/Controllers/ContactTypeController.cs + Domain entity.

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

export interface GetAllContactTypeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface ContactType {
  id: number;
}

export interface CreateContactType {
  id: number;
}

export interface ContactTypePayload {
}

export interface ContactType extends ContactTypePayload {
  id: number;
  isDeleted: boolean;
}

