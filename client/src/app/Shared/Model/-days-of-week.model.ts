// Generated from WebApi/Controllers/DaysOfWeekController.cs + Domain entity.

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

export interface GetAllDaysOfWeekParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface DaysOfWeek {
  id: number;
}

export interface CreateDaysOfWeek {
  id: number;
}

export interface DaysOfWeekPayload {
}

export interface DaysOfWeek extends DaysOfWeekPayload {
  id: number;
  isDeleted: boolean;
}

