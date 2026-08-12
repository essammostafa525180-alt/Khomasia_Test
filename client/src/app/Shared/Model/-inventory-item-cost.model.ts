// Generated from WebApi/Controllers/InventoryItemCostController.cs + Domain entity.

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

export interface GetAllInventoryItemCostParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryItemCost {
  id: number;
  inventoryItemFk?: number | null;
  companyFk?: number | null;
  avgCost?: number | null;
  totalQuantity?: number | null;
  companyFkNavigation?: any | null;
  inventoryItemFkNavigation?: any | null;
}

export interface CreateInventoryItemCost {
  id: number;
  inventoryItemFk?: number | null;
  companyFk?: number | null;
  avgCost?: number | null;
  totalQuantity?: number | null;
  companyFkNavigation?: any | null;
  inventoryItemFkNavigation?: any | null;
}

export interface InventoryItemCostPayload {
  inventoryItemFk?: number | null;
  companyFk?: number | null;
  avgCost?: number | null;
  totalQuantity?: number | null;
  companyFkNavigation?: any | null;
  inventoryItemFkNavigation?: any | null;
}

export interface InventoryItemCost extends InventoryItemCostPayload {
  id: number;
  isDeleted: boolean;
}

