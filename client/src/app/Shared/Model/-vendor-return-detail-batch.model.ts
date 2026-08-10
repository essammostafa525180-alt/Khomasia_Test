// Generated from WebApi/Controllers/VendorReturnDetailBatchController.cs + Domain entity.

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

export interface GetAllVendorReturnDetailBatchParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorReturnDetailBatch {
  id: number;
  vendorReturnDetailFk?: number | null;
  quantity?: number | null;
  returnReasonFk?: number | null;
  notes?: string | null;
  batchFk?: number | null;
  vendorOrderReceiveDetailBatchFk?: number | null;
  returnReasonFkNavigation?: any | null;
}

export interface CreateVendorReturnDetailBatch {
  id: number;
  vendorReturnDetailFk?: number | null;
  quantity?: number | null;
  returnReasonFk?: number | null;
  notes?: string | null;
  batchFk?: number | null;
  vendorOrderReceiveDetailBatchFk?: number | null;
  returnReasonFkNavigation?: any | null;
}

export interface VendorReturnDetailBatchPayload {
  vendorReturnDetailFk?: number | null;
  quantity?: number | null;
  returnReasonFk?: number | null;
  notes?: string | null;
  batchFk?: number | null;
  vendorOrderReceiveDetailBatchFk?: number | null;
  returnReasonFkNavigation?: any | null;
}

export interface VendorReturnDetailBatch extends VendorReturnDetailBatchPayload {
  id: number;
  isDeleted: boolean;
}

