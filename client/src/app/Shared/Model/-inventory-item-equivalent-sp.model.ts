// Generated from WebApi/Controllers/InventoryItemEquivalentSpController.cs + Domain entity.

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

export interface GetAllInventoryItemEquivalentSpParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryItemEquivalentSp {
  id: number;
  inventoryItemFk?: number | null;
  equivalentItemFk?: number | null;
  equivalentItemFkNavigation?: any | null;
  inventoryItemFkNavigation?: any | null;
}

export interface CreateInventoryItemEquivalentSp {
  id: number;
  inventoryItemFk?: number | null;
  equivalentItemFk?: number | null;
  equivalentItemFkNavigation?: any | null;
  inventoryItemFkNavigation?: any | null;
}

export interface InventoryItemEquivalentSpPayload {
  inventoryItemFk?: number | null;
  equivalentItemFk?: number | null;
  equivalentItemFkNavigation?: any | null;
  inventoryItemFkNavigation?: any | null;
}

export interface InventoryItemEquivalentSp extends InventoryItemEquivalentSpPayload {
  id: number;
  isDeleted: boolean;
}

