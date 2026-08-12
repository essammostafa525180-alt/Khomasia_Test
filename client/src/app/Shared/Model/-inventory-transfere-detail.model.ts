// Generated from WebApi/Controllers/InventoryTransfereDetailController.cs + Domain entity.

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

export interface GetAllInventoryTransfereDetailParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryTransfereDetail {
  id: number;
  inventoryTransfereFk?: number | null;
  inventoryItemFk?: number | null;
  quantity?: number | null;
  inventoryItemFkNavigation?: any | null;
  inventoryTransfereFkNavigation?: any | null;
}

export interface CreateInventoryTransfereDetail {
  id: number;
  inventoryTransfereFk?: number | null;
  inventoryItemFk?: number | null;
  quantity?: number | null;
  inventoryItemFkNavigation?: any | null;
  inventoryTransfereFkNavigation?: any | null;
}

export interface InventoryTransfereDetailPayload {
  inventoryTransfereFk?: number | null;
  inventoryItemFk?: number | null;
  quantity?: number | null;
  inventoryItemFkNavigation?: any | null;
  inventoryTransfereFkNavigation?: any | null;
}

export interface InventoryTransfereDetail extends InventoryTransfereDetailPayload {
  id: number;
  isDeleted: boolean;
}

