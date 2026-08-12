// Generated from WebApi/Controllers/VendorTypeController.cs + Domain entity.

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

export interface GetAllVendorTypeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorType {
  id: number;
}

export interface CreateVendorType {
  id: number;
}

export interface VendorTypePayload {
}

export interface VendorType extends VendorTypePayload {
  id: number;
  isDeleted: boolean;
}

