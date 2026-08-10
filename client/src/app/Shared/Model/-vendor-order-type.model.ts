// Generated from WebApi/Controllers/VendorOrderTypeController.cs + Domain entity.

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

export interface GetAllVendorOrderTypeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorOrderType {
  id: number;
}

export interface CreateVendorOrderType {
  id: number;
}

export interface VendorOrderTypePayload {
}

export interface VendorOrderType extends VendorOrderTypePayload {
  id: number;
  isDeleted: boolean;
}

