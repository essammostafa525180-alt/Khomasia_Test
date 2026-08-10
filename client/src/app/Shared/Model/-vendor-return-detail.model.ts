// Generated from WebApi/Controllers/VendorReturnDetailController.cs + Domain entity.

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

export interface GetAllVendorReturnDetailParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorReturnDetail {
  id: number;
  vendorReturnFk?: number | null;
  inventoryItemFk?: number | null;
  quantity?: number | null;
  returnReasonFk?: number | null;
  inventoryItemFkNavigation?: any | null;
  returnReasonFkNavigation?: any | null;
  vendorReturnFkNavigation?: any | null;
}

export interface CreateVendorReturnDetail {
  id: number;
  vendorReturnFk?: number | null;
  inventoryItemFk?: number | null;
  quantity?: number | null;
  returnReasonFk?: number | null;
  inventoryItemFkNavigation?: any | null;
  returnReasonFkNavigation?: any | null;
  vendorReturnFkNavigation?: any | null;
}

export interface VendorReturnDetailPayload {
  vendorReturnFk?: number | null;
  inventoryItemFk?: number | null;
  quantity?: number | null;
  returnReasonFk?: number | null;
  inventoryItemFkNavigation?: any | null;
  returnReasonFkNavigation?: any | null;
  vendorReturnFkNavigation?: any | null;
}

export interface VendorReturnDetail extends VendorReturnDetailPayload {
  id: number;
  isDeleted: boolean;
}

