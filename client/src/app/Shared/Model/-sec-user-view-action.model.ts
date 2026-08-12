// Generated from WebApi/Controllers/SecUserViewActionController.cs + Domain entity.

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

export interface GetAllSecUserViewActionParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface SecUserViewAction {
  id: number;
  userId: number;
  viewActionId: number;
  isAllow?: boolean | null;
  user?: any | null;
  viewAction?: any | null;
}

export interface CreateSecUserViewAction {
  id: number;
  userId: number;
  viewActionId: number;
  isAllow?: boolean | null;
  user?: any | null;
  viewAction?: any | null;
}

export interface SecUserViewActionPayload {
  userId: number;
  viewActionId: number;
  isAllow?: boolean | null;
  user?: any | null;
  viewAction?: any | null;
}

export interface SecUserViewAction extends SecUserViewActionPayload {
  id: number;
  isDeleted: boolean;
}

