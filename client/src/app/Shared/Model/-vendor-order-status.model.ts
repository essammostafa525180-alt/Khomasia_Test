// Generated from WebApi/Controllers/VendorOrderStatusController.cs + Domain entity.

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

export interface GetAllVendorOrderStatusParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorOrderStatus {
  id: number;
}

export interface CreateVendorOrderStatus {
  id: number;
}

export interface VendorOrderStatusPayload {
}

export interface VendorOrderStatus extends VendorOrderStatusPayload {
  id: number;
  isDeleted: boolean;
}

