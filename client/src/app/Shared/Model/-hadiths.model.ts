// Generated from WebApi/Controllers/HadithsController.cs + Domain entity.

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

export interface GetAllHadithsParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Hadiths {
  id: number;
}

export interface CreateHadiths {
  id: number;
}

export interface HadithsPayload {
}

export interface Hadiths extends HadithsPayload {
  id: number;
  isDeleted: boolean;
}

