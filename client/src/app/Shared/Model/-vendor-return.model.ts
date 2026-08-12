// Generated from WebApi/Controllers/VendorReturnController.cs + Domain entity.

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

export interface GetAllVendorReturnParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorReturn {
  id: number;
}

export interface CreateVendorReturn {
  id: number;
}

export interface VendorReturnPayload {
}

export interface VendorReturn extends VendorReturnPayload {
  id: number;
  isDeleted: boolean;
}

