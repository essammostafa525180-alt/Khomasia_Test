// Generated from WebApi/Controllers/VendorStatusController.cs + Domain entity.

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

export interface GetAllVendorStatusParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorStatus {
  id: number;
}

export interface CreateVendorStatus {
  id: number;
}

export interface VendorStatusPayload {
}

export interface VendorStatus extends VendorStatusPayload {
  id: number;
  isDeleted: boolean;
}

