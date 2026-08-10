// Generated from WebApi/Controllers/HadithSharhMissingController.cs + Domain entity.

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

export interface GetAllHadithSharhMissingParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface HadithSharhMissing {
  id: number;
  hadithNumber: number;
  babId?: number | null;
  bookSharhId?: number | null;
  sharhBook?: any | null;
  sharhWithSign?: string | null;
  sharhWithNoSign?: string | null;
  hadithId: number;
}

export interface CreateHadithSharhMissing {
  id: number;
  hadithNumber: number;
  babId?: number | null;
  bookSharhId?: number | null;
  sharhBook?: any | null;
  sharhWithSign?: string | null;
  sharhWithNoSign?: string | null;
  hadithId: number;
}

export interface HadithSharhMissingPayload {
  hadithNumber: number;
  babId?: number | null;
  bookSharhId?: number | null;
  sharhBook?: any | null;
  sharhWithSign?: string | null;
  sharhWithNoSign?: string | null;
  hadithId: number;
}

export interface HadithSharhMissing extends HadithSharhMissingPayload {
  id: number;
  isDeleted: boolean;
}

