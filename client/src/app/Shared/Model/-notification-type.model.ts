// Generated from WebApi/Controllers/NotificationTypeController.cs + Domain entity.

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

export interface GetAllNotificationTypeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface NotificationType {
  id: number;
}

export interface CreateNotificationType {
  id: number;
}

export interface NotificationTypePayload {
}

export interface NotificationType extends NotificationTypePayload {
  id: number;
  isDeleted: boolean;
}

