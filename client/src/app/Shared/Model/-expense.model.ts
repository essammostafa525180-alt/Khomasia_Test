// Generated from WebApi/Controllers/ExpenseController.cs + Domain entity.

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

export interface GetAllExpenseParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Expense {
  id: number;
  code?: string | null;
  name?: string | null;
  nameAr?: string | null;
  companyFk?: number | null;
}

export interface CreateExpense {
  id: number;
  code?: string | null;
  name?: string | null;
  nameAr?: string | null;
  companyFk?: number | null;
}

export interface ExpensePayload {
  code?: string | null;
  name?: string | null;
  nameAr?: string | null;
  companyFk?: number | null;
}

export interface Expense extends ExpensePayload {
  id: number;
  isDeleted: boolean;
}

