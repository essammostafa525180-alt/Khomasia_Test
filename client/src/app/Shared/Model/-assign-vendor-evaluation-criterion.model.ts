// Generated from WebApi/Controllers/AssignVendorEvaluationCriterionController.cs + Domain entity.

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

export interface GetAllAssignVendorEvaluationCriterionParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssignVendorEvaluationCriterion {
  id: number;
  vendorFk?: number | null;
  vendorEvaluationCriteriaFk?: number | null;
  rankFk?: number | null;
  rankFkNavigation?: any | null;
  vendorEvaluationCriteriaFkNavigation?: any | null;
  vendorFkNavigation?: any | null;
}

export interface CreateAssignVendorEvaluationCriterion {
  id: number;
  vendorFk?: number | null;
  vendorEvaluationCriteriaFk?: number | null;
  rankFk?: number | null;
  rankFkNavigation?: any | null;
  vendorEvaluationCriteriaFkNavigation?: any | null;
  vendorFkNavigation?: any | null;
}

export interface AssignVendorEvaluationCriterionPayload {
  vendorFk?: number | null;
  vendorEvaluationCriteriaFk?: number | null;
  rankFk?: number | null;
  rankFkNavigation?: any | null;
  vendorEvaluationCriteriaFkNavigation?: any | null;
  vendorFkNavigation?: any | null;
}

export interface AssignVendorEvaluationCriterion extends AssignVendorEvaluationCriterionPayload {
  id: number;
  isDeleted: boolean;
}

