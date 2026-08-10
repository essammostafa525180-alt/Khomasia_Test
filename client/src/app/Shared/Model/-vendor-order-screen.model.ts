// Generated from WebApi/Controllers/VendorOrderScreenController.cs + Domain entity.

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

export interface GetAllVendorOrderScreenParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorOrderScreen {
  id: number;
}

export interface CreateVendorOrderScreen {
  id: number;
}

export interface VendorOrderScreenPayload {
}

export interface VendorOrderScreen extends VendorOrderScreenPayload {
  id: number;
  isDeleted: boolean;
}

