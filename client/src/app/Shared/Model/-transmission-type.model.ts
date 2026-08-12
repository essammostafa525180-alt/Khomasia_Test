// Generated from WebApi/Controllers/TransmissionTypeController.cs + Domain entity.

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

export interface GetAllTransmissionTypeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface TransmissionType {
  id: number;
}

export interface CreateTransmissionType {
  id: number;
}

export interface TransmissionTypePayload {
}

export interface TransmissionType extends TransmissionTypePayload {
  id: number;
  isDeleted: boolean;
}

