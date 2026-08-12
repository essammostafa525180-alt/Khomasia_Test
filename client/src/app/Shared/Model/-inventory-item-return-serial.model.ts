// Generated from WebApi/Controllers/InventoryItemReturnSerialController.cs + Domain entity.

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

export interface GetAllInventoryItemReturnSerialParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryItemReturnSerial {
  id: number;
  inventoryItemReturnFk?: number | null;
  inventoryItemReturnDetailFk?: number | null;
  inventoryItemSerialFk?: number | null;
  inventoryItemReturnDetailFkNavigation?: any | null;
  inventoryItemReturnFkNavigation?: any | null;
  inventoryItemSerialFkNavigation?: any | null;
}

export interface CreateInventoryItemReturnSerial {
  id: number;
  inventoryItemReturnFk?: number | null;
  inventoryItemReturnDetailFk?: number | null;
  inventoryItemSerialFk?: number | null;
  inventoryItemReturnDetailFkNavigation?: any | null;
  inventoryItemReturnFkNavigation?: any | null;
  inventoryItemSerialFkNavigation?: any | null;
}

export interface InventoryItemReturnSerialPayload {
  inventoryItemReturnFk?: number | null;
  inventoryItemReturnDetailFk?: number | null;
  inventoryItemSerialFk?: number | null;
  inventoryItemReturnDetailFkNavigation?: any | null;
  inventoryItemReturnFkNavigation?: any | null;
  inventoryItemSerialFkNavigation?: any | null;
}

export interface InventoryItemReturnSerial extends InventoryItemReturnSerialPayload {
  id: number;
  isDeleted: boolean;
}

