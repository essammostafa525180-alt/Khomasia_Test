// Generated from WebApi/Controllers/SparePartGroupController.cs + Domain entity.

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

export interface GetAllSparePartGroupParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface SparePartGroup {
  id: number;
}

export interface CreateSparePartGroup {
  id: number;
}

export interface SparePartGroupPayload {
}

export interface SparePartGroup extends SparePartGroupPayload {
  id: number;
  isDeleted: boolean;
}

