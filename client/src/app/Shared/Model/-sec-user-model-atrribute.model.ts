// Generated from WebApi/Controllers/SecUserModelAtrributeController.cs + Domain entity.

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

export interface GetAllSecUserModelAtrributeParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface SecUserModelAtrribute {
  id: number;
  userId: number;
  modelAttributeId: number;
  mode?: number | null;
  modelAttribute?: any | null;
  user?: any | null;
}

export interface CreateSecUserModelAtrribute {
  id: number;
  userId: number;
  modelAttributeId: number;
  mode?: number | null;
  modelAttribute?: any | null;
  user?: any | null;
}

export interface SecUserModelAtrributePayload {
  userId: number;
  modelAttributeId: number;
  mode?: number | null;
  modelAttribute?: any | null;
  user?: any | null;
}

export interface SecUserModelAtrribute extends SecUserModelAtrributePayload {
  id: number;
  isDeleted: boolean;
}

