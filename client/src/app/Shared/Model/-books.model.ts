// Generated from WebApi/Controllers/BooksController.cs + Domain entity.

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

export interface GetAllBooksParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Books {
  id: number;
}

export interface CreateBooks {
  id: number;
}

export interface BooksPayload {
}

export interface Books extends BooksPayload {
  id: number;
  isDeleted: boolean;
}

