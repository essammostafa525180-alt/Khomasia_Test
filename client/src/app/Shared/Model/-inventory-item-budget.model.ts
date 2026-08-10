// Generated from WebApi/Controllers/InventoryItemBudgetController.cs + Domain entity.

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

export interface GetAllInventoryItemBudgetParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryItemBudget {
  id: number;
  companyFk?: number | null;
  projectFk?: number | null;
  locationFk?: number | null;
  serviceMainCategoryFk?: number | null;
  scopeFk?: number | null;
  companyFkNavigation?: any | null;
  locationFkNavigation?: any | null;
  projectFkNavigation?: any | null;
  scopeFkNavigation?: any | null;
  serviceMainCategoryFkNavigation?: any | null;
}

export interface CreateInventoryItemBudget {
  id: number;
  companyFk?: number | null;
  projectFk?: number | null;
  locationFk?: number | null;
  serviceMainCategoryFk?: number | null;
  scopeFk?: number | null;
  companyFkNavigation?: any | null;
  locationFkNavigation?: any | null;
  projectFkNavigation?: any | null;
  scopeFkNavigation?: any | null;
  serviceMainCategoryFkNavigation?: any | null;
}

export interface InventoryItemBudgetPayload {
  companyFk?: number | null;
  projectFk?: number | null;
  locationFk?: number | null;
  serviceMainCategoryFk?: number | null;
  scopeFk?: number | null;
  companyFkNavigation?: any | null;
  locationFkNavigation?: any | null;
  projectFkNavigation?: any | null;
  scopeFkNavigation?: any | null;
  serviceMainCategoryFkNavigation?: any | null;
}

export interface InventoryItemBudget extends InventoryItemBudgetPayload {
  id: number;
  isDeleted: boolean;
}

