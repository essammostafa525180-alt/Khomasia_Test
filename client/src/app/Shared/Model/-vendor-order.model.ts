// Generated from WebApi/Controllers/VendorOrderController.cs + Domain entity.

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

export interface GetAllVendorOrderParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorOrder {
  id: number;
}

export interface CreateVendorOrder {
  id: number;
}

export interface VendorOrderPayload {
}

export interface VendorOrder extends VendorOrderPayload {
  id: number;
  isDeleted: boolean;
}

