// Generated from WebApi/Controllers/NotificationTemplateController.cs + Domain entity.

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

export interface GetAllNotificationTemplateParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface NotificationTemplate {
  id: number;
  notificationTypeId?: number | null;
  languageId?: number | null;
  subject?: string | null;
  subjectAr?: string | null;
  bodySms?: string | null;
  bodySmsar?: string | null;
  bodyEmail?: string | null;
  bodyEmailAr?: string | null;
  code?: string | null;
  codeAr?: string | null;
  durationInDays?: number | null;
  language?: any | null;
  notificationType?: any | null;
}

export interface CreateNotificationTemplate {
  id: number;
  notificationTypeId?: number | null;
  languageId?: number | null;
  subject?: string | null;
  subjectAr?: string | null;
  bodySms?: string | null;
  bodySmsar?: string | null;
  bodyEmail?: string | null;
  bodyEmailAr?: string | null;
  code?: string | null;
  codeAr?: string | null;
  durationInDays?: number | null;
  language?: any | null;
  notificationType?: any | null;
}

export interface NotificationTemplatePayload {
  notificationTypeId?: number | null;
  languageId?: number | null;
  subject?: string | null;
  subjectAr?: string | null;
  bodySms?: string | null;
  bodySmsar?: string | null;
  bodyEmail?: string | null;
  bodyEmailAr?: string | null;
  code?: string | null;
  codeAr?: string | null;
  durationInDays?: number | null;
  language?: any | null;
  notificationType?: any | null;
}

export interface NotificationTemplate extends NotificationTemplatePayload {
  id: number;
  isDeleted: boolean;
}

