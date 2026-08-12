// Generated from WebApi/Controllers/AssignVendorSpecializationController.cs + Domain entity.

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

export interface GetAllAssignVendorSpecializationParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssignVendorSpecialization {
  id: number;
  vendorFk?: number | null;
  vendorSpecializationFk?: number | null;
  vendorFkNavigation?: any | null;
  vendorSpecializationFkNavigation?: any | null;
}

export interface CreateAssignVendorSpecialization {
  id: number;
  vendorFk?: number | null;
  vendorSpecializationFk?: number | null;
  vendorFkNavigation?: any | null;
  vendorSpecializationFkNavigation?: any | null;
}

export interface AssignVendorSpecializationPayload {
  vendorFk?: number | null;
  vendorSpecializationFk?: number | null;
  vendorFkNavigation?: any | null;
  vendorSpecializationFkNavigation?: any | null;
}

export interface AssignVendorSpecialization extends AssignVendorSpecializationPayload {
  id: number;
  isDeleted: boolean;
}

