// Generated from WebApi/Controllers/NotificationStateController.cs + Domain entity.

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

export interface GetAllNotificationStateParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface NotificationState {
  id: number;
}

export interface CreateNotificationState {
  id: number;
}

export interface NotificationStatePayload {
}

export interface NotificationState extends NotificationStatePayload {
  id: number;
  isDeleted: boolean;
}

