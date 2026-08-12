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

export interface GetAllInventoryItemsParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}


export interface InventoryItem {
  id: number;
  itemNumber?: string | null;
  name?: string | null;
  nameAr?: string | null;
  itemTypeFK?: number | null;
  chemicalGroupFK?: number | null;
  assetGroupFK?: number | null;
  materialGroupFK?: number | null;
  sparePartGroupFK?: number | null;
  totalQuantity?: number | null;
  unitOfMeasureFK?: number | null;
  itemExpiryTypeFK?: number | null;
  warrantyStatusFK?: number | null;
  rfid?: string | null;
  englishDescription?: string | null;
  arabicDescription?: string | null;
  autoReplenishment?: boolean | null;
  isMaintainable?: boolean | null;
  manufactureFK?: number | null;
  minLevel?: number | null;
  maxLevel?: number | null;
  autoRequestQuantity?: number | null;
  model?: string | null;
  deliveryPeriodDays?: number | null;
  concentration?: number | null;
  isBatch?: boolean | null;
  isSerial?: boolean | null;
  avgCost?: number | null;
  axSynced?: boolean | null;
  idelPeriod?: number | null;
  lastPurchasePrice?: number | null;
  isScrap?: boolean | null;
  itemQuantityTypeFK?: number | null;
  materialCategoryFK?: number | null;
  materialSubCategoryFK?: number | null;
  isDisabled: boolean;
  density?: number | null;
  volumeSolid?: number | null;
  spreadingRate?: number | null;
  dft?: number | null;
  packing?: number | null;
  itemCode?: string | null;
  isActive: boolean;
}
export interface CreateInventoryItem {
  id: number;
  itemNumber?: string | null;
  name?: string | null;
  nameAr?: string | null;
  itemTypeFK?: number | null;
  chemicalGroupFK?: number | null;
  assetGroupFK?: number | null;
  materialGroupFK?: number | null;
  sparePartGroupFK?: number | null;
  totalQuantity?: number | null;
  unitOfMeasureFK?: number | null;
  itemExpiryTypeFK?: number | null;
  warrantyStatusFK?: number | null;
  rfid?: string | null;
  englishDescription?: string | null;
  arabicDescription?: string | null;
  autoReplenishment?: boolean | null;
  isMaintainable?: boolean | null;
  manufactureFK?: number | null;
  minLevel?: number | null;
  maxLevel?: number | null;
  autoRequestQuantity?: number | null;
  model?: string | null;
  deliveryPeriodDays?: number | null;
  concentration?: number | null;
  isBatch?: boolean | null;
  isSerial?: boolean | null;
  avgCost?: number | null;
  axSynced?: boolean | null;
  idelPeriod?: number | null;
  lastPurchasePrice?: number | null;
  isScrap?: boolean | null;
  itemQuantityTypeFK?: number | null;
  materialCategoryFK?: number | null;
  materialSubCategoryFK?: number | null;
  isDisabled: boolean;
  density?: number | null;
  volumeSolid?: number | null;
  spreadingRate?: number | null;
  dft?: number | null;
  packing?: number | null;
  itemCode?: string | null;
  isActive: boolean;
}
export interface InventoryItemPayload {
  itemNumber?: string | null;
  name?: string | null;
  nameAr?: string | null;
  itemTypeFK?: number | null;
  chemicalGroupFK?: number | null;
  assetGroupFK?: number | null;
  materialGroupFK?: number | null;
  sparePartGroupFK?: number | null;
  totalQuantity?: number | null;
  unitOfMeasureFK?: number | null;
  itemExpiryTypeFK?: number | null;
  warrantyStatusFK?: number | null;
  rfid?: string | null;
  englishDescription?: string | null;
  arabicDescription?: string | null;
  autoReplenishment?: boolean | null;
  isMaintainable?: boolean | null;
  manufactureFK?: number | null;
  minLevel?: number | null;
  maxLevel?: number | null;
  autoRequestQuantity?: number | null;
  model?: string | null;
  deliveryPeriodDays?: number | null;
  concentration?: number | null;
  isBatch?: boolean | null;
  isSerial?: boolean | null;
  avgCost?: number | null;
  axSynced?: boolean | null;
  idelPeriod?: number | null;
  lastPurchasePrice?: number | null;
  isScrap?: boolean | null;
  itemQuantityTypeFK?: number | null;
  materialCategoryFK?: number | null;
  materialSubCategoryFK?: number | null;
  isDisabled: boolean;
  density?: number | null;
  volumeSolid?: number | null;
  spreadingRate?: number | null;
  dft?: number | null;
  packing?: number | null;
  itemCode?: string | null;
  isActive: boolean;
}

export interface InventoryItem extends InventoryItemPayload {
  id: number;
  isDeleted: boolean;
}
