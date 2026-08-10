// Generated from WebApi/Controllers/InventoryItemSerialController.cs + Domain entity.

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

export interface GetAllInventoryItemSerialParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryItemSerial {
  id: number;
}

export interface CreateInventoryItemSerial {
  id: number;
}

export interface InventoryItemSerialPayload {
}

export interface InventoryItemSerial extends InventoryItemSerialPayload {
  id: number;
  isDeleted: boolean;
}

