// Generated from WebApi/Controllers/AssetAttachmentController.cs + Domain entity.

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

export interface GetAllAssetAttachmentParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssetAttachment {
  id: number;
  assetFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  assetFkNavigation?: any | null;
}

export interface CreateAssetAttachment {
  id: number;
  assetFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  assetFkNavigation?: any | null;
}

export interface AssetAttachmentPayload {
  assetFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  assetFkNavigation?: any | null;
}

export interface AssetAttachment extends AssetAttachmentPayload {
  id: number;
  isDeleted: boolean;
}

