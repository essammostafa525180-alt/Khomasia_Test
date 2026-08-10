// Generated from WebApi/Controllers/VendorOrderReceiveDetailBatchController.cs + Domain entity.

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

export interface GetAllVendorOrderReceiveDetailBatchParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorOrderReceiveDetailBatch {
  id: number;
  vendorOrderReceiveDetailFk?: number | null;
  shelfFk?: number | null;
  batchNumber?: string | null;
  quantity?: number | null;
  returnedQuantity?: number | null;
  expiryDate?: Date | null;
  productionDate?: Date | null;
  shelfFkNavigation?: any | null;
  vendorOrderReceiveDetailFkNavigation?: any | null;
}

export interface CreateVendorOrderReceiveDetailBatch {
  id: number;
  vendorOrderReceiveDetailFk?: number | null;
  shelfFk?: number | null;
  batchNumber?: string | null;
  quantity?: number | null;
  returnedQuantity?: number | null;
  expiryDate?: Date | null;
  productionDate?: Date | null;
  shelfFkNavigation?: any | null;
  vendorOrderReceiveDetailFkNavigation?: any | null;
}

export interface VendorOrderReceiveDetailBatchPayload {
  vendorOrderReceiveDetailFk?: number | null;
  shelfFk?: number | null;
  batchNumber?: string | null;
  quantity?: number | null;
  returnedQuantity?: number | null;
  expiryDate?: Date | null;
  productionDate?: Date | null;
  shelfFkNavigation?: any | null;
  vendorOrderReceiveDetailFkNavigation?: any | null;
}

export interface VendorOrderReceiveDetailBatch extends VendorOrderReceiveDetailBatchPayload {
  id: number;
  isDeleted: boolean;
}

