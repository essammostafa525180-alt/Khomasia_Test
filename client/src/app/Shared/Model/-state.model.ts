// Generated from WebApi/Controllers/StateController.cs + Domain entity.

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

export interface GetAllStateParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface State {
  id: number;
}

export interface CreateState {
  id: number;
}

export interface StatePayload {
}

export interface State extends StatePayload {
  id: number;
  isDeleted: boolean;
}

