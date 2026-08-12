// Always import the base environment: the CLI swaps in
// environment.development.ts for the development configuration.
import { environment } from "../../environments/environment";


export type ModuleEndpoints = {
  GetAll        : string;
  GetById       : (id: string | number) => string;
  Create        : string;
  Update        : (id: number | string) => string;
  Delete        : (id: number | string) => string;
  LookUp?       : string;
  Search?       : string;
  SearchLookUp? : string;
}


function endPoint(module: string) : ModuleEndpoints {
  return {
    GetAll: `${module}/get-all`,
    GetById: (id: string | number) => `${module}/get-by-id/${id}`,
    Create: `${module}/create`,
    Update: (id: string | number) => `${module}/update/${id}`,
    Delete: (id: string | number) => `${module}/delete/${id}`,
    LookUp: `${module}/LookUp`,
    Search: `${module}/Search`,
    SearchLookUp: `${module}/SearchLookUp`,
  };
}

export abstract class Configurations {
  static readonly Url = environment.apiUrl;

  static build(path: string): string {
    return `${Configurations.Url}/${path}`;
  }

  static readonly Country = { ...endPoint('Country') };
  static readonly City = { ...endPoint('City') };
  static readonly InventoryItem =
  {
    ...endPoint('InventoryItem') ,
    getByName: (name: string) => `${Configurations.Url}/InventoryItem/GetByName/${name}`};

