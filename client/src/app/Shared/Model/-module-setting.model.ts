// Generated from WebApi/Controllers/ModuleSettingController.cs + Domain entity.

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

export interface GetAllModuleSettingParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface ModuleSetting {
  id: number;
}

export interface CreateModuleSetting {
  id: number;
}

export interface ModuleSettingPayload {
}

export interface ModuleSetting extends ModuleSettingPayload {
  id: number;
  isDeleted: boolean;
}

