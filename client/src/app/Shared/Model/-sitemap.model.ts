// Generated from WebApi/Controllers/SitemapController.cs + Domain entity.

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

export interface GetAllSitemapParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Sitemap {
  id: number;
}

export interface CreateSitemap {
  id: number;
}

export interface SitemapPayload {
}

export interface Sitemap extends SitemapPayload {
  id: number;
  isDeleted: boolean;
}

