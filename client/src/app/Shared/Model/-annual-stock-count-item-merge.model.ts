// Generated from WebApi/Controllers/AnnualStockCountItemMergeController.cs + Domain entity.

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

export interface GetAllAnnualStockCountItemMergeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AnnualStockCountItemMerge {
  id: number;
  annualStockCountFk?: number | null;
  inventoryItemFk?: number | null;
  currentQuantity?: number | null;
  activeInventoryItemFk?: number | null;
  activeInventoryItemFkNavigation?: any | null;
  annualStockCountFkNavigation?: any | null;
  inventoryItemFkNavigation?: any | null;
}

export interface CreateAnnualStockCountItemMerge {
  id: number;
  annualStockCountFk?: number | null;
  inventoryItemFk?: number | null;
  currentQuantity?: number | null;
  activeInventoryItemFk?: number | null;
  activeInventoryItemFkNavigation?: any | null;
  annualStockCountFkNavigation?: any | null;
  inventoryItemFkNavigation?: any | null;
}

export interface AnnualStockCountItemMergePayload {
  annualStockCountFk?: number | null;
  inventoryItemFk?: number | null;
  currentQuantity?: number | null;
  activeInventoryItemFk?: number | null;
  activeInventoryItemFkNavigation?: any | null;
  annualStockCountFkNavigation?: any | null;
  inventoryItemFkNavigation?: any | null;
}

export interface AnnualStockCountItemMerge extends AnnualStockCountItemMergePayload {
  id: number;
  isDeleted: boolean;
}

