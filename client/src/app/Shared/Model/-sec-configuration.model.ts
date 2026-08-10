// Generated from WebApi/Controllers/SecConfigurationController.cs + Domain entity.

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

export interface GetAllSecConfigurationParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface SecConfiguration {
  id: number;
}

export interface CreateSecConfiguration {
  id: number;
}

export interface SecConfigurationPayload {
}

export interface SecConfiguration extends SecConfigurationPayload {
  id: number;
  isDeleted: boolean;
}

