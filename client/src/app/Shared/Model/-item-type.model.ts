// Generated from WebApi/Controllers/ItemTypeController.cs + Domain entity.

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

export interface GetAllItemTypeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface ItemType {
  id: number;
}

export interface CreateItemType {
  id: number;
}

export interface ItemTypePayload {
}

export interface ItemType extends ItemTypePayload {
  id: number;
  isDeleted: boolean;
}

