// Generated from WebApi/Controllers/SecModelController.cs + Domain entity.

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

export interface GetAllSecModelParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface SecModel {
  id: number;
  modelId: number;
  modelName?: string | null;
  modelDisplayName?: string | null;
  secModuleId?: number | null;
  modelDisplayNameAr?: string | null;
  secModule?: any | null;
}

export interface CreateSecModel {
  id: number;
  modelId: number;
  modelName?: string | null;
  modelDisplayName?: string | null;
  secModuleId?: number | null;
  modelDisplayNameAr?: string | null;
  secModule?: any | null;
}

export interface SecModelPayload {
  modelId: number;
  modelName?: string | null;
  modelDisplayName?: string | null;
  secModuleId?: number | null;
  modelDisplayNameAr?: string | null;
  secModule?: any | null;
}

export interface SecModel extends SecModelPayload {
  id: number;
  isDeleted: boolean;
}

