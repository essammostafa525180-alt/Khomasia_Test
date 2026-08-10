// Generated from WebApi/Controllers/VehicleModelController.cs + Domain entity.

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

export interface GetAllVehicleModelParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VehicleModel {
  id: number;
}

export interface CreateVehicleModel {
  id: number;
}

export interface VehicleModelPayload {
}

export interface VehicleModel extends VehicleModelPayload {
  id: number;
  isDeleted: boolean;
}

