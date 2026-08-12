// Generated from WebApi/Controllers/RwPickedBatchController.cs + Domain entity.

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

export interface GetAllRwPickedBatchParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface RwPickedBatch {
  id: number;
  requestWdfk?: number | null;
  returnedQuantity?: number | null;
  pickedQuantity?: number | null;
  pickedDate?: Date | null;
  batchFk?: number | null;
  axsynced?: boolean | null;
}

export interface CreateRwPickedBatch {
  id: number;
  requestWdfk?: number | null;
  returnedQuantity?: number | null;
  pickedQuantity?: number | null;
  pickedDate?: Date | null;
  batchFk?: number | null;
  axsynced?: boolean | null;
}

export interface RwPickedBatchPayload {
  requestWdfk?: number | null;
  returnedQuantity?: number | null;
  pickedQuantity?: number | null;
  pickedDate?: Date | null;
  batchFk?: number | null;
  axsynced?: boolean | null;
}

export interface RwPickedBatch extends RwPickedBatchPayload {
  id: number;
  isDeleted: boolean;
}

