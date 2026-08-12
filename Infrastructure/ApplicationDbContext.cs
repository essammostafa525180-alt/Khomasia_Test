using Application.Abstractions;
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
using Domain.Entities;
using Domain.Entities.Legacy;
using Domain.Primitives;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace Infrastructure;
public sealed class ApplicationDbContext : IdentityDbContext<ApplicationUser>, 
    IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
        //this.Database.SetCommandTimeout(900);
    }
   
    public DbSet<ContactMessage> ContactMessages { get; set; }
    public DbSet<AdUser> AdUsers { get; set; }
    public DbSet<AirFilterType> AirFilterTypes { get; set; }
    public DbSet<AllowedCompany> AllowedCompanys { get; set; }
    public DbSet<AnnualStockCount> AnnualStockCounts { get; set; }
    public DbSet<AnnualStockCountItemMerge> AnnualStockCountItemMerges { get; set; }
    public DbSet<AnnualStockCountItemQuantity> AnnualStockCountItemQuantitys { get; set; }
    public DbSet<ApprovalMatrix> ApprovalMatrixs { get; set; }
    public DbSet<ApprovalMatrixConfig> ApprovalMatrixConfigs { get; set; }
    public DbSet<ApprovalMatrixConfigDetail> ApprovalMatrixConfigDetails { get; set; }
    public DbSet<ApprovalMatrixDetail> ApprovalMatrixDetails { get; set; }
    public DbSet<ApprovalMatrixRange> ApprovalMatrixRanges { get; set; }
    public DbSet<ApprovalScreen> ApprovalScreens { get; set; }
    public DbSet<ApprovalStatus> ApprovalStatus { get; set; }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<AssetAttachment> AssetAttachments { get; set; }
    public DbSet<AssetCommissioning> AssetCommissionings { get; set; }
    public DbSet<AssetCompline> AssetComplines { get; set; }
    public DbSet<AssetComponent> AssetComponents { get; set; }
    public DbSet<AssetCount> AssetCounts { get; set; }
    public DbSet<AssetCountDetail> AssetCountDetails { get; set; }
    public DbSet<AssetCountIssue> AssetCountIssues { get; set; }
    public DbSet<AssetCountIssueStatus> AssetCountIssueStatus { get; set; }
    public DbSet<AssetCountPlan> AssetCountPlans { get; set; }
    public DbSet<AssetCountPlanDetail> AssetCountPlanDetails { get; set; }
    public DbSet<AssetCountPlanStatus> AssetCountPlanStatus { get; set; }
    public DbSet<AssetCountPlanType> AssetCountPlanTypes { get; set; }
    public DbSet<AssetCountStatus> AssetCountStatus { get; set; }
    public DbSet<AssetDisposed> AssetDisposeds { get; set; }
    public DbSet<AssetFunctionality> AssetFunctionalitys { get; set; }
    public DbSet<AssetItem> AssetItems { get; set; }
    public DbSet<AssetItemAttachment> AssetItemAttachments { get; set; }
    public DbSet<AssetItemMaintenance> AssetItemMaintenances { get; set; }
    public DbSet<AssetItemMove> AssetItemMoves { get; set; }
    public DbSet<AssetItemScrap> AssetItemScraps { get; set; }
    public DbSet<AssetMaintenanceStatus> AssetMaintenanceStatus { get; set; }
    public DbSet<AssetMoveType> AssetMoveTypes { get; set; }
    public DbSet<AssetScrapStatus> AssetScrapStatus { get; set; }
    public DbSet<AssetsGroup> AssetsGroups { get; set; }
    public DbSet<AssetStatus> AssetStatus { get; set; }
    public DbSet<AssetsType> AssetsTypes { get; set; }
    public DbSet<AssetWarrantyStatus> AssetWarrantyStatus { get; set; }
    public DbSet<AssignAssetTypeToAssetGroup> AssignAssetTypeToAssetGroups { get; set; }
    public DbSet<AssignCostCenterToSector> AssignCostCenterToSectors { get; set; }
    public DbSet<AssignSiteSection> AssignSiteSections { get; set; }
    public DbSet<AssignVendorEvaluationCriterion> AssignVendorEvaluationCriterions { get; set; }
    public DbSet<AssignVendorSpecialization> AssignVendorSpecializations { get; set; }
    public DbSet<AuditTrail> AuditTrails { get; set; }
    public DbSet<AuditTrailDetail> AuditTrailDetails { get; set; }
    public DbSet<BatteryType> BatteryTypes { get; set; }
    public DbSet<ChemicalGroup> ChemicalGroups { get; set; }
    public DbSet<City> Citys { get; set; }
    public DbSet<CommissionCondition> CommissionConditions { get; set; }
    public DbSet<Company> Companys { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<ContactType> ContactTypes { get; set; }
    public DbSet<CostCenter> CostCenters { get; set; }
    public DbSet<Country> Countrys { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<DaysOfWeek> DaysOfWeeks { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeJob> EmployeeJobs { get; set; }
    public DbSet<EngineSize> EngineSizes { get; set; }
    public DbSet<EquipmentCode> EquipmentCodes { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Factory> Factorys { get; set; }
    public DbSet<FactoryLine> FactoryLines { get; set; }
    public DbSet<Gender> Genders { get; set; }
    public DbSet<InsuranceVendor> InsuranceVendors { get; set; }
    public DbSet<InventoryCurrency> InventoryCurrencys { get; set; }
    public DbSet<InventoryItem> InventoryItems { get; set; }
    public DbSet<InventoryItemAsset> InventoryItemAssets { get; set; }
    public DbSet<InventoryItemBudget> InventoryItemBudgets { get; set; }
    public DbSet<InventoryItemBudgetDetail> InventoryItemBudgetDetails { get; set; }
    public DbSet<InventoryItemCost> InventoryItemCosts { get; set; }
    public DbSet<InventoryItemEquivalentSp> InventoryItemEquivalentSps { get; set; }
    public DbSet<InventoryItemLocation> InventoryItemLocations { get; set; }
    public DbSet<InventoryItemLocationBatch> InventoryItemLocationBatchs { get; set; }
    public DbSet<InventoryItemLocationBatchSerial> InventoryItemLocationBatchSerials { get; set; }
    public DbSet<InventoryItemLocationDetail> InventoryItemLocationDetails { get; set; }
    public DbSet<InventoryItemReturn> InventoryItemReturns { get; set; }
    public DbSet<InventoryItemReturnAttachment> InventoryItemReturnAttachments { get; set; }
    public DbSet<InventoryItemReturnBatch> InventoryItemReturnBatchs { get; set; }
    public DbSet<InventoryItemReturnBatchSerial> InventoryItemReturnBatchSerials { get; set; }
    public DbSet<InventoryItemReturnDetail> InventoryItemReturnDetails { get; set; }
    public DbSet<InventoryItemReturnSerial> InventoryItemReturnSerials { get; set; }
    public DbSet<InventoryItemSerial> InventoryItemSerials { get; set; }
    public DbSet<InventoryItemSerialStatus> InventoryItemSerialStatus { get; set; }
    public DbSet<InventoryItemStatus> InventoryItemStatus { get; set; }
    public DbSet<InventoryItemTransactionType> InventoryItemTransactionTypes { get; set; }
    public DbSet<InventoryItemTrasnsactionType> InventoryItemTrasnsactionTypes { get; set; }
    public DbSet<InventoryItemUoM> InventoryItemUoMs { get; set; }
    public DbSet<InventoryItemVendor> InventoryItemVendors { get; set; }
    public DbSet<InventoryStockCount> InventoryStockCounts { get; set; }
    public DbSet<InventoryStockCountDetail> InventoryStockCountDetails { get; set; }
    public DbSet<InventoryStockCountDetailBatch> InventoryStockCountDetailBatchs { get; set; }
    public DbSet<InventoryStockCountDetailBatchSerial> InventoryStockCountDetailBatchSerials { get; set; }
    public DbSet<InventoryStockCountPlan> InventoryStockCountPlans { get; set; }
    public DbSet<InventoryStockCountPlanDetail> InventoryStockCountPlanDetails { get; set; }
    public DbSet<InventoryStockCountStatus> InventoryStockCountStatus { get; set; }
    public DbSet<InventoryTransfere> InventoryTransferes { get; set; }
    public DbSet<InventoryTransfereAttachment> InventoryTransfereAttachments { get; set; }
    public DbSet<InventoryTransfereDetail> InventoryTransfereDetails { get; set; }
    public DbSet<InventoryTransfereDetailBatch> InventoryTransfereDetailBatchs { get; set; }
    public DbSet<InventoryTransfereDetailBatchSerial> InventoryTransfereDetailBatchSerials { get; set; }
    public DbSet<InventoryTransfereSerial> InventoryTransfereSerials { get; set; }
    public DbSet<InventoryYear> InventoryYears { get; set; }
    public DbSet<InventroyItemRequestWithdraw> InventroyItemRequestWithdraws { get; set; }
    public DbSet<InventroyItemRequestWithdrawAttachment> InventroyItemRequestWithdrawAttachments { get; set; }
    public DbSet<InventroyItemRequestWithdrawDetail> InventroyItemRequestWithdrawDetails { get; set; }
    public DbSet<Isle> Isles { get; set; }
    public DbSet<ItemBalanceStatus> ItemBalanceStatus { get; set; }
    public DbSet<ItemExpiryType> ItemExpiryTypes { get; set; }
    public DbSet<ItemQuantityType> ItemQuantityTypes { get; set; }
    public DbSet<ItemRequestStatus> ItemRequestStatus { get; set; }
    public DbSet<ItemType> ItemTypes { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Line> Lines { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Manufacture> Manufactures { get; set; }
    public DbSet<MaterialCategory> MaterialCategorys { get; set; }
    public DbSet<MaterialGroup> MaterialGroups { get; set; }
    public DbSet<MaterialSubCategory> MaterialSubCategorys { get; set; }
    public DbSet<ModuleSetting> ModuleSettings { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<NotificationLog> NotificationLogs { get; set; }
    public DbSet<NotificationPlaceHolder> NotificationPlaceHolders { get; set; }
    public DbSet<NotificationState> NotificationStates { get; set; }
    public DbSet<NotificationTemplate> NotificationTemplates { get; set; }
    public DbSet<NotificationTemplateContact> NotificationTemplateContacts { get; set; }
    public DbSet<NotificationType> NotificationTypes { get; set; }
    public DbSet<Oil> Oils { get; set; }
    public DbSet<OrderLineItemStatus> OrderLineItemStatus { get; set; }
    public DbSet<Ou> Ous { get; set; }
    public DbSet<Ownership> Ownerships { get; set; }
    public DbSet<PaymentTerm> PaymentTerms { get; set; }
    public DbSet<Pdaassignment> Pdaassignments { get; set; }
    public DbSet<Pdadetail> Pdadetails { get; set; }
    public DbSet<Pdamodel> Pdamodels { get; set; }
    public DbSet<PdarequestsLog> PdarequestsLogs { get; set; }
    public DbSet<PoserviceAsset> PoserviceAssets { get; set; }
    public DbSet<PoserviceDetail> PoserviceDetails { get; set; }
    public DbSet<PoserviceOutsource> PoserviceOutsources { get; set; }
    public DbSet<PoserviceRecomendedResource> PoserviceRecomendedResources { get; set; }
    public DbSet<PoserviceTermsAndCondition> PoserviceTermsAndConditions { get; set; }
    public DbSet<PoserviceType> PoserviceTypes { get; set; }
    public DbSet<PossessionType> PossessionTypes { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Pruser> Prusers { get; set; }
    public DbSet<PurchaseOrderService> PurchaseOrderServices { get; set; }
    public DbSet<PurchaseOrderServiceAttachment> PurchaseOrderServiceAttachments { get; set; }
    public DbSet<Rack> Racks { get; set; }
    public DbSet<Rank> Ranks { get; set; }
    public DbSet<RequestLineItemStatus> RequestLineItemStatus { get; set; }
    public DbSet<RequestWithdrawSerial> RequestWithdrawSerials { get; set; }
    public DbSet<ReturnReason> ReturnReasons { get; set; }
    public DbSet<ReturnStatus> ReturnStatus { get; set; }
    public DbSet<RwDeliveredBatch> RwDeliveredBatchs { get; set; }
    public DbSet<RwDeliveredQuantity> RwDeliveredQuantitys { get; set; }
    public DbSet<RwDeliveredSerial> RwDeliveredSerials { get; set; }
    public DbSet<RwPickedBatch> RwPickedBatchs { get; set; }
    public DbSet<RwPickedQuantity> RwPickedQuantitys { get; set; }
    public DbSet<RwPickedSerial> RwPickedSerials { get; set; }
    public DbSet<SalesInvoice> SalesInvoices { get; set; }
    public DbSet<SalesInvoiceItem> SalesInvoiceItems { get; set; }
    public DbSet<SalesQuotation> SalesQuotations { get; set; }
    public DbSet<SalesQuotationDetail> SalesQuotationDetails { get; set; }
    public DbSet<Scope> Scopes { get; set; }
    public DbSet<SecConfiguration> SecConfigurations { get; set; }
    public DbSet<SecModel> SecModels { get; set; }
    public DbSet<SecModelAttribute> SecModelAttributes { get; set; }
    public DbSet<SecModule> SecModules { get; set; }
    public DbSet<SecProperty> SecPropertys { get; set; }
    public DbSet<SecRole> SecRoles { get; set; }
    public DbSet<SecRoleModelAttribute> SecRoleModelAttributes { get; set; }
    public DbSet<SecRoleModule> SecRoleModules { get; set; }
    public DbSet<SecRoleProperty> SecRolePropertys { get; set; }
    public DbSet<SecRoleSecurableValue> SecRoleSecurableValues { get; set; }
    public DbSet<SecRoleViewAction> SecRoleViewActions { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<Sector> Sectors { get; set; }
    public DbSet<SecUserModelAtrribute> SecUserModelAtrributes { get; set; }
    public DbSet<SecUserModule> SecUserModules { get; set; }
    public DbSet<SecUserProperty> SecUserPropertys { get; set; }
    public DbSet<SecUserSecurableValue> SecUserSecurableValues { get; set; }
    public DbSet<SecUserViewAction> SecUserViewActions { get; set; }
    public DbSet<SecView> SecViews { get; set; }
    public DbSet<SecViewAction> SecViewActions { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ServiceCategory> ServiceCategorys { get; set; }
    public DbSet<ServiceMainCategory> ServiceMainCategorys { get; set; }
    public DbSet<ServiceSubCategory> ServiceSubCategorys { get; set; }
    public DbSet<ServiceType> ServiceTypes { get; set; }
    public DbSet<Shelf> Shelfs { get; set; }
    public DbSet<SparePartGroup> SparePartGroups { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<StockCountPlanStatus> StockCountPlanStatus { get; set; }
    public DbSet<StockCountPlanType> StockCountPlanTypes { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<StoreKeeper> StoreKeepers { get; set; }
    public DbSet<StoreSequence> StoreSequences { get; set; }
    public DbSet<SubSection> SubSections { get; set; }
    public DbSet<SysKeyValue> SysKeyValues { get; set; }
    public DbSet<TermsAndCondition> TermsAndConditions { get; set; }
    public DbSet<ToolsType> ToolsTypes { get; set; }
    public DbSet<TransfereType> TransfereTypes { get; set; }
    public DbSet<TransferReason> TransferReasons { get; set; }
    public DbSet<TransferStatus> TransferStatus { get; set; }
    public DbSet<TransmissionType> TransmissionTypes { get; set; }
    public DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserSessionInfo> UserSessionInfos { get; set; }
    public DbSet<UserSessionInfoDetail> UserSessionInfoDetails { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<VehicleBrand> VehicleBrands { get; set; }
    public DbSet<VehicleColor> VehicleColors { get; set; }
    public DbSet<VehicleModel> VehicleModels { get; set; }
    public DbSet<VehicleOption> VehicleOptions { get; set; }
    public DbSet<VehicleStatus> VehicleStatus { get; set; }
    public DbSet<VehicleType> VehicleTypes { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<VendorEvaluationCriterion> VendorEvaluationCriterions { get; set; }
    public DbSet<VendorOrder> VendorOrders { get; set; }
    public DbSet<VendorOrderAttachment> VendorOrderAttachments { get; set; }
    public DbSet<VendorOrderDetail> VendorOrderDetails { get; set; }
    public DbSet<VendorOrderPartiallyReceivedNote> VendorOrderPartiallyReceivedNotes { get; set; }
    public DbSet<VendorOrderQuality> VendorOrderQualitys { get; set; }
    public DbSet<VendorOrderQualityAttachment> VendorOrderQualityAttachments { get; set; }
    public DbSet<VendorOrderQualityDetail> VendorOrderQualityDetails { get; set; }
    public DbSet<VendorOrderQualityDetailBatch> VendorOrderQualityDetailBatchs { get; set; }
    public DbSet<VendorOrderReceive> VendorOrderReceives { get; set; }
    public DbSet<VendorOrderReceiveAttachment> VendorOrderReceiveAttachments { get; set; }
    public DbSet<VendorOrderReceiveDetail> VendorOrderReceiveDetails { get; set; }
    public DbSet<VendorOrderReceiveDetailBatch> VendorOrderReceiveDetailBatchs { get; set; }
    public DbSet<VendorOrderReceiveDetailBatchSerial> VendorOrderReceiveDetailBatchSerials { get; set; }
    public DbSet<VendorOrderReceiveSerial> VendorOrderReceiveSerials { get; set; }
    public DbSet<VendorOrderScreen> VendorOrderScreens { get; set; }
    public DbSet<VendorOrderStatus> VendorOrderStatus { get; set; }
    public DbSet<VendorOrderType> VendorOrderTypes { get; set; }
    public DbSet<VendorOrderVendorSelection> VendorOrderVendorSelections { get; set; }
    public DbSet<VendorOrderVendorSuggested> VendorOrderVendorSuggesteds { get; set; }
    public DbSet<VendorReturn> VendorReturns { get; set; }
    public DbSet<VendorReturnAttachment> VendorReturnAttachments { get; set; }
    public DbSet<VendorReturnDetail> VendorReturnDetails { get; set; }
    public DbSet<VendorReturnDetailBatch> VendorReturnDetailBatchs { get; set; }
    public DbSet<VendorReturnDetailBatchSerial> VendorReturnDetailBatchSerials { get; set; }
    public DbSet<VendorReturnSerial> VendorReturnSerials { get; set; }
    public DbSet<VendorSpecialization> VendorSpecializations { get; set; }
    public DbSet<VendorStatus> VendorStatus { get; set; }
    public DbSet<VendorType> VendorTypes { get; set; }
    public DbSet<ViewRequestStatus> ViewRequestStatus { get; set; }
    public DbSet<Visit> Visits { get; set; }
    public DbSet<WarrantyStatus> WarrantyStatus { get; set; }
    public DbSet<WorkerType> WorkerTypes { get; set; }
    public DbSet<WsLastSyncTable> WsLastSyncTables { get; set; }
    public DbSet<Zone> Zones { get; set; }
    public DbSet<ZoneStatus> ZoneStatus { get; set; }

    public DbSet<_20230515CairoOpeningBalance> _20230515CairoOpeningBalances { get; set; }
    public DbSet<_20230515HebaOpeningBalance> _20230515HebaOpeningBalances { get; set; }
    public DbSet<Cairo202320240721> Cairo202320240721s { get; set; }
    public DbSet<Cairo202320240721merge> Cairo202320240721merges { get; set; }
    public DbSet<Cairo2024> Cairo2024s { get; set; }
    public DbSet<CairoAvgcost20240729> CairoAvgcost20240729s { get; set; }
    public DbSet<DataMergeItem> DataMergeItems { get; set; }
    public DbSet<Heba202320240721> Heba202320240721s { get; set; }
    public DbSet<Heba202320240721merge> Heba202320240721merges { get; set; }
    public DbSet<Heba2024> Heba2024s { get; set; }
    public DbSet<HebaAvgcost20240729> HebaAvgcost20240729s { get; set; }
    public DbSet<InventoryItem2024> InventoryItem2024s { get; set; }
    public DbSet<InventoryItemLocation20230404> InventoryItemLocation20230404s { get; set; }
    public DbSet<InventoryItemLocation20230505> InventoryItemLocation20230505s { get; set; }
    public DbSet<InventoryItemLocation20240723> InventoryItemLocation20240723s { get; set; }
    public DbSet<InventoryItemLocationDetail20240723> InventoryItemLocationDetail20240723s { get; set; }
    public DbSet<InventoryItemMerge20240522> InventoryItemMerge20240522s { get; set; }
    public DbSet<InventoryItemMerge20240610> InventoryItemMerge20240610s { get; set; }
    public DbSet<MmItemsForMerge2> MmItemsForMerge2s { get; set; }
    public DbSet<MotorodItem> MotorodItems { get; set; }
    public DbSet<NotFoundItem> NotFoundItems { get; set; }
    public DbSet<PoChangeVehicle20240331> PoChangeVehicle20240331s { get; set; }
    public DbSet<ProcDatum> ProcData { get; set; }
    public DbSet<Sheet1> Sheet1s { get; set; }
    public DbSet<StockCount20230331> StockCount20230331s { get; set; }
    public DbSet<Temp> Temps { get; set; }
    public DbSet<TempBatch> TempBatches { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<_20230515CairoOpeningBalance>(e =>
        {
            e.HasNoKey();
            e.ToTable("$20230515_Cairo_OpeningBalance");
        });
        modelBuilder.Entity<_20230515HebaOpeningBalance>(e =>
        {
            e.HasNoKey();
            e.ToTable("$20230515_Heba_OpeningBalance");
        });
        modelBuilder.Entity<Cairo202320240721>(e =>
        {
            e.HasNoKey();
            e.ToTable("Cairo_2023_20240721$");
        });
        modelBuilder.Entity<Cairo202320240721merge>(e =>
        {
            e.HasNoKey();
            e.ToTable("Cairo_2023_2024-07-21Merge$");
        });
        modelBuilder.Entity<Cairo2024>(e =>
        {
            e.HasNoKey();
            e.ToTable("Cairo_2024$");
        });
        modelBuilder.Entity<CairoAvgcost20240729>(e =>
        {
            e.HasNoKey();
            e.ToTable("CairoAVGCost20240729$");
        });
        modelBuilder.Entity<DataMergeItem>(e =>
        {
            e.HasNoKey();
            e.ToTable("Data_Merge_Items");
        });
        modelBuilder.Entity<Heba202320240721>(e =>
        {
            e.HasNoKey();
            e.ToTable("Heba_2023_20240721$");
        });
        modelBuilder.Entity<Heba202320240721merge>(e =>
        {
            e.HasNoKey();
            e.ToTable("Heba_2023_2024-07-21Merge$");
        });
        modelBuilder.Entity<Heba2024>(e =>
        {
            e.HasNoKey();
            e.ToTable("Heba_2024$");
        });
        modelBuilder.Entity<HebaAvgcost20240729>(e =>
        {
            e.HasNoKey();
            e.ToTable("HebaAVGCost20240729$");
        });
        modelBuilder.Entity<InventoryItem2024>(e =>
        {
            e.HasNoKey();
            e.ToTable("$InventoryItem_2024");
        });
        modelBuilder.Entity<InventoryItemLocation20230404>(e =>
        {
            e.HasNoKey();
            e.ToTable("InventoryItemLocation_20230404");
        });
        modelBuilder.Entity<InventoryItemLocation20230505>(e =>
        {
            e.HasNoKey();
            e.ToTable("InventoryItemLocation_20230505");
        });
        modelBuilder.Entity<InventoryItemLocation20240723>(e =>
        {
            e.HasNoKey();
            e.ToTable("$InventoryItemLocation_20240723");
        });
        modelBuilder.Entity<InventoryItemLocationDetail20240723>(e =>
        {
            e.HasNoKey();
            e.ToTable("$InventoryItemLocationDetail_20240723");
        });
        modelBuilder.Entity<InventoryItemMerge20240522>(e =>
        {
            e.HasNoKey();
            e.ToTable("$InventoryItemMerge_2024-05-22");
        });
        modelBuilder.Entity<InventoryItemMerge20240610>(e =>
        {
            e.HasNoKey();
            e.ToTable("$InventoryItemMerge_2024-06-10");
        });
        modelBuilder.Entity<MmItemsForMerge2>(e =>
        {
            e.HasNoKey();
            e.ToTable("MM Items For Merge_2$");
        });
        modelBuilder.Entity<MotorodItem>(e =>
        {
            e.HasNoKey();
            e.ToTable("$MotorodItems");
        });
        modelBuilder.Entity<NotFoundItem>(e =>
        {
            e.HasNoKey();
            e.ToTable("Not found items$");
        });
        modelBuilder.Entity<PoChangeVehicle20240331>(e =>
        {
            e.HasNoKey();
            e.ToTable("$po_ChangeVehicle_2024-03-31");
        });
        modelBuilder.Entity<ProcDatum>(e =>
        {
            e.HasNoKey();
            e.ToTable("ProcData");
        });
        modelBuilder.Entity<Sheet1>(e =>
        {
            e.HasNoKey();
            e.ToTable("Sheet1$");
        });
        modelBuilder.Entity<StockCount20230331>(e =>
        {
            e.HasNoKey();
            e.ToTable("StockCount_2023-03-31$");
        });
        modelBuilder.Entity<Temp>(e =>
        {
            e.HasNoKey();
            e.ToTable("Temp");
        });
        modelBuilder.Entity<TempBatch>(e =>
        {
            e.HasNoKey();
            e.ToTable("TempBatch");
        });


     
        var keepNamespaces = new[]
        {
            "Domain.Aggregates.BookAggregate",
            "Domain.Aggregates.BookSharhAggregate",
            "Domain.Aggregates.ClassificationAggregate",
            "Domain.Aggregates.HadithAggregate",
            "Domain.Aggregates.TakhreejAggregate"
        };

        bool IsDomainType(Type type)
        {
            return type.Namespace != null &&
                (type.Namespace == "Domain.Entities" ||
                 type.Namespace.StartsWith("Domain.Aggregates."));
        }

        bool IsNavigationProperty(PropertyInfo property)
        {
            var type = property.PropertyType;
            if (type == typeof(string)) return false;
            if (typeof(System.Collections.IEnumerable).IsAssignableFrom(type) &&
                type.IsGenericType && type.GetGenericArguments().Length == 1)
            {
                return IsDomainType(type.GetGenericArguments()[0]);
            }
            return IsDomainType(type);
        }

        foreach (var entityType in modelBuilder.Model.GetEntityTypes().ToList())
        {
            var clrType = entityType.ClrType;
            if (clrType.Namespace == null) continue;
            if (keepNamespaces.Contains(clrType.Namespace)) continue;
            if (clrType.Name == "Partation" || clrType.Name == "ContactMessage") continue;
            if (!IsDomainType(clrType)) continue;

            foreach (var property in clrType.GetProperties())
            {
                if (IsNavigationProperty(property))
                {
                    modelBuilder.Entity(clrType).Ignore(property.Name);
                }
            }
        }

        modelBuilder.Entity<ApplicationUser>(entity =>
        {
            entity.Property(x => x.FirstName)
                .HasMaxLength(100);

            entity.Property(x => x.LastName)
                .HasMaxLength(100);

            entity.Property(x => x.ProfileImageUrl)
                .HasMaxLength(500);
        });



        //base.OnModelCreating(modelBuilder);

        //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        //{
        //    if (typeof(AggregateRootEntityBase<int>).IsAssignableFrom(entityType.ClrType))
        //    {
        //        var parameter = System.Linq.Expressions.Expression.Parameter(entityType.ClrType, "e");
        //        var property = System.Linq.Expressions.Expression.Property(parameter, "IsDeleted");
        //        var condition = System.Linq.Expressions.Expression.Equal(property, System.Linq.Expressions.Expression.Constant(false));
        //        var lambda = System.Linq.Expressions.Expression.Lambda(condition, parameter);

        //        modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
        //    }
        //}
        //modelBuilder.Entity<HadithTakhreej>(entity =>
        //{
        //    entity.HasKey(x => new { x.HadithIdFrom, x.HadithIdTo });

        //    // العلاقة الأولى
        //    entity.HasOne(x => x.HadithFrom)
        //          .WithMany(h => h.TakhreejFrom)
        //          .HasForeignKey(x => x.HadithIdFrom)
        //          .OnDelete(DeleteBehavior.Restrict);

        //    // العلاقة الثانية
        //    entity.HasOne(x => x.HadithTo)
        //          .WithMany(h => h.TakhreejTo)
        //          .HasForeignKey(x => x.HadithIdTo)
        //          .OnDelete(DeleteBehavior.Restrict);
        //});


        //modelBuilder.Entity<Hadith>()
        //        .Property(h => h.Id)
        //        .ValueGeneratedNever();

        //modelBuilder.Entity<SharhBook>(entity =>
        //    {
        //        entity.HasOne(x => x.Classification)
        //              .WithMany(c => c.SharhBook)
        //              .HasForeignKey(x => x.ClassificationId)
        //              .OnDelete(DeleteBehavior.Restrict);

        //        entity.HasOne(x => x.ClassificationRefrenace)
        //                  .WithMany()
        //                  .HasForeignKey(x => x.ClassificationRefrenaceId)
        //                  .OnDelete(DeleteBehavior.Restrict);

        //    });



    }
}