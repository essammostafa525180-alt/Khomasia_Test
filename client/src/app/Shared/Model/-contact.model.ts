// Generated from WebApi/Controllers/ContactController.cs + Domain entity.

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

export interface GetAllContactParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Contact {
  id: number;
  contactValue?: string | null;
  contactTypeId?: number | null;
  updatedOn?: Date | null;
  contactType?: any | null;
}

export interface CreateContact {
  id: number;
  contactValue?: string | null;
  contactTypeId?: number | null;
  updatedOn?: Date | null;
  contactType?: any | null;
}

export interface ContactPayload {
  contactValue?: string | null;
  contactTypeId?: number | null;
  updatedOn?: Date | null;
  contactType?: any | null;
}

export interface Contact extends ContactPayload {
  id: number;
  isDeleted: boolean;
}

