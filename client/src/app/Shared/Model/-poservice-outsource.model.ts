// Generated from WebApi/Controllers/PoserviceOutsourceController.cs + Domain entity.

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

export interface GetAllPoserviceOutsourceParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface PoserviceOutsource {
  id: number;
  poserviceFk?: number | null;
  workerTypeFk?: number | null;
  employeeJobFk?: number | null;
  quantity?: number | null;
  costPerDay?: number | null;
  totalCost?: number | null;
  contractTaskEmployeeId?: number | null;
  employeeJobFkNavigation?: any | null;
  poserviceFkNavigation?: any | null;
  workerTypeFkNavigation?: any | null;
}

export interface CreatePoserviceOutsource {
  id: number;
  poserviceFk?: number | null;
  workerTypeFk?: number | null;
  employeeJobFk?: number | null;
  quantity?: number | null;
  costPerDay?: number | null;
  totalCost?: number | null;
  contractTaskEmployeeId?: number | null;
  employeeJobFkNavigation?: any | null;
  poserviceFkNavigation?: any | null;
  workerTypeFkNavigation?: any | null;
}

export interface PoserviceOutsourcePayload {
  poserviceFk?: number | null;
  workerTypeFk?: number | null;
  employeeJobFk?: number | null;
  quantity?: number | null;
  costPerDay?: number | null;
  totalCost?: number | null;
  contractTaskEmployeeId?: number | null;
  employeeJobFkNavigation?: any | null;
  poserviceFkNavigation?: any | null;
  workerTypeFkNavigation?: any | null;
}

export interface PoserviceOutsource extends PoserviceOutsourcePayload {
  id: number;
  isDeleted: boolean;
}

