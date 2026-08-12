// Generated from WebApi/Controllers/InventoryItemReturnController.cs + Domain entity.

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

export interface GetAllInventoryItemReturnParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryItemReturn {
  id: number;
  requestWithdrawFk?: number | null;
  returnNo?: string | null;
  returnDate?: Date | null;
  returnedByFk?: number | null;
  returnedBy?: string | null;
  descriptionEn?: string | null;
  descriptionAr?: string | null;
  itemReturnStatusFk?: number | null;
  isAprove?: boolean | null;
  axsynced?: boolean | null;
  sourceId?: number | null;
  createdByNavigation?: any | null;
  itemReturnStatusFkNavigation?: any | null;
  lastUpdatedByNavigation?: any | null;
  requestWithdrawFkNavigation?: any | null;
  returnedByFkNavigation?: any | null;
}

export interface CreateInventoryItemReturn {
  id: number;
  requestWithdrawFk?: number | null;
  returnNo?: string | null;
  returnDate?: Date | null;
  returnedByFk?: number | null;
  returnedBy?: string | null;
  descriptionEn?: string | null;
  descriptionAr?: string | null;
  itemReturnStatusFk?: number | null;
  isAprove?: boolean | null;
  axsynced?: boolean | null;
  sourceId?: number | null;
  createdByNavigation?: any | null;
  itemReturnStatusFkNavigation?: any | null;
  lastUpdatedByNavigation?: any | null;
  requestWithdrawFkNavigation?: any | null;
  returnedByFkNavigation?: any | null;
}

export interface InventoryItemReturnPayload {
  requestWithdrawFk?: number | null;
  returnNo?: string | null;
  returnDate?: Date | null;
  returnedByFk?: number | null;
  returnedBy?: string | null;
  descriptionEn?: string | null;
  descriptionAr?: string | null;
  itemReturnStatusFk?: number | null;
  isAprove?: boolean | null;
  axsynced?: boolean | null;
  sourceId?: number | null;
  createdByNavigation?: any | null;
  itemReturnStatusFkNavigation?: any | null;
  lastUpdatedByNavigation?: any | null;
  requestWithdrawFkNavigation?: any | null;
  returnedByFkNavigation?: any | null;
}

export interface InventoryItemReturn extends InventoryItemReturnPayload {
  id: number;
  isDeleted: boolean;
}

