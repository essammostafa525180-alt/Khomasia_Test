// Generated from WebApi/Controllers/InventoryStockCountDetailBatchSerialController.cs + Domain entity.

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

export interface GetAllInventoryStockCountDetailBatchSerialParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryStockCountDetailBatchSerial {
  id: number;
  inventoryStockCountDetailBatchFk?: number | null;
  inventoryItemLocationBatchSerialFk?: number | null;
  isNew: boolean;
  isSerialExist: boolean;
  inventoryItemLocationBatchSerialFkNavigation?: any | null;
  inventoryStockCountDetailBatchFkNavigation?: any | null;
}

export interface CreateInventoryStockCountDetailBatchSerial {
  id: number;
  inventoryStockCountDetailBatchFk?: number | null;
  inventoryItemLocationBatchSerialFk?: number | null;
  isNew: boolean;
  isSerialExist: boolean;
  inventoryItemLocationBatchSerialFkNavigation?: any | null;
  inventoryStockCountDetailBatchFkNavigation?: any | null;
}

export interface InventoryStockCountDetailBatchSerialPayload {
  inventoryStockCountDetailBatchFk?: number | null;
  inventoryItemLocationBatchSerialFk?: number | null;
  isNew: boolean;
  isSerialExist: boolean;
  inventoryItemLocationBatchSerialFkNavigation?: any | null;
  inventoryStockCountDetailBatchFkNavigation?: any | null;
}

export interface InventoryStockCountDetailBatchSerial extends InventoryStockCountDetailBatchSerialPayload {
  id: number;
  isDeleted: boolean;
}

