// Generated from WebApi/Controllers/InventoryTransfereDetailBatchSerialController.cs + Domain entity.

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

export interface GetAllInventoryTransfereDetailBatchSerialParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryTransfereDetailBatchSerial {
  id: number;
  inventoryTransfereDetailBatchFk?: number | null;
  serialFk?: number | null;
  inventoryTransfereDetailBatchFkNavigation?: any | null;
  serialFkNavigation?: any | null;
}

export interface CreateInventoryTransfereDetailBatchSerial {
  id: number;
  inventoryTransfereDetailBatchFk?: number | null;
  serialFk?: number | null;
  inventoryTransfereDetailBatchFkNavigation?: any | null;
  serialFkNavigation?: any | null;
}

export interface InventoryTransfereDetailBatchSerialPayload {
  inventoryTransfereDetailBatchFk?: number | null;
  serialFk?: number | null;
  inventoryTransfereDetailBatchFkNavigation?: any | null;
  serialFkNavigation?: any | null;
}

export interface InventoryTransfereDetailBatchSerial extends InventoryTransfereDetailBatchSerialPayload {
  id: number;
  isDeleted: boolean;
}

