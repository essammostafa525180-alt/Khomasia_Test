// Generated from WebApi/Controllers/InsuranceVendorController.cs + Domain entity.

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

export interface GetAllInsuranceVendorParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InsuranceVendor {
  id: number;
}

export interface CreateInsuranceVendor {
  id: number;
}

export interface InsuranceVendorPayload {
}

export interface InsuranceVendor extends InsuranceVendorPayload {
  id: number;
  isDeleted: boolean;
}

