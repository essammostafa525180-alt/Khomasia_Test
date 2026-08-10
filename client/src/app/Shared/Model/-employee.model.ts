// Generated from WebApi/Controllers/EmployeeController.cs + Domain entity.

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

export interface GetAllEmployeeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Employee {
  id: number;
  code?: string | null;
  name?: string | null;
  nameAr?: string | null;
  employeeJobFk?: number | null;
  employeeJobFkNavigation?: any | null;
}

export interface CreateEmployee {
  id: number;
  code?: string | null;
  name?: string | null;
  nameAr?: string | null;
  employeeJobFk?: number | null;
  employeeJobFkNavigation?: any | null;
}

export interface EmployeePayload {
  code?: string | null;
  name?: string | null;
  nameAr?: string | null;
  employeeJobFk?: number | null;
  employeeJobFkNavigation?: any | null;
}

export interface Employee extends EmployeePayload {
  id: number;
  isDeleted: boolean;
}

