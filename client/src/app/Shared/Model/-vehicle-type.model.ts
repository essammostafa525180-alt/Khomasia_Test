// Generated from WebApi/Controllers/VehicleTypeController.cs + Domain entity.

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

export interface GetAllVehicleTypeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VehicleType {
  id: number;
}

export interface CreateVehicleType {
  id: number;
}

export interface VehicleTypePayload {
}

export interface VehicleType extends VehicleTypePayload {
  id: number;
  isDeleted: boolean;
}

