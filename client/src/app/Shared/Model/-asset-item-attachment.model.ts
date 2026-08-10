// Generated from WebApi/Controllers/AssetItemAttachmentController.cs + Domain entity.

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

export interface GetAllAssetItemAttachmentParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssetItemAttachment {
  id: number;
  assetItemFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  assetItemFkNavigation?: any | null;
}

export interface CreateAssetItemAttachment {
  id: number;
  assetItemFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  assetItemFkNavigation?: any | null;
}

export interface AssetItemAttachmentPayload {
  assetItemFk?: number | null;
  attachmentId?: number | null;
  attachmentName?: string | null;
  description?: string | null;
  assetItemFkNavigation?: any | null;
}

export interface AssetItemAttachment extends AssetItemAttachmentPayload {
  id: number;
  isDeleted: boolean;
}

