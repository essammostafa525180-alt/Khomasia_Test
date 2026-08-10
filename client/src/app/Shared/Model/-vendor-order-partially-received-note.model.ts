// Generated from WebApi/Controllers/VendorOrderPartiallyReceivedNoteController.cs + Domain entity.

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

export interface GetAllVendorOrderPartiallyReceivedNoteParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorOrderPartiallyReceivedNote {
  id: number;
  vendorOrderDetailFk?: number | null;
  partiallyReceivedReasonFk?: number | null;
  currentReceivedQuantity?: number | null;
  notes?: string | null;
  vendorOrderDetailFkNavigation?: any | null;
}

export interface CreateVendorOrderPartiallyReceivedNote {
  id: number;
  vendorOrderDetailFk?: number | null;
  partiallyReceivedReasonFk?: number | null;
  currentReceivedQuantity?: number | null;
  notes?: string | null;
  vendorOrderDetailFkNavigation?: any | null;
}

export interface VendorOrderPartiallyReceivedNotePayload {
  vendorOrderDetailFk?: number | null;
  partiallyReceivedReasonFk?: number | null;
  currentReceivedQuantity?: number | null;
  notes?: string | null;
  vendorOrderDetailFkNavigation?: any | null;
}

export interface VendorOrderPartiallyReceivedNote extends VendorOrderPartiallyReceivedNotePayload {
  id: number;
  isDeleted: boolean;
}

