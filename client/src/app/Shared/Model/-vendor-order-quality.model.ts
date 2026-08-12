// Generated from WebApi/Controllers/VendorOrderQualityController.cs + Domain entity.

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

export interface GetAllVendorOrderQualityParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorOrderQuality {
  id: number;
}

export interface CreateVendorOrderQuality {
  id: number;
}

export interface VendorOrderQualityPayload {
}

export interface VendorOrderQuality extends VendorOrderQualityPayload {
  id: number;
  isDeleted: boolean;
}

