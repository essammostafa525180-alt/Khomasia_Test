// Generated from WebApi/Controllers/VendorOrderQualityAttachmentController.cs + Domain entity.

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

export interface GetAllVendorOrderQualityAttachmentParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorOrderQualityAttachment {
  id: number;
  vendorOrderQualityFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  vendorOrderQualityFkNavigation?: any | null;
}

export interface CreateVendorOrderQualityAttachment {
  id: number;
  vendorOrderQualityFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  vendorOrderQualityFkNavigation?: any | null;
}

export interface VendorOrderQualityAttachmentPayload {
  vendorOrderQualityFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  vendorOrderQualityFkNavigation?: any | null;
}

export interface VendorOrderQualityAttachment extends VendorOrderQualityAttachmentPayload {
  id: number;
  isDeleted: boolean;
}

