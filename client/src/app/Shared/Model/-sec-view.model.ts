// Generated from WebApi/Controllers/SecViewController.cs + Domain entity.

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

export interface GetAllSecViewParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface SecView {
  id: number;
  viewId: number;
  viewName?: string | null;
  viewDisplayName?: string | null;
  isVisibleToMenu?: boolean | null;
  url?: string | null;
  secModuleId?: number | null;
  viewDisplayNameAr?: string | null;
  parentId?: number | null;
  sequence?: number | null;
  parent?: any | null;
  secModule?: any | null;
}

export interface CreateSecView {
  id: number;
  viewId: number;
  viewName?: string | null;
  viewDisplayName?: string | null;
  isVisibleToMenu?: boolean | null;
  url?: string | null;
  secModuleId?: number | null;
  viewDisplayNameAr?: string | null;
  parentId?: number | null;
  sequence?: number | null;
  parent?: any | null;
  secModule?: any | null;
}

export interface SecViewPayload {
  viewId: number;
  viewName?: string | null;
  viewDisplayName?: string | null;
  isVisibleToMenu?: boolean | null;
  url?: string | null;
  secModuleId?: number | null;
  viewDisplayNameAr?: string | null;
  parentId?: number | null;
  sequence?: number | null;
  parent?: any | null;
  secModule?: any | null;
}

export interface SecView extends SecViewPayload {
  id: number;
  isDeleted: boolean;
}

