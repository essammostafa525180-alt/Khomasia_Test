using Domain.Abstractions;
using Domain.Entities;
using Domain.Primitives;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Domain.Aggregates.AssetAggregate;
using Domain.Aggregates.AuditAggregate;
using Domain.Aggregates.CompanyAggregate;
using Domain.Aggregates.InventoryItemAggregate;
using Domain.Aggregates.InventoryStockCountAggregate;
using Domain.Aggregates.InventoryTransfereAggregate;
using Domain.Aggregates.LocationAggregate;
using Domain.Aggregates.NotificationAggregate;
using Domain.Aggregates.PdaAggregate;
using Domain.Aggregates.RequestAggregate;
using Domain.Aggregates.SalesAggregate;
using Domain.Aggregates.SecurityAggregate;
using Domain.Aggregates.SiteAggregate;
using Domain.Aggregates.StoreAggregate;
using Domain.Aggregates.UserAggregate;
using Domain.Aggregates.VehicleAggregate;
using Domain.Aggregates.VendorAggregate;
using Domain.Aggregates.VendorOrderAggregate;
using Domain.Aggregates.VendorReturnAggregate;
using Domain.Aggregates.ZoneAggregate;

namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;
    private readonly IMediator _mediator;



    public IRepository<ContactMessage, int> ContactMessageRepository { get; set; }



    public IRepository<AdUser, int> AdUserRepository { get; set; }
    public IRepository<AirFilterType, int> AirFilterTypeRepository { get; set; }
    public IRepository<AllowedCompany, int> AllowedCompanyRepository { get; set; }
    public IRepository<AnnualStockCount, int> AnnualStockCountRepository { get; set; }
    public IRepository<AnnualStockCountItemMerge, int> AnnualStockCountItemMergeRepository { get; set; }
    public IRepository<AnnualStockCountItemQuantity, int> AnnualStockCountItemQuantityRepository { get; set; }
    public IRepository<ApprovalMatrix, int> ApprovalMatrixRepository { get; set; }
    public IRepository<ApprovalMatrixConfig, int> ApprovalMatrixConfigRepository { get; set; }
    public IRepository<ApprovalMatrixConfigDetail, int> ApprovalMatrixConfigDetailRepository { get; set; }
    public IRepository<ApprovalMatrixDetail, int> ApprovalMatrixDetailRepository { get; set; }
    public IRepository<ApprovalMatrixRange, int> ApprovalMatrixRangeRepository { get; set; }
    public IRepository<ApprovalScreen, int> ApprovalScreenRepository { get; set; }
    public IRepository<ApprovalStatus, int> ApprovalStatusRepository { get; set; }
    public IRepository<Asset, int> AssetRepository { get; set; }
    public IRepository<AssetAttachment, int> AssetAttachmentRepository { get; set; }
    public IRepository<AssetCommissioning, int> AssetCommissioningRepository { get; set; }
    public IRepository<AssetCompline, int> AssetComplineRepository { get; set; }
    public IRepository<AssetComponent, int> AssetComponentRepository { get; set; }
    public IRepository<AssetCount, int> AssetCountRepository { get; set; }
    public IRepository<AssetCountDetail, int> AssetCountDetailRepository { get; set; }
    public IRepository<AssetCountIssue, int> AssetCountIssueRepository { get; set; }
    public IRepository<AssetCountIssueStatus, int> AssetCountIssueStatusRepository { get; set; }
    public IRepository<AssetCountPlan, int> AssetCountPlanRepository { get; set; }
    public IRepository<AssetCountPlanDetail, int> AssetCountPlanDetailRepository { get; set; }
    public IRepository<AssetCountPlanStatus, int> AssetCountPlanStatusRepository { get; set; }
    public IRepository<AssetCountPlanType, int> AssetCountPlanTypeRepository { get; set; }
    public IRepository<AssetCountStatus, int> AssetCountStatusRepository { get; set; }
    public IRepository<AssetDisposed, int> AssetDisposedRepository { get; set; }
    public IRepository<AssetFunctionality, int> AssetFunctionalityRepository { get; set; }
    public IRepository<AssetItem, int> AssetItemRepository { get; set; }
    public IRepository<AssetItemAttachment, int> AssetItemAttachmentRepository { get; set; }
    public IRepository<AssetItemMaintenance, int> AssetItemMaintenanceRepository { get; set; }
    public IRepository<AssetItemMove, int> AssetItemMoveRepository { get; set; }
    public IRepository<AssetItemScrap, int> AssetItemScrapRepository { get; set; }
    public IRepository<AssetMaintenanceStatus, int> AssetMaintenanceStatusRepository { get; set; }
    public IRepository<AssetMoveType, int> AssetMoveTypeRepository { get; set; }
    public IRepository<AssetScrapStatus, int> AssetScrapStatusRepository { get; set; }
    public IRepository<AssetsGroup, int> AssetsGroupRepository { get; set; }
    public IRepository<AssetStatus, int> AssetStatusRepository { get; set; }
    public IRepository<AssetsType, int> AssetsTypeRepository { get; set; }
    public IRepository<AssetWarrantyStatus, int> AssetWarrantyStatusRepository { get; set; }
    public IRepository<AssignAssetTypeToAssetGroup, int> AssignAssetTypeToAssetGroupRepository { get; set; }
    public IRepository<AssignCostCenterToSector, int> AssignCostCenterToSectorRepository { get; set; }
    public IRepository<AssignSiteSection, int> AssignSiteSectionRepository { get; set; }
    public IRepository<AssignVendorEvaluationCriterion, int> AssignVendorEvaluationCriterionRepository { get; set; }
    public IRepository<AssignVendorSpecialization, int> AssignVendorSpecializationRepository { get; set; }
    public IRepository<AuditTrail, int> AuditTrailRepository { get; set; }
    public IRepository<AuditTrailDetail, int> AuditTrailDetailRepository { get; set; }
    public IRepository<BatteryType, int> BatteryTypeRepository { get; set; }
    public IRepository<ChemicalGroup, int> ChemicalGroupRepository { get; set; }
    public IRepository<City, int> CityRepository { get; set; }
    public IRepository<CommissionCondition, int> CommissionConditionRepository { get; set; }
    public IRepository<Company, int> CompanyRepository { get; set; }
    public IRepository<Contact, int> ContactRepository { get; set; }
    public IRepository<ContactType, int> ContactTypeRepository { get; set; }
    public IRepository<CostCenter, int> CostCenterRepository { get; set; }
    public IRepository<Country, int> CountryRepository { get; set; }
    public IRepository<Customer, int> CustomerRepository { get; set; }
    public IRepository<DaysOfWeek, int> DaysOfWeekRepository { get; set; }
    public IRepository<Employee, int> EmployeeRepository { get; set; }
    public IRepository<EmployeeJob, int> EmployeeJobRepository { get; set; }
    public IRepository<EngineSize, int> EngineSizeRepository { get; set; }
    public IRepository<EquipmentCode, int> EquipmentCodeRepository { get; set; }
    public IRepository<Expense, int> ExpenseRepository { get; set; }
    public IRepository<Factory, int> FactoryRepository { get; set; }
    public IRepository<FactoryLine, int> FactoryLineRepository { get; set; }
    public IRepository<Gender, int> GenderRepository { get; set; }
    public IRepository<InsuranceVendor, int> InsuranceVendorRepository { get; set; }
    public IRepository<InventoryCurrency, int> InventoryCurrencyRepository { get; set; }
    public IRepository<InventoryItem, long> InventoryItemRepository { get; set; }
    public IRepository<InventoryItemAsset, int> InventoryItemAssetRepository { get; set; }
    public IRepository<InventoryItemBudget, int> InventoryItemBudgetRepository { get; set; }
    public IRepository<InventoryItemBudgetDetail, int> InventoryItemBudgetDetailRepository { get; set; }
    public IRepository<InventoryItemCost, int> InventoryItemCostRepository { get; set; }
    public IRepository<InventoryItemEquivalentSp, int> InventoryItemEquivalentSpRepository { get; set; }
    public IRepository<InventoryItemLocation, int> InventoryItemLocationRepository { get; set; }
    public IRepository<InventoryItemLocationBatch, int> InventoryItemLocationBatchRepository { get; set; }
    public IRepository<InventoryItemLocationBatchSerial, int> InventoryItemLocationBatchSerialRepository { get; set; }
    public IRepository<InventoryItemLocationDetail, int> InventoryItemLocationDetailRepository { get; set; }
    public IRepository<InventoryItemReturn, int> InventoryItemReturnRepository { get; set; }
    public IRepository<InventoryItemReturnAttachment, int> InventoryItemReturnAttachmentRepository { get; set; }
    public IRepository<InventoryItemReturnBatch, int> InventoryItemReturnBatchRepository { get; set; }
    public IRepository<InventoryItemReturnBatchSerial, int> InventoryItemReturnBatchSerialRepository { get; set; }
    public IRepository<InventoryItemReturnDetail, int> InventoryItemReturnDetailRepository { get; set; }
    public IRepository<InventoryItemReturnSerial, int> InventoryItemReturnSerialRepository { get; set; }
    public IRepository<InventoryItemSerial, int> InventoryItemSerialRepository { get; set; }
    public IRepository<InventoryItemSerialStatus, int> InventoryItemSerialStatusRepository { get; set; }
    public IRepository<InventoryItemStatus, int> InventoryItemStatusRepository { get; set; }
    public IRepository<InventoryItemTransactionType, int> InventoryItemTransactionTypeRepository { get; set; }
    public IRepository<InventoryItemTrasnsactionType, int> InventoryItemTrasnsactionTypeRepository { get; set; }
    public IRepository<InventoryItemUoM, int> InventoryItemUoMRepository { get; set; }
    public IRepository<InventoryItemVendor, int> InventoryItemVendorRepository { get; set; }
    public IRepository<InventoryStockCount, int> InventoryStockCountRepository { get; set; }
    public IRepository<InventoryStockCountDetail, int> InventoryStockCountDetailRepository { get; set; }
    public IRepository<InventoryStockCountDetailBatch, int> InventoryStockCountDetailBatchRepository { get; set; }
    public IRepository<InventoryStockCountDetailBatchSerial, int> InventoryStockCountDetailBatchSerialRepository { get; set; }
    public IRepository<InventoryStockCountPlan, int> InventoryStockCountPlanRepository { get; set; }
    public IRepository<InventoryStockCountPlanDetail, int> InventoryStockCountPlanDetailRepository { get; set; }
    public IRepository<InventoryStockCountStatus, int> InventoryStockCountStatusRepository { get; set; }
    public IRepository<InventoryTransfere, int> InventoryTransfereRepository { get; set; }
    public IRepository<InventoryTransfereAttachment, int> InventoryTransfereAttachmentRepository { get; set; }
    public IRepository<InventoryTransfereDetail, int> InventoryTransfereDetailRepository { get; set; }
    public IRepository<InventoryTransfereDetailBatch, int> InventoryTransfereDetailBatchRepository { get; set; }
    public IRepository<InventoryTransfereDetailBatchSerial, int> InventoryTransfereDetailBatchSerialRepository { get; set; }
    public IRepository<InventoryTransfereSerial, int> InventoryTransfereSerialRepository { get; set; }
    public IRepository<InventoryYear, int> InventoryYearRepository { get; set; }
    public IRepository<InventroyItemRequestWithdraw, int> InventroyItemRequestWithdrawRepository { get; set; }
    public IRepository<InventroyItemRequestWithdrawAttachment, int> InventroyItemRequestWithdrawAttachmentRepository { get; set; }
    public IRepository<InventroyItemRequestWithdrawDetail, int> InventroyItemRequestWithdrawDetailRepository { get; set; }
    public IRepository<Isle, int> IsleRepository { get; set; }
    public IRepository<ItemBalanceStatus, int> ItemBalanceStatusRepository { get; set; }
    public IRepository<ItemExpiryType, int> ItemExpiryTypeRepository { get; set; }
    public IRepository<ItemQuantityType, int> ItemQuantityTypeRepository { get; set; }
    public IRepository<ItemRequestStatus, int> ItemRequestStatusRepository { get; set; }
    public IRepository<ItemType, int> ItemTypeRepository { get; set; }
    public IRepository<Language, int> LanguageRepository { get; set; }
    public IRepository<Line, int> LineRepository { get; set; }
    public IRepository<Location, int> LocationRepository { get; set; }
    public IRepository<Manufacture, int> ManufactureRepository { get; set; }
    public IRepository<MaterialCategory, int> MaterialCategoryRepository { get; set; }
    public IRepository<MaterialGroup, int> MaterialGroupRepository { get; set; }
    public IRepository<MaterialSubCategory, int> MaterialSubCategoryRepository { get; set; }
    public IRepository<ModuleSetting, int> ModuleSettingRepository { get; set; }
   
    public IRepository<Notification, int> NotificationRepository { get; set; }
    public IRepository<NotificationLog, int> NotificationLogRepository { get; set; }
    public IRepository<NotificationPlaceHolder, int> NotificationPlaceHolderRepository { get; set; }
    public IRepository<NotificationState, int> NotificationStateRepository { get; set; }
    public IRepository<NotificationTemplate, int> NotificationTemplateRepository { get; set; }
    public IRepository<NotificationTemplateContact, int> NotificationTemplateContactRepository { get; set; }
    public IRepository<NotificationType, int> NotificationTypeRepository { get; set; }
    public IRepository<Oil, int> OilRepository { get; set; }
    public IRepository<OrderLineItemStatus, int> OrderLineItemStatusRepository { get; set; }
    public IRepository<Ou, int> OuRepository { get; set; }
    public IRepository<Ownership, int> OwnershipRepository { get; set; }
    public IRepository<PaymentTerm, int> PaymentTermRepository { get; set; }
    public IRepository<Pdaassignment, int> PdaassignmentRepository { get; set; }
    public IRepository<Pdadetail, int> PdadetailRepository { get; set; }
    public IRepository<Pdamodel, int> PdamodelRepository { get; set; }
    public IRepository<PdarequestsLog, int> PdarequestsLogRepository { get; set; }
    public IRepository<PoserviceAsset, int> PoserviceAssetRepository { get; set; }
    public IRepository<PoserviceDetail, int> PoserviceDetailRepository { get; set; }
    public IRepository<PoserviceOutsource, int> PoserviceOutsourceRepository { get; set; }
    public IRepository<PoserviceRecomendedResource, int> PoserviceRecomendedResourceRepository { get; set; }
    public IRepository<PoserviceTermsAndCondition, int> PoserviceTermsAndConditionRepository { get; set; }
    public IRepository<PoserviceType, int> PoserviceTypeRepository { get; set; }
    public IRepository<PossessionType, int> PossessionTypeRepository { get; set; }
    public IRepository<Project, int> ProjectRepository { get; set; }
    public IRepository<Pruser, int> PruserRepository { get; set; }
    public IRepository<PurchaseOrderService, int> PurchaseOrderServiceRepository { get; set; }
    public IRepository<PurchaseOrderServiceAttachment, int> PurchaseOrderServiceAttachmentRepository { get; set; }
    public IRepository<Rack, int> RackRepository { get; set; }
    public IRepository<Rank, int> RankRepository { get; set; }
    public IRepository<RequestLineItemStatus, int> RequestLineItemStatusRepository { get; set; }
    public IRepository<RequestWithdrawSerial, int> RequestWithdrawSerialRepository { get; set; }
    public IRepository<ReturnReason, int> ReturnReasonRepository { get; set; }
    public IRepository<ReturnStatus, int> ReturnStatusRepository { get; set; }
    public IRepository<RwDeliveredBatch, int> RwDeliveredBatchRepository { get; set; }
    public IRepository<RwDeliveredQuantity, int> RwDeliveredQuantityRepository { get; set; }
    public IRepository<RwDeliveredSerial, int> RwDeliveredSerialRepository { get; set; }
    public IRepository<RwPickedBatch, int> RwPickedBatchRepository { get; set; }
    public IRepository<RwPickedQuantity, int> RwPickedQuantityRepository { get; set; }
    public IRepository<RwPickedSerial, int> RwPickedSerialRepository { get; set; }
    public IRepository<SalesInvoice, int> SalesInvoiceRepository { get; set; }
    public IRepository<SalesInvoiceItem, int> SalesInvoiceItemRepository { get; set; }
    public IRepository<SalesQuotation, int> SalesQuotationRepository { get; set; }
    public IRepository<SalesQuotationDetail, int> SalesQuotationDetailRepository { get; set; }
    public IRepository<Scope, int> ScopeRepository { get; set; }
    public IRepository<SecConfiguration, int> SecConfigurationRepository { get; set; }
    public IRepository<SecModel, int> SecModelRepository { get; set; }
    public IRepository<SecModelAttribute, int> SecModelAttributeRepository { get; set; }
    public IRepository<SecModule, int> SecModuleRepository { get; set; }
    public IRepository<SecProperty, int> SecPropertyRepository { get; set; }
    public IRepository<SecRole, int> SecRoleRepository { get; set; }
    public IRepository<SecRoleModelAttribute, int> SecRoleModelAttributeRepository { get; set; }
    public IRepository<SecRoleModule, int> SecRoleModuleRepository { get; set; }
    public IRepository<SecRoleProperty, int> SecRolePropertyRepository { get; set; }
    public IRepository<SecRoleSecurableValue, int> SecRoleSecurableValueRepository { get; set; }
    public IRepository<SecRoleViewAction, int> SecRoleViewActionRepository { get; set; }
    public IRepository<Section, int> SectionRepository { get; set; }
    public IRepository<Sector, int> SectorRepository { get; set; }
    public IRepository<SecUserModelAtrribute, int> SecUserModelAtrributeRepository { get; set; }
    public IRepository<SecUserModule, int> SecUserModuleRepository { get; set; }
    public IRepository<SecUserProperty, int> SecUserPropertyRepository { get; set; }
    public IRepository<SecUserSecurableValue, int> SecUserSecurableValueRepository { get; set; }
    public IRepository<SecUserViewAction, int> SecUserViewActionRepository { get; set; }
    public IRepository<SecView, int> SecViewRepository { get; set; }
    public IRepository<SecViewAction, int> SecViewActionRepository { get; set; }
    public IRepository<Service, int> ServiceRepository { get; set; }
    public IRepository<ServiceCategory, int> ServiceCategoryRepository { get; set; }
    public IRepository<ServiceMainCategory, int> ServiceMainCategoryRepository { get; set; }
    public IRepository<ServiceSubCategory, int> ServiceSubCategoryRepository { get; set; }
    public IRepository<ServiceType, int> ServiceTypeRepository { get; set; }
    public IRepository<Shelf, int> ShelfRepository { get; set; }
    public IRepository<SparePartGroup, int> SparePartGroupRepository { get; set; }
    public IRepository<State, int> StateRepository { get; set; }
    public IRepository<StockCountPlanStatus, int> StockCountPlanStatusRepository { get; set; }
    public IRepository<StockCountPlanType, int> StockCountPlanTypeRepository { get; set; }
    public IRepository<Store, int> StoreRepository { get; set; }
    public IRepository<StoreKeeper, int> StoreKeeperRepository { get; set; }
    public IRepository<StoreSequence, int> StoreSequenceRepository { get; set; }
    public IRepository<SubSection, int> SubSectionRepository { get; set; }
    public IRepository<SysKeyValue, int> SysKeyValueRepository { get; set; }
    public IRepository<TermsAndCondition, int> TermsAndConditionRepository { get; set; }
    public IRepository<ToolsType, int> ToolsTypeRepository { get; set; }
    public IRepository<TransfereType, int> TransfereTypeRepository { get; set; }
    public IRepository<TransferReason, int> TransferReasonRepository { get; set; }
    public IRepository<TransferStatus, int> TransferStatusRepository { get; set; }
    public IRepository<TransmissionType, int> TransmissionTypeRepository { get; set; }
    public IRepository<UnitOfMeasure, int> UnitOfMeasureRepository { get; set; }
    public IRepository<User, int> UserRepository { get; set; }
    public IRepository<UserSessionInfo, int> UserSessionInfoRepository { get; set; }
    public IRepository<UserSessionInfoDetail, int> UserSessionInfoDetailRepository { get; set; }
    public IRepository<Vehicle, int> VehicleRepository { get; set; }
    public IRepository<VehicleBrand, int> VehicleBrandRepository { get; set; }
    public IRepository<VehicleColor, int> VehicleColorRepository { get; set; }
    public IRepository<VehicleModel, int> VehicleModelRepository { get; set; }
    public IRepository<VehicleOption, int> VehicleOptionRepository { get; set; }
    public IRepository<VehicleStatus, int> VehicleStatusRepository { get; set; }
    public IRepository<VehicleType, int> VehicleTypeRepository { get; set; }
    public IRepository<Vendor, int> VendorRepository { get; set; }
    public IRepository<VendorEvaluationCriterion, int> VendorEvaluationCriterionRepository { get; set; }
    public IRepository<VendorOrder, int> VendorOrderRepository { get; set; }
    public IRepository<VendorOrderAttachment, int> VendorOrderAttachmentRepository { get; set; }
    public IRepository<VendorOrderDetail, int> VendorOrderDetailRepository { get; set; }
    public IRepository<VendorOrderPartiallyReceivedNote, int> VendorOrderPartiallyReceivedNoteRepository { get; set; }
    public IRepository<VendorOrderQuality, int> VendorOrderQualityRepository { get; set; }
    public IRepository<VendorOrderQualityAttachment, int> VendorOrderQualityAttachmentRepository { get; set; }
    public IRepository<VendorOrderQualityDetail, int> VendorOrderQualityDetailRepository { get; set; }
    public IRepository<VendorOrderQualityDetailBatch, int> VendorOrderQualityDetailBatchRepository { get; set; }
    public IRepository<VendorOrderReceive, int> VendorOrderReceiveRepository { get; set; }
    public IRepository<VendorOrderReceiveAttachment, int> VendorOrderReceiveAttachmentRepository { get; set; }
    public IRepository<VendorOrderReceiveDetail, int> VendorOrderReceiveDetailRepository { get; set; }
    public IRepository<VendorOrderReceiveDetailBatch, int> VendorOrderReceiveDetailBatchRepository { get; set; }
    public IRepository<VendorOrderReceiveDetailBatchSerial, int> VendorOrderReceiveDetailBatchSerialRepository { get; set; }
    public IRepository<VendorOrderReceiveSerial, int> VendorOrderReceiveSerialRepository { get; set; }
    public IRepository<VendorOrderScreen, int> VendorOrderScreenRepository { get; set; }
    public IRepository<VendorOrderStatus, int> VendorOrderStatusRepository { get; set; }
    public IRepository<VendorOrderType, int> VendorOrderTypeRepository { get; set; }
    public IRepository<VendorOrderVendorSelection, int> VendorOrderVendorSelectionRepository { get; set; }
    public IRepository<VendorOrderVendorSuggested, int> VendorOrderVendorSuggestedRepository { get; set; }
    public IRepository<VendorReturn, int> VendorReturnRepository { get; set; }
    public IRepository<VendorReturnAttachment, int> VendorReturnAttachmentRepository { get; set; }
    public IRepository<VendorReturnDetail, int> VendorReturnDetailRepository { get; set; }
    public IRepository<VendorReturnDetailBatch, int> VendorReturnDetailBatchRepository { get; set; }
    public IRepository<VendorReturnDetailBatchSerial, int> VendorReturnDetailBatchSerialRepository { get; set; }
    public IRepository<VendorReturnSerial, int> VendorReturnSerialRepository { get; set; }
    public IRepository<VendorSpecialization, int> VendorSpecializationRepository { get; set; }
    public IRepository<VendorStatus, int> VendorStatusRepository { get; set; }
    public IRepository<VendorType, int> VendorTypeRepository { get; set; }
    public IRepository<ViewRequestStatus, int> ViewRequestStatusRepository { get; set; }
    public IRepository<Visit, int> VisitRepository { get; set; }
    public IRepository<WarrantyStatus, int> WarrantyStatusRepository { get; set; }
    public IRepository<WorkerType, int> WorkerTypeRepository { get; set; }
    public IRepository<WsLastSyncTable, int> WsLastSyncTableRepository { get; set; }
    public IRepository<Zone, int> ZoneRepository { get; set; }
    public IRepository<ZoneStatus, int> ZoneStatusRepository { get; set; }
    public IRepository<WarehouseType, int> WarehouseTypeRepository { get; set; }
    public IRepository<Warehouse, int> WarehouseRepository { get; set; }
    public IRepository<StorageUnit, int> StorageUnitRepository { get; set; }

    public UnitOfWork(ApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
        ContactMessageRepository = new Repository<ContactMessage, int>(context);
        AdUserRepository = new Repository<AdUser, int>(context);
        AirFilterTypeRepository = new Repository<AirFilterType, int>(context);
        AllowedCompanyRepository = new Repository<AllowedCompany, int>(context);
        AnnualStockCountRepository = new Repository<AnnualStockCount, int>(context);
        AnnualStockCountItemMergeRepository = new Repository<AnnualStockCountItemMerge, int>(context);
        AnnualStockCountItemQuantityRepository = new Repository<AnnualStockCountItemQuantity, int>(context);
        ApprovalMatrixRepository = new Repository<ApprovalMatrix, int>(context);
        ApprovalMatrixConfigRepository = new Repository<ApprovalMatrixConfig, int>(context);
        ApprovalMatrixConfigDetailRepository = new Repository<ApprovalMatrixConfigDetail, int>(context);
        ApprovalMatrixDetailRepository = new Repository<ApprovalMatrixDetail, int>(context);
        ApprovalMatrixRangeRepository = new Repository<ApprovalMatrixRange, int>(context);
        ApprovalScreenRepository = new Repository<ApprovalScreen, int>(context);
        ApprovalStatusRepository = new Repository<ApprovalStatus, int>(context);
        AssetRepository = new Repository<Asset, int>(context);
        AssetAttachmentRepository = new Repository<AssetAttachment, int>(context);
        AssetCommissioningRepository = new Repository<AssetCommissioning, int>(context);
        AssetComplineRepository = new Repository<AssetCompline, int>(context);
        AssetComponentRepository = new Repository<AssetComponent, int>(context);
        AssetCountRepository = new Repository<AssetCount, int>(context);
        AssetCountDetailRepository = new Repository<AssetCountDetail, int>(context);
        AssetCountIssueRepository = new Repository<AssetCountIssue, int>(context);
        AssetCountIssueStatusRepository = new Repository<AssetCountIssueStatus, int>(context);
        AssetCountPlanRepository = new Repository<AssetCountPlan, int>(context);
        AssetCountPlanDetailRepository = new Repository<AssetCountPlanDetail, int>(context);
        AssetCountPlanStatusRepository = new Repository<AssetCountPlanStatus, int>(context);
        AssetCountPlanTypeRepository = new Repository<AssetCountPlanType, int>(context);
        AssetCountStatusRepository = new Repository<AssetCountStatus, int>(context);
        AssetDisposedRepository = new Repository<AssetDisposed, int>(context);
        AssetFunctionalityRepository = new Repository<AssetFunctionality, int>(context);
        AssetItemRepository = new Repository<AssetItem, int>(context);
        AssetItemAttachmentRepository = new Repository<AssetItemAttachment, int>(context);
        AssetItemMaintenanceRepository = new Repository<AssetItemMaintenance, int>(context);
        AssetItemMoveRepository = new Repository<AssetItemMove, int>(context);
        AssetItemScrapRepository = new Repository<AssetItemScrap, int>(context);
        AssetMaintenanceStatusRepository = new Repository<AssetMaintenanceStatus, int>(context);
        AssetMoveTypeRepository = new Repository<AssetMoveType, int>(context);
        AssetScrapStatusRepository = new Repository<AssetScrapStatus, int>(context);
        AssetsGroupRepository = new Repository<AssetsGroup, int>(context);
        AssetStatusRepository = new Repository<AssetStatus, int>(context);
        AssetsTypeRepository = new Repository<AssetsType, int>(context);
        AssetWarrantyStatusRepository = new Repository<AssetWarrantyStatus, int>(context);
        AssignAssetTypeToAssetGroupRepository = new Repository<AssignAssetTypeToAssetGroup, int>(context);
        AssignCostCenterToSectorRepository = new Repository<AssignCostCenterToSector, int>(context);
        AssignSiteSectionRepository = new Repository<AssignSiteSection, int>(context);
        AssignVendorEvaluationCriterionRepository = new Repository<AssignVendorEvaluationCriterion, int>(context);
        AssignVendorSpecializationRepository = new Repository<AssignVendorSpecialization, int>(context);
        AuditTrailRepository = new Repository<AuditTrail, int>(context);
        AuditTrailDetailRepository = new Repository<AuditTrailDetail, int>(context);
        BatteryTypeRepository = new Repository<BatteryType, int>(context);
        ChemicalGroupRepository = new Repository<ChemicalGroup, int>(context);
        CityRepository = new Repository<City, int>(context);
        CommissionConditionRepository = new Repository<CommissionCondition, int>(context);
        CompanyRepository = new Repository<Company, int>(context);
        ContactRepository = new Repository<Contact, int>(context);
        ContactTypeRepository = new Repository<ContactType, int>(context);
        CostCenterRepository = new Repository<CostCenter, int>(context);
        CountryRepository = new Repository<Country, int>(context);
        CustomerRepository = new Repository<Customer, int>(context);
        DaysOfWeekRepository = new Repository<DaysOfWeek, int>(context);
        EmployeeRepository = new Repository<Employee, int>(context);
        EmployeeJobRepository = new Repository<EmployeeJob, int>(context);
        EngineSizeRepository = new Repository<EngineSize, int>(context);
        EquipmentCodeRepository = new Repository<EquipmentCode, int>(context);
        ExpenseRepository = new Repository<Expense, int>(context);
        FactoryRepository = new Repository<Factory, int>(context);
        FactoryLineRepository = new Repository<FactoryLine, int>(context);
        GenderRepository = new Repository<Gender, int>(context);
        InsuranceVendorRepository = new Repository<InsuranceVendor, int>(context);
        InventoryCurrencyRepository = new Repository<InventoryCurrency, int>(context);
        InventoryItemRepository = new Repository<InventoryItem, long>(context);
        InventoryItemAssetRepository = new Repository<InventoryItemAsset, int>(context);
        InventoryItemBudgetRepository = new Repository<InventoryItemBudget, int>(context);
        InventoryItemBudgetDetailRepository = new Repository<InventoryItemBudgetDetail, int>(context);
        InventoryItemCostRepository = new Repository<InventoryItemCost, int>(context);
        InventoryItemEquivalentSpRepository = new Repository<InventoryItemEquivalentSp, int>(context);
        InventoryItemLocationRepository = new Repository<InventoryItemLocation, int>(context);
        InventoryItemLocationBatchRepository = new Repository<InventoryItemLocationBatch, int>(context);
        InventoryItemLocationBatchSerialRepository = new Repository<InventoryItemLocationBatchSerial, int>(context);
        InventoryItemLocationDetailRepository = new Repository<InventoryItemLocationDetail, int>(context);
        InventoryItemReturnRepository = new Repository<InventoryItemReturn, int>(context);
        InventoryItemReturnAttachmentRepository = new Repository<InventoryItemReturnAttachment, int>(context);
        InventoryItemReturnBatchRepository = new Repository<InventoryItemReturnBatch, int>(context);
        InventoryItemReturnBatchSerialRepository = new Repository<InventoryItemReturnBatchSerial, int>(context);
        InventoryItemReturnDetailRepository = new Repository<InventoryItemReturnDetail, int>(context);
        InventoryItemReturnSerialRepository = new Repository<InventoryItemReturnSerial, int>(context);
        InventoryItemSerialRepository = new Repository<InventoryItemSerial, int>(context);
        InventoryItemSerialStatusRepository = new Repository<InventoryItemSerialStatus, int>(context);
        InventoryItemStatusRepository = new Repository<InventoryItemStatus, int>(context);
        InventoryItemTransactionTypeRepository = new Repository<InventoryItemTransactionType, int>(context);
        InventoryItemTrasnsactionTypeRepository = new Repository<InventoryItemTrasnsactionType, int>(context);
        InventoryItemUoMRepository = new Repository<InventoryItemUoM, int>(context);
        InventoryItemVendorRepository = new Repository<InventoryItemVendor, int>(context);
        InventoryStockCountRepository = new Repository<InventoryStockCount, int>(context);
        InventoryStockCountDetailRepository = new Repository<InventoryStockCountDetail, int>(context);
        InventoryStockCountDetailBatchRepository = new Repository<InventoryStockCountDetailBatch, int>(context);
        InventoryStockCountDetailBatchSerialRepository = new Repository<InventoryStockCountDetailBatchSerial, int>(context);
        InventoryStockCountPlanRepository = new Repository<InventoryStockCountPlan, int>(context);
        InventoryStockCountPlanDetailRepository = new Repository<InventoryStockCountPlanDetail, int>(context);
        InventoryStockCountStatusRepository = new Repository<InventoryStockCountStatus, int>(context);
        InventoryTransfereRepository = new Repository<InventoryTransfere, int>(context);
        InventoryTransfereAttachmentRepository = new Repository<InventoryTransfereAttachment, int>(context);
        InventoryTransfereDetailRepository = new Repository<InventoryTransfereDetail, int>(context);
        InventoryTransfereDetailBatchRepository = new Repository<InventoryTransfereDetailBatch, int>(context);
        InventoryTransfereDetailBatchSerialRepository = new Repository<InventoryTransfereDetailBatchSerial, int>(context);
        InventoryTransfereSerialRepository = new Repository<InventoryTransfereSerial, int>(context);
        InventoryYearRepository = new Repository<InventoryYear, int>(context);
        InventroyItemRequestWithdrawRepository = new Repository<InventroyItemRequestWithdraw, int>(context);
        InventroyItemRequestWithdrawAttachmentRepository = new Repository<InventroyItemRequestWithdrawAttachment, int>(context);
        InventroyItemRequestWithdrawDetailRepository = new Repository<InventroyItemRequestWithdrawDetail, int>(context);
        IsleRepository = new Repository<Isle, int>(context);
        ItemBalanceStatusRepository = new Repository<ItemBalanceStatus, int>(context);
        ItemExpiryTypeRepository = new Repository<ItemExpiryType, int>(context);
        ItemQuantityTypeRepository = new Repository<ItemQuantityType, int>(context);
        ItemRequestStatusRepository = new Repository<ItemRequestStatus, int>(context);
        ItemTypeRepository = new Repository<ItemType, int>(context);
        LanguageRepository = new Repository<Language, int>(context);
        LineRepository = new Repository<Line, int>(context);
        LocationRepository = new Repository<Location, int>(context);
        ManufactureRepository = new Repository<Manufacture, int>(context);
        MaterialCategoryRepository = new Repository<MaterialCategory, int>(context);
        MaterialGroupRepository = new Repository<MaterialGroup, int>(context);
        MaterialSubCategoryRepository = new Repository<MaterialSubCategory, int>(context);
        ModuleSettingRepository = new Repository<ModuleSetting, int>(context);
    
        NotificationRepository = new Repository<Notification, int>(context);
        NotificationLogRepository = new Repository<NotificationLog, int>(context);
        NotificationPlaceHolderRepository = new Repository<NotificationPlaceHolder, int>(context);
        NotificationStateRepository = new Repository<NotificationState, int>(context);
        NotificationTemplateRepository = new Repository<NotificationTemplate, int>(context);
        NotificationTemplateContactRepository = new Repository<NotificationTemplateContact, int>(context);
        NotificationTypeRepository = new Repository<NotificationType, int>(context);
        OilRepository = new Repository<Oil, int>(context);
        OrderLineItemStatusRepository = new Repository<OrderLineItemStatus, int>(context);
        OuRepository = new Repository<Ou, int>(context);
        OwnershipRepository = new Repository<Ownership, int>(context);
        PaymentTermRepository = new Repository<PaymentTerm, int>(context);
        PdaassignmentRepository = new Repository<Pdaassignment, int>(context);
        PdadetailRepository = new Repository<Pdadetail, int>(context);
        PdamodelRepository = new Repository<Pdamodel, int>(context);
        PdarequestsLogRepository = new Repository<PdarequestsLog, int>(context);
        PoserviceAssetRepository = new Repository<PoserviceAsset, int>(context);
        PoserviceDetailRepository = new Repository<PoserviceDetail, int>(context);
        PoserviceOutsourceRepository = new Repository<PoserviceOutsource, int>(context);
        PoserviceRecomendedResourceRepository = new Repository<PoserviceRecomendedResource, int>(context);
        PoserviceTermsAndConditionRepository = new Repository<PoserviceTermsAndCondition, int>(context);
        PoserviceTypeRepository = new Repository<PoserviceType, int>(context);
        PossessionTypeRepository = new Repository<PossessionType, int>(context);
        ProjectRepository = new Repository<Project, int>(context);
        PruserRepository = new Repository<Pruser, int>(context);
        PurchaseOrderServiceRepository = new Repository<PurchaseOrderService, int>(context);
        PurchaseOrderServiceAttachmentRepository = new Repository<PurchaseOrderServiceAttachment, int>(context);
        RackRepository = new Repository<Rack, int>(context);
        RankRepository = new Repository<Rank, int>(context);
        RequestLineItemStatusRepository = new Repository<RequestLineItemStatus, int>(context);
        RequestWithdrawSerialRepository = new Repository<RequestWithdrawSerial, int>(context);
        ReturnReasonRepository = new Repository<ReturnReason, int>(context);
        ReturnStatusRepository = new Repository<ReturnStatus, int>(context);
        RwDeliveredBatchRepository = new Repository<RwDeliveredBatch, int>(context);
        RwDeliveredQuantityRepository = new Repository<RwDeliveredQuantity, int>(context);
        RwDeliveredSerialRepository = new Repository<RwDeliveredSerial, int>(context);
        RwPickedBatchRepository = new Repository<RwPickedBatch, int>(context);
        RwPickedQuantityRepository = new Repository<RwPickedQuantity, int>(context);
        RwPickedSerialRepository = new Repository<RwPickedSerial, int>(context);
        SalesInvoiceRepository = new Repository<SalesInvoice, int>(context);
        SalesInvoiceItemRepository = new Repository<SalesInvoiceItem, int>(context);
        SalesQuotationRepository = new Repository<SalesQuotation, int>(context);
        SalesQuotationDetailRepository = new Repository<SalesQuotationDetail, int>(context);
        ScopeRepository = new Repository<Scope, int>(context);
        SecConfigurationRepository = new Repository<SecConfiguration, int>(context);
        SecModelRepository = new Repository<SecModel, int>(context);
        SecModelAttributeRepository = new Repository<SecModelAttribute, int>(context);
        SecModuleRepository = new Repository<SecModule, int>(context);
        SecPropertyRepository = new Repository<SecProperty, int>(context);
        SecRoleRepository = new Repository<SecRole, int>(context);
        SecRoleModelAttributeRepository = new Repository<SecRoleModelAttribute, int>(context);
        SecRoleModuleRepository = new Repository<SecRoleModule, int>(context);
        SecRolePropertyRepository = new Repository<SecRoleProperty, int>(context);
        SecRoleSecurableValueRepository = new Repository<SecRoleSecurableValue, int>(context);
        SecRoleViewActionRepository = new Repository<SecRoleViewAction, int>(context);
        SectionRepository = new Repository<Section, int>(context);
        SectorRepository = new Repository<Sector, int>(context);
        SecUserModelAtrributeRepository = new Repository<SecUserModelAtrribute, int>(context);
        SecUserModuleRepository = new Repository<SecUserModule, int>(context);
        SecUserPropertyRepository = new Repository<SecUserProperty, int>(context);
        SecUserSecurableValueRepository = new Repository<SecUserSecurableValue, int>(context);
        SecUserViewActionRepository = new Repository<SecUserViewAction, int>(context);
        SecViewRepository = new Repository<SecView, int>(context);
        SecViewActionRepository = new Repository<SecViewAction, int>(context);
        ServiceRepository = new Repository<Service, int>(context);
        ServiceCategoryRepository = new Repository<ServiceCategory, int>(context);
        ServiceMainCategoryRepository = new Repository<ServiceMainCategory, int>(context);
        ServiceSubCategoryRepository = new Repository<ServiceSubCategory, int>(context);
        ServiceTypeRepository = new Repository<ServiceType, int>(context);
        ShelfRepository = new Repository<Shelf, int>(context);
        SparePartGroupRepository = new Repository<SparePartGroup, int>(context);
        StateRepository = new Repository<State, int>(context);
        StockCountPlanStatusRepository = new Repository<StockCountPlanStatus, int>(context);
        StockCountPlanTypeRepository = new Repository<StockCountPlanType, int>(context);
        StoreRepository = new Repository<Store, int>(context);
        StoreKeeperRepository = new Repository<StoreKeeper, int>(context);
        StoreSequenceRepository = new Repository<StoreSequence, int>(context);
        SubSectionRepository = new Repository<SubSection, int>(context);
        SysKeyValueRepository = new Repository<SysKeyValue, int>(context);
        TermsAndConditionRepository = new Repository<TermsAndCondition, int>(context);
        ToolsTypeRepository = new Repository<ToolsType, int>(context);
        TransfereTypeRepository = new Repository<TransfereType, int>(context);
        TransferReasonRepository = new Repository<TransferReason, int>(context);
        TransferStatusRepository = new Repository<TransferStatus, int>(context);
        TransmissionTypeRepository = new Repository<TransmissionType, int>(context);
        UnitOfMeasureRepository = new Repository<UnitOfMeasure, int>(context);
        UserRepository = new Repository<User, int>(context);
        UserSessionInfoRepository = new Repository<UserSessionInfo, int>(context);
        UserSessionInfoDetailRepository = new Repository<UserSessionInfoDetail, int>(context);
        VehicleRepository = new Repository<Vehicle, int>(context);
        VehicleBrandRepository = new Repository<VehicleBrand, int>(context);
        VehicleColorRepository = new Repository<VehicleColor, int>(context);
        VehicleModelRepository = new Repository<VehicleModel, int>(context);
        VehicleOptionRepository = new Repository<VehicleOption, int>(context);
        VehicleStatusRepository = new Repository<VehicleStatus, int>(context);
        VehicleTypeRepository = new Repository<VehicleType, int>(context);
        VendorRepository = new Repository<Vendor, int>(context);
        VendorEvaluationCriterionRepository = new Repository<VendorEvaluationCriterion, int>(context);
        VendorOrderRepository = new Repository<VendorOrder, int>(context);
        VendorOrderAttachmentRepository = new Repository<VendorOrderAttachment, int>(context);
        VendorOrderDetailRepository = new Repository<VendorOrderDetail, int>(context);
        VendorOrderPartiallyReceivedNoteRepository = new Repository<VendorOrderPartiallyReceivedNote, int>(context);
        VendorOrderQualityRepository = new Repository<VendorOrderQuality, int>(context);
        VendorOrderQualityAttachmentRepository = new Repository<VendorOrderQualityAttachment, int>(context);
        VendorOrderQualityDetailRepository = new Repository<VendorOrderQualityDetail, int>(context);
        VendorOrderQualityDetailBatchRepository = new Repository<VendorOrderQualityDetailBatch, int>(context);
        VendorOrderReceiveRepository = new Repository<VendorOrderReceive, int>(context);
        VendorOrderReceiveAttachmentRepository = new Repository<VendorOrderReceiveAttachment, int>(context);
        VendorOrderReceiveDetailRepository = new Repository<VendorOrderReceiveDetail, int>(context);
        VendorOrderReceiveDetailBatchRepository = new Repository<VendorOrderReceiveDetailBatch, int>(context);
        VendorOrderReceiveDetailBatchSerialRepository = new Repository<VendorOrderReceiveDetailBatchSerial, int>(context);
        VendorOrderReceiveSerialRepository = new Repository<VendorOrderReceiveSerial, int>(context);
        VendorOrderScreenRepository = new Repository<VendorOrderScreen, int>(context);
        VendorOrderStatusRepository = new Repository<VendorOrderStatus, int>(context);
        VendorOrderTypeRepository = new Repository<VendorOrderType, int>(context);
        VendorOrderVendorSelectionRepository = new Repository<VendorOrderVendorSelection, int>(context);
        VendorOrderVendorSuggestedRepository = new Repository<VendorOrderVendorSuggested, int>(context);
        VendorReturnRepository = new Repository<VendorReturn, int>(context);
        VendorReturnAttachmentRepository = new Repository<VendorReturnAttachment, int>(context);
        VendorReturnDetailRepository = new Repository<VendorReturnDetail, int>(context);
        VendorReturnDetailBatchRepository = new Repository<VendorReturnDetailBatch, int>(context);
        VendorReturnDetailBatchSerialRepository = new Repository<VendorReturnDetailBatchSerial, int>(context);
        VendorReturnSerialRepository = new Repository<VendorReturnSerial, int>(context);
        VendorSpecializationRepository = new Repository<VendorSpecialization, int>(context);
        VendorStatusRepository = new Repository<VendorStatus, int>(context);
        VendorTypeRepository = new Repository<VendorType, int>(context);
        ViewRequestStatusRepository = new Repository<ViewRequestStatus, int>(context);
        VisitRepository = new Repository<Visit, int>(context);
        WarrantyStatusRepository = new Repository<WarrantyStatus, int>(context);
        WorkerTypeRepository = new Repository<WorkerType, int>(context);
        WsLastSyncTableRepository = new Repository<WsLastSyncTable, int>(context);
        ZoneRepository = new Repository<Zone, int>(context);
        ZoneStatusRepository = new Repository<ZoneStatus, int>(context);
        WarehouseTypeRepository = new Repository<WarehouseType, int>(context);
        WarehouseRepository = new Repository<Warehouse, int>(context);
        StorageUnitRepository = new Repository<StorageUnit, int>(context);
    }
    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in _context.ChangeTracker.Entries<AuditableEntityBase<Guid>>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedBy = "System";
                entry.Entity.CreatedOn = DateTime.UtcNow;
            }

            else if (entry.State == EntityState.Modified && entry.Entity.IsDeleted)
            {
                entry.Entity.DeletedBy = "System";
                entry.Entity.DeletedAt = DateTime.UtcNow;
            }
            else
            {
                entry.Entity.ModifiedBy = "System";
                entry.Entity.ModifiedAt = DateTime.UtcNow;
            }
        }
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {

        try
        {
            // Start a transaction to ensure both saving and event dispatching happen atomically
            return await CreateExecutionStrategy(async () =>
            {
                // Dispatch the domain events before saving changes
                await DispatchDomainEvents(_context).ConfigureAwait(false);

                // Now save the changes
                var result = await SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                return result > 0;
            }, cancellationToken).ConfigureAwait(false);
        }
        catch
        {
            throw;
        }
    }
    private async Task DispatchDomainEvents(DbContext? context)
    {
        if (context == null) return;

        var entities = context.ChangeTracker
            .Entries<AggregateRootEntityBase<Guid>>()
            .Where(e => e.Entity.DomainEvents.Any())
            .Select(e => e.Entity);

        var domainEvents = entities
            .SelectMany(e => e.DomainEvents)
            .ToList();

        entities.ToList().ForEach(e => e.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
            await _mediator.Publish(domainEvent);
    }
    private async Task<bool> CreateExecutionStrategy(Func<Task<bool>> action, CancellationToken cancellationToken = default)
    {
        var strategy = _context.Database.CreateExecutionStrategy();
        var result = await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken)
            .ConfigureAwait(false);
            var result = await action();
            await transaction.CommitAsync(cancellationToken)
            .ConfigureAwait(false);
            return result;
        });
        return result;
    }
}


