// Generated from WebApi/Controllers/VendorOrderAttachmentController.cs + Domain entity.

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

export interface GetAllVendorOrderAttachmentParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorOrderAttachment {
  id: number;
  vendorOrderFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  vendorOrderFkNavigation?: any | null;
}

export interface CreateVendorOrderAttachment {
  id: number;
  vendorOrderFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  vendorOrderFkNavigation?: any | null;
}

export interface VendorOrderAttachmentPayload {
  vendorOrderFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  vendorOrderFkNavigation?: any | null;
}

export interface VendorOrderAttachment extends VendorOrderAttachmentPayload {
  id: number;
  isDeleted: boolean;
}

