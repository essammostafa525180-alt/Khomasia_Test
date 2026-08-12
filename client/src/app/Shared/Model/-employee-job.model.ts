// Generated from WebApi/Controllers/EmployeeJobController.cs + Domain entity.

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

export interface GetAllEmployeeJobParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface EmployeeJob {
  id: number;
}

export interface CreateEmployeeJob {
  id: number;
}

export interface EmployeeJobPayload {
}

export interface EmployeeJob extends EmployeeJobPayload {
  id: number;
  isDeleted: boolean;
}

