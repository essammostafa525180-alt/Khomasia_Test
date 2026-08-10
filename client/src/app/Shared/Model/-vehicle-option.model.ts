// Generated from WebApi/Controllers/VehicleOptionController.cs + Domain entity.

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

export interface GetAllVehicleOptionParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VehicleOption {
  id: number;
}

export interface CreateVehicleOption {
  id: number;
}

export interface VehicleOptionPayload {
}

export interface VehicleOption extends VehicleOptionPayload {
  id: number;
  isDeleted: boolean;
}

