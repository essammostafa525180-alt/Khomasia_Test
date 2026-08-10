// Generated from WebApi/Controllers/RankController.cs + Domain entity.

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

export interface GetAllRankParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Rank {
  id: number;
}

export interface CreateRank {
  id: number;
}

export interface RankPayload {
}

export interface Rank extends RankPayload {
  id: number;
  isDeleted: boolean;
}

