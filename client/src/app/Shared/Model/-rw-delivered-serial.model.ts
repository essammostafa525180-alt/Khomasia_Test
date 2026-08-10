// Generated from WebApi/Controllers/RwDeliveredSerialController.cs + Domain entity.

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

export interface GetAllRwDeliveredSerialParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface RwDeliveredSerial {
  id: number;
  rwDeliveredBatchFk?: number | null;
  serialFk?: number | null;
  axsynced?: boolean | null;
  rwDeliveredBatchFkNavigation?: any | null;
  serialFkNavigation?: any | null;
}

export interface CreateRwDeliveredSerial {
  id: number;
  rwDeliveredBatchFk?: number | null;
  serialFk?: number | null;
  axsynced?: boolean | null;
  rwDeliveredBatchFkNavigation?: any | null;
  serialFkNavigation?: any | null;
}

export interface RwDeliveredSerialPayload {
  rwDeliveredBatchFk?: number | null;
  serialFk?: number | null;
  axsynced?: boolean | null;
  rwDeliveredBatchFkNavigation?: any | null;
  serialFkNavigation?: any | null;
}

export interface RwDeliveredSerial extends RwDeliveredSerialPayload {
  id: number;
  isDeleted: boolean;
}

