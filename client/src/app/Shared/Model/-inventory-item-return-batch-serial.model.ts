// Generated from WebApi/Controllers/InventoryItemReturnBatchSerialController.cs + Domain entity.

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

export interface GetAllInventoryItemReturnBatchSerialParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryItemReturnBatchSerial {
  id: number;
  inventoryItemReturnBatchFk?: number | null;
  returnReasonFk?: number | null;
  rwDelivedSerialFk?: number | null;
  notes?: string | null;
  inventoryItemReturnBatchFkNavigation?: any | null;
  returnReasonFkNavigation?: any | null;
  rwDelivedSerialFkNavigation?: any | null;
}

export interface CreateInventoryItemReturnBatchSerial {
  id: number;
  inventoryItemReturnBatchFk?: number | null;
  returnReasonFk?: number | null;
  rwDelivedSerialFk?: number | null;
  notes?: string | null;
  inventoryItemReturnBatchFkNavigation?: any | null;
  returnReasonFkNavigation?: any | null;
  rwDelivedSerialFkNavigation?: any | null;
}

export interface InventoryItemReturnBatchSerialPayload {
  inventoryItemReturnBatchFk?: number | null;
  returnReasonFk?: number | null;
  rwDelivedSerialFk?: number | null;
  notes?: string | null;
  inventoryItemReturnBatchFkNavigation?: any | null;
  returnReasonFkNavigation?: any | null;
  rwDelivedSerialFkNavigation?: any | null;
}

export interface InventoryItemReturnBatchSerial extends InventoryItemReturnBatchSerialPayload {
  id: number;
  isDeleted: boolean;
}

