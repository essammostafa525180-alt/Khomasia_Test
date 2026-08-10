// Generated from WebApi/Controllers/SecModelAttributeController.cs + Domain entity.

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

export interface GetAllSecModelAttributeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface SecModelAttribute {
  id: number;
}

export interface CreateSecModelAttribute {
  id: number;
}

export interface SecModelAttributePayload {
}

export interface SecModelAttribute extends SecModelAttributePayload {
  id: number;
  isDeleted: boolean;
}

