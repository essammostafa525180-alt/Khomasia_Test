// Generated from WebApi/Controllers/AssetCountIssueController.cs + Domain entity.

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

export interface GetAllAssetCountIssueParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssetCountIssue {
  id: number;
  issueNumber?: string | null;
  assetCountDetailFk?: number | null;
  assetCountIssueStatusFk?: number | null;
  notes?: string | null;
  assetCountDetailFkNavigation?: any | null;
  assetCountIssueStatusFkNavigation?: any | null;
}

export interface CreateAssetCountIssue {
  id: number;
  issueNumber?: string | null;
  assetCountDetailFk?: number | null;
  assetCountIssueStatusFk?: number | null;
  notes?: string | null;
  assetCountDetailFkNavigation?: any | null;
  assetCountIssueStatusFkNavigation?: any | null;
}

export interface AssetCountIssuePayload {
  issueNumber?: string | null;
  assetCountDetailFk?: number | null;
  assetCountIssueStatusFk?: number | null;
  notes?: string | null;
  assetCountDetailFkNavigation?: any | null;
  assetCountIssueStatusFkNavigation?: any | null;
}

export interface AssetCountIssue extends AssetCountIssuePayload {
  id: number;
  isDeleted: boolean;
}

