// Generated from WebApi/Controllers/ApprovalScreenController.cs + Domain entity.

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

export interface GetAllApprovalScreenParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface ApprovalScreen {
  id: number;
}

export interface CreateApprovalScreen {
  id: number;
}

export interface ApprovalScreenPayload {
}

export interface ApprovalScreen extends ApprovalScreenPayload {
  id: number;
  isDeleted: boolean;
}

