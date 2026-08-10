// Generated from WebApi/Controllers/InventoryItemLocationBatchController.cs + Domain entity.

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

export interface GetAllInventoryItemLocationBatchParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryItemLocationBatch {
  id: number;
  inventoryItemLocationFk?: number | null;
  batchNumber?: string | null;
  shelfFk?: number | null;
  totalQuantity?: number | null;
  expiryDate?: Date | null;
  inventoryItemFk?: number | null;
  productionDate?: Date | null;
  inventoryItemLocationFkNavigation?: any | null;
  shelfFkNavigation?: any | null;
}

export interface CreateInventoryItemLocationBatch {
  id: number;
  inventoryItemLocationFk?: number | null;
  batchNumber?: string | null;
  shelfFk?: number | null;
  totalQuantity?: number | null;
  expiryDate?: Date | null;
  inventoryItemFk?: number | null;
  productionDate?: Date | null;
  inventoryItemLocationFkNavigation?: any | null;
  shelfFkNavigation?: any | null;
}

export interface InventoryItemLocationBatchPayload {
  inventoryItemLocationFk?: number | null;
  batchNumber?: string | null;
  shelfFk?: number | null;
  totalQuantity?: number | null;
  expiryDate?: Date | null;
  inventoryItemFk?: number | null;
  productionDate?: Date | null;
  inventoryItemLocationFkNavigation?: any | null;
  shelfFkNavigation?: any | null;
}

export interface InventoryItemLocationBatch extends InventoryItemLocationBatchPayload {
  id: number;
  isDeleted: boolean;
}

