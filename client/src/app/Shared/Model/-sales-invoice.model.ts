// Generated from WebApi/Controllers/SalesInvoiceController.cs + Domain entity.

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

export interface GetAllSalesInvoiceParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface SalesInvoice {
  id: number;
  customerId?: number | null;
  userId?: number | null;
  address?: string | null;
  contactPerson?: string | null;
  vatpercentage?: number | null;
  vatamount?: number | null;
  totalAmount?: number | null;
  updatedOn?: Date | null;
  updatedBy?: number | null;
  customer?: any | null;
  user?: any | null;
}

export interface CreateSalesInvoice {
  id: number;
  customerId?: number | null;
  userId?: number | null;
  address?: string | null;
  contactPerson?: string | null;
  vatpercentage?: number | null;
  vatamount?: number | null;
  totalAmount?: number | null;
  updatedOn?: Date | null;
  updatedBy?: number | null;
  customer?: any | null;
  user?: any | null;
}

export interface SalesInvoicePayload {
  customerId?: number | null;
  userId?: number | null;
  address?: string | null;
  contactPerson?: string | null;
  vatpercentage?: number | null;
  vatamount?: number | null;
  totalAmount?: number | null;
  updatedOn?: Date | null;
  updatedBy?: number | null;
  customer?: any | null;
  user?: any | null;
}

export interface SalesInvoice extends SalesInvoicePayload {
  id: number;
  isDeleted: boolean;
}

