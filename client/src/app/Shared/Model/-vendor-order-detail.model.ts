// Generated from WebApi/Controllers/VendorOrderDetailController.cs + Domain entity.

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

export interface GetAllVendorOrderDetailParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorOrderDetail {
  id: number;
}

export interface CreateVendorOrderDetail {
  id: number;
}

export interface VendorOrderDetailPayload {
}

export interface VendorOrderDetail extends VendorOrderDetailPayload {
  id: number;
  isDeleted: boolean;
}

