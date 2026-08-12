// Generated from WebApi/Controllers/VehicleStatusController.cs + Domain entity.

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

export interface GetAllVehicleStatusParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VehicleStatus {
  id: number;
}

export interface CreateVehicleStatus {
  id: number;
}

export interface VehicleStatusPayload {
}

export interface VehicleStatus extends VehicleStatusPayload {
  id: number;
  isDeleted: boolean;
}

