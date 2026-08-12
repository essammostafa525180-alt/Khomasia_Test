// Generated from WebApi/Controllers/AllowedCompanyController.cs + Domain entity.

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

export interface GetAllAllowedCompanyParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AllowedCompany {
  id: number;
}

export interface CreateAllowedCompany {
  id: number;
}

export interface AllowedCompanyPayload {
}

export interface AllowedCompany extends AllowedCompanyPayload {
  id: number;
  isDeleted: boolean;
}

