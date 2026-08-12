// Generated from WebApi/Controllers/CompanyController.cs + Domain entity.

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

export interface GetAllCompanyParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Company {
  id: number;
  code?: string | null;
  name?: string | null;
  nameAr?: string | null;
}

export interface CreateCompany {
  id: number;
  code?: string | null;
  name?: string | null;
  nameAr?: string | null;
}

export interface CompanyPayload {
  code?: string | null;
  name?: string | null;
  nameAr?: string | null;
}

export interface Company extends CompanyPayload {
  id: number;
  isDeleted: boolean;
}

