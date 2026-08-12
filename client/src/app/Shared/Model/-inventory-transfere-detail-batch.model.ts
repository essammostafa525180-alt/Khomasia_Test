// Generated from WebApi/Controllers/InventoryTransfereDetailBatchController.cs + Domain entity.

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

export interface GetAllInventoryTransfereDetailBatchParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryTransfereDetailBatch {
  id: number;
  inventoryTransfereDetailFk?: number | null;
  batchFk?: number | null;
  newBatchNumber?: string | null;
  qunatity?: number | null;
  expiryDate?: Date | null;
  shelfFk?: number | null;
  batchFkNavigation?: any | null;
  inventoryTransfereDetailFkNavigation?: any | null;
  shelfFkNavigation?: any | null;
}

export interface CreateInventoryTransfereDetailBatch {
  id: number;
  inventoryTransfereDetailFk?: number | null;
  batchFk?: number | null;
  newBatchNumber?: string | null;
  qunatity?: number | null;
  expiryDate?: Date | null;
  shelfFk?: number | null;
  batchFkNavigation?: any | null;
  inventoryTransfereDetailFkNavigation?: any | null;
  shelfFkNavigation?: any | null;
}

export interface InventoryTransfereDetailBatchPayload {
  inventoryTransfereDetailFk?: number | null;
  batchFk?: number | null;
  newBatchNumber?: string | null;
  qunatity?: number | null;
  expiryDate?: Date | null;
  shelfFk?: number | null;
  batchFkNavigation?: any | null;
  inventoryTransfereDetailFkNavigation?: any | null;
  shelfFkNavigation?: any | null;
}

export interface InventoryTransfereDetailBatch extends InventoryTransfereDetailBatchPayload {
  id: number;
  isDeleted: boolean;
}

