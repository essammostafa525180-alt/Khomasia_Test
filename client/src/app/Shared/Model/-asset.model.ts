// Generated from WebApi/Controllers/AssetController.cs + Domain entity.

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

export interface GetAllAssetParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Asset {
  id: number;
  assetGroupFk?: number | null;
  assetTypeFk?: number | null;
  toolsTypeFk?: number | null;
  code?: string | null;
  name?: string | null;
  nameAr?: string | null;
  zoneFk?: number | null;
  equipmentCodeFk?: number | null;
  equipmentLocationCode?: string | null;
  functionalCode?: string | null;
  quantity?: number | null;
  costPerHour?: number | null;
  currencyFk?: number | null;
  warrantyStatusFk?: number | null;
  rfid?: string | null;
  remarks?: string | null;
  possessionTypeFk?: number | null;
  operationDate?: Date | null;
  isOperational?: boolean | null;
  insuranceVendorFk?: number | null;
  policyNumber?: string | null;
  policyDate?: Date | null;
  policyExpiryDate?: Date | null;
  policyAmount?: number | null;
  manufactureFk?: number | null;
  model?: string | null;
  modelYearFk?: number | null;
  serialNumber?: string | null;
  guaranteeExpiryDate?: Date | null;
  technicalInformation?: string | null;
  axsynced?: boolean | null;
  projectFk?: number | null;
  assetStatusFk?: number | null;
  purchasePrice?: number | null;
  purchaseDate?: Date | null;
  checkDate?: Date | null;
  lifeTime?: number | null;
  depreciationRate?: number | null;
  plannedDepreciationDate?: Date | null;
  actualDepreciationDate?: Date | null;
  oufk?: number | null;
  assetDisposed?: any | null;
  assetGroupFkNavigation?: any | null;
  assetStatusFkNavigation?: any | null;
  assetTypeFkNavigation?: any | null;
  currencyFkNavigation?: any | null;
  equipmentCodeFkNavigation?: any | null;
  insuranceVendorFkNavigation?: any | null;
  manufactureFkNavigation?: any | null;
  modelYearFkNavigation?: any | null;
  oufkNavigation?: any | null;
  possessionTypeFkNavigation?: any | null;
  projectFkNavigation?: any | null;
  toolsTypeFkNavigation?: any | null;
  warrantyStatusFkNavigation?: any | null;
  zoneFkNavigation?: any | null;
}

export interface CreateAsset {
  id: number;
  assetGroupFk?: number | null;
  assetTypeFk?: number | null;
  toolsTypeFk?: number | null;
  code?: string | null;
  name?: string | null;
  nameAr?: string | null;
  zoneFk?: number | null;
  equipmentCodeFk?: number | null;
  equipmentLocationCode?: string | null;
  functionalCode?: string | null;
  quantity?: number | null;
  costPerHour?: number | null;
  currencyFk?: number | null;
  warrantyStatusFk?: number | null;
  rfid?: string | null;
  remarks?: string | null;
  possessionTypeFk?: number | null;
  operationDate?: Date | null;
  isOperational?: boolean | null;
  insuranceVendorFk?: number | null;
  policyNumber?: string | null;
  policyDate?: Date | null;
  policyExpiryDate?: Date | null;
  policyAmount?: number | null;
  manufactureFk?: number | null;
  model?: string | null;
  modelYearFk?: number | null;
  serialNumber?: string | null;
  guaranteeExpiryDate?: Date | null;
  technicalInformation?: string | null;
  axsynced?: boolean | null;
  projectFk?: number | null;
  assetStatusFk?: number | null;
  purchasePrice?: number | null;
  purchaseDate?: Date | null;
  checkDate?: Date | null;
  lifeTime?: number | null;
  depreciationRate?: number | null;
  plannedDepreciationDate?: Date | null;
  actualDepreciationDate?: Date | null;
  oufk?: number | null;
  assetDisposed?: any | null;
  assetGroupFkNavigation?: any | null;
  assetStatusFkNavigation?: any | null;
  assetTypeFkNavigation?: any | null;
  currencyFkNavigation?: any | null;
  equipmentCodeFkNavigation?: any | null;
  insuranceVendorFkNavigation?: any | null;
  manufactureFkNavigation?: any | null;
  modelYearFkNavigation?: any | null;
  oufkNavigation?: any | null;
  possessionTypeFkNavigation?: any | null;
  projectFkNavigation?: any | null;
  toolsTypeFkNavigation?: any | null;
  warrantyStatusFkNavigation?: any | null;
  zoneFkNavigation?: any | null;
}

export interface AssetPayload {
  assetGroupFk?: number | null;
  assetTypeFk?: number | null;
  toolsTypeFk?: number | null;
  code?: string | null;
  name?: string | null;
  nameAr?: string | null;
  zoneFk?: number | null;
  equipmentCodeFk?: number | null;
  equipmentLocationCode?: string | null;
  functionalCode?: string | null;
  quantity?: number | null;
  costPerHour?: number | null;
  currencyFk?: number | null;
  warrantyStatusFk?: number | null;
  rfid?: string | null;
  remarks?: string | null;
  possessionTypeFk?: number | null;
  operationDate?: Date | null;
  isOperational?: boolean | null;
  insuranceVendorFk?: number | null;
  policyNumber?: string | null;
  policyDate?: Date | null;
  policyExpiryDate?: Date | null;
  policyAmount?: number | null;
  manufactureFk?: number | null;
  model?: string | null;
  modelYearFk?: number | null;
  serialNumber?: string | null;
  guaranteeExpiryDate?: Date | null;
  technicalInformation?: string | null;
  axsynced?: boolean | null;
  projectFk?: number | null;
  assetStatusFk?: number | null;
  purchasePrice?: number | null;
  purchaseDate?: Date | null;
  checkDate?: Date | null;
  lifeTime?: number | null;
  depreciationRate?: number | null;
  plannedDepreciationDate?: Date | null;
  actualDepreciationDate?: Date | null;
  oufk?: number | null;
  assetDisposed?: any | null;
  assetGroupFkNavigation?: any | null;
  assetStatusFkNavigation?: any | null;
  assetTypeFkNavigation?: any | null;
  currencyFkNavigation?: any | null;
  equipmentCodeFkNavigation?: any | null;
  insuranceVendorFkNavigation?: any | null;
  manufactureFkNavigation?: any | null;
  modelYearFkNavigation?: any | null;
  oufkNavigation?: any | null;
  possessionTypeFkNavigation?: any | null;
  projectFkNavigation?: any | null;
  toolsTypeFkNavigation?: any | null;
  warrantyStatusFkNavigation?: any | null;
  zoneFkNavigation?: any | null;
}

export interface Asset extends AssetPayload {
  id: number;
  isDeleted: boolean;
}

