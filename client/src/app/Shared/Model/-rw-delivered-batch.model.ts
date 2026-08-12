// Generated from WebApi/Controllers/RwDeliveredBatchController.cs + Domain entity.

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

export interface GetAllRwDeliveredBatchParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface RwDeliveredBatch {
  id: number;
  requestWdfk?: number | null;
  returnedQuantity?: number | null;
  deliveredQuantity?: number | null;
  deliveredDate?: Date | null;
  batchFk?: number | null;
  axsynced?: boolean | null;
  batchFkNavigation?: any | null;
  requestWdfkNavigation?: any | null;
}

export interface CreateRwDeliveredBatch {
  id: number;
  requestWdfk?: number | null;
  returnedQuantity?: number | null;
  deliveredQuantity?: number | null;
  deliveredDate?: Date | null;
  batchFk?: number | null;
  axsynced?: boolean | null;
  batchFkNavigation?: any | null;
  requestWdfkNavigation?: any | null;
}

export interface RwDeliveredBatchPayload {
  requestWdfk?: number | null;
  returnedQuantity?: number | null;
  deliveredQuantity?: number | null;
  deliveredDate?: Date | null;
  batchFk?: number | null;
  axsynced?: boolean | null;
  batchFkNavigation?: any | null;
  requestWdfkNavigation?: any | null;
}

export interface RwDeliveredBatch extends RwDeliveredBatchPayload {
  id: number;
  isDeleted: boolean;
}

