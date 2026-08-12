// Generated from WebApi/Controllers/InventoryItemVendorController.cs + Domain entity.

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

export interface GetAllInventoryItemVendorParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventoryItemVendor {
  id: number;
  inventoryItemFk?: number | null;
  vendorFk?: number | null;
  vendorOrder?: number | null;
  inventoryItemFkNavigation?: any | null;
  vendorFkNavigation?: any | null;
}

export interface CreateInventoryItemVendor {
  id: number;
  inventoryItemFk?: number | null;
  vendorFk?: number | null;
  vendorOrder?: number | null;
  inventoryItemFkNavigation?: any | null;
  vendorFkNavigation?: any | null;
}

export interface InventoryItemVendorPayload {
  inventoryItemFk?: number | null;
  vendorFk?: number | null;
  vendorOrder?: number | null;
  inventoryItemFkNavigation?: any | null;
  vendorFkNavigation?: any | null;
}

export interface InventoryItemVendor extends InventoryItemVendorPayload {
  id: number;
  isDeleted: boolean;
}

