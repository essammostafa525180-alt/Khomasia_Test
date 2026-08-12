// Generated from WebApi/Controllers/PaymentTermController.cs + Domain entity.

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

export interface GetAllPaymentTermParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface PaymentTerm {
  id: number;
}

export interface CreatePaymentTerm {
  id: number;
}

export interface PaymentTermPayload {
}

export interface PaymentTerm extends PaymentTermPayload {
  id: number;
  isDeleted: boolean;
}

