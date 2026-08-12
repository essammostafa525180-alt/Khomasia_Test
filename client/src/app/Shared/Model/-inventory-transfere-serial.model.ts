// Generated from WebApi/Controllers/InventoryTransfereSerialController.cs + Domain entity.

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

export interface GetAllInventoryTransfereSerialParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryTransfereSerial {
  id: number;
  inventoryTransfereFk?: number | null;
  inventoryTransfereDetailFk?: number | null;
  inventoryItemSerialFk?: number | null;
  inventoryItemSerialFkNavigation?: any | null;
  inventoryTransfereDetailFkNavigation?: any | null;
  inventoryTransfereFkNavigation?: any | null;
}

export interface CreateInventoryTransfereSerial {
  id: number;
  inventoryTransfereFk?: number | null;
  inventoryTransfereDetailFk?: number | null;
  inventoryItemSerialFk?: number | null;
  inventoryItemSerialFkNavigation?: any | null;
  inventoryTransfereDetailFkNavigation?: any | null;
  inventoryTransfereFkNavigation?: any | null;
}

export interface InventoryTransfereSerialPayload {
  inventoryTransfereFk?: number | null;
  inventoryTransfereDetailFk?: number | null;
  inventoryItemSerialFk?: number | null;
  inventoryItemSerialFkNavigation?: any | null;
  inventoryTransfereDetailFkNavigation?: any | null;
  inventoryTransfereFkNavigation?: any | null;
}

export interface InventoryTransfereSerial extends InventoryTransfereSerialPayload {
  id: number;
  isDeleted: boolean;
}

