// Generated from WebApi/Controllers/VehicleColorController.cs + Domain entity.

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

export interface GetAllVehicleColorParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VehicleColor {
  id: number;
}

export interface CreateVehicleColor {
  id: number;
}

export interface VehicleColorPayload {
}

export interface VehicleColor extends VehicleColorPayload {
  id: number;
  isDeleted: boolean;
}

