// Generated from WebApi/Controllers/VendorReturnDetailBatchSerialController.cs + Domain entity.

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

export interface GetAllVendorReturnDetailBatchSerialParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorReturnDetailBatchSerial {
  id: number;
  vendorReturnDetailBatchFk?: number | null;
  serialFk?: number | null;
  returnReasonFk?: number | null;
  notes?: string | null;
  returnReasonFkNavigation?: any | null;
  serialFkNavigation?: any | null;
  vendorReturnDetailBatchFkNavigation?: any | null;
}

export interface CreateVendorReturnDetailBatchSerial {
  id: number;
  vendorReturnDetailBatchFk?: number | null;
  serialFk?: number | null;
  returnReasonFk?: number | null;
  notes?: string | null;
  returnReasonFkNavigation?: any | null;
  serialFkNavigation?: any | null;
  vendorReturnDetailBatchFkNavigation?: any | null;
}

export interface VendorReturnDetailBatchSerialPayload {
  vendorReturnDetailBatchFk?: number | null;
  serialFk?: number | null;
  returnReasonFk?: number | null;
  notes?: string | null;
  returnReasonFkNavigation?: any | null;
  serialFkNavigation?: any | null;
  vendorReturnDetailBatchFkNavigation?: any | null;
}

export interface VendorReturnDetailBatchSerial extends VendorReturnDetailBatchSerialPayload {
  id: number;
  isDeleted: boolean;
}

