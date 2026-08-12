export interface PagedResultModel<T> {
  items: T[];
  currentPage: number;
  itemsPerPage: number;
  totalItems: number;
  totalPages: number;
  nextPage: boolean;
}


export interface ApiResponse<T> {
  isSuccess: boolean;
  data: T;
  errorMessage: string | null;
}
