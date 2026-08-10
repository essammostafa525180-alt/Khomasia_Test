// Generated from WebApi/Controllers/ManufactureController.cs + Domain entity.

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

export interface GetAllManufactureParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Manufacture {
  id: number;
}

export interface CreateManufacture {
  id: number;
}

export interface ManufacturePayload {
}

export interface Manufacture extends ManufacturePayload {
  id: number;
  isDeleted: boolean;
}

