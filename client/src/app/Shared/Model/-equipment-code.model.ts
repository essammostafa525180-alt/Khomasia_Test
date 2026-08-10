// Generated from WebApi/Controllers/EquipmentCodeController.cs + Domain entity.

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

export interface GetAllEquipmentCodeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface EquipmentCode {
  id: number;
}

export interface CreateEquipmentCode {
  id: number;
}

export interface EquipmentCodePayload {
}

export interface EquipmentCode extends EquipmentCodePayload {
  id: number;
  isDeleted: boolean;
}

