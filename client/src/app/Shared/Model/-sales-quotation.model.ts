// Generated from WebApi/Controllers/SalesQuotationController.cs + Domain entity.

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

export interface GetAllSalesQuotationParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface SalesQuotation {
  id: number;
  companyFk?: number | null;
  requestForQuotationFk?: number | null;
  orderNo?: string | null;
  orderDate?: Date | null;
  expectedDeliveryDate?: any | null;
  customerFk?: number | null;
  notes?: string | null;
  totalRatio?: number | null;
  totalCost?: number | null;
  customerFkNavigation?: any | null;
  requestForQuotationFkNavigation?: any | null;
}

export interface CreateSalesQuotation {
  id: number;
  companyFk?: number | null;
  requestForQuotationFk?: number | null;
  orderNo?: string | null;
  orderDate?: Date | null;
  expectedDeliveryDate?: any | null;
  customerFk?: number | null;
  notes?: string | null;
  totalRatio?: number | null;
  totalCost?: number | null;
  customerFkNavigation?: any | null;
  requestForQuotationFkNavigation?: any | null;
}

export interface SalesQuotationPayload {
  companyFk?: number | null;
  requestForQuotationFk?: number | null;
  orderNo?: string | null;
  orderDate?: Date | null;
  expectedDeliveryDate?: any | null;
  customerFk?: number | null;
  notes?: string | null;
  totalRatio?: number | null;
  totalCost?: number | null;
  customerFkNavigation?: any | null;
  requestForQuotationFkNavigation?: any | null;
}

export interface SalesQuotation extends SalesQuotationPayload {
  id: number;
  isDeleted: boolean;
}

