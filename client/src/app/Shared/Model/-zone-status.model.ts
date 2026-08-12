// Generated from WebApi/Controllers/ZoneStatusController.cs + Domain entity.

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

export interface GetAllZoneStatusParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface ZoneStatus {
  id: number;
}

export interface CreateZoneStatus {
  id: number;
}

export interface ZoneStatusPayload {
}

export interface ZoneStatus extends ZoneStatusPayload {
  id: number;
  isDeleted: boolean;
}

