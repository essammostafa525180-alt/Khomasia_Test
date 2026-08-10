// Generated from WebApi/Controllers/InventoryItemLocationController.cs + Domain entity.

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

export interface GetAllInventoryItemLocationParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryItemLocation {
  id: number;
}

export interface CreateInventoryItemLocation {
  id: number;
}

export interface InventoryItemLocationPayload {
}

export interface InventoryItemLocation extends InventoryItemLocationPayload {
  id: number;
  isDeleted: boolean;
}

