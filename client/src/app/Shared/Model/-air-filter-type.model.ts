// Generated from WebApi/Controllers/AirFilterTypeController.cs + Domain entity.

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

export interface GetAllAirFilterTypeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AirFilterType {
  id: number;
}

export interface CreateAirFilterType {
  id: number;
}

export interface AirFilterTypePayload {
}

export interface AirFilterType extends AirFilterTypePayload {
  id: number;
  isDeleted: boolean;
}

