// Generated from WebApi/Controllers/PdamodelController.cs + Domain entity.

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

export interface GetAllPdamodelParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Pdamodel {
  id: number;
  name?: string | null;
  nameAr?: string | null;
}

export interface CreatePdamodel {
  id: number;
  name?: string | null;
  nameAr?: string | null;
}

export interface PdamodelPayload {
  name?: string | null;
  nameAr?: string | null;
}

export interface Pdamodel extends PdamodelPayload {
  id: number;
  isDeleted: boolean;
}

