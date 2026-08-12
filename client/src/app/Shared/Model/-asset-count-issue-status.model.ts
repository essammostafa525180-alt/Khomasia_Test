// Generated from WebApi/Controllers/AssetCountIssueStatusController.cs + Domain entity.

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

export interface GetAllAssetCountIssueStatusParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssetCountIssueStatus {
  id: number;
}

export interface CreateAssetCountIssueStatus {
  id: number;
}

export interface AssetCountIssueStatusPayload {
}

export interface AssetCountIssueStatus extends AssetCountIssueStatusPayload {
  id: number;
  isDeleted: boolean;
}

