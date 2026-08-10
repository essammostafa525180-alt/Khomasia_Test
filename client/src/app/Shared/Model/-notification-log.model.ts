// Generated from WebApi/Controllers/NotificationLogController.cs + Domain entity.

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

export interface GetAllNotificationLogParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface NotificationLog {
  id: number;
  customerId?: number | null;
  templateId?: number | null;
  loyaltyLevelId?: number | null;
}

export interface CreateNotificationLog {
  id: number;
  customerId?: number | null;
  templateId?: number | null;
  loyaltyLevelId?: number | null;
}

export interface NotificationLogPayload {
  customerId?: number | null;
  templateId?: number | null;
  loyaltyLevelId?: number | null;
}

export interface NotificationLog extends NotificationLogPayload {
  id: number;
  isDeleted: boolean;
}

