// Generated from WebApi/Controllers/VendorReturnAttachmentController.cs + Domain entity.

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

export interface GetAllVendorReturnAttachmentParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorReturnAttachment {
  id: number;
  vendorReturnFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  vendorReturnFkNavigation?: any | null;
}

export interface CreateVendorReturnAttachment {
  id: number;
  vendorReturnFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  vendorReturnFkNavigation?: any | null;
}

export interface VendorReturnAttachmentPayload {
  vendorReturnFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  vendorReturnFkNavigation?: any | null;
}

export interface VendorReturnAttachment extends VendorReturnAttachmentPayload {
  id: number;
  isDeleted: boolean;
}

