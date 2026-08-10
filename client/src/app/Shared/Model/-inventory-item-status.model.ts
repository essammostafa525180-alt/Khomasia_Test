// Generated from WebApi/Controllers/InventoryItemStatusController.cs + Domain entity.

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

export interface GetAllInventoryItemStatusParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryItemStatus {
  id: number;
}

export interface CreateInventoryItemStatus {
  id: number;
}

export interface InventoryItemStatusPayload {
}

export interface InventoryItemStatus extends InventoryItemStatusPayload {
  id: number;
  isDeleted: boolean;
}

