// Generated from WebApi/Controllers/AssetItemMoveController.cs + Domain entity.

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

export interface GetAllAssetItemMoveParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssetItemMove {
  id: number;
  code?: string | null;
  assetItemFk?: number | null;
  assetMoveTypeFk?: number | null;
  fromProjectFk?: number | null;
  fromAssetLocationFk?: number | null;
  toProjectFk?: number | null;
  toAssetLocationFk?: number | null;
  employeeFk?: number | null;
  moveDate?: any | null;
  ownerApprovedFk?: number | null;
  isOwnerApprovedFk?: number | null;
  ownerApprovedDate?: Date | null;
  managerApprovedFk?: number | null;
  isManagerApprovedFk?: number | null;
  managerApprovedDate?: Date | null;
  assetItemFkNavigation?: any | null;
  assetMoveTypeFkNavigation?: any | null;
  employeeFkNavigation?: any | null;
  fromAssetLocationFkNavigation?: any | null;
  fromProjectFkNavigation?: any | null;
  isManagerApprovedFkNavigation?: any | null;
  isOwnerApprovedFkNavigation?: any | null;
  managerApprovedFkNavigation?: any | null;
  ownerApprovedFkNavigation?: any | null;
  toAssetLocationFkNavigation?: any | null;
  toProjectFkNavigation?: any | null;
}

export interface CreateAssetItemMove {
  id: number;
  code?: string | null;
  assetItemFk?: number | null;
  assetMoveTypeFk?: number | null;
  fromProjectFk?: number | null;
  fromAssetLocationFk?: number | null;
  toProjectFk?: number | null;
  toAssetLocationFk?: number | null;
  employeeFk?: number | null;
  moveDate?: any | null;
  ownerApprovedFk?: number | null;
  isOwnerApprovedFk?: number | null;
  ownerApprovedDate?: Date | null;
  managerApprovedFk?: number | null;
  isManagerApprovedFk?: number | null;
  managerApprovedDate?: Date | null;
  assetItemFkNavigation?: any | null;
  assetMoveTypeFkNavigation?: any | null;
  employeeFkNavigation?: any | null;
  fromAssetLocationFkNavigation?: any | null;
  fromProjectFkNavigation?: any | null;
  isManagerApprovedFkNavigation?: any | null;
  isOwnerApprovedFkNavigation?: any | null;
  managerApprovedFkNavigation?: any | null;
  ownerApprovedFkNavigation?: any | null;
  toAssetLocationFkNavigation?: any | null;
  toProjectFkNavigation?: any | null;
}

export interface AssetItemMovePayload {
  code?: string | null;
  assetItemFk?: number | null;
  assetMoveTypeFk?: number | null;
  fromProjectFk?: number | null;
  fromAssetLocationFk?: number | null;
  toProjectFk?: number | null;
  toAssetLocationFk?: number | null;
  employeeFk?: number | null;
  moveDate?: any | null;
  ownerApprovedFk?: number | null;
  isOwnerApprovedFk?: number | null;
  ownerApprovedDate?: Date | null;
  managerApprovedFk?: number | null;
  isManagerApprovedFk?: number | null;
  managerApprovedDate?: Date | null;
  assetItemFkNavigation?: any | null;
  assetMoveTypeFkNavigation?: any | null;
  employeeFkNavigation?: any | null;
  fromAssetLocationFkNavigation?: any | null;
  fromProjectFkNavigation?: any | null;
  isManagerApprovedFkNavigation?: any | null;
  isOwnerApprovedFkNavigation?: any | null;
  managerApprovedFkNavigation?: any | null;
  ownerApprovedFkNavigation?: any | null;
  toAssetLocationFkNavigation?: any | null;
  toProjectFkNavigation?: any | null;
}

export interface AssetItemMove extends AssetItemMovePayload {
  id: number;
  isDeleted: boolean;
}

