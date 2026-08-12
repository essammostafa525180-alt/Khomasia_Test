// Generated from WebApi/Controllers/ProjectController.cs + Domain entity.

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

export interface GetAllProjectParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Project {
  id: number;
  code?: string | null;
  name?: string | null;
  nameAr?: string | null;
  companyFk?: number | null;
  storeFk?: number | null;
  customerFk?: number | null;
  companyFkNavigation?: any | null;
  storeFkNavigation?: any | null;
}

export interface CreateProject {
  id: number;
  code?: string | null;
  name?: string | null;
  nameAr?: string | null;
  companyFk?: number | null;
  storeFk?: number | null;
  customerFk?: number | null;
  companyFkNavigation?: any | null;
  storeFkNavigation?: any | null;
}

export interface ProjectPayload {
  code?: string | null;
  name?: string | null;
  nameAr?: string | null;
  companyFk?: number | null;
  storeFk?: number | null;
  customerFk?: number | null;
  companyFkNavigation?: any | null;
  storeFkNavigation?: any | null;
}

export interface Project extends ProjectPayload {
  id: number;
  isDeleted: boolean;
}

