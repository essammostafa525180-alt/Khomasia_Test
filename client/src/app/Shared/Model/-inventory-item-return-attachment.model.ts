// Generated from WebApi/Controllers/InventoryItemReturnAttachmentController.cs + Domain entity.

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

export interface GetAllInventoryItemReturnAttachmentParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryItemReturnAttachment {
  id: number;
  inventoryItemReturnFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  inventoryItemReturnFkNavigation?: any | null;
}

export interface CreateInventoryItemReturnAttachment {
  id: number;
  inventoryItemReturnFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  inventoryItemReturnFkNavigation?: any | null;
}

export interface InventoryItemReturnAttachmentPayload {
  inventoryItemReturnFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  inventoryItemReturnFkNavigation?: any | null;
}

export interface InventoryItemReturnAttachment extends InventoryItemReturnAttachmentPayload {
  id: number;
  isDeleted: boolean;
}

