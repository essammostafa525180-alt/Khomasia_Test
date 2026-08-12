// Generated from WebApi/Controllers/VendorReturnSerialController.cs + Domain entity.

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

export interface GetAllVendorReturnSerialParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorReturnSerial {
  id: number;
  vendorReturnFk?: number | null;
  vendorReturnDetailFk?: number | null;
  inventoryItemSerialFk?: number | null;
  inventoryItemSerialFkNavigation?: any | null;
  vendorReturnDetailFkNavigation?: any | null;
  vendorReturnFkNavigation?: any | null;
}

export interface CreateVendorReturnSerial {
  id: number;
  vendorReturnFk?: number | null;
  vendorReturnDetailFk?: number | null;
  inventoryItemSerialFk?: number | null;
  inventoryItemSerialFkNavigation?: any | null;
  vendorReturnDetailFkNavigation?: any | null;
  vendorReturnFkNavigation?: any | null;
}

export interface VendorReturnSerialPayload {
  vendorReturnFk?: number | null;
  vendorReturnDetailFk?: number | null;
  inventoryItemSerialFk?: number | null;
  inventoryItemSerialFkNavigation?: any | null;
  vendorReturnDetailFkNavigation?: any | null;
  vendorReturnFkNavigation?: any | null;
}

export interface VendorReturnSerial extends VendorReturnSerialPayload {
  id: number;
  isDeleted: boolean;
}

