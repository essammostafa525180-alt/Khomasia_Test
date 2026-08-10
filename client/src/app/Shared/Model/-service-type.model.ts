// Generated from WebApi/Controllers/ServiceTypeController.cs + Domain entity.

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

export interface GetAllServiceTypeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface ServiceType {
  id: number;
}

export interface CreateServiceType {
  id: number;
}

export interface ServiceTypePayload {
}

export interface ServiceType extends ServiceTypePayload {
  id: number;
  isDeleted: boolean;
}

