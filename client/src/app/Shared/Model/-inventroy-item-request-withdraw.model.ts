// Generated from WebApi/Controllers/InventroyItemRequestWithdrawController.cs + Domain entity.

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

export interface GetAllInventroyItemRequestWithdrawParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface InventroyItemRequestWithdraw {
  id: number;
  itemTypeFk?: number | null;
  requestNo?: string | null;
  requestDate?: Date | null;
  descriptionEn?: string | null;
  descriptionAr?: string | null;
  isApproved?: boolean | null;
  requestedByFk?: number | null;
  requestedBy?: string | null;
  assignedToUserFk?: number | null;
  itemRequestStatusFk?: number | null;
  workOrderNo?: string | null;
  storeFk?: number | null;
  sentCount?: number | null;
  axsynced?: boolean | null;
  projectFk?: number | null;
  oufk?: number | null;
  itemNeededDate?: Date | null;
  scopeFk?: number | null;
  companyFk?: number | null;
  serviceMainCategoryFk?: number | null;
  siteManagerApproval?: boolean | null;
  siteManagerApprovalUserId?: number | null;
  siteManagerApprovalDateTime?: Date | null;
  warehouseManagerApprovalUserId?: number | null;
  warehouseManagerApprovalDateTime?: Date | null;
  locationFk?: number | null;
  inventoryItemBudgetFk?: number | null;
  sourceTypeId?: number | null;
  entityId?: number | null;
  entityFormula?: string | null;
  receivedFk?: number | null;
  vehicleFk?: number | null;
  lineFk?: number | null;
  sourceEntity?: string | null;
  sourceId?: number | null;
  sectorFk?: number | null;
  costCenterFk?: number | null;
  customerFk?: number | null;
  factoryFk?: number | null;
  factoryLineFk?: number | null;
  assignedToUserFkNavigation?: any | null;
  companyFkNavigation?: any | null;
  createdByNavigation?: any | null;
  itemRequestStatusFkNavigation?: any | null;
  itemTypeFkNavigation?: any | null;
  lastUpdatedByNavigation?: any | null;
  lineFkNavigation?: any | null;
  locationFkNavigation?: any | null;
  oufkNavigation?: any | null;
  projectFkNavigation?: any | null;
  receivedFkNavigation?: any | null;
  requestedByFkNavigation?: any | null;
  scopeFkNavigation?: any | null;
  serviceMainCategoryFkNavigation?: any | null;
  storeFkNavigation?: any | null;
  vehicleFkNavigation?: any | null;
}

export interface CreateInventroyItemRequestWithdraw {
  id: number;
  itemTypeFk?: number | null;
  requestNo?: string | null;
  requestDate?: Date | null;
  descriptionEn?: string | null;
  descriptionAr?: string | null;
  isApproved?: boolean | null;
  requestedByFk?: number | null;
  requestedBy?: string | null;
  assignedToUserFk?: number | null;
  itemRequestStatusFk?: number | null;
  workOrderNo?: string | null;
  storeFk?: number | null;
  sentCount?: number | null;
  axsynced?: boolean | null;
  projectFk?: number | null;
  oufk?: number | null;
  itemNeededDate?: Date | null;
  scopeFk?: number | null;
  companyFk?: number | null;
  serviceMainCategoryFk?: number | null;
  siteManagerApproval?: boolean | null;
  siteManagerApprovalUserId?: number | null;
  siteManagerApprovalDateTime?: Date | null;
  warehouseManagerApprovalUserId?: number | null;
  warehouseManagerApprovalDateTime?: Date | null;
  locationFk?: number | null;
  inventoryItemBudgetFk?: number | null;
  sourceTypeId?: number | null;
  entityId?: number | null;
  entityFormula?: string | null;
  receivedFk?: number | null;
  vehicleFk?: number | null;
  lineFk?: number | null;
  sourceEntity?: string | null;
  sourceId?: number | null;
  sectorFk?: number | null;
  costCenterFk?: number | null;
  customerFk?: number | null;
  factoryFk?: number | null;
  factoryLineFk?: number | null;
  assignedToUserFkNavigation?: any | null;
  companyFkNavigation?: any | null;
  createdByNavigation?: any | null;
  itemRequestStatusFkNavigation?: any | null;
  itemTypeFkNavigation?: any | null;
  lastUpdatedByNavigation?: any | null;
  lineFkNavigation?: any | null;
  locationFkNavigation?: any | null;
  oufkNavigation?: any | null;
  projectFkNavigation?: any | null;
  receivedFkNavigation?: any | null;
  requestedByFkNavigation?: any | null;
  scopeFkNavigation?: any | null;
  serviceMainCategoryFkNavigation?: any | null;
  storeFkNavigation?: any | null;
  vehicleFkNavigation?: any | null;
}

export interface InventroyItemRequestWithdrawPayload {
  itemTypeFk?: number | null;
  requestNo?: string | null;
  requestDate?: Date | null;
  descriptionEn?: string | null;
  descriptionAr?: string | null;
  isApproved?: boolean | null;
  requestedByFk?: number | null;
  requestedBy?: string | null;
  assignedToUserFk?: number | null;
  itemRequestStatusFk?: number | null;
  workOrderNo?: string | null;
  storeFk?: number | null;
  sentCount?: number | null;
  axsynced?: boolean | null;
  projectFk?: number | null;
  oufk?: number | null;
  itemNeededDate?: Date | null;
  scopeFk?: number | null;
  companyFk?: number | null;
  serviceMainCategoryFk?: number | null;
  siteManagerApproval?: boolean | null;
  siteManagerApprovalUserId?: number | null;
  siteManagerApprovalDateTime?: Date | null;
  warehouseManagerApprovalUserId?: number | null;
  warehouseManagerApprovalDateTime?: Date | null;
  locationFk?: number | null;
  inventoryItemBudgetFk?: number | null;
  sourceTypeId?: number | null;
  entityId?: number | null;
  entityFormula?: string | null;
  receivedFk?: number | null;
  vehicleFk?: number | null;
  lineFk?: number | null;
  sourceEntity?: string | null;
  sourceId?: number | null;
  sectorFk?: number | null;
  costCenterFk?: number | null;
  customerFk?: number | null;
  factoryFk?: number | null;
  factoryLineFk?: number | null;
  assignedToUserFkNavigation?: any | null;
  companyFkNavigation?: any | null;
  createdByNavigation?: any | null;
  itemRequestStatusFkNavigation?: any | null;
  itemTypeFkNavigation?: any | null;
  lastUpdatedByNavigation?: any | null;
  lineFkNavigation?: any | null;
  locationFkNavigation?: any | null;
  oufkNavigation?: any | null;
  projectFkNavigation?: any | null;
  receivedFkNavigation?: any | null;
  requestedByFkNavigation?: any | null;
  scopeFkNavigation?: any | null;
  serviceMainCategoryFkNavigation?: any | null;
  storeFkNavigation?: any | null;
  vehicleFkNavigation?: any | null;
}

export interface InventroyItemRequestWithdraw extends InventroyItemRequestWithdrawPayload {
  id: number;
  isDeleted: boolean;
}

