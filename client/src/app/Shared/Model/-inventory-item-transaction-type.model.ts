// Generated from WebApi/Controllers/InventoryItemTransactionTypeController.cs + Domain entity.

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

export interface GetAllInventoryItemTransactionTypeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryItemTransactionType {
  id: number;
}

export interface CreateInventoryItemTransactionType {
  id: number;
}

export interface InventoryItemTransactionTypePayload {
}

export interface InventoryItemTransactionType extends InventoryItemTransactionTypePayload {
  id: number;
  isDeleted: boolean;
}

