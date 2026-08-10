// Generated from WebApi/Controllers/AnnualStockCountItemQuantityController.cs + Domain entity.

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

export interface GetAllAnnualStockCountItemQuantityParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AnnualStockCountItemQuantity {
  id: number;
  annualStockCountFk?: number | null;
  inventoryItemFk?: number | null;
  newName?: string | null;
  currentQuantity?: number | null;
  stockQuantity?: number | null;
  refId?: string | null;
}

export interface CreateAnnualStockCountItemQuantity {
  id: number;
  annualStockCountFk?: number | null;
  inventoryItemFk?: number | null;
  newName?: string | null;
  currentQuantity?: number | null;
  stockQuantity?: number | null;
  refId?: string | null;
}

export interface AnnualStockCountItemQuantityPayload {
  annualStockCountFk?: number | null;
  inventoryItemFk?: number | null;
  newName?: string | null;
  currentQuantity?: number | null;
  stockQuantity?: number | null;
  refId?: string | null;
}

export interface AnnualStockCountItemQuantity extends AnnualStockCountItemQuantityPayload {
  id: number;
  isDeleted: boolean;
}

