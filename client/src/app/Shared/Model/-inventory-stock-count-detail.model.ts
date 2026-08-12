// Generated from WebApi/Controllers/InventoryStockCountDetailController.cs + Domain entity.

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

export interface GetAllInventoryStockCountDetailParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryStockCountDetail {
  id: number;
  inventoryStockCountFk?: number | null;
  inventoryItemFk?: number | null;
  quantity?: number | null;
  countQuantity?: number | null;
  incDecReason?: string | null;
  inventoryItemFkNavigation?: any | null;
  inventoryStockCountFkNavigation?: any | null;
}

export interface CreateInventoryStockCountDetail {
  id: number;
  inventoryStockCountFk?: number | null;
  inventoryItemFk?: number | null;
  quantity?: number | null;
  countQuantity?: number | null;
  incDecReason?: string | null;
  inventoryItemFkNavigation?: any | null;
  inventoryStockCountFkNavigation?: any | null;
}

export interface InventoryStockCountDetailPayload {
  inventoryStockCountFk?: number | null;
  inventoryItemFk?: number | null;
  quantity?: number | null;
  countQuantity?: number | null;
  incDecReason?: string | null;
  inventoryItemFkNavigation?: any | null;
  inventoryStockCountFkNavigation?: any | null;
}

export interface InventoryStockCountDetail extends InventoryStockCountDetailPayload {
  id: number;
  isDeleted: boolean;
}

