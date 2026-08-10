// Generated from WebApi/Controllers/InventoryItemUoMController.cs + Domain entity.

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

export interface GetAllInventoryItemUoMParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryItemUoM {
  id: number;
  inventoryItemFk?: number | null;
  unitOfMeasureFk?: number | null;
  convertRate?: number | null;
  inventoryItemFkNavigation?: any | null;
  unitOfMeasureFkNavigation?: any | null;
}

export interface CreateInventoryItemUoM {
  id: number;
  inventoryItemFk?: number | null;
  unitOfMeasureFk?: number | null;
  convertRate?: number | null;
  inventoryItemFkNavigation?: any | null;
  unitOfMeasureFkNavigation?: any | null;
}

export interface InventoryItemUoMPayload {
  inventoryItemFk?: number | null;
  unitOfMeasureFk?: number | null;
  convertRate?: number | null;
  inventoryItemFkNavigation?: any | null;
  unitOfMeasureFkNavigation?: any | null;
}

export interface InventoryItemUoM extends InventoryItemUoMPayload {
  id: number;
  isDeleted: boolean;
}

