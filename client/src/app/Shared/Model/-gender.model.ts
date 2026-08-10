// Generated from WebApi/Controllers/GenderController.cs + Domain entity.

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

export interface GetAllGenderParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Gender {
  id: number;
}

export interface CreateGender {
  id: number;
}

export interface GenderPayload {
}

export interface Gender extends GenderPayload {
  id: number;
  isDeleted: boolean;
}

