// Generated from WebApi/Controllers/ClassificationsController.cs + Domain entity.

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

export interface GetAllClassificationsParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Classifications {
  id: number;
}

export interface CreateClassifications {
  id: number;
}

export interface ClassificationsPayload {
}

export interface Classifications extends ClassificationsPayload {
  id: number;
  isDeleted: boolean;
}

