// Generated from WebApi/Controllers/ItemBalanceStatusController.cs + Domain entity.

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

export interface GetAllItemBalanceStatusParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface ItemBalanceStatus {
  id: number;
}

export interface CreateItemBalanceStatus {
  id: number;
}

export interface ItemBalanceStatusPayload {
}

export interface ItemBalanceStatus extends ItemBalanceStatusPayload {
  id: number;
  isDeleted: boolean;
}

