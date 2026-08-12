// Generated from WebApi/Controllers/InventoryTransfereController.cs + Domain entity.

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

export interface GetAllInventoryTransfereParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryTransfere {
  id: number;
}

export interface CreateInventoryTransfere {
  id: number;
}

export interface InventoryTransferePayload {
}

export interface InventoryTransfere extends InventoryTransferePayload {
  id: number;
  isDeleted: boolean;
}

