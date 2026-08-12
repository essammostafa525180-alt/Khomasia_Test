// Generated from WebApi/Controllers/PoserviceRecomendedResourceController.cs + Domain entity.

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

export interface GetAllPoserviceRecomendedResourceParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface PoserviceRecomendedResource {
  id: number;
  poserviceFk: number;
  contractFk?: number | null;
  employeeJobFk?: number | null;
  vendorFk?: number | null;
  employeeJobFkNavigation?: any | null;
  poserviceFkNavigation?: any | null;
  vendorFkNavigation?: any | null;
}

export interface CreatePoserviceRecomendedResource {
  id: number;
  poserviceFk: number;
  contractFk?: number | null;
  employeeJobFk?: number | null;
  vendorFk?: number | null;
  employeeJobFkNavigation?: any | null;
  poserviceFkNavigation?: any | null;
  vendorFkNavigation?: any | null;
}

export interface PoserviceRecomendedResourcePayload {
  poserviceFk: number;
  contractFk?: number | null;
  employeeJobFk?: number | null;
  vendorFk?: number | null;
  employeeJobFkNavigation?: any | null;
  poserviceFkNavigation?: any | null;
  vendorFkNavigation?: any | null;
}

export interface PoserviceRecomendedResource extends PoserviceRecomendedResourcePayload {
  id: number;
  isDeleted: boolean;
}

