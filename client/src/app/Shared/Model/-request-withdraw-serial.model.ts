// Generated from WebApi/Controllers/RequestWithdrawSerialController.cs + Domain entity.

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

export interface GetAllRequestWithdrawSerialParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface RequestWithdrawSerial {
  id: number;
  requestWithdrawFk?: number | null;
  requestWithdrawDetailFk?: number | null;
  rwDeliveredQuantityFk?: number | null;
  inventoryItemSerialFk?: number | null;
  inventoryItemSerialFkNavigation?: any | null;
  requestWithdrawDetailFkNavigation?: any | null;
  requestWithdrawFkNavigation?: any | null;
  rwDeliveredQuantityFkNavigation?: any | null;
}

export interface CreateRequestWithdrawSerial {
  id: number;
  requestWithdrawFk?: number | null;
  requestWithdrawDetailFk?: number | null;
  rwDeliveredQuantityFk?: number | null;
  inventoryItemSerialFk?: number | null;
  inventoryItemSerialFkNavigation?: any | null;
  requestWithdrawDetailFkNavigation?: any | null;
  requestWithdrawFkNavigation?: any | null;
  rwDeliveredQuantityFkNavigation?: any | null;
}

export interface RequestWithdrawSerialPayload {
  requestWithdrawFk?: number | null;
  requestWithdrawDetailFk?: number | null;
  rwDeliveredQuantityFk?: number | null;
  inventoryItemSerialFk?: number | null;
  inventoryItemSerialFkNavigation?: any | null;
  requestWithdrawDetailFkNavigation?: any | null;
  requestWithdrawFkNavigation?: any | null;
  rwDeliveredQuantityFkNavigation?: any | null;
}

export interface RequestWithdrawSerial extends RequestWithdrawSerialPayload {
  id: number;
  isDeleted: boolean;
}

