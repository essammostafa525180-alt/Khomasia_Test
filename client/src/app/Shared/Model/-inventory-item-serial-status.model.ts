// Generated from WebApi/Controllers/InventoryItemSerialStatusController.cs + Domain entity.

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

export interface GetAllInventoryItemSerialStatusParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryItemSerialStatus {
  id: number;
}

export interface CreateInventoryItemSerialStatus {
  id: number;
}

export interface InventoryItemSerialStatusPayload {
}

export interface InventoryItemSerialStatus extends InventoryItemSerialStatusPayload {
  id: number;
  isDeleted: boolean;
}

