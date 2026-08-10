// Generated from WebApi/Controllers/VendorOrderReceiveSerialController.cs + Domain entity.

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

export interface GetAllVendorOrderReceiveSerialParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorOrderReceiveSerial {
  id: number;
  vendorOrderReceiveFk?: number | null;
  vendorOrderReceiveDetailFk?: number | null;
  inventoryItemSerialFk?: number | null;
  inventoryItemSerialFkNavigation?: any | null;
  vendorOrderReceiveDetailFkNavigation?: any | null;
  vendorOrderReceiveFkNavigation?: any | null;
}

export interface CreateVendorOrderReceiveSerial {
  id: number;
  vendorOrderReceiveFk?: number | null;
  vendorOrderReceiveDetailFk?: number | null;
  inventoryItemSerialFk?: number | null;
  inventoryItemSerialFkNavigation?: any | null;
  vendorOrderReceiveDetailFkNavigation?: any | null;
  vendorOrderReceiveFkNavigation?: any | null;
}

export interface VendorOrderReceiveSerialPayload {
  vendorOrderReceiveFk?: number | null;
  vendorOrderReceiveDetailFk?: number | null;
  inventoryItemSerialFk?: number | null;
  inventoryItemSerialFkNavigation?: any | null;
  vendorOrderReceiveDetailFkNavigation?: any | null;
  vendorOrderReceiveFkNavigation?: any | null;
}

export interface VendorOrderReceiveSerial extends VendorOrderReceiveSerialPayload {
  id: number;
  isDeleted: boolean;
}