public class UnitOfWork<TEntity, TId> : IUnitOfWork<TEntity, TId>, IDisposable
    where TEntity : Entity<TId>
    where TId : struct, IEquatable<TId>
{
    private readonly ApplicationDbContext _context;
    private readonly IMediator _mediator;

    public IRepository<TEntity, TId> Repository { get; set; }

    public UnitOfWork(ApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
        Repository = new Repository<TEntity, TId>(context);
    }
    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in _context.ChangeTracker.Entries<AuditableEntityBase<Guid>>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedBy = "System";
                entry.Entity.CreatedOn = DateTime.UtcNow;
            }

            else if (entry.State == EntityState.Modified && entry.Entity.IsDeleted)
            {
                entry.Entity.DeletedBy = "System";
                entry.Entity.DeletedAt = DateTime.UtcNow;
            }
            else
            {
                entry.Entity.ModifiedBy = "System";
                entry.Entity.ModifiedAt = DateTime.UtcNow;
            }
        }

        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {

        try
        {
            // Start a transaction to ensure both saving and event dispatching happen atomically
            return await CreateExecutionStrategy(async () =>
            {
                // Dispatch the domain events before saving changes
                await DispatchDomainEvents(_context).ConfigureAwait(false);

                // Now save the changes
                var result = await SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                return result > 0;
            }, cancellationToken).ConfigureAwait(false);
        }
        catch
        {
            throw;
        }
    }
    private async Task DispatchDomainEvents(DbContext? context)
    {
        if (context == null) return;

        var entities = context.ChangeTracker
            .Entries<AggregateRootEntityBase<Guid>>()
            .Where(e => e.Entity.DomainEvents.Any())
            .Select(e => e.Entity);

        var domainEvents = entities
            .SelectMany(e => e.DomainEvents)
            .ToList();

        entities.ToList().ForEach(e => e.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
            await _mediator.Publish(domainEvent);
    }
    private async Task<bool> CreateExecutionStrategy(Func<Task<bool>> action, CancellationToken cancellationToken = default)
    {
        var strategy = _context.Database.CreateExecutionStrategy();
        var result = await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken)
            .ConfigureAwait(false);
            var result = await action();
            await transaction.CommitAsync(cancellationToken)
            .ConfigureAwait(false);
            return result;
        });

        return result;
    }
}
