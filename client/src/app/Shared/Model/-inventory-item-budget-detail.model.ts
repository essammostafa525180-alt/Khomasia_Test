// Generated from WebApi/Controllers/InventoryItemBudgetDetailController.cs + Domain entity.

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

export interface GetAllInventoryItemBudgetDetailParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryItemBudgetDetail {
  id: number;
  inventoryItemBudgetFk?: number | null;
  itemTypeFk?: number | null;
  inventoryItemFk?: number | null;
  budgetQuantity?: number | null;
  budgetCost?: number | null;
  inventoryItemBudgetFkNavigation?: any | null;
  inventoryItemFkNavigation?: any | null;
  itemTypeFkNavigation?: any | null;
}

export interface CreateInventoryItemBudgetDetail {
  id: number;
  inventoryItemBudgetFk?: number | null;
  itemTypeFk?: number | null;
  inventoryItemFk?: number | null;
  budgetQuantity?: number | null;
  budgetCost?: number | null;
  inventoryItemBudgetFkNavigation?: any | null;
  inventoryItemFkNavigation?: any | null;
  itemTypeFkNavigation?: any | null;
}

export interface InventoryItemBudgetDetailPayload {
  inventoryItemBudgetFk?: number | null;
  itemTypeFk?: number | null;
  inventoryItemFk?: number | null;
  budgetQuantity?: number | null;
  budgetCost?: number | null;
  inventoryItemBudgetFkNavigation?: any | null;
  inventoryItemFkNavigation?: any | null;
  itemTypeFkNavigation?: any | null;
}

export interface InventoryItemBudgetDetail extends InventoryItemBudgetDetailPayload {
  id: number;
  isDeleted: boolean;
}

