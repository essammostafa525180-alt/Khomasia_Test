// Generated from WebApi/Controllers/NotificationPlaceHolderController.cs + Domain entity.

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

export interface GetAllNotificationPlaceHolderParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface NotificationPlaceHolder {
  id: number;
}

export interface CreateNotificationPlaceHolder {
  id: number;
}

export interface NotificationPlaceHolderPayload {
}

export interface NotificationPlaceHolder extends NotificationPlaceHolderPayload {
  id: number;
  isDeleted: boolean;
}

