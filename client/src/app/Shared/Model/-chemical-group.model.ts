// Generated from WebApi/Controllers/ChemicalGroupController.cs + Domain entity.

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

export interface GetAllChemicalGroupParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface ChemicalGroup {
  id: number;
}

export interface CreateChemicalGroup {
  id: number;
}

export interface ChemicalGroupPayload {
}

export interface ChemicalGroup extends ChemicalGroupPayload {
  id: number;
  isDeleted: boolean;
}

