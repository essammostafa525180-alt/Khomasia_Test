// Generated from WebApi/Controllers/VendorSpecializationController.cs + Domain entity.

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

export interface GetAllVendorSpecializationParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorSpecialization {
  id: number;
}

export interface CreateVendorSpecialization {
  id: number;
}

export interface VendorSpecializationPayload {
}

export interface VendorSpecialization extends VendorSpecializationPayload {
  id: number;
  isDeleted: boolean;
}

