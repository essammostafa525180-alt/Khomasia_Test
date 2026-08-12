// Generated from WebApi/Controllers/CustomerController.cs + Domain entity.

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

export interface GetAllCustomerParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Customer {
  id: number;
  code?: string | null;
  name?: string | null;
  nameAr?: string | null;
  phone?: string | null;
  address?: string | null;
  contactPerson?: string | null;
  commercialRecord?: string | null;
  otherVendor?: string | null;
  companyFk?: number | null;
  sectorFk?: number | null;
}

export interface CreateCustomer {
  id: number;
  code?: string | null;
  name?: string | null;
  nameAr?: string | null;
  phone?: string | null;
  address?: string | null;
  contactPerson?: string | null;
  commercialRecord?: string | null;
  otherVendor?: string | null;
  companyFk?: number | null;
  sectorFk?: number | null;
}

export interface CustomerPayload {
  code?: string | null;
  name?: string | null;
  nameAr?: string | null;
  phone?: string | null;
  address?: string | null;
  contactPerson?: string | null;
  commercialRecord?: string | null;
  otherVendor?: string | null;
  companyFk?: number | null;
  sectorFk?: number | null;
}

export interface Customer extends CustomerPayload {
  id: number;
  isDeleted: boolean;
}

