// Generated from WebApi/Controllers/VendorOrderQualityDetailBatchController.cs + Domain entity.

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

export interface GetAllVendorOrderQualityDetailBatchParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorOrderQualityDetailBatch {
  id: number;
  vendorOrderQualityDetailFk?: number | null;
  shelfFk?: number | null;
  batchNumber?: string | null;
  quantity?: number | null;
  expiryDate?: Date | null;
  productionDate?: Date | null;
  vendorOrderQualityDetailFkNavigation?: any | null;
}

export interface CreateVendorOrderQualityDetailBatch {
  id: number;
  vendorOrderQualityDetailFk?: number | null;
  shelfFk?: number | null;
  batchNumber?: string | null;
  quantity?: number | null;
  expiryDate?: Date | null;
  productionDate?: Date | null;
  vendorOrderQualityDetailFkNavigation?: any | null;
}

export interface VendorOrderQualityDetailBatchPayload {
  vendorOrderQualityDetailFk?: number | null;
  shelfFk?: number | null;
  batchNumber?: string | null;
  quantity?: number | null;
  expiryDate?: Date | null;
  productionDate?: Date | null;
  vendorOrderQualityDetailFkNavigation?: any | null;
}

export interface VendorOrderQualityDetailBatch extends VendorOrderQualityDetailBatchPayload {
  id: number;
  isDeleted: boolean;
}

