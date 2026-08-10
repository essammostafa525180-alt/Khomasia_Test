// Generated from WebApi/Controllers/WsLastSyncTableController.cs + Domain entity.

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

export interface GetAllWsLastSyncTableParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface WsLastSyncTable {
  id: number;
}

export interface CreateWsLastSyncTable {
  id: number;
}

export interface WsLastSyncTablePayload {
}

export interface WsLastSyncTable extends WsLastSyncTablePayload {
  id: number;
  isDeleted: boolean;
}

