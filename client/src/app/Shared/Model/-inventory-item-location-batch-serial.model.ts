// Generated from WebApi/Controllers/InventoryItemLocationBatchSerialController.cs + Domain entity.

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

export interface GetAllInventoryItemLocationBatchSerialParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryItemLocationBatchSerial {
  id: number;
  inventoryItemLocationBatchFk?: number | null;
  serialNumber?: string | null;
  isAvailable?: boolean | null;
  inventoryItemLocationBatchFkNavigation?: any | null;
}

export interface CreateInventoryItemLocationBatchSerial {
  id: number;
  inventoryItemLocationBatchFk?: number | null;
  serialNumber?: string | null;
  isAvailable?: boolean | null;
  inventoryItemLocationBatchFkNavigation?: any | null;
}

export interface InventoryItemLocationBatchSerialPayload {
  inventoryItemLocationBatchFk?: number | null;
  serialNumber?: string | null;
  isAvailable?: boolean | null;
  inventoryItemLocationBatchFkNavigation?: any | null;
}

export interface InventoryItemLocationBatchSerial extends InventoryItemLocationBatchSerialPayload {
  id: number;
  isDeleted: boolean;
}

