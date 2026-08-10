// Generated from WebApi/Controllers/AnnualStockCountController.cs + Domain entity.

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

export interface GetAllAnnualStockCountParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AnnualStockCount {
  id: number;
  yearId?: number | null;
  storeFk?: number | null;
  isCompleted: boolean;
  storeFkNavigation?: any | null;
}

export interface CreateAnnualStockCount {
  id: number;
  yearId?: number | null;
  storeFk?: number | null;
  isCompleted: boolean;
  storeFkNavigation?: any | null;
}

export interface AnnualStockCountPayload {
  yearId?: number | null;
  storeFk?: number | null;
  isCompleted: boolean;
  storeFkNavigation?: any | null;
}

export interface AnnualStockCount extends AnnualStockCountPayload {
  id: number;
  isDeleted: boolean;
}

