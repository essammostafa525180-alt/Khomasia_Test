// Generated from WebApi/Controllers/InventoryYearController.cs + Domain entity.

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

export interface GetAllInventoryYearParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryYear {
  id: number;
}

export interface CreateInventoryYear {
  id: number;
}

export interface InventoryYearPayload {
}

export interface InventoryYear extends InventoryYearPayload {
  id: number;
  isDeleted: boolean;
}

