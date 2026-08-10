// Generated from WebApi/Controllers/AssetDisposedController.cs + Domain entity.

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

export interface GetAllAssetDisposedParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssetDisposed {
  id: number;
  organizationName?: string | null;
  cost?: number | null;
  notes?: string | null;
  idNavigation?: any | null;
}

export interface CreateAssetDisposed {
  id: number;
  organizationName?: string | null;
  cost?: number | null;
  notes?: string | null;
  idNavigation?: any | null;
}

export interface AssetDisposedPayload {
  organizationName?: string | null;
  cost?: number | null;
  notes?: string | null;
  idNavigation?: any | null;
}

export interface AssetDisposed extends AssetDisposedPayload {
  id: number;
  isDeleted: boolean;
}

