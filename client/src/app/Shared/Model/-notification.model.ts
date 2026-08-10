// Generated from WebApi/Controllers/NotificationController.cs + Domain entity.

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

export interface GetAllNotificationParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Notification {
  id: number;
  to?: string | null;
  cc?: string | null;
  bcc?: string | null;
  phoneNumber?: string | null;
  subject?: string | null;
  body?: string | null;
  statusId?: number | null;
  createDate?: Date | null;
  lastUpdateDate?: Date | null;
  sendDate?: Date | null;
  notificationTypeId?: number | null;
  notificationSource?: string | null;
  errorMessage?: string | null;
  sendTries?: number | null;
  notificationDateTime?: Date | null;
  attachment?: any[] | null;
  attachmentType?: string | null;
  notificationType?: any | null;
  status?: any | null;
}

export interface CreateNotification {
  id: number;
  to?: string | null;
  cc?: string | null;
  bcc?: string | null;
  phoneNumber?: string | null;
  subject?: string | null;
  body?: string | null;
  statusId?: number | null;
  createDate?: Date | null;
  lastUpdateDate?: Date | null;
  sendDate?: Date | null;
  notificationTypeId?: number | null;
  notificationSource?: string | null;
  errorMessage?: string | null;
  sendTries?: number | null;
  notificationDateTime?: Date | null;
  attachment?: any[] | null;
  attachmentType?: string | null;
  notificationType?: any | null;
  status?: any | null;
}

export interface NotificationPayload {
  to?: string | null;
  cc?: string | null;
  bcc?: string | null;
  phoneNumber?: string | null;
  subject?: string | null;
  body?: string | null;
  statusId?: number | null;
  createDate?: Date | null;
  lastUpdateDate?: Date | null;
  sendDate?: Date | null;
  notificationTypeId?: number | null;
  notificationSource?: string | null;
  errorMessage?: string | null;
  sendTries?: number | null;
  notificationDateTime?: Date | null;
  attachment?: any[] | null;
  attachmentType?: string | null;
  notificationType?: any | null;
  status?: any | null;
}

export interface Notification extends NotificationPayload {
  id: number;
  isDeleted: boolean;
}

