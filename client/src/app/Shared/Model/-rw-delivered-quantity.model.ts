// Generated from WebApi/Controllers/RwDeliveredQuantityController.cs + Domain entity.

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

export interface GetAllRwDeliveredQuantityParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface RwDeliveredQuantity {
  id: number;
  requestWdfk?: number | null;
  deliveredQuantity?: number | null;
  scrapedQuantity?: number | null;
  deliveredDate?: Date | null;
  axsynced?: boolean | null;
  isReceived?: boolean | null;
  maintainableQuantity?: number | null;
  deliveredNumber?: string | null;
  requestWdfkNavigation?: any | null;
}

export interface CreateRwDeliveredQuantity {
  id: number;
  requestWdfk?: number | null;
  deliveredQuantity?: number | null;
  scrapedQuantity?: number | null;
  deliveredDate?: Date | null;
  axsynced?: boolean | null;
  isReceived?: boolean | null;
  maintainableQuantity?: number | null;
  deliveredNumber?: string | null;
  requestWdfkNavigation?: any | null;
}

export interface RwDeliveredQuantityPayload {
  requestWdfk?: number | null;
  deliveredQuantity?: number | null;
  scrapedQuantity?: number | null;
  deliveredDate?: Date | null;
  axsynced?: boolean | null;
  isReceived?: boolean | null;
  maintainableQuantity?: number | null;
  deliveredNumber?: string | null;
  requestWdfkNavigation?: any | null;
}

export interface RwDeliveredQuantity extends RwDeliveredQuantityPayload {
  id: number;
  isDeleted: boolean;
}

