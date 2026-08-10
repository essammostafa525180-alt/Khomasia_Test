// Generated from WebApi/Controllers/BatteryTypeController.cs + Domain entity.

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

export interface GetAllBatteryTypeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface BatteryType {
  id: number;
}

export interface CreateBatteryType {
  id: number;
}

export interface BatteryTypePayload {
}

export interface BatteryType extends BatteryTypePayload {
  id: number;
  isDeleted: boolean;
}

