// Generated from WebApi/Controllers/InventoryItemReturnDetailController.cs + Domain entity.

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

export interface GetAllInventoryItemReturnDetailParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryItemReturnDetail {
  id: number;
  inventoryItemReturnFk?: number | null;
  inventoryItemFk?: number | null;
  returnedQuantity?: number | null;
  returnReasonFk?: number | null;
  notes?: string | null;
  externalReturnedQuantity?: number | null;
  requestWdfk?: number | null;
  inventoryItemFkNavigation?: any | null;
  inventoryItemReturnFkNavigation?: any | null;
  returnReasonFkNavigation?: any | null;
}

export interface CreateInventoryItemReturnDetail {
  id: number;
  inventoryItemReturnFk?: number | null;
  inventoryItemFk?: number | null;
  returnedQuantity?: number | null;
  returnReasonFk?: number | null;
  notes?: string | null;
  externalReturnedQuantity?: number | null;
  requestWdfk?: number | null;
  inventoryItemFkNavigation?: any | null;
  inventoryItemReturnFkNavigation?: any | null;
  returnReasonFkNavigation?: any | null;
}

export interface InventoryItemReturnDetailPayload {
  inventoryItemReturnFk?: number | null;
  inventoryItemFk?: number | null;
  returnedQuantity?: number | null;
  returnReasonFk?: number | null;
  notes?: string | null;
  externalReturnedQuantity?: number | null;
  requestWdfk?: number | null;
  inventoryItemFkNavigation?: any | null;
  inventoryItemReturnFkNavigation?: any | null;
  returnReasonFkNavigation?: any | null;
}

export interface InventoryItemReturnDetail extends InventoryItemReturnDetailPayload {
  id: number;
  isDeleted: boolean;
}

