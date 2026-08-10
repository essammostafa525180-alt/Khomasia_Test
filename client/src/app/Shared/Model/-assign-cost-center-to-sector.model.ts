// Generated from WebApi/Controllers/AssignCostCenterToSectorController.cs + Domain entity.

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

export interface GetAllAssignCostCenterToSectorParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssignCostCenterToSector {
  id: number;
  sectorFk?: number | null;
  costCenterFk?: number | null;
  costCenterFkNavigation?: any | null;
  sectorFkNavigation?: any | null;
}

export interface CreateAssignCostCenterToSector {
  id: number;
  sectorFk?: number | null;
  costCenterFk?: number | null;
  costCenterFkNavigation?: any | null;
  sectorFkNavigation?: any | null;
}

export interface AssignCostCenterToSectorPayload {
  sectorFk?: number | null;
  costCenterFk?: number | null;
  costCenterFkNavigation?: any | null;
  sectorFkNavigation?: any | null;
}

export interface AssignCostCenterToSector extends AssignCostCenterToSectorPayload {
  id: number;
  isDeleted: boolean;
}

