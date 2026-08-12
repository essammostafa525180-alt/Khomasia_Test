using Domain.Aggregates.AssetAggregate;
using Domain.Aggregates.AuditAggregate;
using Domain.Aggregates.BookAggregate;
using Domain.Aggregates.BookSharhAggregate;
using Domain.Aggregates.ClassificationAggregate;
using Domain.Aggregates.CompanyAggregate;
using Domain.Aggregates.HadithAggregate;
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
using Domain.Aggregates.TakhreejAggregate;
using Domain.Aggregates.UserAggregate;
using Domain.Aggregates.VehicleAggregate;
using Domain.Aggregates.VendorAggregate;
using Domain.Aggregates.VendorOrderAggregate;
using Domain.Aggregates.VendorReturnAggregate;
using Domain.Aggregates.ZoneAggregate;
using Domain.Entities;

namespace Domain.Abstractions;
public interface IUnitOfWork
{


    public IRepository<Partation, int> PartitionRepository { get; set; }
    public IRepository<HadithCollection, int> HadithCollectionRepository { get; set; }
    public IRepository<Classification, int> ClassificationRepository { get; set; }
    public IRepository<HadithTakhreej, int> HadithTakhreejRepository { get; set; }
    public IRepository<Hadith, int> HadithRepository { get; set; }
    // Ã™â€¡Ã˜ÂªÃ˜ÂªÃ˜Â´Ã˜Â§Ã™â€ž Ã™â€šÃ˜Â¯Ã˜Â§Ã™â€¦ Ã™â€žÃ™â€¦ Ã˜Â§Ã™â€žÃ˜Â¯Ã˜Â§Ã˜ÂªÃ˜Â§ Ã˜ÂªÃ˜ÂªÃ˜ÂµÃ™â€žÃ˜Â­
    public IRepository<HadithMissing, int> HadithMissingRepository { get; set; }
    public IRepository<HadithTranslations, int> HadithTranslationRepository { get; set; }

    public IRepository<HadithSharh, int> HadithSharhRepository { get; set; }
    public IRepository<Bab, int> BabRepository { get; set; }
    public IRepository<Book, int> BookRepository { get; set; }
    public IRepository<Narrator, int> NarratorRepository { get; set; }
    public IRepository<SharhBook, int> SharhBookRepository { get; set; }
    public IRepository<ContactMessage, int> ContactMessageRepository { get; set; }
    public IRepository<HadithSharhMissing, int> HadithSharhMissingRepository { get; set; }

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
    public IRepository<NarratorsCriticism, int> NarratorsCriticismRepository { get; set; }
    public IRepository<NarratorStudent, int> NarratorStudentRepository { get; set; }
    public IRepository<NarratorTeacher, int> NarratorTeacherRepository { get; set; }
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

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);

}

public interface IUnitOfWork<TEntity, TId>
{
    public IRepository<TEntity, TId> Repository { get; set; }


    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
}
