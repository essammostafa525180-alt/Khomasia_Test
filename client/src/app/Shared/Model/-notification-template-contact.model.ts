// Generated from WebApi/Controllers/NotificationTemplateContactController.cs + Domain entity.

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

export interface GetAllNotificationTemplateContactParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface NotificationTemplateContact {
  id: number;
  contactId?: number | null;
  templateId?: number | null;
  updatedOn?: Date | null;
  contact?: any | null;
  template?: any | null;
}

export interface CreateNotificationTemplateContact {
  id: number;
  contactId?: number | null;
  templateId?: number | null;
  updatedOn?: Date | null;
  contact?: any | null;
  template?: any | null;
}

export interface NotificationTemplateContactPayload {
  contactId?: number | null;
  templateId?: number | null;
  updatedOn?: Date | null;
  contact?: any | null;
  template?: any | null;
}

export interface NotificationTemplateContact extends NotificationTemplateContactPayload {
  id: number;
  isDeleted: boolean;
}

