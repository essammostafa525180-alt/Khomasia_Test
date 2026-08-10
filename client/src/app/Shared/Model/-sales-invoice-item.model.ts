// Generated from WebApi/Controllers/SalesInvoiceItemController.cs + Domain entity.

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

export interface GetAllSalesInvoiceItemParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface SalesInvoiceItem {
  id: number;
  salesInvoiceId?: number | null;
  productId?: number | null;
  quantity?: number | null;
  price?: number | null;
  discount?: number | null;
  netAmount?: number | null;
  updatedOn?: Date | null;
  updatedBy?: number | null;
  salesInvoice?: any | null;
}

export interface CreateSalesInvoiceItem {
  id: number;
  salesInvoiceId?: number | null;
  productId?: number | null;
  quantity?: number | null;
  price?: number | null;
  discount?: number | null;
  netAmount?: number | null;
  updatedOn?: Date | null;
  updatedBy?: number | null;
  salesInvoice?: any | null;
}

export interface SalesInvoiceItemPayload {
  salesInvoiceId?: number | null;
  productId?: number | null;
  quantity?: number | null;
  price?: number | null;
  discount?: number | null;
  netAmount?: number | null;
  updatedOn?: Date | null;
  updatedBy?: number | null;
  salesInvoice?: any | null;
}

export interface SalesInvoiceItem extends SalesInvoiceItemPayload {
  id: number;
  isDeleted: boolean;
}

