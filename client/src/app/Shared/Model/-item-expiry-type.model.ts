// Generated from WebApi/Controllers/ItemExpiryTypeController.cs + Domain entity.

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

export interface GetAllItemExpiryTypeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface ItemExpiryType {
  id: number;
}

export interface CreateItemExpiryType {
  id: number;
}

export interface ItemExpiryTypePayload {
}

export interface ItemExpiryType extends ItemExpiryTypePayload {
  id: number;
  isDeleted: boolean;
}

