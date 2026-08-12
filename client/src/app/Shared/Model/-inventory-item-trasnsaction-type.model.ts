// Generated from WebApi/Controllers/InventoryItemTrasnsactionTypeController.cs + Domain entity.

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

export interface GetAllInventoryItemTrasnsactionTypeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryItemTrasnsactionType {
  id: number;
}

export interface CreateInventoryItemTrasnsactionType {
  id: number;
}

export interface InventoryItemTrasnsactionTypePayload {
}

export interface InventoryItemTrasnsactionType extends InventoryItemTrasnsactionTypePayload {
  id: number;
  isDeleted: boolean;
}

