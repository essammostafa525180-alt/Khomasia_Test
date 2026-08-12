// Generated from WebApi/Controllers/SecViewActionController.cs + Domain entity.

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

export interface GetAllSecViewActionParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface SecViewAction {
  id: number;
}

export interface CreateSecViewAction {
  id: number;
}

export interface SecViewActionPayload {
}

export interface SecViewAction extends SecViewActionPayload {
  id: number;
  isDeleted: boolean;
}

