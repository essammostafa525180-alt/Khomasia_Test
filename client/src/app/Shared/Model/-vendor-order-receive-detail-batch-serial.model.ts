// Generated from WebApi/Controllers/VendorOrderReceiveDetailBatchSerialController.cs + Domain entity.

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

export interface GetAllVendorOrderReceiveDetailBatchSerialParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorOrderReceiveDetailBatchSerial {
  id: number;
  vendorOrderReceiveDetailBatchFk?: number | null;
  serialNumber?: string | null;
  vendorOrderReceiveDetailBatchFkNavigation?: any | null;
}

export interface CreateVendorOrderReceiveDetailBatchSerial {
  id: number;
  vendorOrderReceiveDetailBatchFk?: number | null;
  serialNumber?: string | null;
  vendorOrderReceiveDetailBatchFkNavigation?: any | null;
}

export interface VendorOrderReceiveDetailBatchSerialPayload {
  vendorOrderReceiveDetailBatchFk?: number | null;
  serialNumber?: string | null;
  vendorOrderReceiveDetailBatchFkNavigation?: any | null;
}

export interface VendorOrderReceiveDetailBatchSerial extends VendorOrderReceiveDetailBatchSerialPayload {
  id: number;
  isDeleted: boolean;
}

