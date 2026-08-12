// Generated from WebApi/Controllers/PurchaseOrderServiceController.cs + Domain entity.

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

export interface GetAllPurchaseOrderServiceParams {
  pageNumber?: number;
  pageSize?: number;
  searchText?: string;
}

export interface PurchaseOrderService {
  id: number;
  orderScreenFk?: number | null;
  poserviceTypeFk?: number | null;
  vendorOrderTypeFk?: number | null;
  vendorFk?: number | null;
  prfk?: number | null;
  orderNo?: string | null;
  requestDate?: Date | null;
  orderDate?: Date | null;
  orderByUserFk?: number | null;
  projectFk?: number | null;
  locationFk?: number | null;
  serviceMainCategoryFk?: number | null;
  scopeFk?: number | null;
  vendorOrderStatusFk?: number | null;
  paymentTermFk?: number | null;
  paymentTerms?: string | null;
  isApproved?: boolean | null;
  duration?: number | null;
  companyFk?: number | null;
  contractId?: number | null;
  startDate?: Date | null;
  endDate?: Date | null;
  contractCode?: string | null;
  totalCost?: number | null;
  description?: string | null;
  inventoryItemBudgetFk?: number | null;
  companyFkNavigation?: any | null;
  locationFkNavigation?: any | null;
  orderScreenFkNavigation?: any | null;
  paymentTermFkNavigation?: any | null;
  poserviceTypeFkNavigation?: any | null;
  prfkNavigation?: any | null;
  projectFkNavigation?: any | null;
  scopeFkNavigation?: any | null;
  serviceMainCategoryFkNavigation?: any | null;
  vendorFkNavigation?: any | null;
  vendorOrderStatusFkNavigation?: any | null;
  vendorOrderTypeFkNavigation?: any | null;
}

export interface CreatePurchaseOrderService {
  id: number;
  orderScreenFk?: number | null;
  poserviceTypeFk?: number | null;
  vendorOrderTypeFk?: number | null;
  vendorFk?: number | null;
  prfk?: number | null;
  orderNo?: string | null;
  requestDate?: Date | null;
  orderDate?: Date | null;
  orderByUserFk?: number | null;
  projectFk?: number | null;
  locationFk?: number | null;
  serviceMainCategoryFk?: number | null;
  scopeFk?: number | null;
  vendorOrderStatusFk?: number | null;
  paymentTermFk?: number | null;
  paymentTerms?: string | null;
  isApproved?: boolean | null;
  duration?: number | null;
  companyFk?: number | null;
  contractId?: number | null;
  startDate?: Date | null;
  endDate?: Date | null;
  contractCode?: string | null;
  totalCost?: number | null;
  description?: string | null;
  inventoryItemBudgetFk?: number | null;
  companyFkNavigation?: any | null;
  locationFkNavigation?: any | null;
  orderScreenFkNavigation?: any | null;
  paymentTermFkNavigation?: any | null;
  poserviceTypeFkNavigation?: any | null;
  prfkNavigation?: any | null;
  projectFkNavigation?: any | null;
  scopeFkNavigation?: any | null;
  serviceMainCategoryFkNavigation?: any | null;
  vendorFkNavigation?: any | null;
  vendorOrderStatusFkNavigation?: any | null;
  vendorOrderTypeFkNavigation?: any | null;
}

export interface PurchaseOrderServicePayload {
  orderScreenFk?: number | null;
  poserviceTypeFk?: number | null;
  vendorOrderTypeFk?: number | null;
  vendorFk?: number | null;
  prfk?: number | null;
  orderNo?: string | null;
  requestDate?: Date | null;
  orderDate?: Date | null;
  orderByUserFk?: number | null;
  projectFk?: number | null;
  locationFk?: number | null;
  serviceMainCategoryFk?: number | null;
  scopeFk?: number | null;
  vendorOrderStatusFk?: number | null;
  paymentTermFk?: number | null;
  paymentTerms?: string | null;
  isApproved?: boolean | null;
  duration?: number | null;
  companyFk?: number | null;
  contractId?: number | null;
  startDate?: Date | null;
  endDate?: Date | null;
  contractCode?: string | null;
  totalCost?: number | null;
  description?: string | null;
  inventoryItemBudgetFk?: number | null;
  companyFkNavigation?: any | null;
  locationFkNavigation?: any | null;
  orderScreenFkNavigation?: any | null;
  paymentTermFkNavigation?: any | null;
  poserviceTypeFkNavigation?: any | null;
  prfkNavigation?: any | null;
  projectFkNavigation?: any | null;
  scopeFkNavigation?: any | null;
  serviceMainCategoryFkNavigation?: any | null;
  vendorFkNavigation?: any | null;
  vendorOrderStatusFkNavigation?: any | null;
  vendorOrderTypeFkNavigation?: any | null;
}

export interface PurchaseOrderService extends PurchaseOrderServicePayload {
  id: number;
  isDeleted: boolean;
}

