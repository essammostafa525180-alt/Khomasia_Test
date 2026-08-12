// Generated from WebApi/Controllers/VendorOrderReceiveDetailController.cs + Domain entity.

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

export interface GetAllVendorOrderReceiveDetailParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorOrderReceiveDetail {
  id: number;
  vendorOrderReceiveFk?: number | null;
  vendorOrderQualityDetailFk?: number | null;
  inventoryItemFk?: number | null;
  receivedQuantity?: number | null;
  returnedQuantity?: number | null;
  fromSerialize?: number | null;
  toSerialize?: number | null;
  notes?: string | null;
  partNo?: string | null;
  manufacturerCountry?: string | null;
  inventoryItemFkNavigation?: any | null;
  vendorOrderQualityDetailFkNavigation?: any | null;
  vendorOrderReceiveFkNavigation?: any | null;
}

export interface CreateVendorOrderReceiveDetail {
  id: number;
  vendorOrderReceiveFk?: number | null;
  vendorOrderQualityDetailFk?: number | null;
  inventoryItemFk?: number | null;
  receivedQuantity?: number | null;
  returnedQuantity?: number | null;
  fromSerialize?: number | null;
  toSerialize?: number | null;
  notes?: string | null;
  partNo?: string | null;
  manufacturerCountry?: string | null;
  inventoryItemFkNavigation?: any | null;
  vendorOrderQualityDetailFkNavigation?: any | null;
  vendorOrderReceiveFkNavigation?: any | null;
}

export interface VendorOrderReceiveDetailPayload {
  vendorOrderReceiveFk?: number | null;
  vendorOrderQualityDetailFk?: number | null;
  inventoryItemFk?: number | null;
  receivedQuantity?: number | null;
  returnedQuantity?: number | null;
  fromSerialize?: number | null;
  toSerialize?: number | null;
  notes?: string | null;
  partNo?: string | null;
  manufacturerCountry?: string | null;
  inventoryItemFkNavigation?: any | null;
  vendorOrderQualityDetailFkNavigation?: any | null;
  vendorOrderReceiveFkNavigation?: any | null;
}

export interface VendorOrderReceiveDetail extends VendorOrderReceiveDetailPayload {
  id: number;
  isDeleted: boolean;
}

