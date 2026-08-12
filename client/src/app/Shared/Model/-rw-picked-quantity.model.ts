// Generated from WebApi/Controllers/RwPickedQuantityController.cs + Domain entity.

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

export interface GetAllRwPickedQuantityParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface RwPickedQuantity {
  id: number;
  requestWdfk?: number | null;
  pickedQuantity?: number | null;
  pickedDate?: Date | null;
  axsynced?: boolean | null;
  requestWdfkNavigation?: any | null;
}

export interface CreateRwPickedQuantity {
  id: number;
  requestWdfk?: number | null;
  pickedQuantity?: number | null;
  pickedDate?: Date | null;
  axsynced?: boolean | null;
  requestWdfkNavigation?: any | null;
}

export interface RwPickedQuantityPayload {
  requestWdfk?: number | null;
  pickedQuantity?: number | null;
  pickedDate?: Date | null;
  axsynced?: boolean | null;
  requestWdfkNavigation?: any | null;
}

export interface RwPickedQuantity extends RwPickedQuantityPayload {
  id: number;
  isDeleted: boolean;
}

