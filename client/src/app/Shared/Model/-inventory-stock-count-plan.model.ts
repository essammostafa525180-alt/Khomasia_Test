// Generated from WebApi/Controllers/InventoryStockCountPlanController.cs + Domain entity.

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

export interface GetAllInventoryStockCountPlanParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryStockCountPlan {
  id: number;
  countPlanNo?: string | null;
  name?: string | null;
  nameAr?: string | null;
  planDate?: Date | null;
  executionDate?: Date | null;
  stockCountPlanStatusFk?: number | null;
  stockCountPlanTypeFk?: number | null;
  assignedToUserFk?: number | null;
  stockCountPlanStatusFkNavigation?: any | null;
  stockCountPlanTypeFkNavigation?: any | null;
}

export interface CreateInventoryStockCountPlan {
  id: number;
  countPlanNo?: string | null;
  name?: string | null;
  nameAr?: string | null;
  planDate?: Date | null;
  executionDate?: Date | null;
  stockCountPlanStatusFk?: number | null;
  stockCountPlanTypeFk?: number | null;
  assignedToUserFk?: number | null;
  stockCountPlanStatusFkNavigation?: any | null;
  stockCountPlanTypeFkNavigation?: any | null;
}

export interface InventoryStockCountPlanPayload {
  countPlanNo?: string | null;
  name?: string | null;
  nameAr?: string | null;
  planDate?: Date | null;
  executionDate?: Date | null;
  stockCountPlanStatusFk?: number | null;
  stockCountPlanTypeFk?: number | null;
  assignedToUserFk?: number | null;
  stockCountPlanStatusFkNavigation?: any | null;
  stockCountPlanTypeFkNavigation?: any | null;
}

export interface InventoryStockCountPlan extends InventoryStockCountPlanPayload {
  id: number;
  isDeleted: boolean;
}

