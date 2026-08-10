// Generated from WebApi/Controllers/SalesQuotationDetailController.cs + Domain entity.

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

export interface GetAllSalesQuotationDetailParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface SalesQuotationDetail {
  id: number;
  salesQuotationFk?: number | null;
  requestForQuotationDetailFk?: number | null;
  inventoryItemFk?: number | null;
  vendorCostPrice?: number | null;
  costPriceRatio?: number | null;
  costPrice?: number | null;
  orderedQuantity?: number | null;
  totalPrice?: number | null;
  inventoryItemFkNavigation?: any | null;
  requestForQuotationDetailFkNavigation?: any | null;
  salesQuotationFkNavigation?: any | null;
}

export interface CreateSalesQuotationDetail {
  id: number;
  salesQuotationFk?: number | null;
  requestForQuotationDetailFk?: number | null;
  inventoryItemFk?: number | null;
  vendorCostPrice?: number | null;
  costPriceRatio?: number | null;
  costPrice?: number | null;
  orderedQuantity?: number | null;
  totalPrice?: number | null;
  inventoryItemFkNavigation?: any | null;
  requestForQuotationDetailFkNavigation?: any | null;
  salesQuotationFkNavigation?: any | null;
}

export interface SalesQuotationDetailPayload {
  salesQuotationFk?: number | null;
  requestForQuotationDetailFk?: number | null;
  inventoryItemFk?: number | null;
  vendorCostPrice?: number | null;
  costPriceRatio?: number | null;
  costPrice?: number | null;
  orderedQuantity?: number | null;
  totalPrice?: number | null;
  inventoryItemFkNavigation?: any | null;
  requestForQuotationDetailFkNavigation?: any | null;
  salesQuotationFkNavigation?: any | null;
}

export interface SalesQuotationDetail extends SalesQuotationDetailPayload {
  id: number;
  isDeleted: boolean;
}