  // --- Generated from every controller under /WebApi/Controllers ---
  static readonly AdUser = { ...endPoint('AdUser') };
  static readonly AirFilterType = { ...endPoint('AirFilterType') };
  static readonly AllowedCompany = { ...endPoint('AllowedCompany') };
  static readonly AnnualStockCount = { ...endPoint('AnnualStockCount') };
  static readonly AnnualStockCountItemMerge = { ...endPoint('AnnualStockCountItemMerge') };
  static readonly AnnualStockCountItemQuantity = { ...endPoint('AnnualStockCountItemQuantity') };
  static readonly ApprovalMatrix = { ...endPoint('ApprovalMatrix') };
  static readonly ApprovalMatrixConfig = { ...endPoint('ApprovalMatrixConfig') };
  static readonly ApprovalMatrixConfigDetail = { ...endPoint('ApprovalMatrixConfigDetail') };
  static readonly ApprovalMatrixDetail = { ...endPoint('ApprovalMatrixDetail') };
  static readonly ApprovalMatrixRange = { ...endPoint('ApprovalMatrixRange') };
  static readonly ApprovalScreen = { ...endPoint('ApprovalScreen') };
  static readonly ApprovalStatus = { ...endPoint('ApprovalStatus') };
  static readonly Asset = { ...endPoint('Asset') };
  static readonly AssetAttachment = { ...endPoint('AssetAttachment') };
  static readonly AssetCommissioning = { ...endPoint('AssetCommissioning') };
  static readonly AssetCompline = { ...endPoint('AssetCompline') };
  static readonly AssetComponent = { ...endPoint('AssetComponent') };
  static readonly AssetCount = { ...endPoint('AssetCount') };
  static readonly AssetCountDetail = { ...endPoint('AssetCountDetail') };
  static readonly AssetCountIssue = { ...endPoint('AssetCountIssue') };
  static readonly AssetCountIssueStatus = { ...endPoint('AssetCountIssueStatus') };
  static readonly AssetCountPlan = { ...endPoint('AssetCountPlan') };
  static readonly AssetCountPlanDetail = { ...endPoint('AssetCountPlanDetail') };
  static readonly AssetCountPlanStatus = { ...endPoint('AssetCountPlanStatus') };
  static readonly AssetCountPlanType = { ...endPoint('AssetCountPlanType') };
  static readonly AssetCountStatus = { ...endPoint('AssetCountStatus') };
  static readonly AssetDisposed = { ...endPoint('AssetDisposed') };
  static readonly AssetFunctionality = { ...endPoint('AssetFunctionality') };
  static readonly AssetItem = { ...endPoint('AssetItem') };
  static readonly AssetItemAttachment = { ...endPoint('AssetItemAttachment') };
  static readonly AssetItemMaintenance = { ...endPoint('AssetItemMaintenance') };
  static readonly AssetItemMove = { ...endPoint('AssetItemMove') };
  static readonly AssetItemScrap = { ...endPoint('AssetItemScrap') };
  static readonly AssetMaintenanceStatus = { ...endPoint('AssetMaintenanceStatus') };
  static readonly AssetMoveType = { ...endPoint('AssetMoveType') };
  static readonly AssetScrapStatus = { ...endPoint('AssetScrapStatus') };
  static readonly AssetsGroup = { ...endPoint('AssetsGroup') };
  static readonly AssetStatus = { ...endPoint('AssetStatus') };
  static readonly AssetsType = { ...endPoint('AssetsType') };
  static readonly AssetWarrantyStatus = { ...endPoint('AssetWarrantyStatus') };
  static readonly AssignAssetTypeToAssetGroup = { ...endPoint('AssignAssetTypeToAssetGroup') };
  static readonly AssignCostCenterToSector = { ...endPoint('AssignCostCenterToSector') };
  static readonly AssignSiteSection = { ...endPoint('AssignSiteSection') };
  static readonly AssignVendorEvaluationCriterion = { ...endPoint('AssignVendorEvaluationCriterion') };
  static readonly AssignVendorSpecialization = { ...endPoint('AssignVendorSpecialization') };
  static readonly AuditTrail = { ...endPoint('AuditTrail') };
  static readonly AuditTrailDetail = { ...endPoint('AuditTrailDetail') };
  static readonly BatteryType = { ...endPoint('BatteryType') };
  static readonly ChemicalGroup = { ...endPoint('ChemicalGroup') };
  static readonly Classifications = { ...endPoint('Classifications') };
  static readonly CommissionCondition = { ...endPoint('CommissionCondition') };
  static readonly Company = { ...endPoint('Company') };
  static readonly Contact = { ...endPoint('Contact') };
  static readonly Contacts = { ...endPoint('Contacts') };
  static readonly ContactType = { ...endPoint('ContactType') };
  static readonly CostCenter = { ...endPoint('CostCenter') };
  static readonly Customer = { ...endPoint('Customer') };
  static readonly DaysOfWeek = { ...endPoint('DaysOfWeek') };
  static readonly Employee = { ...endPoint('Employee') };
  static readonly EmployeeJob = { ...endPoint('EmployeeJob') };
  static readonly EngineSize = { ...endPoint('EngineSize') };
  static readonly EquipmentCode = { ...endPoint('EquipmentCode') };
  static readonly Expense = { ...endPoint('Expense') };
  static readonly Factory = { ...endPoint('Factory') };
  static readonly FactoryLine = { ...endPoint('FactoryLine') };
  static readonly Gender = { ...endPoint('Gender') };
  static readonly InsuranceVendor = { ...endPoint('InsuranceVendor') };
  static readonly InventoryCurrency = { ...endPoint('InventoryCurrency') };
  static readonly InventoryItemAsset = { ...endPoint('InventoryItemAsset') };
  static readonly InventoryItemBudget = { ...endPoint('InventoryItemBudget') };
  static readonly InventoryItemBudgetDetail = { ...endPoint('InventoryItemBudgetDetail') };
  static readonly InventoryItemCost = { ...endPoint('InventoryItemCost') };
  static readonly InventoryItemEquivalentSp = { ...endPoint('InventoryItemEquivalentSp') };
  static readonly InventoryItemLocation = { ...endPoint('InventoryItemLocation') };
  static readonly InventoryItemLocationBatch = { ...endPoint('InventoryItemLocationBatch') };
  static readonly InventoryItemLocationBatchSerial = { ...endPoint('InventoryItemLocationBatchSerial') };
  static readonly InventoryItemLocationDetail = { ...endPoint('InventoryItemLocationDetail') };
  static readonly InventoryItemReturn = { ...endPoint('InventoryItemReturn') };
  static readonly InventoryItemReturnAttachment = { ...endPoint('InventoryItemReturnAttachment') };
  static readonly InventoryItemReturnBatch = { ...endPoint('InventoryItemReturnBatch') };
  static readonly InventoryItemReturnBatchSerial = { ...endPoint('InventoryItemReturnBatchSerial') };
  static readonly InventoryItemReturnDetail = { ...endPoint('InventoryItemReturnDetail') };
  static readonly InventoryItemReturnSerial = { ...endPoint('InventoryItemReturnSerial') };
  static readonly InventoryItemSerial = { ...endPoint('InventoryItemSerial') };
  static readonly InventoryItemSerialStatus = { ...endPoint('InventoryItemSerialStatus') };
  static readonly InventoryItemStatus = { ...endPoint('InventoryItemStatus') };
  static readonly InventoryItemTransactionType = { ...endPoint('InventoryItemTransactionType') };
  static readonly InventoryItemTrasnsactionType = { ...endPoint('InventoryItemTrasnsactionType') };
  static readonly InventoryItemUoM = { ...endPoint('InventoryItemUoM') };
  static readonly InventoryItemVendor = { ...endPoint('InventoryItemVendor') };
  static readonly InventoryStockCount = { ...endPoint('InventoryStockCount') };
  static readonly InventoryStockCountDetail = { ...endPoint('InventoryStockCountDetail') };
  static readonly InventoryStockCountDetailBatch = { ...endPoint('InventoryStockCountDetailBatch') };
  static readonly InventoryStockCountDetailBatchSerial = { ...endPoint('InventoryStockCountDetailBatchSerial') };
  static readonly InventoryStockCountPlan = { ...endPoint('InventoryStockCountPlan') };
  static readonly InventoryStockCountPlanDetail = { ...endPoint('InventoryStockCountPlanDetail') };
  static readonly InventoryStockCountStatus = { ...endPoint('InventoryStockCountStatus') };
  static readonly InventoryTransfere = { ...endPoint('InventoryTransfere') };
  static readonly InventoryTransfereAttachment = { ...endPoint('InventoryTransfereAttachment') };
  static readonly InventoryTransfereDetail = { ...endPoint('InventoryTransfereDetail') };
  static readonly InventoryTransfereDetailBatch = { ...endPoint('InventoryTransfereDetailBatch') };
  static readonly InventoryTransfereDetailBatchSerial = { ...endPoint('InventoryTransfereDetailBatchSerial') };
  static readonly InventoryTransfereSerial = { ...endPoint('InventoryTransfereSerial') };
  static readonly InventoryYear = { ...endPoint('InventoryYear') };
  static readonly InventroyItemRequestWithdraw = { ...endPoint('InventroyItemRequestWithdraw') };
  static readonly InventroyItemRequestWithdrawAttachment = { ...endPoint('InventroyItemRequestWithdrawAttachment') };
  static readonly InventroyItemRequestWithdrawDetail = { ...endPoint('InventroyItemRequestWithdrawDetail') };
  static readonly Isle = { ...endPoint('Isle') };
  static readonly ItemBalanceStatus = { ...endPoint('ItemBalanceStatus') };
  static readonly ItemExpiryType = { ...endPoint('ItemExpiryType') };
  static readonly ItemQuantityType = { ...endPoint('ItemQuantityType') };
  static readonly ItemRequestStatus = { ...endPoint('ItemRequestStatus') };
  static readonly ItemType = { ...endPoint('ItemType') };
  static readonly Language = { ...endPoint('Language') };
  static readonly Line = { ...endPoint('Line') };
  static readonly Location = { ...endPoint('Location') };
  static readonly Manufacture = { ...endPoint('Manufacture') };
  static readonly MaterialCategory = { ...endPoint('MaterialCategory') };
  static readonly MaterialGroup = { ...endPoint('MaterialGroup') };
  static readonly MaterialSubCategory = { ...endPoint('MaterialSubCategory') };
  static readonly ModuleSetting = { ...endPoint('ModuleSetting') };
  static readonly Narrators = { ...endPoint('Narrators') };
  static readonly Notification = { ...endPoint('Notification') };
  static readonly NotificationLog = { ...endPoint('NotificationLog') };
  static readonly NotificationPlaceHolder = { ...endPoint('NotificationPlaceHolder') };
  static readonly NotificationState = { ...endPoint('NotificationState') };
  static readonly NotificationTemplate = { ...endPoint('NotificationTemplate') };
  static readonly NotificationTemplateContact = { ...endPoint('NotificationTemplateContact') };
  static readonly NotificationType = { ...endPoint('NotificationType') };
  static readonly Oil = { ...endPoint('Oil') };
  static readonly OrderLineItemStatus = { ...endPoint('OrderLineItemStatus') };
  static readonly Ou = { ...endPoint('Ou') };
  static readonly Ownership = { ...endPoint('Ownership') };
  static readonly Partitions = { ...endPoint('Partitions') };
  static readonly PaymentTerm = { ...endPoint('PaymentTerm') };
  static readonly Pdaassignment = { ...endPoint('Pdaassignment') };
  static readonly Pdadetail = { ...endPoint('Pdadetail') };
  static readonly Pdamodel = { ...endPoint('Pdamodel') };
  static readonly PdarequestsLog = { ...endPoint('PdarequestsLog') };
  static readonly PoserviceAsset = { ...endPoint('PoserviceAsset') };
  static readonly PoserviceDetail = { ...endPoint('PoserviceDetail') };
  static readonly PoserviceOutsource = { ...endPoint('PoserviceOutsource') };
  static readonly PoserviceRecomendedResource = { ...endPoint('PoserviceRecomendedResource') };
  static readonly PoserviceTermsAndCondition = { ...endPoint('PoserviceTermsAndCondition') };
  static readonly PoserviceType = { ...endPoint('PoserviceType') };
  static readonly PossessionType = { ...endPoint('PossessionType') };
  static readonly Project = { ...endPoint('Project') };
  static readonly Pruser = { ...endPoint('Pruser') };
  static readonly PurchaseOrderService = { ...endPoint('PurchaseOrderService') };
  static readonly PurchaseOrderServiceAttachment = { ...endPoint('PurchaseOrderServiceAttachment') };
  static readonly Rack = { ...endPoint('Rack') };
  static readonly Rank = { ...endPoint('Rank') };
  static readonly RequestLineItemStatus = { ...endPoint('RequestLineItemStatus') };
  static readonly RequestWithdrawSerial = { ...endPoint('RequestWithdrawSerial') };
  static readonly ReturnReason = { ...endPoint('ReturnReason') };
  static readonly ReturnStatus = { ...endPoint('ReturnStatus') };
  static readonly RwDeliveredBatch = { ...endPoint('RwDeliveredBatch') };
  static readonly RwDeliveredQuantity = { ...endPoint('RwDeliveredQuantity') };
  static readonly RwDeliveredSerial = { ...endPoint('RwDeliveredSerial') };
  static readonly RwPickedBatch = { ...endPoint('RwPickedBatch') };
  static readonly RwPickedQuantity = { ...endPoint('RwPickedQuantity') };
  static readonly RwPickedSerial = { ...endPoint('RwPickedSerial') };
  static readonly SalesInvoice = { ...endPoint('SalesInvoice') };
  static readonly SalesInvoiceItem = { ...endPoint('SalesInvoiceItem') };
  static readonly SalesQuotation = { ...endPoint('SalesQuotation') };
  static readonly SalesQuotationDetail = { ...endPoint('SalesQuotationDetail') };
  static readonly Scope = { ...endPoint('Scope') };
  static readonly SecConfiguration = { ...endPoint('SecConfiguration') };
  static readonly SecModel = { ...endPoint('SecModel') };
  static readonly SecModelAttribute = { ...endPoint('SecModelAttribute') };
  static readonly SecModule = { ...endPoint('SecModule') };
  static readonly SecProperty = { ...endPoint('SecProperty') };
  static readonly SecRole = { ...endPoint('SecRole') };
  static readonly SecRoleModelAttribute = { ...endPoint('SecRoleModelAttribute') };
  static readonly SecRoleModule = { ...endPoint('SecRoleModule') };
  static readonly SecRoleProperty = { ...endPoint('SecRoleProperty') };
  static readonly SecRoleSecurableValue = { ...endPoint('SecRoleSecurableValue') };
  static readonly SecRoleViewAction = { ...endPoint('SecRoleViewAction') };
  static readonly Section = { ...endPoint('Section') };
  static readonly Sector = { ...endPoint('Sector') };
  static readonly SecUserModelAtrribute = { ...endPoint('SecUserModelAtrribute') };
  static readonly SecUserModule = { ...endPoint('SecUserModule') };
  static readonly SecUserProperty = { ...endPoint('SecUserProperty') };
  static readonly SecUserSecurableValue = { ...endPoint('SecUserSecurableValue') };
  static readonly SecUserViewAction = { ...endPoint('SecUserViewAction') };
  static readonly SecView = { ...endPoint('SecView') };
  static readonly SecViewAction = { ...endPoint('SecViewAction') };
  static readonly SecViewController = { ...endPoint('SecViewController') };
  static readonly Service = { ...endPoint('Service') };
  static readonly ServiceCategory = { ...endPoint('ServiceCategory') };
  static readonly ServiceMainCategory = { ...endPoint('ServiceMainCategory') };
  static readonly ServiceSubCategory = { ...endPoint('ServiceSubCategory') };
  static readonly ServiceType = { ...endPoint('ServiceType') };
  static readonly Sharhs = { ...endPoint('Sharhs') };
  static readonly Shelf = { ...endPoint('Shelf') };
  static readonly Sitemap = { ...endPoint('Sitemap') };
  static readonly SparePartGroup = { ...endPoint('SparePartGroup') };
  static readonly State = { ...endPoint('State') };
  static readonly StockCountPlanStatus = { ...endPoint('StockCountPlanStatus') };
  static readonly StockCountPlanType = { ...endPoint('StockCountPlanType') };
  static readonly Store = { ...endPoint('Store') };
  static readonly StoreKeeper = { ...endPoint('StoreKeeper') };
  static readonly StoreSequence = { ...endPoint('StoreSequence') };
  static readonly SubSection = { ...endPoint('SubSection') };
  static readonly SysKeyValue = { ...endPoint('SysKeyValue') };
  static readonly TermsAndCondition = { ...endPoint('TermsAndCondition') };
  static readonly ToolsType = { ...endPoint('ToolsType') };
  static readonly TransfereType = { ...endPoint('TransfereType') };
  static readonly TransferReason = { ...endPoint('TransferReason') };
  static readonly TransferStatus = { ...endPoint('TransferStatus') };
  static readonly TransmissionType = { ...endPoint('TransmissionType') };
  static readonly UnitOfMeasure = { ...endPoint('UnitOfMeasure') };
  static readonly User = { ...endPoint('User') };
  static readonly UserSessionInfo = { ...endPoint('UserSessionInfo') };
  static readonly UserSessionInfoDetail = { ...endPoint('UserSessionInfoDetail') };
  static readonly Vehicle = { ...endPoint('Vehicle') };
  static readonly VehicleBrand = { ...endPoint('VehicleBrand') };
  static readonly VehicleColor = { ...endPoint('VehicleColor') };
  static readonly VehicleModel = { ...endPoint('VehicleModel') };
  static readonly VehicleOption = { ...endPoint('VehicleOption') };
  static readonly VehicleStatus = { ...endPoint('VehicleStatus') };
  static readonly VehicleType = { ...endPoint('VehicleType') };
  static readonly Vendor = { ...endPoint('Vendor') };
  static readonly VendorEvaluationCriterion = { ...endPoint('VendorEvaluationCriterion') };
  static readonly VendorOrder = { ...endPoint('VendorOrder') };
  static readonly VendorOrderAttachment = { ...endPoint('VendorOrderAttachment') };
  static readonly VendorOrderDetail = { ...endPoint('VendorOrderDetail') };
  static readonly VendorOrderPartiallyReceivedNote = { ...endPoint('VendorOrderPartiallyReceivedNote') };
  static readonly VendorOrderQuality = { ...endPoint('VendorOrderQuality') };
  static readonly VendorOrderQualityAttachment = { ...endPoint('VendorOrderQualityAttachment') };
  static readonly VendorOrderQualityDetail = { ...endPoint('VendorOrderQualityDetail') };
  static readonly VendorOrderQualityDetailBatch = { ...endPoint('VendorOrderQualityDetailBatch') };
  static readonly VendorOrderReceive = { ...endPoint('VendorOrderReceive') };
  static readonly VendorOrderReceiveAttachment = { ...endPoint('VendorOrderReceiveAttachment') };
  static readonly VendorOrderReceiveDetail = { ...endPoint('VendorOrderReceiveDetail') };
  static readonly VendorOrderReceiveDetailBatch = { ...endPoint('VendorOrderReceiveDetailBatch') };
  static readonly VendorOrderReceiveDetailBatchSerial = { ...endPoint('VendorOrderReceiveDetailBatchSerial') };
  static readonly VendorOrderReceiveSerial = { ...endPoint('VendorOrderReceiveSerial') };
  static readonly VendorOrderScreen = { ...endPoint('VendorOrderScreen') };
  static readonly VendorOrderStatus = { ...endPoint('VendorOrderStatus') };
  static readonly VendorOrderType = { ...endPoint('VendorOrderType') };
  static readonly VendorOrderVendorSelection = { ...endPoint('VendorOrderVendorSelection') };
  static readonly VendorOrderVendorSuggested = { ...endPoint('VendorOrderVendorSuggested') };
  static readonly VendorReturn = { ...endPoint('VendorReturn') };
  static readonly VendorReturnAttachment = { ...endPoint('VendorReturnAttachment') };
  static readonly VendorReturnDetail = { ...endPoint('VendorReturnDetail') };
  static readonly VendorReturnDetailBatch = { ...endPoint('VendorReturnDetailBatch') };
  static readonly VendorReturnDetailBatchSerial = { ...endPoint('VendorReturnDetailBatchSerial') };
  static readonly VendorReturnSerial = { ...endPoint('VendorReturnSerial') };
  static readonly VendorSpecialization = { ...endPoint('VendorSpecialization') };
  static readonly VendorStatus = { ...endPoint('VendorStatus') };
  static readonly VendorType = { ...endPoint('VendorType') };
  static readonly ViewRequestStatus = { ...endPoint('ViewRequestStatus') };
  static readonly Visit = { ...endPoint('Visit') };
  static readonly WarrantyStatus = { ...endPoint('WarrantyStatus') };
  static readonly Warehouse = { ...endPoint('Warehouse') };
  static readonly WarehouseType = { ...endPoint('WarehouseType') };
  static readonly StorageUnit = { ...endPoint('StorageUnit') };
  static readonly WorkerType = { ...endPoint('WorkerType') };
  static readonly WsLastSyncTable = { ...endPoint('WsLastSyncTable') };
  static readonly Zone = { ...endPoint('Zone') };
  static readonly ZoneStatus = { ...endPoint('ZoneStatus') };
}
