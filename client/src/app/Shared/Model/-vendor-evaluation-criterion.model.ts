// Generated from WebApi/Controllers/VendorEvaluationCriterionController.cs + Domain entity.

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

export interface GetAllVendorEvaluationCriterionParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface VendorEvaluationCriterion {
  id: number;
}

export interface CreateVendorEvaluationCriterion {
  id: number;
}

export interface VendorEvaluationCriterionPayload {
}

export interface VendorEvaluationCriterion extends VendorEvaluationCriterionPayload {
  id: number;
  isDeleted: boolean;
}

