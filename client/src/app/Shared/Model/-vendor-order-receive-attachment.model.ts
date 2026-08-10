// Generated from WebApi/Controllers/VendorOrderReceiveAttachmentController.cs + Domain entity.

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

export interface GetAllVendorOrderReceiveAttachmentParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorOrderReceiveAttachment {
  id: number;
  vendorOrderReceiveFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  vendorOrderReceiveFkNavigation?: any | null;
}

export interface CreateVendorOrderReceiveAttachment {
  id: number;
  vendorOrderReceiveFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  vendorOrderReceiveFkNavigation?: any | null;
}

export interface VendorOrderReceiveAttachmentPayload {
  vendorOrderReceiveFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  vendorOrderReceiveFkNavigation?: any | null;
}

export interface VendorOrderReceiveAttachment extends VendorOrderReceiveAttachmentPayload {
  id: number;
  isDeleted: boolean;
}

