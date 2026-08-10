// Generated from WebApi/Controllers/InventroyItemRequestWithdrawAttachmentController.cs + Domain entity.

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

export interface GetAllInventroyItemRequestWithdrawAttachmentParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventroyItemRequestWithdrawAttachment {
  id: number;
  inventroyItemRequestWithdrawFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  inventroyItemRequestWithdrawFkNavigation?: any | null;
}

export interface CreateInventroyItemRequestWithdrawAttachment {
  id: number;
  inventroyItemRequestWithdrawFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  inventroyItemRequestWithdrawFkNavigation?: any | null;
}

export interface InventroyItemRequestWithdrawAttachmentPayload {
  inventroyItemRequestWithdrawFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  inventroyItemRequestWithdrawFkNavigation?: any | null;
}

export interface InventroyItemRequestWithdrawAttachment extends InventroyItemRequestWithdrawAttachmentPayload {
  id: number;
  isDeleted: boolean;
}

