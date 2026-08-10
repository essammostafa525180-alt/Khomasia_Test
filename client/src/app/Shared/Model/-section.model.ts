// Generated from WebApi/Controllers/SectionController.cs + Domain entity.

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

export interface GetAllSectionParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Section {
  id: number;
}

export interface CreateSection {
  id: number;
}

export interface SectionPayload {
}

export interface Section extends SectionPayload {
  id: number;
  isDeleted: boolean;
}

