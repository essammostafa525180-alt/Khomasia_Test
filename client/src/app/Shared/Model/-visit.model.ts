// Generated from WebApi/Controllers/VisitController.cs + Domain entity.

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

export interface GetAllVisitParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Visit {
  id: number;
  customerId?: number | null;
  userId?: number | null;
  latitude?: number | null;
  longitude?: number | null;
  image?: string | null;
  otherSupplier?: string | null;
  updatedOn?: Date | null;
  updatedBy?: number | null;
  customer?: any | null;
  user?: any | null;
}

export interface CreateVisit {
  id: number;
  customerId?: number | null;
  userId?: number | null;
  latitude?: number | null;
  longitude?: number | null;
  image?: string | null;
  otherSupplier?: string | null;
  updatedOn?: Date | null;
  updatedBy?: number | null;
  customer?: any | null;
  user?: any | null;
}

export interface VisitPayload {
  customerId?: number | null;
  userId?: number | null;
  latitude?: number | null;
  longitude?: number | null;
  image?: string | null;
  otherSupplier?: string | null;
  updatedOn?: Date | null;
  updatedBy?: number | null;
  customer?: any | null;
  user?: any | null;
}

export interface Visit extends VisitPayload {
  id: number;
  isDeleted: boolean;
}

