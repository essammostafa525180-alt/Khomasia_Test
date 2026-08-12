// Generated from WebApi/Controllers/RwPickedSerialController.cs + Domain entity.

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

export interface GetAllRwPickedSerialParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface RwPickedSerial {
  id: number;
  rwPickedBatchFk?: number | null;
  serialFk?: number | null;
  axsynced?: boolean | null;
  rwPickedBatchFkNavigation?: any | null;
}

export interface CreateRwPickedSerial {
  id: number;
  rwPickedBatchFk?: number | null;
  serialFk?: number | null;
  axsynced?: boolean | null;
  rwPickedBatchFkNavigation?: any | null;
}

export interface RwPickedSerialPayload {
  rwPickedBatchFk?: number | null;
  serialFk?: number | null;
  axsynced?: boolean | null;
  rwPickedBatchFkNavigation?: any | null;
}

export interface RwPickedSerial extends RwPickedSerialPayload {
  id: number;
  isDeleted: boolean;
}

