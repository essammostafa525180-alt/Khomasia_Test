// Generated from WebApi/Controllers/HadithCollectionsController.cs + Domain entity.

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

export interface GetAllHadithCollectionsParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface HadithCollections {
  id: number;
}

export interface CreateHadithCollections {
  id: number;
}

export interface HadithCollectionsPayload {
}

export interface HadithCollections extends HadithCollectionsPayload {
  id: number;
  isDeleted: boolean;
}

