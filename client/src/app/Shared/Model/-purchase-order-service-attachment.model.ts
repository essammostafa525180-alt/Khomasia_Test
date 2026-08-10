// Generated from WebApi/Controllers/PurchaseOrderServiceAttachmentController.cs + Domain entity.

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

export interface GetAllPurchaseOrderServiceAttachmentParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface PurchaseOrderServiceAttachment {
  id: number;
  purchaseOrderServiceFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  purchaseOrderServiceFkNavigation?: any | null;
}

export interface CreatePurchaseOrderServiceAttachment {
  id: number;
  purchaseOrderServiceFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  purchaseOrderServiceFkNavigation?: any | null;
}

export interface PurchaseOrderServiceAttachmentPayload {
  purchaseOrderServiceFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  purchaseOrderServiceFkNavigation?: any | null;
}

export interface PurchaseOrderServiceAttachment extends PurchaseOrderServiceAttachmentPayload {
  id: number;
  isDeleted: boolean;
}

