// Generated from WebApi/Controllers/InventoryItemAssetController.cs + Domain entity.

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

export interface GetAllInventoryItemAssetParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryItemAsset {
  id: number;
  inventoryItemFk?: number | null;
  assetFk?: number | null;
  assetFkNavigation?: any | null;
  inventoryItemFkNavigation?: any | null;
}

export interface CreateInventoryItemAsset {
  id: number;
  inventoryItemFk?: number | null;
  assetFk?: number | null;
  assetFkNavigation?: any | null;
  inventoryItemFkNavigation?: any | null;
}

export interface InventoryItemAssetPayload {
  inventoryItemFk?: number | null;
  assetFk?: number | null;
  assetFkNavigation?: any | null;
  inventoryItemFkNavigation?: any | null;
}

export interface InventoryItemAsset extends InventoryItemAssetPayload {
  id: number;
  isDeleted: boolean;
}

