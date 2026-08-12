// Generated from WebApi/Controllers/PdaassignmentController.cs + Domain entity.

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

export interface GetAllPdaassignmentParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Pdaassignment {
  id: number;
  pdadetailFk?: number | null;
  userFk?: number | null;
  pdadetailFkNavigation?: any | null;
}

export interface CreatePdaassignment {
  id: number;
  pdadetailFk?: number | null;
  userFk?: number | null;
  pdadetailFkNavigation?: any | null;
}

export interface PdaassignmentPayload {
  pdadetailFk?: number | null;
  userFk?: number | null;
  pdadetailFkNavigation?: any | null;
}

export interface Pdaassignment extends PdaassignmentPayload {
  id: number;
  isDeleted: boolean;
}

