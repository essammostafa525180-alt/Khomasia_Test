// Generated from WebApi/Controllers/InventoryItemReturnBatchController.cs + Domain entity.

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

export interface GetAllInventoryItemReturnBatchParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryItemReturnBatch {
  id: number;
  itemReturnDetailFk?: number | null;
  returnedQuantity?: number | null;
  returnReasonFk?: number | null;
  rwDeliveredBatchFk?: number | null;
  notes?: string | null;
  batchFk?: number | null;
  itemReturnDetailFkNavigation?: any | null;
  returnReasonFkNavigation?: any | null;
  rwDeliveredBatchFkNavigation?: any | null;
}

export interface CreateInventoryItemReturnBatch {
  id: number;
  itemReturnDetailFk?: number | null;
  returnedQuantity?: number | null;
  returnReasonFk?: number | null;
  rwDeliveredBatchFk?: number | null;
  notes?: string | null;
  batchFk?: number | null;
  itemReturnDetailFkNavigation?: any | null;
  returnReasonFkNavigation?: any | null;
  rwDeliveredBatchFkNavigation?: any | null;
}

export interface InventoryItemReturnBatchPayload {
  itemReturnDetailFk?: number | null;
  returnedQuantity?: number | null;
  returnReasonFk?: number | null;
  rwDeliveredBatchFk?: number | null;
  notes?: string | null;
  batchFk?: number | null;
  itemReturnDetailFkNavigation?: any | null;
  returnReasonFkNavigation?: any | null;
  rwDeliveredBatchFkNavigation?: any | null;
}

export interface InventoryItemReturnBatch extends InventoryItemReturnBatchPayload {
  id: number;
  isDeleted: boolean;
}

