// Generated from WebApi/Controllers/UserSessionInfoDetailController.cs + Domain entity.

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

export interface GetAllUserSessionInfoDetailParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface UserSessionInfoDetail {
  id: number;
  userSessionInfoId?: number | null;
  infoKey?: number | null;
  infoValue?: string | null;
  infoDescription?: string | null;
  userSessionInfo?: any | null;
}

export interface CreateUserSessionInfoDetail {
  id: number;
  userSessionInfoId?: number | null;
  infoKey?: number | null;
  infoValue?: string | null;
  infoDescription?: string | null;
  userSessionInfo?: any | null;
}

export interface UserSessionInfoDetailPayload {
  userSessionInfoId?: number | null;
  infoKey?: number | null;
  infoValue?: string | null;
  infoDescription?: string | null;
  userSessionInfo?: any | null;
}

export interface UserSessionInfoDetail extends UserSessionInfoDetailPayload {
  id: number;
  isDeleted: boolean;
}

