// Generated from WebApi/Controllers/VendorOrderQualityDetailController.cs + Domain entity.

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

export interface GetAllVendorOrderQualityDetailParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorOrderQualityDetail {
  id: number;
  vendorOrderQualityFk?: number | null;
  vendorOrderDetailFk?: number | null;
  inventoryItemFk?: number | null;
  receivedQuantity?: number | null;
  landedCost?: number | null;
  inventoryItemFkNavigation?: any | null;
  vendorOrderDetailFkNavigation?: any | null;
  vendorOrderQualityFkNavigation?: any | null;
}

export interface CreateVendorOrderQualityDetail {
  id: number;
  vendorOrderQualityFk?: number | null;
  vendorOrderDetailFk?: number | null;
  inventoryItemFk?: number | null;
  receivedQuantity?: number | null;
  landedCost?: number | null;
  inventoryItemFkNavigation?: any | null;
  vendorOrderDetailFkNavigation?: any | null;
  vendorOrderQualityFkNavigation?: any | null;
}

export interface VendorOrderQualityDetailPayload {
  vendorOrderQualityFk?: number | null;
  vendorOrderDetailFk?: number | null;
  inventoryItemFk?: number | null;
  receivedQuantity?: number | null;
  landedCost?: number | null;
  inventoryItemFkNavigation?: any | null;
  vendorOrderDetailFkNavigation?: any | null;
  vendorOrderQualityFkNavigation?: any | null;
}

export interface VendorOrderQualityDetail extends VendorOrderQualityDetailPayload {
  id: number;
  isDeleted: boolean;
}

