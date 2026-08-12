// Generated from WebApi/Controllers/FactoryLineController.cs + Domain entity.

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

export interface GetAllFactoryLineParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface FactoryLine {
  id: number;
  code?: string | null;
  description?: string | null;
  factoryFk: number;
  name: string;
  nameAr?: string | null;
  capacity?: number | null;
  lineTypes: string;
  factoryFkNavigation?: any | null;
}

export interface CreateFactoryLine {
  id: number;
  code?: string | null;
  description?: string | null;
  factoryFk: number;
  name: string;
  nameAr?: string | null;
  capacity?: number | null;
  lineTypes: string;
  factoryFkNavigation?: any | null;
}

export interface FactoryLinePayload {
  code?: string | null;
  description?: string | null;
  factoryFk: number;
  name: string;
  nameAr?: string | null;
  capacity?: number | null;
  lineTypes: string;
  factoryFkNavigation?: any | null;
}

export interface FactoryLine extends FactoryLinePayload {
  id: number;
  isDeleted: boolean;
}

