// Generated from WebApi/Controllers/UserSessionInfoController.cs + Domain entity.

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

export interface GetAllUserSessionInfoParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface UserSessionInfo {
  id: number;
  userId: number;
  lastHit: Date;
  expireAt: Date;
  remeberMe?: boolean | null;
  language?: string | null;
  validModules?: string | null;
  userToken: string;
  user?: any | null;
}

export interface CreateUserSessionInfo {
  id: number;
  userId: number;
  lastHit: Date;
  expireAt: Date;
  remeberMe?: boolean | null;
  language?: string | null;
  validModules?: string | null;
  userToken: string;
  user?: any | null;
}

export interface UserSessionInfoPayload {
  userId: number;
  lastHit: Date;
  expireAt: Date;
  remeberMe?: boolean | null;
  language?: string | null;
  validModules?: string | null;
  userToken: string;
  user?: any | null;
}

export interface UserSessionInfo extends UserSessionInfoPayload {
  id: number;
  isDeleted: boolean;
}

