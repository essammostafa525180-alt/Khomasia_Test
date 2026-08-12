// Generated from WebApi/Controllers/ToolsTypeController.cs + Domain entity.

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

export interface GetAllToolsTypeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface ToolsType {
  id: number;
}

export interface CreateToolsType {
  id: number;
}

export interface ToolsTypePayload {
}

export interface ToolsType extends ToolsTypePayload {
  id: number;
  isDeleted: boolean;
}

