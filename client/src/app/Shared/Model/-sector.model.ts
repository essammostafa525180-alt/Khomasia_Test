// Generated from WebApi/Controllers/SectorController.cs + Domain entity.

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

export interface GetAllSectorParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Sector {
  id: number;
}

export interface CreateSector {
  id: number;
}

export interface SectorPayload {
}

export interface Sector extends SectorPayload {
  id: number;
  isDeleted: boolean;
}

