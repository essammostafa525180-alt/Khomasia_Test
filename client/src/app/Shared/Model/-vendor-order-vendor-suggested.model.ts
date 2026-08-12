// Generated from WebApi/Controllers/VendorOrderVendorSuggestedController.cs + Domain entity.

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

export interface GetAllVendorOrderVendorSuggestedParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorOrderVendorSuggested {
  id: number;
  vendorOrderFk?: number | null;
  vendorName?: string | null;
  address?: string | null;
  phone?: string | null;
  email?: string | null;
  website?: string | null;
  vendorOrderFkNavigation?: any | null;
}

export interface CreateVendorOrderVendorSuggested {
  id: number;
  vendorOrderFk?: number | null;
  vendorName?: string | null;
  address?: string | null;
  phone?: string | null;
  email?: string | null;
  website?: string | null;
  vendorOrderFkNavigation?: any | null;
}

export interface VendorOrderVendorSuggestedPayload {
  vendorOrderFk?: number | null;
  vendorName?: string | null;
  address?: string | null;
  phone?: string | null;
  email?: string | null;
  website?: string | null;
  vendorOrderFkNavigation?: any | null;
}

export interface VendorOrderVendorSuggested extends VendorOrderVendorSuggestedPayload {
  id: number;
  isDeleted: boolean;
}

