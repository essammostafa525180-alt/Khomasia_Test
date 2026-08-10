// Generated from WebApi/Controllers/VehicleBrandController.cs + Domain entity.

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

export interface GetAllVehicleBrandParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VehicleBrand {
  id: number;
}

export interface CreateVehicleBrand {
  id: number;
}

export interface VehicleBrandPayload {
}

export interface VehicleBrand extends VehicleBrandPayload {
  id: number;
  isDeleted: boolean;
}

