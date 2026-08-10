// Generated from WebApi/Controllers/InventoryItemLocationDetailController.cs + Domain entity.

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

export interface GetAllInventoryItemLocationDetailParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryItemLocationDetail {
  id: number;
  storeFk?: number | null;
  inventoryItemFk?: number | null;
  itemQuantityTypeFk?: number | null;
  transactionTypeFk?: number | null;
  screen?: string | null;
  entityId?: number | null;
  entityCode?: string | null;
  entityDate?: Date | null;
  entityDetailId?: number | null;
  inventoryItemLocationFk?: number | null;
  quantityBefore?: number | null;
  quantity: number;
  quantityAfter?: number | null;
  entityDetailCost?: number | null;
  avgcost?: number | null;
  inventoryItemLocationBatchFk?: number | null;
  inventoryItemFkNavigation?: any | null;
  inventoryItemLocationFkNavigation?: any | null;
  itemQuantityTypeFkNavigation?: any | null;
  storeFkNavigation?: any | null;
  transactionTypeFkNavigation?: any | null;
}

export interface CreateInventoryItemLocationDetail {
  id: number;
  storeFk?: number | null;
  inventoryItemFk?: number | null;
  itemQuantityTypeFk?: number | null;
  transactionTypeFk?: number | null;
  screen?: string | null;
  entityId?: number | null;
  entityCode?: string | null;
  entityDate?: Date | null;
  entityDetailId?: number | null;
  inventoryItemLocationFk?: number | null;
  quantityBefore?: number | null;
  quantity: number;
  quantityAfter?: number | null;
  entityDetailCost?: number | null;
  avgcost?: number | null;
  inventoryItemLocationBatchFk?: number | null;
  inventoryItemFkNavigation?: any | null;
  inventoryItemLocationFkNavigation?: any | null;
  itemQuantityTypeFkNavigation?: any | null;
  storeFkNavigation?: any | null;
  transactionTypeFkNavigation?: any | null;
}

export interface InventoryItemLocationDetailPayload {
  storeFk?: number | null;
  inventoryItemFk?: number | null;
  itemQuantityTypeFk?: number | null;
  transactionTypeFk?: number | null;
  screen?: string | null;
  entityId?: number | null;
  entityCode?: string | null;
  entityDate?: Date | null;
  entityDetailId?: number | null;
  inventoryItemLocationFk?: number | null;
  quantityBefore?: number | null;
  quantity: number;
  quantityAfter?: number | null;
  entityDetailCost?: number | null;
  avgcost?: number | null;
  inventoryItemLocationBatchFk?: number | null;
  inventoryItemFkNavigation?: any | null;
  inventoryItemLocationFkNavigation?: any | null;
  itemQuantityTypeFkNavigation?: any | null;
  storeFkNavigation?: any | null;
  transactionTypeFkNavigation?: any | null;
}

export interface InventoryItemLocationDetail extends InventoryItemLocationDetailPayload {
  id: number;
  isDeleted: boolean;
}

