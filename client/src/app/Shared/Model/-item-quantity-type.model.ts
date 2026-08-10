// Generated from WebApi/Controllers/ItemQuantityTypeController.cs + Domain entity.

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

export interface GetAllItemQuantityTypeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface ItemQuantityType {
  id: number;
}

export interface CreateItemQuantityType {
  id: number;
}

export interface ItemQuantityTypePayload {
}

export interface ItemQuantityType extends ItemQuantityTypePayload {
  id: number;
  isDeleted: boolean;
}

