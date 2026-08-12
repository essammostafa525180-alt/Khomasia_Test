// Generated from WebApi/Controllers/AssignSiteSectionController.cs + Domain entity.

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

export interface GetAllAssignSiteSectionParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssignSiteSection {
  id: number;
}

export interface CreateAssignSiteSection {
  id: number;
}

export interface AssignSiteSectionPayload {
}

export interface AssignSiteSection extends AssignSiteSectionPayload {
  id: number;
  isDeleted: boolean;
}

