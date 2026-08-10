// Generated from WebApi/Controllers/WarrantyStatusController.cs + Domain entity.

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

export interface GetAllWarrantyStatusParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface WarrantyStatus {
  id: number;
}

export interface CreateWarrantyStatus {
  id: number;
}

export interface WarrantyStatusPayload {
}

export interface WarrantyStatus extends WarrantyStatusPayload {
  id: number;
  isDeleted: boolean;
}

