// Generated from WebApi/Controllers/LanguageController.cs + Domain entity.

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

export interface GetAllLanguageParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Language {
  id: number;
}

export interface CreateLanguage {
  id: number;
}

export interface LanguagePayload {
}

export interface Language extends LanguagePayload {
  id: number;
  isDeleted: boolean;
}

