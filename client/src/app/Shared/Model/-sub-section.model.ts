// Generated from WebApi/Controllers/SubSectionController.cs + Domain entity.

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

export interface GetAllSubSectionParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface SubSection {
  id: number;
}

export interface CreateSubSection {
  id: number;
}

export interface SubSectionPayload {
}

export interface SubSection extends SubSectionPayload {
  id: number;
  isDeleted: boolean;
}

