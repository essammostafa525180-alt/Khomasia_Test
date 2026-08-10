// Generated from WebApi/Controllers/VendorOrderVendorSelectionController.cs + Domain entity.

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

export interface GetAllVendorOrderVendorSelectionParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorOrderVendorSelection {
  id: number;
  vendorOrderFk?: number | null;
  vendorFk?: number | null;
  isSelected: boolean;
  vendorFkNavigation?: any | null;
  vendorOrderFkNavigation?: any | null;
}

export interface CreateVendorOrderVendorSelection {
  id: number;
  vendorOrderFk?: number | null;
  vendorFk?: number | null;
  isSelected: boolean;
  vendorFkNavigation?: any | null;
  vendorOrderFkNavigation?: any | null;
}

export interface VendorOrderVendorSelectionPayload {
  vendorOrderFk?: number | null;
  vendorFk?: number | null;
  isSelected: boolean;
  vendorFkNavigation?: any | null;
  vendorOrderFkNavigation?: any | null;
}

export interface VendorOrderVendorSelection extends VendorOrderVendorSelectionPayload {
  id: number;
  isDeleted: boolean;
}

