// Generated from WebApi/Controllers/AssetItemController.cs + Domain entity.

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

export interface GetAllAssetItemParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface AssetItem {
  id: number;
  assetStatusFk?: number | null;
  purchaseValue?: number | null;
  purchaseDate?: any | null;
  departmentFk?: number | null;
  projectFk?: number | null;
  assetLocationFk?: number | null;
  employeeFk?: number | null;
  moveDate?: Date | null;
  assetWarrantyStatusFk?: number | null;
  endWarrantyDate?: any | null;
  isOperational: boolean;
  operationDate?: any | null;
  scrapDate?: any | null;
  maintenanceDate?: any | null;
  depreciationRate?: number | null;
  depreciationDuration?: number | null;
  firstDepreciationDate?: any | null;
  fixedAssetAccountCode?: string | null;
  depreciationAccountCode?: string | null;
  insuranceVendorFk?: number | null;
  insuranceAccountCode?: string | null;
  policyNumber?: string | null;
  policyDate?: any | null;
  policyExpiryDate?: any | null;
  policyAmount?: number | null;
  modelName?: string | null;
  manufactureDate?: any | null;
  description?: string | null;
  assetRowVersion?: any[] | null;
  assetLocationFkNavigation?: any | null;
  assetStatusFkNavigation?: any | null;
  assetWarrantyStatusFkNavigation?: any | null;
  employeeFkNavigation?: any | null;
  idNavigation?: any | null;
  insuranceVendorFkNavigation?: any | null;
  projectFkNavigation?: any | null;
}

export interface CreateAssetItem {
  id: number;
  assetStatusFk?: number | null;
  purchaseValue?: number | null;
  purchaseDate?: any | null;
  departmentFk?: number | null;
  projectFk?: number | null;
  assetLocationFk?: number | null;
  employeeFk?: number | null;
  moveDate?: Date | null;
  assetWarrantyStatusFk?: number | null;
  endWarrantyDate?: any | null;
  isOperational: boolean;
  operationDate?: any | null;
  scrapDate?: any | null;
  maintenanceDate?: any | null;
  depreciationRate?: number | null;
  depreciationDuration?: number | null;
  firstDepreciationDate?: any | null;
  fixedAssetAccountCode?: string | null;
  depreciationAccountCode?: string | null;
  insuranceVendorFk?: number | null;
  insuranceAccountCode?: string | null;
  policyNumber?: string | null;
  policyDate?: any | null;
  policyExpiryDate?: any | null;
  policyAmount?: number | null;
  modelName?: string | null;
  manufactureDate?: any | null;
  description?: string | null;
  assetRowVersion?: any[] | null;
  assetLocationFkNavigation?: any | null;
  assetStatusFkNavigation?: any | null;
  assetWarrantyStatusFkNavigation?: any | null;
  employeeFkNavigation?: any | null;
  idNavigation?: any | null;
  insuranceVendorFkNavigation?: any | null;
  projectFkNavigation?: any | null;
}

export interface AssetItemPayload {
  assetStatusFk?: number | null;
  purchaseValue?: number | null;
  purchaseDate?: any | null;
  departmentFk?: number | null;
  projectFk?: number | null;
  assetLocationFk?: number | null;
  employeeFk?: number | null;
  moveDate?: Date | null;
  assetWarrantyStatusFk?: number | null;
  endWarrantyDate?: any | null;
  isOperational: boolean;
  operationDate?: any | null;
  scrapDate?: any | null;
  maintenanceDate?: any | null;
  depreciationRate?: number | null;
  depreciationDuration?: number | null;
  firstDepreciationDate?: any | null;
  fixedAssetAccountCode?: string | null;
  depreciationAccountCode?: string | null;
  insuranceVendorFk?: number | null;
  insuranceAccountCode?: string | null;
  policyNumber?: string | null;
  policyDate?: any | null;
  policyExpiryDate?: any | null;
  policyAmount?: number | null;
  modelName?: string | null;
  manufactureDate?: any | null;
  description?: string | null;
  assetRowVersion?: any[] | null;
  assetLocationFkNavigation?: any | null;
  assetStatusFkNavigation?: any | null;
  assetWarrantyStatusFkNavigation?: any | null;
  employeeFkNavigation?: any | null;
  idNavigation?: any | null;
  insuranceVendorFkNavigation?: any | null;
  projectFkNavigation?: any | null;
}

export interface AssetItem extends AssetItemPayload {
  id: number;
  isDeleted: boolean;
}

