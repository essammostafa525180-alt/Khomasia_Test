// Generated from WebApi/Controllers/InventroyItemRequestWithdrawDetailController.cs + Domain entity.

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

export interface GetAllInventroyItemRequestWithdrawDetailParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventroyItemRequestWithdrawDetail {
  id: number;
  requestWfk?: number | null;
  inventoryItemFk?: number | null;
  requestedQuantity?: number | null;
  pickedQuantity?: number | null;
  deliveredQuantity?: number | null;
  returnedQuantity?: number | null;
  scrapedQuantity?: number | null;
  requestLineItemStatusFk?: number | null;
  fromSerial?: number | null;
  toSerial?: number | null;
  integrationId?: number | null;
  isSync?: boolean | null;
  lastPurchasePrice?: number | null;
  avgCost?: number | null;
  inventoryItemFkNavigation?: any | null;
  requestLineItemStatusFkNavigation?: any | null;
  requestWfkNavigation?: any | null;
}

export interface CreateInventroyItemRequestWithdrawDetail {
  id: number;
  requestWfk?: number | null;
  inventoryItemFk?: number | null;
  requestedQuantity?: number | null;
  pickedQuantity?: number | null;
  deliveredQuantity?: number | null;
  returnedQuantity?: number | null;
  scrapedQuantity?: number | null;
  requestLineItemStatusFk?: number | null;
  fromSerial?: number | null;
  toSerial?: number | null;
  integrationId?: number | null;
  isSync?: boolean | null;
  lastPurchasePrice?: number | null;
  avgCost?: number | null;
  inventoryItemFkNavigation?: any | null;
  requestLineItemStatusFkNavigation?: any | null;
  requestWfkNavigation?: any | null;
}

export interface InventroyItemRequestWithdrawDetailPayload {
  requestWfk?: number | null;
  inventoryItemFk?: number | null;
  requestedQuantity?: number | null;
  pickedQuantity?: number | null;
  deliveredQuantity?: number | null;
  returnedQuantity?: number | null;
  scrapedQuantity?: number | null;
  requestLineItemStatusFk?: number | null;
  fromSerial?: number | null;
  toSerial?: number | null;
  integrationId?: number | null;
  isSync?: boolean | null;
  lastPurchasePrice?: number | null;
  avgCost?: number | null;
  inventoryItemFkNavigation?: any | null;
  requestLineItemStatusFkNavigation?: any | null;
  requestWfkNavigation?: any | null;
}

export interface InventroyItemRequestWithdrawDetail extends InventroyItemRequestWithdrawDetailPayload {
  id: number;
  isDeleted: boolean;
}

