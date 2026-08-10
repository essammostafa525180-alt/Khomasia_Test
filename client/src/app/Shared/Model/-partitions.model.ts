// Generated from WebApi/Controllers/PartitionsController.cs + Domain entity.

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

export interface GetAllPartitionsParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Partitions {
  id: number;
}

export interface CreatePartitions {
  id: number;
}

export interface PartitionsPayload {
}

export interface Partitions extends PartitionsPayload {
  id: number;
  isDeleted: boolean;
}

