// Generated from WebApi/Controllers/ZoneController.cs + Domain entity.

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

export interface GetAllZoneParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Zone {
  id: number;
}

export interface CreateZone {
  id: number;
}

export interface ZonePayload {
}

export interface Zone extends ZonePayload {
  id: number;
  isDeleted: boolean;
}

