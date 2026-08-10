// Generated from WebApi/Controllers/InventoryStockCountDetailBatchController.cs + Domain entity.

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

export interface GetAllInventoryStockCountDetailBatchParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryStockCountDetailBatch {
  id: number;
  inventoryStockCountDetailFk?: number | null;
  batchFk?: number | null;
  quantity?: number | null;
  countQuantity?: number | null;
  batchFkNavigation?: any | null;
  inventoryStockCountDetailFkNavigation?: any | null;
}

export interface CreateInventoryStockCountDetailBatch {
  id: number;
  inventoryStockCountDetailFk?: number | null;
  batchFk?: number | null;
  quantity?: number | null;
  countQuantity?: number | null;
  batchFkNavigation?: any | null;
  inventoryStockCountDetailFkNavigation?: any | null;
}

export interface InventoryStockCountDetailBatchPayload {
  inventoryStockCountDetailFk?: number | null;
  batchFk?: number | null;
  quantity?: number | null;
  countQuantity?: number | null;
  batchFkNavigation?: any | null;
  inventoryStockCountDetailFkNavigation?: any | null;
}

export interface InventoryStockCountDetailBatch extends InventoryStockCountDetailBatchPayload {
  id: number;
  isDeleted: boolean;
}

