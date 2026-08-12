// Generated from WebApi/Controllers/InventoryTransfereAttachmentController.cs + Domain entity.

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

export interface GetAllInventoryTransfereAttachmentParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryTransfereAttachment {
  id: number;
  inventoryTransfereFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  inventoryTransfereFkNavigation?: any | null;
}

export interface CreateInventoryTransfereAttachment {
  id: number;
  inventoryTransfereFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  inventoryTransfereFkNavigation?: any | null;
}

export interface InventoryTransfereAttachmentPayload {
  inventoryTransfereFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  inventoryTransfereFkNavigation?: any | null;
}

export interface InventoryTransfereAttachment extends InventoryTransfereAttachmentPayload {
  id: number;
  isDeleted: boolean;
}

