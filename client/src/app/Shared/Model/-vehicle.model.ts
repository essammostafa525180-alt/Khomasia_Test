// Generated from WebApi/Controllers/VehicleController.cs + Domain entity.

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

export interface GetAllVehicleParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface Vehicle {
  id: number;
  code?: string | null;
  barcode?: string | null;
  rfid?: string | null;
  equipmentTypeFk?: number | null;
  vehicleTypeFk?: number | null;
  vehicleBrandFk?: number | null;
  vehicleModelFk?: number | null;
  yearFk?: number | null;
  serialNumber?: string | null;
  plateNumber?: string | null;
  colorFk?: number | null;
  description?: string | null;
  vehicleStatusFk?: number | null;
  ownershipFk?: number | null;
  oufk?: number | null;
  costCenterFk?: number | null;
  employeeFk?: number | null;
  grossWeight?: number | null;
  height?: number | null;
  width?: number | null;
  wheelBase?: number | null;
  length?: number | null;
  chassisNumber?: string | null;
  engineNumber?: string | null;
  engineSizeFk?: number | null;
  transmissionTypeFk?: number | null;
  cylindersNumber?: number | null;
  batteryTypeFk?: number | null;
  airFilterTypeFk?: number | null;
  sectorFk?: number | null;
  operationDate?: Date | null;
  tagNumber?: string | null;
  retireDate?: Date | null;
  bookValue?: number | null;
  laborRateRatio?: number | null;
  sparePartRateRatio?: number | null;
  depreciation?: number | null;
  originalValue?: number | null;
  serviceLife?: number | null;
  vehicleOptionFk?: number | null;
  remainingMonths?: number | null;
  companyFk?: number | null;
  projectFk?: number | null;
  airFilterTypeFkNavigation?: any | null;
  batteryTypeFkNavigation?: any | null;
  colorFkNavigation?: any | null;
  costCenterFkNavigation?: any | null;
  engineSizeFkNavigation?: any | null;
  oufkNavigation?: any | null;
  ownershipFkNavigation?: any | null;
  projectFkNavigation?: any | null;
  sectorFkNavigation?: any | null;
  transmissionTypeFkNavigation?: any | null;
  vehicleBrandFkNavigation?: any | null;
  vehicleModelFkNavigation?: any | null;
  vehicleOptionFkNavigation?: any | null;
  vehicleStatusFkNavigation?: any | null;
  vehicleTypeFkNavigation?: any | null;
  yearFkNavigation?: any | null;
}

export interface CreateVehicle {
  id: number;
  code?: string | null;
  barcode?: string | null;
  rfid?: string | null;
  equipmentTypeFk?: number | null;
  vehicleTypeFk?: number | null;
  vehicleBrandFk?: number | null;
  vehicleModelFk?: number | null;
  yearFk?: number | null;
  serialNumber?: string | null;
  plateNumber?: string | null;
  colorFk?: number | null;
  description?: string | null;
  vehicleStatusFk?: number | null;
  ownershipFk?: number | null;
  oufk?: number | null;
  costCenterFk?: number | null;
  employeeFk?: number | null;
  grossWeight?: number | null;
  height?: number | null;
  width?: number | null;
  wheelBase?: number | null;
  length?: number | null;
  chassisNumber?: string | null;
  engineNumber?: string | null;
  engineSizeFk?: number | null;
  transmissionTypeFk?: number | null;
  cylindersNumber?: number | null;
  batteryTypeFk?: number | null;
  airFilterTypeFk?: number | null;
  sectorFk?: number | null;
  operationDate?: Date | null;
  tagNumber?: string | null;
  retireDate?: Date | null;
  bookValue?: number | null;
  laborRateRatio?: number | null;
  sparePartRateRatio?: number | null;
  depreciation?: number | null;
  originalValue?: number | null;
  serviceLife?: number | null;
  vehicleOptionFk?: number | null;
  remainingMonths?: number | null;
  companyFk?: number | null;
  projectFk?: number | null;
  airFilterTypeFkNavigation?: any | null;
  batteryTypeFkNavigation?: any | null;
  colorFkNavigation?: any | null;
  costCenterFkNavigation?: any | null;
  engineSizeFkNavigation?: any | null;
  oufkNavigation?: any | null;
  ownershipFkNavigation?: any | null;
  projectFkNavigation?: any | null;
  sectorFkNavigation?: any | null;
  transmissionTypeFkNavigation?: any | null;
  vehicleBrandFkNavigation?: any | null;
  vehicleModelFkNavigation?: any | null;
  vehicleOptionFkNavigation?: any | null;
  vehicleStatusFkNavigation?: any | null;
  vehicleTypeFkNavigation?: any | null;
  yearFkNavigation?: any | null;
}

export interface VehiclePayload {
  code?: string | null;
  barcode?: string | null;
  rfid?: string | null;
  equipmentTypeFk?: number | null;
  vehicleTypeFk?: number | null;
  vehicleBrandFk?: number | null;
  vehicleModelFk?: number | null;
  yearFk?: number | null;
  serialNumber?: string | null;
  plateNumber?: string | null;
  colorFk?: number | null;
  description?: string | null;
  vehicleStatusFk?: number | null;
  ownershipFk?: number | null;
  oufk?: number | null;
  costCenterFk?: number | null;
  employeeFk?: number | null;
  grossWeight?: number | null;
  height?: number | null;
  width?: number | null;
  wheelBase?: number | null;
  length?: number | null;
  chassisNumber?: string | null;
  engineNumber?: string | null;
  engineSizeFk?: number | null;
  transmissionTypeFk?: number | null;
  cylindersNumber?: number | null;
  batteryTypeFk?: number | null;
  airFilterTypeFk?: number | null;
  sectorFk?: number | null;
  operationDate?: Date | null;
  tagNumber?: string | null;
  retireDate?: Date | null;
  bookValue?: number | null;
  laborRateRatio?: number | null;
  sparePartRateRatio?: number | null;
  depreciation?: number | null;
  originalValue?: number | null;
  serviceLife?: number | null;
  vehicleOptionFk?: number | null;
  remainingMonths?: number | null;
  companyFk?: number | null;
  projectFk?: number | null;
  airFilterTypeFkNavigation?: any | null;
  batteryTypeFkNavigation?: any | null;
  colorFkNavigation?: any | null;
  costCenterFkNavigation?: any | null;
  engineSizeFkNavigation?: any | null;
  oufkNavigation?: any | null;
  ownershipFkNavigation?: any | null;
  projectFkNavigation?: any | null;
  sectorFkNavigation?: any | null;
  transmissionTypeFkNavigation?: any | null;
  vehicleBrandFkNavigation?: any | null;
  vehicleModelFkNavigation?: any | null;
  vehicleOptionFkNavigation?: any | null;
  vehicleStatusFkNavigation?: any | null;
  vehicleTypeFkNavigation?: any | null;
  yearFkNavigation?: any | null;
}

export interface Vehicle extends VehiclePayload {
  id: number;
  isDeleted: boolean;
}

