// Generated from WebApi/Controllers/VendorController.cs + Domain entity.

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

export interface GetAllVendorParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Vendor {
  id: number;
}

export interface CreateVendor {
  id: number;
}

export interface VendorPayload {
}

export interface Vendor extends VendorPayload {
  id: number;
  isDeleted: boolean;
}

