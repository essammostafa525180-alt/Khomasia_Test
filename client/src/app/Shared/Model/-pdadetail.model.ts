// Generated from WebApi/Controllers/PdadetailController.cs + Domain entity.

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

export interface GetAllPdadetailParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Pdadetail {
  id: number;
  pdamodelFk?: number | null;
  imei?: string | null;
  productionYearFk?: number | null;
  productionCountryFk?: number | null;
  startingDate?: Date | null;
  pdamodelFkNavigation?: any | null;
  productionCountryFkNavigation?: any | null;
  productionYearFkNavigation?: any | null;
}

export interface CreatePdadetail {
  id: number;
  pdamodelFk?: number | null;
  imei?: string | null;
  productionYearFk?: number | null;
  productionCountryFk?: number | null;
  startingDate?: Date | null;
  pdamodelFkNavigation?: any | null;
  productionCountryFkNavigation?: any | null;
  productionYearFkNavigation?: any | null;
}

export interface PdadetailPayload {
  pdamodelFk?: number | null;
  imei?: string | null;
  productionYearFk?: number | null;
  productionCountryFk?: number | null;
  startingDate?: Date | null;
  pdamodelFkNavigation?: any | null;
  productionCountryFkNavigation?: any | null;
  productionYearFkNavigation?: any | null;
}

export interface Pdadetail extends PdadetailPayload {
  id: number;
  isDeleted: boolean;
}

