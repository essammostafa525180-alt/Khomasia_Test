// Generated from WebApi/Controllers/OrderLineItemStatusController.cs + Domain entity.

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

export interface GetAllOrderLineItemStatusParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface OrderLineItemStatus {
  id: number;
}

export interface CreateOrderLineItemStatus {
  id: number;
}

export interface OrderLineItemStatusPayload {
}

export interface OrderLineItemStatus extends OrderLineItemStatusPayload {
  id: number;
  isDeleted: boolean;
}

