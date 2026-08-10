// Generated from WebApi/Controllers/ContactsController.cs + Domain entity.

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

export interface GetAllContactsParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Contacts {
  id: number;
}

export interface CreateContacts {
  id: number;
}

export interface ContactsPayload {
}

export interface Contacts extends ContactsPayload {
  id: number;
  isDeleted: boolean;
}

