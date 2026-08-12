// Generated from WebApi/Controllers/OilController.cs + Domain entity.

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

export interface GetAllOilParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Oil {
  id: number;
  storeId?: number | null;
  storeName?: string | null;
  stockCountDate?: Date | null;
  inventoryItemId?: number | null;
  inventoryItemCode?: string | null;
  inventoryItemName?: string | null;
  avgCost?: number | null;
  totalQuantity?: number | null;
  stockCountQuantity?: number | null;
  mmbalance?: number | null;
  isMatch?: string | null;
  isUpdated?: number | null;
}

export interface CreateOil {
  id: number;
  storeId?: number | null;
  storeName?: string | null;
  stockCountDate?: Date | null;
  inventoryItemId?: number | null;
  inventoryItemCode?: string | null;
  inventoryItemName?: string | null;
  avgCost?: number | null;
  totalQuantity?: number | null;
  stockCountQuantity?: number | null;
  mmbalance?: number | null;
  isMatch?: string | null;
  isUpdated?: number | null;
}

export interface OilPayload {
  storeId?: number | null;
  storeName?: string | null;
  stockCountDate?: Date | null;
  inventoryItemId?: number | null;
  inventoryItemCode?: string | null;
  inventoryItemName?: string | null;
  avgCost?: number | null;
  totalQuantity?: number | null;
  stockCountQuantity?: number | null;
  mmbalance?: number | null;
  isMatch?: string | null;
  isUpdated?: number | null;
}

export interface Oil extends OilPayload {
  id: number;
  isDeleted: boolean;
}

