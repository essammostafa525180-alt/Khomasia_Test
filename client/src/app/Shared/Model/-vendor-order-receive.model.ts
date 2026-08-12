// Generated from WebApi/Controllers/VendorOrderReceiveController.cs + Domain entity.

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

export interface GetAllVendorOrderReceiveParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorOrderReceive {
  id: number;
}

export interface CreateVendorOrderReceive {
  id: number;
}

export interface VendorOrderReceivePayload {
}

export interface VendorOrderReceive extends VendorOrderReceivePayload {
  id: number;
  isDeleted: boolean;
}

