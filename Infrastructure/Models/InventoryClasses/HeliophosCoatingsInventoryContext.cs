using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models.InventoryClasses;

public partial class HeliophosCoatingsInventoryContext : DbContext
{
    public HeliophosCoatingsInventoryContext()
    {
    }

    public HeliophosCoatingsInventoryContext(DbContextOptions<HeliophosCoatingsInventoryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdUser> AdUsers { get; set; }

    public virtual DbSet<AirFilterType> AirFilterTypes { get; set; }

    public virtual DbSet<AllowedCompany> AllowedCompanies { get; set; }

    public virtual DbSet<AnnualStockCount> AnnualStockCounts { get; set; }

    public virtual DbSet<AnnualStockCountItemMerge> AnnualStockCountItemMerges { get; set; }

    public virtual DbSet<AnnualStockCountItemQuantity> AnnualStockCountItemQuantities { get; set; }

    public virtual DbSet<ApprovalMatrix> ApprovalMatrices { get; set; }

    public virtual DbSet<ApprovalMatrixConfig> ApprovalMatrixConfigs { get; set; }

    public virtual DbSet<ApprovalMatrixConfigDetail> ApprovalMatrixConfigDetails { get; set; }

    public virtual DbSet<ApprovalMatrixDetail> ApprovalMatrixDetails { get; set; }

    public virtual DbSet<ApprovalMatrixRange> ApprovalMatrixRanges { get; set; }

    public virtual DbSet<ApprovalScreen> ApprovalScreens { get; set; }

    public virtual DbSet<ApprovalStatus> ApprovalStatuses { get; set; }

    public virtual DbSet<Asset> Assets { get; set; }

    public virtual DbSet<AssetAttachment> AssetAttachments { get; set; }

    public virtual DbSet<AssetCommissioning> AssetCommissionings { get; set; }

    public virtual DbSet<AssetCompline> AssetComplines { get; set; }

    public virtual DbSet<AssetComponent> AssetComponents { get; set; }

    public virtual DbSet<AssetCount> AssetCounts { get; set; }

    public virtual DbSet<AssetCountDetail> AssetCountDetails { get; set; }

    public virtual DbSet<AssetCountIssue> AssetCountIssues { get; set; }

    public virtual DbSet<AssetCountIssueStatus> AssetCountIssueStatuses { get; set; }

    public virtual DbSet<AssetCountPlan> AssetCountPlans { get; set; }

    public virtual DbSet<AssetCountPlanDetail> AssetCountPlanDetails { get; set; }

    public virtual DbSet<AssetCountPlanStatus> AssetCountPlanStatuses { get; set; }

    public virtual DbSet<AssetCountPlanType> AssetCountPlanTypes { get; set; }

    public virtual DbSet<AssetCountStatus> AssetCountStatuses { get; set; }

    public virtual DbSet<AssetDisposed> AssetDisposeds { get; set; }

    public virtual DbSet<AssetFunctionality> AssetFunctionalities { get; set; }

    public virtual DbSet<AssetItem> AssetItems { get; set; }

    public virtual DbSet<AssetItemAttachment> AssetItemAttachments { get; set; }

    public virtual DbSet<AssetItemMaintenance> AssetItemMaintenances { get; set; }

    public virtual DbSet<AssetItemMove> AssetItemMoves { get; set; }

    public virtual DbSet<AssetItemScrap> AssetItemScraps { get; set; }

    public virtual DbSet<AssetMaintenanceStatus> AssetMaintenanceStatuses { get; set; }

    public virtual DbSet<AssetMoveType> AssetMoveTypes { get; set; }

    public virtual DbSet<AssetScrapStatus> AssetScrapStatuses { get; set; }

    public virtual DbSet<AssetStatus> AssetStatuses { get; set; }

    public virtual DbSet<AssetWarrantyStatus> AssetWarrantyStatuses { get; set; }

    public virtual DbSet<AssetsGroup> AssetsGroups { get; set; }

    public virtual DbSet<AssetsType> AssetsTypes { get; set; }

    public virtual DbSet<AssignAssetTypeToAssetGroup> AssignAssetTypeToAssetGroups { get; set; }

    public virtual DbSet<AssignCostCenterToSector> AssignCostCenterToSectors { get; set; }

    public virtual DbSet<AssignLocationSite> AssignLocationSites { get; set; }

    public virtual DbSet<AssignSiteSection> AssignSiteSections { get; set; }

    public virtual DbSet<AssignVendorEvaluationCriterion> AssignVendorEvaluationCriteria { get; set; }

    public virtual DbSet<AssignVendorSpecialization> AssignVendorSpecializations { get; set; }

    public virtual DbSet<AuditTrail> AuditTrails { get; set; }

    public virtual DbSet<AuditTrailDetail> AuditTrailDetails { get; set; }

    public virtual DbSet<BatteryType> BatteryTypes { get; set; }

    public virtual DbSet<Cairo202320240721> Cairo202320240721s { get; set; }

    public virtual DbSet<Cairo202320240721merge> Cairo202320240721merges { get; set; }

    public virtual DbSet<Cairo2024> Cairo2024s { get; set; }

    public virtual DbSet<CairoAvgcost20240729> CairoAvgcost20240729s { get; set; }

    public virtual DbSet<ChemicalGroup> ChemicalGroups { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<CommissionCondition> CommissionConditions { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<ContactType> ContactTypes { get; set; }

    public virtual DbSet<CostCenter> CostCenters { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DashboardInventoryItemBalancePerStore> DashboardInventoryItemBalancePerStores { get; set; }

    public virtual DbSet<DashboardIssueIn> DashboardIssueIns { get; set; }

    public virtual DbSet<DashboardIssueOut> DashboardIssueOuts { get; set; }

    public virtual DbSet<DashboardPurchaseOrder> DashboardPurchaseOrders { get; set; }

    public virtual DbSet<DashboardPurchaseRequest> DashboardPurchaseRequests { get; set; }

    public virtual DbSet<DataMergeItem> DataMergeItems { get; set; }

    public virtual DbSet<DaysOfWeek> DaysOfWeeks { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeJob> EmployeeJobs { get; set; }

    public virtual DbSet<EngineSize> EngineSizes { get; set; }

    public virtual DbSet<EquipmentCode> EquipmentCodes { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<Factory> Factories { get; set; }

    public virtual DbSet<FactoryLine> FactoryLines { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Heba202320240721> Heba202320240721s { get; set; }

    public virtual DbSet<Heba202320240721merge> Heba202320240721merges { get; set; }

    public virtual DbSet<Heba2024> Heba2024s { get; set; }

    public virtual DbSet<HebaAvgcost20240729> HebaAvgcost20240729s { get; set; }

    public virtual DbSet<InsuranceVendor> InsuranceVendors { get; set; }

    public virtual DbSet<InventoryCurrency> InventoryCurrencies { get; set; }

    public virtual DbSet<InventoryItem> InventoryItems { get; set; }

    public virtual DbSet<InventoryItem2024> InventoryItem2024s { get; set; }

    public virtual DbSet<InventoryItemAsset> InventoryItemAssets { get; set; }

    public virtual DbSet<InventoryItemBudget> InventoryItemBudgets { get; set; }

    public virtual DbSet<InventoryItemBudgetDetail> InventoryItemBudgetDetails { get; set; }

    public virtual DbSet<InventoryItemCost> InventoryItemCosts { get; set; }

    public virtual DbSet<InventoryItemEquivalentSp> InventoryItemEquivalentSps { get; set; }

    public virtual DbSet<InventoryItemLocation> InventoryItemLocations { get; set; }

    public virtual DbSet<InventoryItemLocation20230404> InventoryItemLocation20230404s { get; set; }

    public virtual DbSet<InventoryItemLocation20230505> InventoryItemLocation20230505s { get; set; }

    public virtual DbSet<InventoryItemLocation20240723> InventoryItemLocation20240723s { get; set; }

    public virtual DbSet<InventoryItemLocationBatch> InventoryItemLocationBatches { get; set; }

    public virtual DbSet<InventoryItemLocationBatchSerial> InventoryItemLocationBatchSerials { get; set; }

    public virtual DbSet<InventoryItemLocationDetail> InventoryItemLocationDetails { get; set; }

    public virtual DbSet<InventoryItemLocationDetail20240723> InventoryItemLocationDetail20240723s { get; set; }

    public virtual DbSet<InventoryItemMerge20240522> InventoryItemMerge20240522s { get; set; }

    public virtual DbSet<InventoryItemMerge20240610> InventoryItemMerge20240610s { get; set; }

    public virtual DbSet<InventoryItemOpeningBalance> InventoryItemOpeningBalances { get; set; }

    public virtual DbSet<InventoryItemReturn> InventoryItemReturns { get; set; }

    public virtual DbSet<InventoryItemReturnAttachment> InventoryItemReturnAttachments { get; set; }

    public virtual DbSet<InventoryItemReturnBatch> InventoryItemReturnBatches { get; set; }

    public virtual DbSet<InventoryItemReturnBatchSerial> InventoryItemReturnBatchSerials { get; set; }

    public virtual DbSet<InventoryItemReturnDetail> InventoryItemReturnDetails { get; set; }

    public virtual DbSet<InventoryItemReturnSerial> InventoryItemReturnSerials { get; set; }

    public virtual DbSet<InventoryItemSerial> InventoryItemSerials { get; set; }

    public virtual DbSet<InventoryItemSerialStatus> InventoryItemSerialStatuses { get; set; }

    public virtual DbSet<InventoryItemStatus> InventoryItemStatuses { get; set; }

    public virtual DbSet<InventoryItemTransactionType> InventoryItemTransactionTypes { get; set; }

    public virtual DbSet<InventoryItemTrasnsactionType> InventoryItemTrasnsactionTypes { get; set; }

    public virtual DbSet<InventoryItemUoM> InventoryItemUoMs { get; set; }

    public virtual DbSet<InventoryItemVendor> InventoryItemVendors { get; set; }

    public virtual DbSet<InventoryStockCount> InventoryStockCounts { get; set; }

    public virtual DbSet<InventoryStockCountDetail> InventoryStockCountDetails { get; set; }

    public virtual DbSet<InventoryStockCountDetailBatch> InventoryStockCountDetailBatches { get; set; }

    public virtual DbSet<InventoryStockCountDetailBatchSerial> InventoryStockCountDetailBatchSerials { get; set; }

    public virtual DbSet<InventoryStockCountPlan> InventoryStockCountPlans { get; set; }

    public virtual DbSet<InventoryStockCountPlanDetail> InventoryStockCountPlanDetails { get; set; }

    public virtual DbSet<InventoryStockCountStatus> InventoryStockCountStatuses { get; set; }

    public virtual DbSet<InventoryTransfere> InventoryTransferes { get; set; }

    public virtual DbSet<InventoryTransfereAttachment> InventoryTransfereAttachments { get; set; }

    public virtual DbSet<InventoryTransfereDetail> InventoryTransfereDetails { get; set; }

    public virtual DbSet<InventoryTransfereDetailBatch> InventoryTransfereDetailBatches { get; set; }

    public virtual DbSet<InventoryTransfereDetailBatchSerial> InventoryTransfereDetailBatchSerials { get; set; }

    public virtual DbSet<InventoryTransfereSerial> InventoryTransfereSerials { get; set; }

    public virtual DbSet<InventoryYear> InventoryYears { get; set; }

    public virtual DbSet<InventroyItemRequestWithdraw> InventroyItemRequestWithdraws { get; set; }

    public virtual DbSet<InventroyItemRequestWithdrawAttachment> InventroyItemRequestWithdrawAttachments { get; set; }

    public virtual DbSet<InventroyItemRequestWithdrawDetail> InventroyItemRequestWithdrawDetails { get; set; }

    public virtual DbSet<Isle> Isles { get; set; }

    public virtual DbSet<ItemBalanceStatus> ItemBalanceStatuses { get; set; }

    public virtual DbSet<ItemExpiryType> ItemExpiryTypes { get; set; }

    public virtual DbSet<ItemQuantityType> ItemQuantityTypes { get; set; }

    public virtual DbSet<ItemRequestStatus> ItemRequestStatuses { get; set; }

    public virtual DbSet<ItemType> ItemTypes { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Line> Lines { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Manufacture> Manufactures { get; set; }

    public virtual DbSet<MaterialCategory> MaterialCategories { get; set; }

    public virtual DbSet<MaterialGroup> MaterialGroups { get; set; }

    public virtual DbSet<MaterialSubCategory> MaterialSubCategories { get; set; }

    public virtual DbSet<MmItemsForMerge2> MmItemsForMerge2s { get; set; }

    public virtual DbSet<ModuleSetting> ModuleSettings { get; set; }

    public virtual DbSet<MotorodItem> MotorodItems { get; set; }

    public virtual DbSet<NotFoundItem> NotFoundItems { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<NotificationLog> NotificationLogs { get; set; }

    public virtual DbSet<NotificationPlaceHolder> NotificationPlaceHolders { get; set; }

    public virtual DbSet<NotificationState> NotificationStates { get; set; }

    public virtual DbSet<NotificationTemplate> NotificationTemplates { get; set; }

    public virtual DbSet<NotificationTemplateContact> NotificationTemplateContacts { get; set; }

    public virtual DbSet<NotificationType> NotificationTypes { get; set; }

    public virtual DbSet<Oil> Oils { get; set; }

    public virtual DbSet<OrderLineItemStatus> OrderLineItemStatuses { get; set; }

    public virtual DbSet<Ou> Ous { get; set; }

    public virtual DbSet<Ownership> Ownerships { get; set; }

    public virtual DbSet<PaymentTerm> PaymentTerms { get; set; }

    public virtual DbSet<Pdaassignment> Pdaassignments { get; set; }

    public virtual DbSet<Pdadetail> Pdadetails { get; set; }

    public virtual DbSet<Pdamodel> Pdamodels { get; set; }

    public virtual DbSet<PdarequestsLog> PdarequestsLogs { get; set; }

    public virtual DbSet<PoChangeVehicle20240331> PoChangeVehicle20240331s { get; set; }

    public virtual DbSet<PoserviceAsset> PoserviceAssets { get; set; }

    public virtual DbSet<PoserviceDetail> PoserviceDetails { get; set; }

    public virtual DbSet<PoserviceOutsource> PoserviceOutsources { get; set; }

    public virtual DbSet<PoserviceRecomendedResource> PoserviceRecomendedResources { get; set; }

    public virtual DbSet<PoserviceTermsAndCondition> PoserviceTermsAndConditions { get; set; }

    public virtual DbSet<PoserviceType> PoserviceTypes { get; set; }

    public virtual DbSet<PossessionType> PossessionTypes { get; set; }

    public virtual DbSet<ProcDatum> ProcData { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Pruser> Prusers { get; set; }

    public virtual DbSet<PurchaseOrderService> PurchaseOrderServices { get; set; }

    public virtual DbSet<PurchaseOrderServiceAttachment> PurchaseOrderServiceAttachments { get; set; }

    public virtual DbSet<Rack> Racks { get; set; }

    public virtual DbSet<Rank> Ranks { get; set; }

    public virtual DbSet<RequestLineItemStatus> RequestLineItemStatuses { get; set; }

    public virtual DbSet<RequestWithdrawSerial> RequestWithdrawSerials { get; set; }

    public virtual DbSet<ReturnReason> ReturnReasons { get; set; }

    public virtual DbSet<ReturnStatus> ReturnStatuses { get; set; }

    public virtual DbSet<RwDeliveredBatch> RwDeliveredBatches { get; set; }

    public virtual DbSet<RwDeliveredQuantity> RwDeliveredQuantities { get; set; }

    public virtual DbSet<RwDeliveredSerial> RwDeliveredSerials { get; set; }

    public virtual DbSet<RwPickedBatch> RwPickedBatches { get; set; }

    public virtual DbSet<RwPickedQuantity> RwPickedQuantities { get; set; }

    public virtual DbSet<RwPickedSerial> RwPickedSerials { get; set; }

    public virtual DbSet<SalesInvoice> SalesInvoices { get; set; }

    public virtual DbSet<SalesInvoiceItem> SalesInvoiceItems { get; set; }

    public virtual DbSet<SalesQuotation> SalesQuotations { get; set; }

    public virtual DbSet<SalesQuotationDetail> SalesQuotationDetails { get; set; }

    public virtual DbSet<Scope> Scopes { get; set; }

    public virtual DbSet<SecConfiguration> SecConfigurations { get; set; }

    public virtual DbSet<SecModel> SecModels { get; set; }

    public virtual DbSet<SecModelAttribute> SecModelAttributes { get; set; }

    public virtual DbSet<SecModule> SecModules { get; set; }

    public virtual DbSet<SecProperty> SecProperties { get; set; }

    public virtual DbSet<SecRole> SecRoles { get; set; }

    public virtual DbSet<SecRoleModelAttribute> SecRoleModelAttributes { get; set; }

    public virtual DbSet<SecRoleModule> SecRoleModules { get; set; }

    public virtual DbSet<SecRoleProperty> SecRoleProperties { get; set; }

    public virtual DbSet<SecRoleSecurableValue> SecRoleSecurableValues { get; set; }

    public virtual DbSet<SecRoleViewAction> SecRoleViewActions { get; set; }

    public virtual DbSet<SecUserModelAtrribute> SecUserModelAtrributes { get; set; }

    public virtual DbSet<SecUserModule> SecUserModules { get; set; }

    public virtual DbSet<SecUserProperty> SecUserProperties { get; set; }

    public virtual DbSet<SecUserSecurableValue> SecUserSecurableValues { get; set; }

    public virtual DbSet<SecUserViewAction> SecUserViewActions { get; set; }

    public virtual DbSet<SecView> SecViews { get; set; }

    public virtual DbSet<SecViewAction> SecViewActions { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Sector> Sectors { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceCategory> ServiceCategories { get; set; }

    public virtual DbSet<ServiceMainCategory> ServiceMainCategories { get; set; }

    public virtual DbSet<ServiceSubCategory> ServiceSubCategories { get; set; }

    public virtual DbSet<ServiceType> ServiceTypes { get; set; }

    public virtual DbSet<Sheet1> Sheet1s { get; set; }

    public virtual DbSet<Shelf> Shelves { get; set; }

    public virtual DbSet<Site> Sites { get; set; }

    public virtual DbSet<SparePartGroup> SparePartGroups { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<StockCount20230331> StockCount20230331s { get; set; }

    public virtual DbSet<StockCountPlanStatus> StockCountPlanStatuses { get; set; }

    public virtual DbSet<StockCountPlanType> StockCountPlanTypes { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<StoreKeeper> StoreKeepers { get; set; }

    public virtual DbSet<StoreSequence> StoreSequences { get; set; }

    public virtual DbSet<SubSection> SubSections { get; set; }

    public virtual DbSet<SysKeyValue> SysKeyValues { get; set; }

    public virtual DbSet<Temp> Temps { get; set; }

    public virtual DbSet<TempBatch> TempBatches { get; set; }

    public virtual DbSet<TermsAndCondition> TermsAndConditions { get; set; }

    public virtual DbSet<ToolsType> ToolsTypes { get; set; }

    public virtual DbSet<TransferReason> TransferReasons { get; set; }

    public virtual DbSet<TransferStatus> TransferStatuses { get; set; }

    public virtual DbSet<TransfereType> TransfereTypes { get; set; }

    public virtual DbSet<TransmissionType> TransmissionTypes { get; set; }

    public virtual DbSet<UnitOfMeasure> UnitOfMeasures { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserSessionInfo> UserSessionInfos { get; set; }

    public virtual DbSet<UserSessionInfoDetail> UserSessionInfoDetails { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<VehicleBrand> VehicleBrands { get; set; }

    public virtual DbSet<VehicleColor> VehicleColors { get; set; }

    public virtual DbSet<VehicleModel> VehicleModels { get; set; }

    public virtual DbSet<VehicleOption> VehicleOptions { get; set; }

    public virtual DbSet<VehicleStatus> VehicleStatuses { get; set; }

    public virtual DbSet<VehicleType> VehicleTypes { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    public virtual DbSet<VendorAttachment> VendorAttachments { get; set; }

    public virtual DbSet<VendorEvaluationCriterion> VendorEvaluationCriteria { get; set; }

    public virtual DbSet<VendorOrder> VendorOrders { get; set; }

    public virtual DbSet<VendorOrderAttachment> VendorOrderAttachments { get; set; }

    public virtual DbSet<VendorOrderDetail> VendorOrderDetails { get; set; }

    public virtual DbSet<VendorOrderPartiallyReceivedNote> VendorOrderPartiallyReceivedNotes { get; set; }

    public virtual DbSet<VendorOrderQuality> VendorOrderQualities { get; set; }

    public virtual DbSet<VendorOrderQualityAttachment> VendorOrderQualityAttachments { get; set; }

    public virtual DbSet<VendorOrderQualityDetail> VendorOrderQualityDetails { get; set; }

    public virtual DbSet<VendorOrderQualityDetailBatch> VendorOrderQualityDetailBatches { get; set; }

    public virtual DbSet<VendorOrderReceive> VendorOrderReceives { get; set; }

    public virtual DbSet<VendorOrderReceiveAttachment> VendorOrderReceiveAttachments { get; set; }

    public virtual DbSet<VendorOrderReceiveDetail> VendorOrderReceiveDetails { get; set; }

    public virtual DbSet<VendorOrderReceiveDetailBatch> VendorOrderReceiveDetailBatches { get; set; }

    public virtual DbSet<VendorOrderReceiveDetailBatchSerial> VendorOrderReceiveDetailBatchSerials { get; set; }

    public virtual DbSet<VendorOrderReceiveSerial> VendorOrderReceiveSerials { get; set; }

    public virtual DbSet<VendorOrderScreen> VendorOrderScreens { get; set; }

    public virtual DbSet<VendorOrderStatus> VendorOrderStatuses { get; set; }

    public virtual DbSet<VendorOrderType> VendorOrderTypes { get; set; }

    public virtual DbSet<VendorOrderVendorSelection> VendorOrderVendorSelections { get; set; }

    public virtual DbSet<VendorOrderVendorSuggested> VendorOrderVendorSuggesteds { get; set; }

    public virtual DbSet<VendorReturn> VendorReturns { get; set; }

    public virtual DbSet<VendorReturnAttachment> VendorReturnAttachments { get; set; }

    public virtual DbSet<VendorReturnDetail> VendorReturnDetails { get; set; }

    public virtual DbSet<VendorReturnDetailBatch> VendorReturnDetailBatches { get; set; }

    public virtual DbSet<VendorReturnDetailBatchSerial> VendorReturnDetailBatchSerials { get; set; }

    public virtual DbSet<VendorReturnSerial> VendorReturnSerials { get; set; }

    public virtual DbSet<VendorSpecialization> VendorSpecializations { get; set; }

    public virtual DbSet<VendorStatus> VendorStatuses { get; set; }

    public virtual DbSet<VendorType> VendorTypes { get; set; }

    public virtual DbSet<ViewRequestStatus> ViewRequestStatuses { get; set; }

    public virtual DbSet<Visit> Visits { get; set; }

    public virtual DbSet<VwInventoryItemDetail> VwInventoryItemDetails { get; set; }

    public virtual DbSet<VwInventoryItemDetailsClean> VwInventoryItemDetailsCleans { get; set; }

    public virtual DbSet<WarrantyStatus> WarrantyStatuses { get; set; }

    public virtual DbSet<WorkerType> WorkerTypes { get; set; }

    public virtual DbSet<WsLastSyncTable> WsLastSyncTables { get; set; }

    public virtual DbSet<Zone> Zones { get; set; }

    public virtual DbSet<ZoneStatus> ZoneStatuses { get; set; }

    public virtual DbSet<_20230515CairoOpeningBalance> _20230515CairoOpeningBalances { get; set; }

    public virtual DbSet<_20230515HebaOpeningBalance> _20230515HebaOpeningBalances { get; set; }

    public virtual DbSet<مسطرد> مسطردs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=10.2.20.3\\MSSQL2012;Database=HeliophosCoatings_Inventory;User Id=ils;Password=!L$@1237;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AD_Users");

            entity.ToTable("AD_User");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AdAccount)
                .HasMaxLength(500)
                .HasColumnName("AD_Account");
            entity.Property(e => e.Mail).HasMaxLength(500);
        });

        modelBuilder.Entity<AirFilterType>(entity =>
        {
            entity.ToTable("AirFilterType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsEnabled).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.NameAr).HasMaxLength(50);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<AllowedCompany>(entity =>
        {
            entity.ToTable("AllowedCompany");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CompanyFk).HasColumnName("CompanyFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.UserFk).HasColumnName("UserFK");

            entity.HasOne(d => d.CompanyFkNavigation).WithMany(p => p.AllowedCompanies)
                .HasForeignKey(d => d.CompanyFk)
                .HasConstraintName("FK_AllowedCompany_Company1");
        });

        modelBuilder.Entity<AnnualStockCount>(entity =>
        {
            entity.ToTable("AnnualStockCount");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.StoreFk).HasColumnName("StoreFK");
            entity.Property(e => e.YearId).HasColumnName("YearID");

            entity.HasOne(d => d.StoreFkNavigation).WithMany(p => p.AnnualStockCounts)
                .HasForeignKey(d => d.StoreFk)
                .HasConstraintName("FK_AnnualStockCount_Store");
        });

        modelBuilder.Entity<AnnualStockCountItemMerge>(entity =>
        {
            entity.ToTable("AnnualStockCountItemMerge");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ActiveInventoryItemFk).HasColumnName("ActiveInventoryItemFK");
            entity.Property(e => e.AnnualStockCountFk).HasColumnName("AnnualStockCountFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.CurrentQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.ActiveInventoryItemFkNavigation).WithMany(p => p.AnnualStockCountItemMergeActiveInventoryItemFkNavigations)
                .HasForeignKey(d => d.ActiveInventoryItemFk)
                .HasConstraintName("FK_AnnualStockCountItemMerge_ActiveInventoryItem");

            entity.HasOne(d => d.AnnualStockCountFkNavigation).WithMany(p => p.AnnualStockCountItemMerges)
                .HasForeignKey(d => d.AnnualStockCountFk)
                .HasConstraintName("FK_AnnualStockCountItemMerge_AnnualStockCount");

            entity.HasOne(d => d.InventoryItemFkNavigation).WithMany(p => p.AnnualStockCountItemMergeInventoryItemFkNavigations)
                .HasForeignKey(d => d.InventoryItemFk)
                .HasConstraintName("FK_AnnualStockCountItemMerge_InventoryItem");
        });

        modelBuilder.Entity<AnnualStockCountItemQuantity>(entity =>
        {
            entity.ToTable("AnnualStockCountItemQuantity");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AnnualStockCountFk).HasColumnName("AnnualStockCountFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.CurrentQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.NewName).HasMaxLength(250);
            entity.Property(e => e.RefId).HasColumnName("RefID");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.StockQuantity).HasColumnType("decimal(18, 3)");
        });

        modelBuilder.Entity<ApprovalMatrix>(entity =>
        {
            entity.ToTable("ApprovalMatrix");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApprovalDate).HasColumnType("datetime");
            entity.Property(e => e.ApprovalMatrixConfigFk).HasColumnName("ApprovalMatrixConfigFK");
            entity.Property(e => e.ApprovalStatusFk).HasColumnName("ApprovalStatusFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EntityId).HasColumnName("EntityID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.ScreenFk).HasColumnName("ScreenFK");

            entity.HasOne(d => d.ApprovalMatrixConfigFkNavigation).WithMany(p => p.ApprovalMatrices)
                .HasForeignKey(d => d.ApprovalMatrixConfigFk)
                .HasConstraintName("FK_ApprovalMatrix_ApprovalMatrixConfig");

            entity.HasOne(d => d.ApprovalStatusFkNavigation).WithMany(p => p.ApprovalMatrices)
                .HasForeignKey(d => d.ApprovalStatusFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApprovalMatrix_ApprovalStatus");

            entity.HasOne(d => d.Entity).WithMany(p => p.ApprovalMatrices)
                .HasForeignKey(d => d.EntityId)
                .HasConstraintName("FK_ApprovalMatrix_InventoryTransfere");

            entity.HasOne(d => d.EntityNavigation).WithMany(p => p.ApprovalMatrices)
                .HasForeignKey(d => d.EntityId)
                .HasConstraintName("FK_ApprovalMatrix_InventroyItemRequestWithdraw");

            entity.HasOne(d => d.Entity1).WithMany(p => p.ApprovalMatrices)
                .HasForeignKey(d => d.EntityId)
                .HasConstraintName("FK_ApprovalMatrix_PurchaseOrderService");

            entity.HasOne(d => d.Entity2).WithMany(p => p.ApprovalMatrices)
                .HasForeignKey(d => d.EntityId)
                .HasConstraintName("FK_ApprovalMatrix_VendorOrder");

            entity.HasOne(d => d.Entity3).WithMany(p => p.ApprovalMatrices)
                .HasForeignKey(d => d.EntityId)
                .HasConstraintName("FK_ApprovalMatrix_VendorReturn");

            entity.HasOne(d => d.ScreenFkNavigation).WithMany(p => p.ApprovalMatrices)
                .HasForeignKey(d => d.ScreenFk)
                .HasConstraintName("FK_ApprovalMatrix_ApprovalScreen");
        });

        modelBuilder.Entity<ApprovalMatrixConfig>(entity =>
        {
            entity.ToTable("ApprovalMatrixConfig");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CompanyFk).HasColumnName("CompanyFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.LocationFk).HasColumnName("LocationFK");
            entity.Property(e => e.ProjectFk).HasColumnName("ProjectFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.ScopeFk).HasColumnName("ScopeFK");
            entity.Property(e => e.ScreenFk).HasColumnName("ScreenFK");
            entity.Property(e => e.ServiceMainCategoryFk).HasColumnName("ServiceMainCategoryFK");

            entity.HasOne(d => d.CompanyFkNavigation).WithMany(p => p.ApprovalMatrixConfigs)
                .HasForeignKey(d => d.CompanyFk)
                .HasConstraintName("FK_ApprovalMatrixConfig_Company");

            entity.HasOne(d => d.LocationFkNavigation).WithMany(p => p.ApprovalMatrixConfigs)
                .HasForeignKey(d => d.LocationFk)
                .HasConstraintName("FK_ApprovalMatrixConfig_Location");

            entity.HasOne(d => d.ProjectFkNavigation).WithMany(p => p.ApprovalMatrixConfigs)
                .HasForeignKey(d => d.ProjectFk)
                .HasConstraintName("FK_ApprovalMatrixConfig_Project");

            entity.HasOne(d => d.ScopeFkNavigation).WithMany(p => p.ApprovalMatrixConfigs)
                .HasForeignKey(d => d.ScopeFk)
                .HasConstraintName("FK_ApprovalMatrixConfig_Scope");

            entity.HasOne(d => d.ScreenFkNavigation).WithMany(p => p.ApprovalMatrixConfigs)
                .HasForeignKey(d => d.ScreenFk)
                .HasConstraintName("FK_ApprovalMatrixConfig_ApprovalScreen");

            entity.HasOne(d => d.ServiceMainCategoryFkNavigation).WithMany(p => p.ApprovalMatrixConfigs)
                .HasForeignKey(d => d.ServiceMainCategoryFk)
                .HasConstraintName("FK_ApprovalMatrixConfig_ServiceMainCategory");
        });

        modelBuilder.Entity<ApprovalMatrixConfigDetail>(entity =>
        {
            entity.ToTable("ApprovalMatrixConfigDetail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApprovalMatrixConfigFk).HasColumnName("ApprovalMatrixConfigFK");
            entity.Property(e => e.ApprovalMatrixRangeFk).HasColumnName("ApprovalMatrixRangeFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.StepName).HasMaxLength(250);
            entity.Property(e => e.StepNameAr).HasMaxLength(250);
            entity.Property(e => e.UserFk).HasColumnName("UserFK");

            entity.HasOne(d => d.ApprovalMatrixConfigFkNavigation).WithMany(p => p.ApprovalMatrixConfigDetails)
                .HasForeignKey(d => d.ApprovalMatrixConfigFk)
                .HasConstraintName("FK_ApprovalMatrixConfigDetail_ApprovalMatrixConfig");

            entity.HasOne(d => d.ApprovalMatrixRangeFkNavigation).WithMany(p => p.ApprovalMatrixConfigDetails)
                .HasForeignKey(d => d.ApprovalMatrixRangeFk)
                .HasConstraintName("FK_ApprovalMatrixConfigDetail_ApprovalMatrixRange");

            entity.HasOne(d => d.UserFkNavigation).WithMany(p => p.ApprovalMatrixConfigDetails)
                .HasForeignKey(d => d.UserFk)
                .HasConstraintName("FK_ApprovalMatrixConfigDetail_User");
        });

        modelBuilder.Entity<ApprovalMatrixDetail>(entity =>
        {
            entity.ToTable("ApprovalMatrixDetail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApprovalDate).HasColumnType("datetime");
            entity.Property(e => e.ApprovalMatrixConfigDetailFk).HasColumnName("ApprovalMatrixConfigDetailFK");
            entity.Property(e => e.ApprovalMatrixFk).HasColumnName("ApprovalMatrixFK");
            entity.Property(e => e.ApprovalStatusFk).HasColumnName("ApprovalStatusFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.UserFk).HasColumnName("UserFK");

            entity.HasOne(d => d.ApprovalMatrixConfigDetailFkNavigation).WithMany(p => p.ApprovalMatrixDetails)
                .HasForeignKey(d => d.ApprovalMatrixConfigDetailFk)
                .HasConstraintName("FK_ApprovalMatrixDetail_ApprovalMatrixConfigDetail");

            entity.HasOne(d => d.ApprovalMatrixFkNavigation).WithMany(p => p.ApprovalMatrixDetails)
                .HasForeignKey(d => d.ApprovalMatrixFk)
                .HasConstraintName("FK_ApprovalMatrixDetail_ApprovalMatrix");

            entity.HasOne(d => d.ApprovalStatusFkNavigation).WithMany(p => p.ApprovalMatrixDetails)
                .HasForeignKey(d => d.ApprovalStatusFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApprovalMatrixDetail_ApprovalStatus");

            entity.HasOne(d => d.UserFkNavigation).WithMany(p => p.ApprovalMatrixDetails)
                .HasForeignKey(d => d.UserFk)
                .HasConstraintName("FK_ApprovalMatrixDetail_User");
        });

        modelBuilder.Entity<ApprovalMatrixRange>(entity =>
        {
            entity.ToTable("ApprovalMatrixRange");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.RangeFrom).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RangeTo).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<ApprovalScreen>(entity =>
        {
            entity.ToTable("ApprovalScreen");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<ApprovalStatus>(entity =>
        {
            entity.ToTable("ApprovalStatus");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Asset>(entity =>
        {
            entity.ToTable("Asset");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ActualDepreciationDate).HasColumnType("datetime");
            entity.Property(e => e.AssetGroupFk).HasColumnName("AssetGroupFK");
            entity.Property(e => e.AssetStatusFk).HasColumnName("AssetStatusFK");
            entity.Property(e => e.AssetTypeFk).HasColumnName("AssetTypeFK");
            entity.Property(e => e.Axsynced).HasColumnName("AXSynced");
            entity.Property(e => e.CheckDate).HasColumnType("datetime");
            entity.Property(e => e.CostPerHour).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.CurrencyFk).HasColumnName("CurrencyFK");
            entity.Property(e => e.DepreciationRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EquipmentCodeFk).HasColumnName("EquipmentCodeFK");
            entity.Property(e => e.GuaranteeExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.InsuranceVendorFk).HasColumnName("InsuranceVendorFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.LifeTime).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ManufactureFk).HasColumnName("ManufactureFK");
            entity.Property(e => e.ModelYearFk).HasColumnName("ModelYearFK");
            entity.Property(e => e.OperationDate).HasColumnType("datetime");
            entity.Property(e => e.Oufk).HasColumnName("OUFK");
            entity.Property(e => e.PlannedDepreciationDate).HasColumnType("datetime");
            entity.Property(e => e.PolicyAmount).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.PolicyDate).HasColumnType("datetime");
            entity.Property(e => e.PolicyExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.PossessionTypeFk).HasColumnName("PossessionTypeFK");
            entity.Property(e => e.ProjectFk).HasColumnName("ProjectFK");
            entity.Property(e => e.PurchaseDate).HasColumnType("datetime");
            entity.Property(e => e.PurchasePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Rfid).HasColumnName("RFID");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.ToolsTypeFk).HasColumnName("ToolsTypeFK");
            entity.Property(e => e.WarrantyStatusFk).HasColumnName("WarrantyStatusFK");
            entity.Property(e => e.ZoneFk).HasColumnName("ZoneFK");

            entity.HasOne(d => d.AssetGroupFkNavigation).WithMany(p => p.Assets)
                .HasForeignKey(d => d.AssetGroupFk)
                .HasConstraintName("FK_Asset_AssetsGroup");

            entity.HasOne(d => d.AssetStatusFkNavigation).WithMany(p => p.Assets)
                .HasForeignKey(d => d.AssetStatusFk)
                .HasConstraintName("FK_Asset_AssetStatus");

            entity.HasOne(d => d.AssetTypeFkNavigation).WithMany(p => p.Assets)
                .HasForeignKey(d => d.AssetTypeFk)
                .HasConstraintName("FK_Asset_AssetsType");

            entity.HasOne(d => d.CurrencyFkNavigation).WithMany(p => p.Assets)
                .HasForeignKey(d => d.CurrencyFk)
                .HasConstraintName("FK_Asset_InventoryCurrency");

            entity.HasOne(d => d.EquipmentCodeFkNavigation).WithMany(p => p.Assets)
                .HasForeignKey(d => d.EquipmentCodeFk)
                .HasConstraintName("FK_Asset_EquipmentCode");

            entity.HasOne(d => d.InsuranceVendorFkNavigation).WithMany(p => p.Assets)
                .HasForeignKey(d => d.InsuranceVendorFk)
                .HasConstraintName("FK_Asset_InsuranceVendor");

            entity.HasOne(d => d.ManufactureFkNavigation).WithMany(p => p.Assets)
                .HasForeignKey(d => d.ManufactureFk)
                .HasConstraintName("FK_Asset_Manufacture");

            entity.HasOne(d => d.ModelYearFkNavigation).WithMany(p => p.Assets)
                .HasForeignKey(d => d.ModelYearFk)
                .HasConstraintName("FK_Asset_InventoryYear");

            entity.HasOne(d => d.OufkNavigation).WithMany(p => p.Assets)
                .HasForeignKey(d => d.Oufk)
                .HasConstraintName("FK_Asset_OU");

            entity.HasOne(d => d.PossessionTypeFkNavigation).WithMany(p => p.Assets)
                .HasForeignKey(d => d.PossessionTypeFk)
                .HasConstraintName("FK_Asset_PossessionType");

            entity.HasOne(d => d.ProjectFkNavigation).WithMany(p => p.Assets)
                .HasForeignKey(d => d.ProjectFk)
                .HasConstraintName("FK_Asset_Project");

            entity.HasOne(d => d.ToolsTypeFkNavigation).WithMany(p => p.Assets)
                .HasForeignKey(d => d.ToolsTypeFk)
                .HasConstraintName("FK_Asset_ToolsType");

            entity.HasOne(d => d.WarrantyStatusFkNavigation).WithMany(p => p.Assets)
                .HasForeignKey(d => d.WarrantyStatusFk)
                .HasConstraintName("FK_Asset_WarrantyStatus");

            entity.HasOne(d => d.ZoneFkNavigation).WithMany(p => p.Assets)
                .HasForeignKey(d => d.ZoneFk)
                .HasConstraintName("FK_Asset_Zone");
        });

        modelBuilder.Entity<AssetAttachment>(entity =>
        {
            entity.ToTable("AssetAttachment");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssetFk).HasColumnName("AssetFK");
            entity.Property(e => e.AttachmentId).HasColumnName("AttachmentID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.AssetFkNavigation).WithMany(p => p.AssetAttachments)
                .HasForeignKey(d => d.AssetFk)
                .HasConstraintName("FK_AssetAttachment_Asset");
        });

        modelBuilder.Entity<AssetCommissioning>(entity =>
        {
            entity.ToTable("AssetCommissioning");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssetComplineFk).HasColumnName("AssetComplineFK");
            entity.Property(e => e.AssetFk).HasColumnName("AssetFK");
            entity.Property(e => e.AssetFunctionalityFk).HasColumnName("AssetFunctionalityFK");
            entity.Property(e => e.CommissionConditionFk).HasColumnName("CommissionConditionFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.SubSectionFk).HasColumnName("SubSectionFK");

            entity.HasOne(d => d.AssetComplineFkNavigation).WithMany(p => p.AssetCommissionings)
                .HasForeignKey(d => d.AssetComplineFk)
                .HasConstraintName("FK_AssetCommissioning_AssetCompline");

            entity.HasOne(d => d.AssetFkNavigation).WithMany(p => p.AssetCommissionings)
                .HasForeignKey(d => d.AssetFk)
                .HasConstraintName("FK_AssetCommissioning_Asset");

            entity.HasOne(d => d.AssetFunctionalityFkNavigation).WithMany(p => p.AssetCommissionings)
                .HasForeignKey(d => d.AssetFunctionalityFk)
                .HasConstraintName("FK_AssetCommissioning_AssetFunctionality");

            entity.HasOne(d => d.CommissionConditionFkNavigation).WithMany(p => p.AssetCommissionings)
                .HasForeignKey(d => d.CommissionConditionFk)
                .HasConstraintName("FK_AssetCommissioning_CommissionCondition");

            entity.HasOne(d => d.SubSectionFkNavigation).WithMany(p => p.AssetCommissionings)
                .HasForeignKey(d => d.SubSectionFk)
                .HasConstraintName("FK_AssetCommissioning_SubSection");
        });

        modelBuilder.Entity<AssetCompline>(entity =>
        {
            entity.ToTable("AssetCompline");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<AssetComponent>(entity =>
        {
            entity.ToTable("AssetComponent");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssetFk).HasColumnName("AssetFK");
            entity.Property(e => e.ComponentFk).HasColumnName("ComponentFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.AssetFkNavigation).WithMany(p => p.AssetComponentAssetFkNavigations)
                .HasForeignKey(d => d.AssetFk)
                .HasConstraintName("FK_AssetComponent_Asset");

            entity.HasOne(d => d.ComponentFkNavigation).WithMany(p => p.AssetComponentComponentFkNavigations)
                .HasForeignKey(d => d.ComponentFk)
                .HasConstraintName("FK_AssetComponent_Component");
        });

        modelBuilder.Entity<AssetCount>(entity =>
        {
            entity.ToTable("AssetCount", tb => tb.HasTrigger("GenerateNumberForAssetCount"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CountDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.ZoneFk).HasColumnName("ZoneFK");

            entity.HasOne(d => d.AssetCountPlanFkNavigation).WithMany(p => p.AssetCounts)
                .HasForeignKey(d => d.AssetCountPlanFk)
                .HasConstraintName("FK_AssetCount_AssetCountPlan");

            entity.HasOne(d => d.ZoneFkNavigation).WithMany(p => p.AssetCounts)
                .HasForeignKey(d => d.ZoneFk)
                .HasConstraintName("FK_AssetCount_Zone");
        });

        modelBuilder.Entity<AssetCountDetail>(entity =>
        {
            entity.ToTable("AssetCountDetail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssetCountStatusFk).HasColumnName("AssetCountStatusFK");
            entity.Property(e => e.AssetFk).HasColumnName("AssetFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.AssetCountFkNavigation).WithMany(p => p.AssetCountDetails)
                .HasForeignKey(d => d.AssetCountFk)
                .HasConstraintName("FK_AssetCountDetail_AssetCount");

            entity.HasOne(d => d.AssetCountStatusFkNavigation).WithMany(p => p.AssetCountDetails)
                .HasForeignKey(d => d.AssetCountStatusFk)
                .HasConstraintName("FK_AssetCountDetail_AssetCountStatus");

            entity.HasOne(d => d.AssetFkNavigation).WithMany(p => p.AssetCountDetails)
                .HasForeignKey(d => d.AssetFk)
                .HasConstraintName("FK_AssetCountDetail_Asset");
        });

        modelBuilder.Entity<AssetCountIssue>(entity =>
        {
            entity.ToTable("AssetCountIssue", tb => tb.HasTrigger("GenerateNumberForIssueNumber"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssetCountDetailFk).HasColumnName("AssetCountDetailFK");
            entity.Property(e => e.AssetCountIssueStatusFk).HasColumnName("AssetCountIssueStatusFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.AssetCountDetailFkNavigation).WithMany(p => p.AssetCountIssues)
                .HasForeignKey(d => d.AssetCountDetailFk)
                .HasConstraintName("FK_AssetCountIssue_AssetCountDetail");

            entity.HasOne(d => d.AssetCountIssueStatusFkNavigation).WithMany(p => p.AssetCountIssues)
                .HasForeignKey(d => d.AssetCountIssueStatusFk)
                .HasConstraintName("FK_AssetCountIssue_AssetCountIssueStatus");
        });

        modelBuilder.Entity<AssetCountIssueStatus>(entity =>
        {
            entity.ToTable("AssetCountIssueStatus");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<AssetCountPlan>(entity =>
        {
            entity.ToTable("AssetCountPlan", tb =>
                {
                    tb.HasTrigger("GenerateNumberForAssetCountPlan");
                    tb.HasTrigger("PDAPlanLogUpdate");
                });

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssetCountPlanStatusFk).HasColumnName("AssetCountPlanStatusFK");
            entity.Property(e => e.AssetCountPlanTypeFk).HasColumnName("AssetCountPlanTypeFK");
            entity.Property(e => e.AssignedToUserFk).HasColumnName("AssignedToUserFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ExecutionDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.PlaneDate).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.AssetCountPlanStatusFkNavigation).WithMany(p => p.AssetCountPlans)
                .HasForeignKey(d => d.AssetCountPlanStatusFk)
                .HasConstraintName("FK_AssetCountPlan_AssetCountPlanStatus");

            entity.HasOne(d => d.AssetCountPlanTypeFkNavigation).WithMany(p => p.AssetCountPlans)
                .HasForeignKey(d => d.AssetCountPlanTypeFk)
                .HasConstraintName("FK_AssetCountPlan_AssetCountPlanType");
        });

        modelBuilder.Entity<AssetCountPlanDetail>(entity =>
        {
            entity.ToTable("AssetCountPlanDetail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssetCountPlanFk).HasColumnName("AssetCountPlanFK");
            entity.Property(e => e.AssignedToUserFk).HasColumnName("AssignedToUserFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.ZoneFk).HasColumnName("ZoneFK");

            entity.HasOne(d => d.AssetCountPlanFkNavigation).WithMany(p => p.AssetCountPlanDetails)
                .HasForeignKey(d => d.AssetCountPlanFk)
                .HasConstraintName("FK_AssetCountPlanDetail_AssetCountPlan");

            entity.HasOne(d => d.ZoneFkNavigation).WithMany(p => p.AssetCountPlanDetails)
                .HasForeignKey(d => d.ZoneFk)
                .HasConstraintName("FK_AssetCountPlanDetail_Zone");
        });

        modelBuilder.Entity<AssetCountPlanStatus>(entity =>
        {
            entity.ToTable("AssetCountPlanStatus");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<AssetCountPlanType>(entity =>
        {
            entity.ToTable("AssetCountPlanType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<AssetCountStatus>(entity =>
        {
            entity.ToTable("AssetCountStatus");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<AssetDisposed>(entity =>
        {
            entity.ToTable("AssetDisposed");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.OrganizationName).HasMaxLength(500);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.AssetDisposed)
                .HasForeignKey<AssetDisposed>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssetDisposed_Asset");
        });

        modelBuilder.Entity<AssetFunctionality>(entity =>
        {
            entity.ToTable("AssetFunctionality");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<AssetItem>(entity =>
        {
            entity.ToTable("AssetItem");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AssetLocationFk).HasColumnName("AssetLocationFK");
            entity.Property(e => e.AssetRowVersion)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("Asset_RowVersion");
            entity.Property(e => e.AssetStatusFk).HasColumnName("AssetStatusFK");
            entity.Property(e => e.AssetWarrantyStatusFk).HasColumnName("AssetWarrantyStatusFK");
            entity.Property(e => e.DepartmentFk).HasColumnName("DepartmentFK");
            entity.Property(e => e.DepreciationAccountCode).HasMaxLength(50);
            entity.Property(e => e.DepreciationDuration).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.DepreciationRate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.EmployeeFk).HasColumnName("EmployeeFK");
            entity.Property(e => e.FixedAssetAccountCode).HasMaxLength(50);
            entity.Property(e => e.InsuranceAccountCode).HasMaxLength(50);
            entity.Property(e => e.InsuranceVendorFk).HasColumnName("InsuranceVendorFK");
            entity.Property(e => e.ModelName).HasMaxLength(250);
            entity.Property(e => e.MoveDate).HasColumnType("datetime");
            entity.Property(e => e.PolicyAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PolicyNumber).HasMaxLength(50);
            entity.Property(e => e.ProjectFk).HasColumnName("ProjectFK");
            entity.Property(e => e.PurchaseValue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.AssetLocationFkNavigation).WithMany(p => p.AssetItems)
                .HasForeignKey(d => d.AssetLocationFk)
                .HasConstraintName("FK_AssetItem_Location");

            entity.HasOne(d => d.AssetStatusFkNavigation).WithMany(p => p.AssetItems)
                .HasForeignKey(d => d.AssetStatusFk)
                .HasConstraintName("FK_AssetItem_AssetStatus");

            entity.HasOne(d => d.AssetWarrantyStatusFkNavigation).WithMany(p => p.AssetItems)
                .HasForeignKey(d => d.AssetWarrantyStatusFk)
                .HasConstraintName("FK_AssetItem_AssetWarrantyStatus");

            entity.HasOne(d => d.EmployeeFkNavigation).WithMany(p => p.AssetItems)
                .HasForeignKey(d => d.EmployeeFk)
                .HasConstraintName("FK_AssetItem_Employee");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.AssetItem)
                .HasForeignKey<AssetItem>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AssetItem_InventoryItemSerial");

            entity.HasOne(d => d.InsuranceVendorFkNavigation).WithMany(p => p.AssetItems)
                .HasForeignKey(d => d.InsuranceVendorFk)
                .HasConstraintName("FK_AssetItem_InsuranceVendor");

            entity.HasOne(d => d.ProjectFkNavigation).WithMany(p => p.AssetItems)
                .HasForeignKey(d => d.ProjectFk)
                .HasConstraintName("FK_AssetItem_Project");
        });

        modelBuilder.Entity<AssetItemAttachment>(entity =>
        {
            entity.ToTable("AssetItemAttachment");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssetItemFk).HasColumnName("AssetItemFK");
            entity.Property(e => e.AttachmentId).HasColumnName("AttachmentID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.AssetItemFkNavigation).WithMany(p => p.AssetItemAttachments)
                .HasForeignKey(d => d.AssetItemFk)
                .HasConstraintName("FK_AssetItemAttachment_AssetItem");
        });

        modelBuilder.Entity<AssetItemMaintenance>(entity =>
        {
            entity.ToTable("AssetItemMaintenance", tb => tb.HasTrigger("AssetItemMaintenance_Code"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssetItemFk).HasColumnName("AssetItemFK");
            entity.Property(e => e.AssetItemMoveFk).HasColumnName("AssetItemMoveFK");
            entity.Property(e => e.AssetMaintenanceStatusFk).HasColumnName("AssetMaintenanceStatusFK");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.AssetItemFkNavigation).WithMany(p => p.AssetItemMaintenances)
                .HasForeignKey(d => d.AssetItemFk)
                .HasConstraintName("FK_AssetItemMaintenance_AssetItem");

            entity.HasOne(d => d.AssetItemMoveFkNavigation).WithMany(p => p.AssetItemMaintenances)
                .HasForeignKey(d => d.AssetItemMoveFk)
                .HasConstraintName("FK_AssetItemMaintenance_AssetItemMove");

            entity.HasOne(d => d.AssetMaintenanceStatusFkNavigation).WithMany(p => p.AssetItemMaintenances)
                .HasForeignKey(d => d.AssetMaintenanceStatusFk)
                .HasConstraintName("FK_AssetItemMaintenance_AssetMaintenanceStatus");
        });

        modelBuilder.Entity<AssetItemMove>(entity =>
        {
            entity.ToTable("AssetItemMove", tb => tb.HasTrigger("AssetItemMove_Code"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssetItemFk).HasColumnName("AssetItemFK");
            entity.Property(e => e.AssetMoveTypeFk).HasColumnName("AssetMoveTypeFK");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EmployeeFk).HasColumnName("EmployeeFK");
            entity.Property(e => e.FromAssetLocationFk).HasColumnName("FromAssetLocationFK");
            entity.Property(e => e.FromProjectFk).HasColumnName("FromProjectFK");
            entity.Property(e => e.IsManagerApprovedFk).HasColumnName("IsManagerApprovedFK");
            entity.Property(e => e.IsOwnerApprovedFk).HasColumnName("IsOwnerApprovedFK");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.ManagerApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.ManagerApprovedFk).HasColumnName("ManagerApprovedFK");
            entity.Property(e => e.OwnerApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.OwnerApprovedFk).HasColumnName("OwnerApprovedFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.ToAssetLocationFk).HasColumnName("ToAssetLocationFK");
            entity.Property(e => e.ToProjectFk).HasColumnName("ToProjectFK");

            entity.HasOne(d => d.AssetItemFkNavigation).WithMany(p => p.AssetItemMoves)
                .HasForeignKey(d => d.AssetItemFk)
                .HasConstraintName("FK_AssetItemMove_AssetItem");

            entity.HasOne(d => d.AssetMoveTypeFkNavigation).WithMany(p => p.AssetItemMoves)
                .HasForeignKey(d => d.AssetMoveTypeFk)
                .HasConstraintName("FK_AssetItemMove_AssetMoveType");

            entity.HasOne(d => d.EmployeeFkNavigation).WithMany(p => p.AssetItemMoveEmployeeFkNavigations)
                .HasForeignKey(d => d.EmployeeFk)
                .HasConstraintName("FK_AssetItemMove_Employee");

            entity.HasOne(d => d.FromAssetLocationFkNavigation).WithMany(p => p.AssetItemMoveFromAssetLocationFkNavigations)
                .HasForeignKey(d => d.FromAssetLocationFk)
                .HasConstraintName("FK_AssetMove_FromAssetLocation");

            entity.HasOne(d => d.FromProjectFkNavigation).WithMany(p => p.AssetItemMoveFromProjectFkNavigations)
                .HasForeignKey(d => d.FromProjectFk)
                .HasConstraintName("FK_AssetItemMove_FromProject");

            entity.HasOne(d => d.IsManagerApprovedFkNavigation).WithMany(p => p.AssetItemMoveIsManagerApprovedFkNavigations)
                .HasForeignKey(d => d.IsManagerApprovedFk)
                .HasConstraintName("FK_AssetItemMove_IsManagerApproved");

            entity.HasOne(d => d.IsOwnerApprovedFkNavigation).WithMany(p => p.AssetItemMoveIsOwnerApprovedFkNavigations)
                .HasForeignKey(d => d.IsOwnerApprovedFk)
                .HasConstraintName("FK_AssetItemMove_IsOwnerApproved");

            entity.HasOne(d => d.ManagerApprovedFkNavigation).WithMany(p => p.AssetItemMoveManagerApprovedFkNavigations)
                .HasForeignKey(d => d.ManagerApprovedFk)
                .HasConstraintName("FK_AssetItemMove_ManagerApproved");

            entity.HasOne(d => d.OwnerApprovedFkNavigation).WithMany(p => p.AssetItemMoveOwnerApprovedFkNavigations)
                .HasForeignKey(d => d.OwnerApprovedFk)
                .HasConstraintName("FK_AssetItemMove_OwnerApproved");

            entity.HasOne(d => d.ToAssetLocationFkNavigation).WithMany(p => p.AssetItemMoveToAssetLocationFkNavigations)
                .HasForeignKey(d => d.ToAssetLocationFk)
                .HasConstraintName("FK_AssetMove_ToAssetLocation");

            entity.HasOne(d => d.ToProjectFkNavigation).WithMany(p => p.AssetItemMoveToProjectFkNavigations)
                .HasForeignKey(d => d.ToProjectFk)
                .HasConstraintName("FK_AssetItemMove_ToProject");
        });

        modelBuilder.Entity<AssetItemScrap>(entity =>
        {
            entity.ToTable("AssetItemScrap", tb => tb.HasTrigger("AssetItemScrap_Code"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ActionDate).HasColumnType("datetime");
            entity.Property(e => e.ApprovalStatusFk).HasColumnName("ApprovalStatusFK");
            entity.Property(e => e.AssetItemFk).HasColumnName("AssetItemFK");
            entity.Property(e => e.AssetItemMaintenanceFk).HasColumnName("AssetItemMaintenanceFK");
            entity.Property(e => e.AssetItemMoveFk).HasColumnName("AssetItemMoveFK");
            entity.Property(e => e.AssetScrapStatusFk).HasColumnName("AssetScrapStatusFK");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.SoldAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ApprovalStatusFkNavigation).WithMany(p => p.AssetItemScraps)
                .HasForeignKey(d => d.ApprovalStatusFk)
                .HasConstraintName("FK_AssetItemScrap_ApprovalStatus");

            entity.HasOne(d => d.AssetItemFkNavigation).WithMany(p => p.AssetItemScraps)
                .HasForeignKey(d => d.AssetItemFk)
                .HasConstraintName("FK_AssetItemScrap_AssetItem");

            entity.HasOne(d => d.AssetItemMaintenanceFkNavigation).WithMany(p => p.AssetItemScraps)
                .HasForeignKey(d => d.AssetItemMaintenanceFk)
                .HasConstraintName("FK_AssetItemScrap_AssetItemMaintenance");

            entity.HasOne(d => d.AssetItemMoveFkNavigation).WithMany(p => p.AssetItemScraps)
                .HasForeignKey(d => d.AssetItemMoveFk)
                .HasConstraintName("FK_AssetItemScrap_AssetItemMove");

            entity.HasOne(d => d.AssetScrapStatusFkNavigation).WithMany(p => p.AssetItemScraps)
                .HasForeignKey(d => d.AssetScrapStatusFk)
                .HasConstraintName("FK_AssetItemScrap_AssetScrapStatus");
        });

        modelBuilder.Entity<AssetMaintenanceStatus>(entity =>
        {
            entity.ToTable("AssetMaintenanceStatus");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<AssetMoveType>(entity =>
        {
            entity.ToTable("AssetMoveType");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<AssetScrapStatus>(entity =>
        {
            entity.ToTable("AssetScrapStatus");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<AssetStatus>(entity =>
        {
            entity.ToTable("AssetStatus");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<AssetWarrantyStatus>(entity =>
        {
            entity.ToTable("AssetWarrantyStatus");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<AssetsGroup>(entity =>
        {
            entity.ToTable("AssetsGroup");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DepreciationDuration).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.DepreciationRate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .HasMaxLength(8)
                .IsFixedLength();
        });

        modelBuilder.Entity<AssetsType>(entity =>
        {
            entity.ToTable("AssetsType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<AssignAssetTypeToAssetGroup>(entity =>
        {
            entity.ToTable("AssignAssetTypeToAssetGroup");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssetGroupFk).HasColumnName("AssetGroupFK");
            entity.Property(e => e.AssetTypeFk).HasColumnName("AssetTypeFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.AssetGroupFkNavigation).WithMany(p => p.AssignAssetTypeToAssetGroups)
                .HasForeignKey(d => d.AssetGroupFk)
                .HasConstraintName("FK_AssignAssetTypeToAssetGroup_AssetsGroup");

            entity.HasOne(d => d.AssetTypeFkNavigation).WithMany(p => p.AssignAssetTypeToAssetGroups)
                .HasForeignKey(d => d.AssetTypeFk)
                .HasConstraintName("FK_AssignAssetTypeToAssetGroup_AssetsType");
        });

        modelBuilder.Entity<AssignCostCenterToSector>(entity =>
        {
            entity.ToTable("AssignCostCenterToSector");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CostCenterFk).HasColumnName("CostCenterFK");
            entity.Property(e => e.SectorFk).HasColumnName("SectorFK");

            entity.HasOne(d => d.CostCenterFkNavigation).WithMany(p => p.AssignCostCenterToSectors)
                .HasForeignKey(d => d.CostCenterFk)
                .HasConstraintName("FK_AssignCostCenterToSector_CostCenter");

            entity.HasOne(d => d.SectorFkNavigation).WithMany(p => p.AssignCostCenterToSectors)
                .HasForeignKey(d => d.SectorFk)
                .HasConstraintName("FK_AssignCostCenterToSector_Sector");
        });

        modelBuilder.Entity<AssignLocationSite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LocationSite");

            entity.ToTable("AssignLocationSite");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.LocationFk).HasColumnName("LocationFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.SiteFk).HasColumnName("SiteFK");

            entity.HasOne(d => d.LocationFkNavigation).WithMany(p => p.AssignLocationSites)
                .HasForeignKey(d => d.LocationFk)
                .HasConstraintName("FK_LocationSite_Location");

            entity.HasOne(d => d.SiteFkNavigation).WithMany(p => p.AssignLocationSites)
                .HasForeignKey(d => d.SiteFk)
                .HasConstraintName("FK_LocationSite_Site");
        });

        modelBuilder.Entity<AssignSiteSection>(entity =>
        {
            entity.ToTable("AssignSiteSection");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.SectionFk).HasColumnName("SectionFK");
            entity.Property(e => e.SiteFk).HasColumnName("SiteFK");

            entity.HasOne(d => d.SectionFkNavigation).WithMany(p => p.AssignSiteSections)
                .HasForeignKey(d => d.SectionFk)
                .HasConstraintName("FK_AssignSiteSection_Section");

            entity.HasOne(d => d.SiteFkNavigation).WithMany(p => p.AssignSiteSections)
                .HasForeignKey(d => d.SiteFk)
                .HasConstraintName("FK_AssignSiteSection_Site");
        });

        modelBuilder.Entity<AssignVendorEvaluationCriterion>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RankFk).HasColumnName("RankFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.VendorEvaluationCriteriaFk).HasColumnName("VendorEvaluationCriteriaFK");
            entity.Property(e => e.VendorFk).HasColumnName("VendorFK");

            entity.HasOne(d => d.RankFkNavigation).WithMany(p => p.AssignVendorEvaluationCriteria)
                .HasForeignKey(d => d.RankFk)
                .HasConstraintName("FK_AssignVendorEvaluationCriteria_Rank");

            entity.HasOne(d => d.VendorEvaluationCriteriaFkNavigation).WithMany(p => p.AssignVendorEvaluationCriteria)
                .HasForeignKey(d => d.VendorEvaluationCriteriaFk)
                .HasConstraintName("FK_AssignVendorEvaluationCriteria_VendorEvaluationCriteria");

            entity.HasOne(d => d.VendorFkNavigation).WithMany(p => p.AssignVendorEvaluationCriteria)
                .HasForeignKey(d => d.VendorFk)
                .HasConstraintName("FK_AssignVendorEvaluationCriteria_Vendor");
        });

        modelBuilder.Entity<AssignVendorSpecialization>(entity =>
        {
            entity.ToTable("AssignVendorSpecialization");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.VendorFk).HasColumnName("VendorFK");
            entity.Property(e => e.VendorSpecializationFk).HasColumnName("VendorSpecializationFK");

            entity.HasOne(d => d.VendorFkNavigation).WithMany(p => p.AssignVendorSpecializations)
                .HasForeignKey(d => d.VendorFk)
                .HasConstraintName("FK_AssignVendorSpecialization_Vendor");

            entity.HasOne(d => d.VendorSpecializationFkNavigation).WithMany(p => p.AssignVendorSpecializations)
                .HasForeignKey(d => d.VendorSpecializationFk)
                .HasConstraintName("FK_AssignVendorSpecialization_VendorSpecialization");
        });

        modelBuilder.Entity<AuditTrail>(entity =>
        {
            entity.ToTable("AuditTrail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Action).HasMaxLength(150);
            entity.Property(e => e.ClientIp).HasColumnName("ClientIP");
            entity.Property(e => e.EntityId).HasColumnName("EntityID");
            entity.Property(e => e.ExecutedAt).HasColumnType("datetime");
            entity.Property(e => e.ParentAuditTrailId).HasColumnName("ParentAuditTrailID");
            entity.Property(e => e.TableName).HasMaxLength(150);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.ParentAuditTrail).WithMany(p => p.InverseParentAuditTrail)
                .HasForeignKey(d => d.ParentAuditTrailId)
                .HasConstraintName("FK_AuditTrail_AuditTrail");

            entity.HasOne(d => d.User).WithMany(p => p.AuditTrails)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AuditTrail_User");
        });

        modelBuilder.Entity<AuditTrailDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_AuditTrialID");

            entity.ToTable("AuditTrailDetail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AuditTrailId).HasColumnName("AuditTrailID");
            entity.Property(e => e.Property).HasMaxLength(150);
            entity.Property(e => e.ReferenceTable)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.AuditTrail).WithMany(p => p.AuditTrailDetails)
                .HasForeignKey(d => d.AuditTrailId)
                .HasConstraintName("FK_AuditTrialDetail_AuditTrail");
        });

        modelBuilder.Entity<BatteryType>(entity =>
        {
            entity.ToTable("BatteryType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(255);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsEnabled).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.NameAr).HasMaxLength(255);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Cairo202320240721>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Cairo_2023_20240721$");

            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.ItemName).HasMaxLength(255);
            entity.Property(e => e.ItemNumber).HasMaxLength(255);
            entity.Property(e => e.Store2).HasColumnName("Store_2");
            entity.Property(e => e.Store3).HasColumnName("Store_3");
            entity.Property(e => e.Store9).HasColumnName("Store_9");
        });

        modelBuilder.Entity<Cairo202320240721merge>(entity =>
        {
            entity.ToTable("Cairo_2023_2024-07-21Merge$");

            entity.Property(e => e.DeletedItemNumber).HasMaxLength(50);
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.ItemNumber).HasMaxLength(50);
        });

        modelBuilder.Entity<Cairo2024>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Cairo_2024$");

            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.ItemName).HasMaxLength(255);
            entity.Property(e => e.MaterialCategory).HasMaxLength(255);
            entity.Property(e => e.MaterialGroup).HasMaxLength(255);
            entity.Property(e => e.MaterialSubCategory).HasMaxLength(255);
            entity.Property(e => e.Store).HasMaxLength(255);
            entity.Property(e => e.StoreFk).HasColumnName("StoreFK");
            entity.Property(e => e.UnitOfMeasure).HasMaxLength(255);
        });

        modelBuilder.Entity<CairoAvgcost20240729>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CairoAVGCost20240729$");

            entity.Property(e => e.Avgcost).HasColumnName("AVGCost");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ItemName).HasMaxLength(255);
            entity.Property(e => e.ItemNumber).HasMaxLength(255);
            entity.Property(e => e.Store).HasMaxLength(255);
        });

        modelBuilder.Entity<ChemicalGroup>(entity =>
        {
            entity.ToTable("ChemicalGroup");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.NameAr).HasMaxLength(50);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("City", tb => tb.HasTrigger("Code_City"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Axsynced).HasColumnName("AXSynced");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RelatedProjectFk).HasColumnName("RelatedProjectFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.StateFk).HasColumnName("StateFK");

            entity.HasOne(d => d.RelatedProjectFkNavigation).WithMany(p => p.Cities)
                .HasForeignKey(d => d.RelatedProjectFk)
                .HasConstraintName("FK_City_Project");

            entity.HasOne(d => d.StateFkNavigation).WithMany(p => p.Cities)
                .HasForeignKey(d => d.StateFk)
                .HasConstraintName("FK_City_State");
        });

        modelBuilder.Entity<CommissionCondition>(entity =>
        {
            entity.ToTable("CommissionCondition");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("Company");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .HasMaxLength(8)
                .IsFixedLength();
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.ToTable("Contact");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ContactValue).HasMaxLength(250);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.ContactType).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.ContactTypeId)
                .HasConstraintName("FK_Contact_ContactType");
        });

        modelBuilder.Entity<ContactType>(entity =>
        {
            entity.ToTable("ContactType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<CostCenter>(entity =>
        {
            entity.ToTable("CostCenter");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsEnabled).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.NameAr).HasMaxLength(50);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country", tb => tb.HasTrigger("Code_Country"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer", tb => tb.HasTrigger("AutoGenerateNumber_Customer"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CommercialRecord).HasMaxLength(250);
            entity.Property(e => e.CompanyFk).HasColumnName("CompanyFK");
            entity.Property(e => e.ContactPerson).HasMaxLength(250);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.OtherVendor).HasMaxLength(250);
            entity.Property(e => e.Phone).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.SectorFk).HasColumnName("SectorFK");
        });

        modelBuilder.Entity<DashboardInventoryItemBalancePerStore>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Dashboard_InventoryItemBalancePerStore");

            entity.Property(e => e.Company).HasMaxLength(250);
            entity.Property(e => e.CompanyFk).HasColumnName("CompanyFK");
            entity.Property(e => e.Cost).HasColumnType("decimal(37, 5)");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.StoreFk).HasColumnName("StoreFK");
        });

        modelBuilder.Entity<DashboardIssueIn>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Dashboard_IssueIN");

            entity.Property(e => e.Company).HasMaxLength(250);
            entity.Property(e => e.CompanyFk).HasColumnName("CompanyFK");
            entity.Property(e => e.ProjectFk).HasColumnName("ProjectFK");
            entity.Property(e => e.ReceivingDate).HasColumnType("datetime");
            entity.Property(e => e.StoreFk).HasColumnName("StoreFK");
            entity.Property(e => e.VendorFk).HasColumnName("VendorFK");
        });

        modelBuilder.Entity<DashboardIssueOut>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Dashboard_IssueOUT");

            entity.Property(e => e.Company).HasMaxLength(250);
            entity.Property(e => e.CompanyFk).HasColumnName("CompanyFK");
            entity.Property(e => e.Line).HasMaxLength(250);
            entity.Property(e => e.LineFk).HasColumnName("LineFK");
            entity.Property(e => e.ProjectFk).HasColumnName("ProjectFK");
            entity.Property(e => e.RequestDate).HasColumnType("datetime");
            entity.Property(e => e.StoreFk).HasColumnName("StoreFK");
        });

        modelBuilder.Entity<DashboardPurchaseOrder>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Dashboard_PurchaseOrder");

            entity.Property(e => e.Company).HasMaxLength(250);
            entity.Property(e => e.CompanyFk).HasColumnName("CompanyFK");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.ProjectFk).HasColumnName("ProjectFK");
            entity.Property(e => e.StoreFk).HasColumnName("StoreFK");
            entity.Property(e => e.TotalCost).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.VendorFk).HasColumnName("VendorFK");
            entity.Property(e => e.VendorOrderStatusFk).HasColumnName("VendorOrderStatusFK");
        });

        modelBuilder.Entity<DashboardPurchaseRequest>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Dashboard_PurchaseRequest");

            entity.Property(e => e.Company).HasMaxLength(250);
            entity.Property(e => e.CompanyFk).HasColumnName("CompanyFK");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.ProjectFk).HasColumnName("ProjectFK");
            entity.Property(e => e.StoreFk).HasColumnName("StoreFK");
            entity.Property(e => e.VendorOrderStatusFk).HasColumnName("VendorOrderStatusFK");
        });

        modelBuilder.Entity<DataMergeItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Data_Merge_Items");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.NewItemFk).HasColumnName("NewItemFK");
            entity.Property(e => e.OldItemFk).HasColumnName("OldItemFK");
        });

        modelBuilder.Entity<DaysOfWeek>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Days");

            entity.ToTable("DaysOfWeek");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EmployeeJobFk).HasColumnName("EmployeeJobFK");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .HasMaxLength(8)
                .IsFixedLength();

            entity.HasOne(d => d.EmployeeJobFkNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeeJobFk)
                .HasConstraintName("FK_Employee_EmployeeJob");
        });

        modelBuilder.Entity<EmployeeJob>(entity =>
        {
            entity.ToTable("EmployeeJob");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.EmployeeJobFk).HasColumnName("EmployeeJobFK");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<EngineSize>(entity =>
        {
            entity.ToTable("EngineSize");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsEnabled).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<EquipmentCode>(entity =>
        {
            entity.ToTable("EquipmentCode");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.ToTable("Expense");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CompanyFk).HasColumnName("CompanyFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
        });

        modelBuilder.Entity<Factory>(entity =>
        {
            entity.ToTable("Factory");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.NameAr).HasMaxLength(100);
            entity.Property(e => e.RowVersion)
                .HasMaxLength(8)
                .IsFixedLength();
        });

        modelBuilder.Entity<FactoryLine>(entity =>
        {
            entity.ToTable("FactoryLine");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.FactoryFk).HasColumnName("FactoryFK");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.NameAr).HasMaxLength(100);
            entity.Property(e => e.RowVersion)
                .HasMaxLength(8)
                .IsFixedLength();

            entity.HasOne(d => d.FactoryFkNavigation).WithMany(p => p.FactoryLines)
                .HasForeignKey(d => d.FactoryFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FactoryLine_Factory");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.ToTable("Gender");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Heba202320240721>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Heba_2023_20240721$");

            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.ItemName).HasMaxLength(255);
            entity.Property(e => e.ItemNumber).HasMaxLength(255);
            entity.Property(e => e.Store1).HasColumnName("Store_1");
            entity.Property(e => e.Store4).HasColumnName("Store_4");
            entity.Property(e => e.Store5).HasColumnName("Store_5");
            entity.Property(e => e.Store6).HasColumnName("Store_6");
            entity.Property(e => e.Store7).HasColumnName("Store_7");
            entity.Property(e => e.Store8).HasColumnName("Store_8");
        });

        modelBuilder.Entity<Heba202320240721merge>(entity =>
        {
            entity.ToTable("Heba_2023_2024-07-21Merge$");

            entity.Property(e => e.DeletedItemNumber).HasMaxLength(50);
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.ItemNumber).HasMaxLength(50);
        });

        modelBuilder.Entity<Heba2024>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Heba_2024$");

            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.ItemName).HasMaxLength(255);
            entity.Property(e => e.MaterialCategory).HasMaxLength(255);
            entity.Property(e => e.MaterialGroup).HasMaxLength(255);
            entity.Property(e => e.MaterialSubCategory).HasMaxLength(255);
            entity.Property(e => e.Store).HasMaxLength(255);
            entity.Property(e => e.StoreFk).HasColumnName("StoreFK");
            entity.Property(e => e.UnitOfMeasure).HasMaxLength(255);
        });

        modelBuilder.Entity<HebaAvgcost20240729>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("HebaAVGCost20240729$");

            entity.Property(e => e.Avgcost).HasColumnName("AVGCost");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ItemName).HasMaxLength(255);
            entity.Property(e => e.ItemNumber).HasMaxLength(255);
            entity.Property(e => e.Store).HasMaxLength(255);
        });

        modelBuilder.Entity<InsuranceVendor>(entity =>
        {
            entity.ToTable("InsuranceVendor");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .HasMaxLength(8)
                .IsFixedLength();
        });

        modelBuilder.Entity<InventoryCurrency>(entity =>
        {
            entity.ToTable("InventoryCurrency");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<InventoryItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_InventoryItems");

            entity.ToTable("InventoryItem", tb => tb.HasTrigger("Code_InventoryItem"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssetGroupFk).HasColumnName("AssetGroupFK");
            entity.Property(e => e.AutoRequestQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.AvgCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Axsynced).HasColumnName("AXSynced");
            entity.Property(e => e.ChemicalGroupFk).HasColumnName("ChemicalGroupFK");
            entity.Property(e => e.Concentration).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DeliveryPeriodDays).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Density).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Dft)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("DFT");
            entity.Property(e => e.IdelPeriod).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ItemExpiryTypeFk).HasColumnName("ItemExpiryTypeFK");
            entity.Property(e => e.ItemQuantityTypeFk).HasColumnName("ItemQuantityTypeFK");
            entity.Property(e => e.ItemTypeFk).HasColumnName("ItemTypeFK");
            entity.Property(e => e.LastPurchasePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.ManufactureFk).HasColumnName("ManufactureFK");
            entity.Property(e => e.MaterialCategoryFk).HasColumnName("MaterialCategoryFK");
            entity.Property(e => e.MaterialGroupFk).HasColumnName("MaterialGroupFK");
            entity.Property(e => e.MaterialSubCategoryFk).HasColumnName("MaterialSubCategoryFK");
            entity.Property(e => e.MaxLevel).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.MinLevel).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Packing).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Rfid).HasColumnName("RFID");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.SparePartGroupFk).HasColumnName("SparePartGroupFK");
            entity.Property(e => e.SpreadingRate).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.TotalQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.UnitOfMeasureFk).HasColumnName("UnitOfMeasureFK");
            entity.Property(e => e.VolumeSolid).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.WarrantyStatusFk).HasColumnName("WarrantyStatusFK");

            entity.HasOne(d => d.AssetGroupFkNavigation).WithMany(p => p.InventoryItems)
                .HasForeignKey(d => d.AssetGroupFk)
                .HasConstraintName("FK_InventoryItem_Assets");

            entity.HasOne(d => d.ChemicalGroupFkNavigation).WithMany(p => p.InventoryItems)
                .HasForeignKey(d => d.ChemicalGroupFk)
                .HasConstraintName("FK_InventoryItem_ChemicalGroup");

            entity.HasOne(d => d.ItemExpiryTypeFkNavigation).WithMany(p => p.InventoryItems)
                .HasForeignKey(d => d.ItemExpiryTypeFk)
                .HasConstraintName("FK_InventoryItem_ItemExpiryType");

            entity.HasOne(d => d.ItemQuantityTypeFkNavigation).WithMany(p => p.InventoryItems)
                .HasForeignKey(d => d.ItemQuantityTypeFk)
                .HasConstraintName("FK_InventoryItem_ItemQuantityType");

            entity.HasOne(d => d.ItemTypeFkNavigation).WithMany(p => p.InventoryItems)
                .HasForeignKey(d => d.ItemTypeFk)
                .HasConstraintName("FK_InventoryItems_ItemType");

            entity.HasOne(d => d.ManufactureFkNavigation).WithMany(p => p.InventoryItems)
                .HasForeignKey(d => d.ManufactureFk)
                .HasConstraintName("FK_InventoryItem_Manufacture");

            entity.HasOne(d => d.MaterialCategoryFkNavigation).WithMany(p => p.InventoryItems)
                .HasForeignKey(d => d.MaterialCategoryFk)
                .HasConstraintName("FK_InventoryItem_MaterialCategory");

            entity.HasOne(d => d.MaterialGroupFkNavigation).WithMany(p => p.InventoryItems)
                .HasForeignKey(d => d.MaterialGroupFk)
                .HasConstraintName("FK_InventoryItem_MaterialGroup");

            entity.HasOne(d => d.MaterialSubCategoryFkNavigation).WithMany(p => p.InventoryItems)
                .HasForeignKey(d => d.MaterialSubCategoryFk)
                .HasConstraintName("FK_InventoryItem_MaterialSubCategory");

            entity.HasOne(d => d.SparePartGroupFkNavigation).WithMany(p => p.InventoryItems)
                .HasForeignKey(d => d.SparePartGroupFk)
                .HasConstraintName("FK_InventoryItem_SparePartGroup");

            entity.HasOne(d => d.UnitOfMeasureFkNavigation).WithMany(p => p.InventoryItems)
                .HasForeignKey(d => d.UnitOfMeasureFk)
                .HasConstraintName("FK_InventoryItem_UnitOfMeasure");

            entity.HasOne(d => d.WarrantyStatusFkNavigation).WithMany(p => p.InventoryItems)
                .HasForeignKey(d => d.WarrantyStatusFk)
                .HasConstraintName("FK_InventoryItem_WarrantyStatus");
        });

        modelBuilder.Entity<InventoryItem2024>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("$InventoryItem_2024");

            entity.Property(e => e.ItemCardAr)
                .HasMaxLength(255)
                .HasColumnName("Item Card AR");
            entity.Property(e => e.ItemCardEn)
                .HasMaxLength(255)
                .HasColumnName("Item Card EN");
            entity.Property(e => e.MaterialCategory)
                .HasMaxLength(255)
                .HasColumnName("Material Category");
            entity.Property(e => e.MaterialCategoryFk).HasColumnName("MaterialCategoryFK");
            entity.Property(e => e.MaterialGroup)
                .HasMaxLength(255)
                .HasColumnName("Material Group");
            entity.Property(e => e.MaterialGroup1)
                .HasMaxLength(255)
                .HasColumnName("_MaterialGroup");
            entity.Property(e => e.MaterialGroupFk).HasColumnName("MaterialGroupFK");
            entity.Property(e => e.MaterialSubCategory)
                .HasMaxLength(255)
                .HasColumnName("Material Sub Category");
            entity.Property(e => e.MaterialSubCategoryFk).HasColumnName("MaterialSubCategoryFK");
            entity.Property(e => e.Store).HasMaxLength(255);
            entity.Property(e => e.TotalQuantity).HasColumnName("Total Quantity");
            entity.Property(e => e.UnitOfMeasure)
                .HasMaxLength(255)
                .HasColumnName("Unit Of Measure");
            entity.Property(e => e.UnitOfMeasureFk).HasColumnName("UnitOfMeasureFK");
        });

        modelBuilder.Entity<InventoryItemAsset>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_InventoryItemAssets");

            entity.ToTable("InventoryItemAsset");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssetFk).HasColumnName("AssetFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.AssetFkNavigation).WithMany(p => p.InventoryItemAssets)
                .HasForeignKey(d => d.AssetFk)
                .HasConstraintName("FK_InventoryItemAsset_Asset");

            entity.HasOne(d => d.InventoryItemFkNavigation).WithMany(p => p.InventoryItemAssets)
                .HasForeignKey(d => d.InventoryItemFk)
                .HasConstraintName("FK_InventoryItemAssets_InventoryItem");
        });

        modelBuilder.Entity<InventoryItemBudget>(entity =>
        {
            entity.ToTable("InventoryItemBudget");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CompanyFk).HasColumnName("CompanyFK");
            entity.Property(e => e.LocationFk).HasColumnName("LocationFK");
            entity.Property(e => e.ProjectFk).HasColumnName("ProjectFK");
            entity.Property(e => e.RowVersion)
                .HasMaxLength(8)
                .IsFixedLength();
            entity.Property(e => e.ScopeFk).HasColumnName("ScopeFK");
            entity.Property(e => e.ServiceMainCategoryFk).HasColumnName("ServiceMainCategoryFK");

            entity.HasOne(d => d.CompanyFkNavigation).WithMany(p => p.InventoryItemBudgets)
                .HasForeignKey(d => d.CompanyFk)
                .HasConstraintName("FK_InventoryItemBudget_Company");

            entity.HasOne(d => d.LocationFkNavigation).WithMany(p => p.InventoryItemBudgets)
                .HasForeignKey(d => d.LocationFk)
                .HasConstraintName("FK_InventoryItemBudget_Location");

            entity.HasOne(d => d.ProjectFkNavigation).WithMany(p => p.InventoryItemBudgets)
                .HasForeignKey(d => d.ProjectFk)
                .HasConstraintName("FK_InventoryItemBudget_Project");

            entity.HasOne(d => d.ScopeFkNavigation).WithMany(p => p.InventoryItemBudgets)
                .HasForeignKey(d => d.ScopeFk)
                .HasConstraintName("FK_InventoryItemBudget_Scope");

            entity.HasOne(d => d.ServiceMainCategoryFkNavigation).WithMany(p => p.InventoryItemBudgets)
                .HasForeignKey(d => d.ServiceMainCategoryFk)
                .HasConstraintName("FK_InventoryItemBudget_ServiceMainCategory");
        });

        modelBuilder.Entity<InventoryItemBudgetDetail>(entity =>
        {
            entity.ToTable("InventoryItemBudgetDetail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BudgetCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.InventoryItemBudgetFk).HasColumnName("InventoryItemBudgetFK");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.ItemTypeFk).HasColumnName("ItemTypeFK");

            entity.HasOne(d => d.InventoryItemBudgetFkNavigation).WithMany(p => p.InventoryItemBudgetDetails)
                .HasForeignKey(d => d.InventoryItemBudgetFk)
                .HasConstraintName("FK_InventoryItemBudgetDetail_InventoryItemBudget");

            entity.HasOne(d => d.InventoryItemFkNavigation).WithMany(p => p.InventoryItemBudgetDetails)
                .HasForeignKey(d => d.InventoryItemFk)
                .HasConstraintName("FK_InventoryItemBudgetDetail_InventoryItem");

            entity.HasOne(d => d.ItemTypeFkNavigation).WithMany(p => p.InventoryItemBudgetDetails)
                .HasForeignKey(d => d.ItemTypeFk)
                .HasConstraintName("FK_InventoryItemBudgetDetail_ItemType");
        });

        modelBuilder.Entity<InventoryItemCost>(entity =>
        {
            entity.ToTable("InventoryItemCost");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AvgCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CompanyFk).HasColumnName("CompanyFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.TotalQuantity).HasColumnType("decimal(18, 3)");

            entity.HasOne(d => d.CompanyFkNavigation).WithMany(p => p.InventoryItemCosts)
                .HasForeignKey(d => d.CompanyFk)
                .HasConstraintName("FK_InventoryItemCost_Company");

            entity.HasOne(d => d.InventoryItemFkNavigation).WithMany(p => p.InventoryItemCosts)
                .HasForeignKey(d => d.InventoryItemFk)
                .HasConstraintName("FK_InventoryItemCost_InventoryItem");
        });

        modelBuilder.Entity<InventoryItemEquivalentSp>(entity =>
        {
            entity.ToTable("InventoryItemEquivalentSP");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EquivalentItemFk).HasColumnName("EquivalentItemFK");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.EquivalentItemFkNavigation).WithMany(p => p.InventoryItemEquivalentSpEquivalentItemFkNavigations)
                .HasForeignKey(d => d.EquivalentItemFk)
                .HasConstraintName("FK_InventoryItemEquivalentSP_InventoryItem1");

            entity.HasOne(d => d.InventoryItemFkNavigation).WithMany(p => p.InventoryItemEquivalentSpInventoryItemFkNavigations)
                .HasForeignKey(d => d.InventoryItemFk)
                .HasConstraintName("FK_InventoryItemEquivalentSP_InventoryItem");
        });

        modelBuilder.Entity<InventoryItemLocation>(entity =>
        {
            entity.ToTable("InventoryItemLocation");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AvgCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ItemQuantityTypeFk).HasColumnName("ItemQuantityTypeFK");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.StoreFk).HasColumnName("StoreFK");

            entity.HasOne(d => d.InventoryItemFkNavigation).WithMany(p => p.InventoryItemLocations)
                .HasForeignKey(d => d.InventoryItemFk)
                .HasConstraintName("FK_InventoryItemLocation_InventoryItem");

            entity.HasOne(d => d.ItemQuantityTypeFkNavigation).WithMany(p => p.InventoryItemLocations)
                .HasForeignKey(d => d.ItemQuantityTypeFk)
                .HasConstraintName("FK_InventoryItemLocation_ItemQuantityType");

            entity.HasOne(d => d.StoreFkNavigation).WithMany(p => p.InventoryItemLocations)
                .HasForeignKey(d => d.StoreFk)
                .HasConstraintName("FK_InventoryItemLocation_Store1");
        });

        modelBuilder.Entity<InventoryItemLocation20230404>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("InventoryItemLocation_20230404");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.ItemQuantityTypeFk).HasColumnName("ItemQuantityTypeFK");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.StoreFk).HasColumnName("StoreFK");
        });

        modelBuilder.Entity<InventoryItemLocation20230505>(entity =>
        {
            entity.ToTable("InventoryItemLocation_20230505");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.ItemQuantityTypeFk).HasColumnName("ItemQuantityTypeFK");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.StoreFk).HasColumnName("StoreFK");
        });

        modelBuilder.Entity<InventoryItemLocation20240723>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("$InventoryItemLocation_20240723");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.ItemQuantityTypeFk).HasColumnName("ItemQuantityTypeFK");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.StoreFk).HasColumnName("StoreFK");
        });

        modelBuilder.Entity<InventoryItemLocationBatch>(entity =>
        {
            entity.ToTable("InventoryItemLocationBatch");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.InventoryItemLocationFk).HasColumnName("InventoryItemLocationFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.ProductionDate).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.ShelfFk).HasColumnName("ShelfFK");
            entity.Property(e => e.TotalQuantity).HasColumnType("decimal(18, 3)");

            entity.HasOne(d => d.InventoryItemLocationFkNavigation).WithMany(p => p.InventoryItemLocationBatches)
                .HasForeignKey(d => d.InventoryItemLocationFk)
                .HasConstraintName("FK_InventoryItemLocationBatch_InventoryItemLocation");

            entity.HasOne(d => d.ShelfFkNavigation).WithMany(p => p.InventoryItemLocationBatches)
                .HasForeignKey(d => d.ShelfFk)
                .HasConstraintName("FK_InventoryItemLocationBatch_Shelf");
        });

        modelBuilder.Entity<InventoryItemLocationBatchSerial>(entity =>
        {
            entity.ToTable("InventoryItemLocationBatchSerial");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryItemLocationBatchFk).HasColumnName("InventoryItemLocationBatchFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.InventoryItemLocationBatchFkNavigation).WithMany(p => p.InventoryItemLocationBatchSerials)
                .HasForeignKey(d => d.InventoryItemLocationBatchFk)
                .HasConstraintName("FK_InventoryItemLocationBatchSerial_InventoryItemLocationBatch");
        });

        modelBuilder.Entity<InventoryItemLocationDetail>(entity =>
        {
            entity.ToTable("InventoryItemLocationDetail", tb => tb.HasTrigger("tr_InventoryItemLocationDetail"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Avgcost)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("AVGCost");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EntityCode).HasMaxLength(50);
            entity.Property(e => e.EntityDate).HasColumnType("datetime");
            entity.Property(e => e.EntityDetailCost).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.EntityDetailId).HasColumnName("EntityDetailID");
            entity.Property(e => e.EntityId).HasColumnName("EntityID");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.InventoryItemLocationBatchFk).HasColumnName("InventoryItemLocationBatchFK");
            entity.Property(e => e.InventoryItemLocationFk).HasColumnName("InventoryItemLocationFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ItemQuantityTypeFk).HasColumnName("ItemQuantityTypeFK");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.QuantityAfter).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.QuantityBefore).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Screen).HasMaxLength(250);
            entity.Property(e => e.StoreFk).HasColumnName("StoreFK");
            entity.Property(e => e.TransactionTypeFk).HasColumnName("TransactionTypeFK");

            entity.HasOne(d => d.InventoryItemFkNavigation).WithMany(p => p.InventoryItemLocationDetails)
                .HasForeignKey(d => d.InventoryItemFk)
                .HasConstraintName("FK_InventoryItemLocationDetail_InventoryItem");

            entity.HasOne(d => d.InventoryItemLocationFkNavigation).WithMany(p => p.InventoryItemLocationDetails)
                .HasForeignKey(d => d.InventoryItemLocationFk)
                .HasConstraintName("FK_InventoryItemLocationDetail_InventoryItemLocation");

            entity.HasOne(d => d.ItemQuantityTypeFkNavigation).WithMany(p => p.InventoryItemLocationDetails)
                .HasForeignKey(d => d.ItemQuantityTypeFk)
                .HasConstraintName("FK_InventoryItemLocationDetail_ItemQuantityType");

            entity.HasOne(d => d.StoreFkNavigation).WithMany(p => p.InventoryItemLocationDetails)
                .HasForeignKey(d => d.StoreFk)
                .HasConstraintName("FK_InventoryItemLocationDetail_Store");

            entity.HasOne(d => d.TransactionTypeFkNavigation).WithMany(p => p.InventoryItemLocationDetails)
                .HasForeignKey(d => d.TransactionTypeFk)
                .HasConstraintName("FK_InventoryItemLocationDetail_InventoryItemTransactionType");
        });

        modelBuilder.Entity<InventoryItemLocationDetail20240723>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("$InventoryItemLocationDetail_20240723");

            entity.Property(e => e.Avgcost).HasColumnName("AVGCost");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EntityCode).HasMaxLength(50);
            entity.Property(e => e.EntityDate).HasColumnType("datetime");
            entity.Property(e => e.EntityDetailCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EntityDetailId).HasColumnName("EntityDetailID");
            entity.Property(e => e.EntityId).HasColumnName("EntityID");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.InventoryItemLocationFk).HasColumnName("InventoryItemLocationFK");
            entity.Property(e => e.ItemQuantityTypeFk).HasColumnName("ItemQuantityTypeFK");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.QuantityAfter).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.QuantityBefore).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Screen).HasMaxLength(250);
            entity.Property(e => e.StoreFk).HasColumnName("StoreFK");
            entity.Property(e => e.TransactionTypeFk).HasColumnName("TransactionTypeFK");
        });

        modelBuilder.Entity<InventoryItemMerge20240522>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("$InventoryItemMerge_2024-05-22");

            entity.Property(e => e.ItemNumber2023).HasMaxLength(255);
            entity.Property(e => e.ItemNumber2023Id).HasColumnName("ItemNumber2023_ID");
            entity.Property(e => e.ItemNumber2024).HasMaxLength(255);
            entity.Property(e => e.ItemNumber2024Id).HasColumnName("ItemNumber2024_ID");
            entity.Property(e => e.OpeningQuantity2024).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.TotalQuantity2023).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.TotalQuantity2024).HasColumnType("decimal(18, 3)");
        });

        modelBuilder.Entity<InventoryItemMerge20240610>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("$InventoryItemMerge_2024-06-10");

            entity.Property(e => e.ItemNumber2023)
                .HasMaxLength(255)
                .HasColumnName("itemNumber_2023");
            entity.Property(e => e.ItemNumber2023Id).HasColumnName("ItemNumber2023_ID");
            entity.Property(e => e.ItemNumber2024)
                .HasMaxLength(255)
                .HasColumnName("itemNumber_2024");
            entity.Property(e => e.ItemNumber2024Id).HasColumnName("ItemNumber2024_ID");
            entity.Property(e => e.OpeningQuantity2024).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.TotalQuantity2023).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.TotalQuantity2024).HasColumnType("decimal(18, 3)");
        });

        modelBuilder.Entity<InventoryItemOpeningBalance>(entity =>
        {
            entity.ToTable("InventoryItemOpeningBalance");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AvgCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.InventoryItemLocationFk).HasColumnName("InventoryItemLocationFK");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.StoreFk).HasColumnName("StoreFK");

            entity.HasOne(d => d.InventoryItemFkNavigation).WithMany(p => p.InventoryItemOpeningBalances)
                .HasForeignKey(d => d.InventoryItemFk)
                .HasConstraintName("FK_InventoryItemOpeningBalance_InventoryItem");

            entity.HasOne(d => d.InventoryItemLocationFkNavigation).WithMany(p => p.InventoryItemOpeningBalances)
                .HasForeignKey(d => d.InventoryItemLocationFk)
                .HasConstraintName("FK_InventoryItemOpeningBalance_InventoryItemLocation");

            entity.HasOne(d => d.StoreFkNavigation).WithMany(p => p.InventoryItemOpeningBalances)
                .HasForeignKey(d => d.StoreFk)
                .HasConstraintName("FK_InventoryItemOpeningBalance_Store");
        });

        modelBuilder.Entity<InventoryItemReturn>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_InventoryItemRWReturn");

            entity.ToTable("InventoryItemReturn", tb => tb.HasTrigger("AutoGenerateNumber_InventoryItemReturn"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Axsynced).HasColumnName("AXSynced");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DescriptionAr).HasColumnName("DescriptionAR");
            entity.Property(e => e.DescriptionEn).HasColumnName("DescriptionEN");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ItemReturnStatusFk).HasColumnName("ItemReturnStatusFK");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RequestWithdrawFk).HasColumnName("RequestWithdrawFK");
            entity.Property(e => e.ReturnDate).HasColumnType("datetime");
            entity.Property(e => e.ReturnedByFk).HasColumnName("ReturnedByFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InventoryItemReturnCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_InventoryItemReturn_CreatedByUser");

            entity.HasOne(d => d.ItemReturnStatusFkNavigation).WithMany(p => p.InventoryItemReturns)
                .HasForeignKey(d => d.ItemReturnStatusFk)
                .HasConstraintName("FK_InventoryItemRWReturn_ReturnStatus");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.InventoryItemReturnLastUpdatedByNavigations)
                .HasForeignKey(d => d.LastUpdatedBy)
                .HasConstraintName("FK_InventoryItemReturn_LastUpdatedByUser");

            entity.HasOne(d => d.RequestWithdrawFkNavigation).WithMany(p => p.InventoryItemReturns)
                .HasForeignKey(d => d.RequestWithdrawFk)
                .HasConstraintName("FK_InventoryItemReturn_InventroyItemRequestWithdraw");

            entity.HasOne(d => d.ReturnedByFkNavigation).WithMany(p => p.InventoryItemReturnReturnedByFkNavigations)
                .HasForeignKey(d => d.ReturnedByFk)
                .HasConstraintName("FK_InventoryItemReturn_ReturnedByUser");
        });

        modelBuilder.Entity<InventoryItemReturnAttachment>(entity =>
        {
            entity.ToTable("InventoryItemReturnAttachment");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AttachmentId).HasColumnName("AttachmentID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryItemReturnFk).HasColumnName("InventoryItemReturnFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.InventoryItemReturnFkNavigation).WithMany(p => p.InventoryItemReturnAttachments)
                .HasForeignKey(d => d.InventoryItemReturnFk)
                .HasConstraintName("FK_InventoryItemReturnAttachment_InventoryItemReturn");
        });

        modelBuilder.Entity<InventoryItemReturnBatch>(entity =>
        {
            entity.ToTable("InventoryItemReturnBatch");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BatchFk).HasColumnName("BatchFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ItemReturnDetailFk).HasColumnName("ItemReturnDetailFK");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.ReturnReasonFk).HasColumnName("ReturnReasonFK");
            entity.Property(e => e.ReturnedQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.RwDeliveredBatchFk).HasColumnName("RW_DeliveredBatchFK");

            entity.HasOne(d => d.ItemReturnDetailFkNavigation).WithMany(p => p.InventoryItemReturnBatches)
                .HasForeignKey(d => d.ItemReturnDetailFk)
                .HasConstraintName("FK_InventoryItemReturnBatch_InventoryItemReturnDetail");

            entity.HasOne(d => d.ReturnReasonFkNavigation).WithMany(p => p.InventoryItemReturnBatches)
                .HasForeignKey(d => d.ReturnReasonFk)
                .HasConstraintName("FK_InventoryItemReturnBatch_ReturnReason");

            entity.HasOne(d => d.RwDeliveredBatchFkNavigation).WithMany(p => p.InventoryItemReturnBatches)
                .HasForeignKey(d => d.RwDeliveredBatchFk)
                .HasConstraintName("FK_InventoryItemReturnBatch_RW_DeliveredBatch");
        });

        modelBuilder.Entity<InventoryItemReturnBatchSerial>(entity =>
        {
            entity.ToTable("InventoryItemReturnBatchSerial");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryItemReturnBatchFk).HasColumnName("InventoryItemReturnBatchFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.ReturnReasonFk).HasColumnName("ReturnReasonFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.RwDelivedSerialFk).HasColumnName("RW_DelivedSerialFK");

            entity.HasOne(d => d.InventoryItemReturnBatchFkNavigation).WithMany(p => p.InventoryItemReturnBatchSerials)
                .HasForeignKey(d => d.InventoryItemReturnBatchFk)
                .HasConstraintName("FK_InventoryItemReturnBatchSerial_InventoryItemReturnBatch");

            entity.HasOne(d => d.ReturnReasonFkNavigation).WithMany(p => p.InventoryItemReturnBatchSerials)
                .HasForeignKey(d => d.ReturnReasonFk)
                .HasConstraintName("FK_InventoryItemReturnBatchSerial_ReturnReason");

            entity.HasOne(d => d.RwDelivedSerialFkNavigation).WithMany(p => p.InventoryItemReturnBatchSerials)
                .HasForeignKey(d => d.RwDelivedSerialFk)
                .HasConstraintName("FK_InventoryItemReturnBatchSerial_RW_DeliveredSerial");
        });

        modelBuilder.Entity<InventoryItemReturnDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_InventoryItemRWReturnDetail");

            entity.ToTable("InventoryItemReturnDetail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ExternalReturnedQuantity).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.InventoryItemReturnFk).HasColumnName("InventoryItemReturnFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RequestWdfk).HasColumnName("RequestWDFK");
            entity.Property(e => e.ReturnReasonFk).HasColumnName("ReturnReasonFK");
            entity.Property(e => e.ReturnedQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.InventoryItemFkNavigation).WithMany(p => p.InventoryItemReturnDetails)
                .HasForeignKey(d => d.InventoryItemFk)
                .HasConstraintName("FK_InventoryItemReturnDetail_InventoryItem");

            entity.HasOne(d => d.InventoryItemReturnFkNavigation).WithMany(p => p.InventoryItemReturnDetails)
                .HasForeignKey(d => d.InventoryItemReturnFk)
                .HasConstraintName("FK_InventoryItemRWReturnDetail_InventoryItemRWReturn");

            entity.HasOne(d => d.ReturnReasonFkNavigation).WithMany(p => p.InventoryItemReturnDetails)
                .HasForeignKey(d => d.ReturnReasonFk)
                .HasConstraintName("FK_InventoryItemReturnDetail_ReturnReason");
        });

        modelBuilder.Entity<InventoryItemReturnSerial>(entity =>
        {
            entity.ToTable("InventoryItemReturnSerial");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryItemReturnDetailFk).HasColumnName("InventoryItemReturnDetailFK");
            entity.Property(e => e.InventoryItemReturnFk).HasColumnName("InventoryItemReturnFK");
            entity.Property(e => e.InventoryItemSerialFk).HasColumnName("InventoryItemSerialFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.InventoryItemReturnDetailFkNavigation).WithMany(p => p.InventoryItemReturnSerials)
                .HasForeignKey(d => d.InventoryItemReturnDetailFk)
                .HasConstraintName("FK_InventoryItemReturnSerial_InventoryItemReturnDetail");

            entity.HasOne(d => d.InventoryItemReturnFkNavigation).WithMany(p => p.InventoryItemReturnSerials)
                .HasForeignKey(d => d.InventoryItemReturnFk)
                .HasConstraintName("FK_InventoryItemReturnSerial_InventoryItemReturn");

            entity.HasOne(d => d.InventoryItemSerialFkNavigation).WithMany(p => p.InventoryItemReturnSerials)
                .HasForeignKey(d => d.InventoryItemSerialFk)
                .HasConstraintName("FK_InventoryItemReturnSerial_InventoryItemSerial");
        });

        modelBuilder.Entity<InventoryItemSerial>(entity =>
        {
            entity.ToTable("InventoryItemSerial");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.InventoryItemSerialStatusFk).HasColumnName("InventoryItemSerialStatusFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.StoreFk).HasColumnName("StoreFK");

            entity.HasOne(d => d.InventoryItemFkNavigation).WithMany(p => p.InventoryItemSerials)
                .HasForeignKey(d => d.InventoryItemFk)
                .HasConstraintName("FK_InventoryItemSerial_InventoryItem");

            entity.HasOne(d => d.InventoryItemSerialStatusFkNavigation).WithMany(p => p.InventoryItemSerials)
                .HasForeignKey(d => d.InventoryItemSerialStatusFk)
                .HasConstraintName("FK_InventoryItemSerial_InventoryItemSerialStatus");

            entity.HasOne(d => d.StoreFkNavigation).WithMany(p => p.InventoryItemSerials)
                .HasForeignKey(d => d.StoreFk)
                .HasConstraintName("FK_InventoryItemSerial_Store");
        });

        modelBuilder.Entity<InventoryItemSerialStatus>(entity =>
        {
            entity.ToTable("InventoryItemSerialStatus");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<InventoryItemStatus>(entity =>
        {
            entity.ToTable("InventoryItemStatus");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<InventoryItemTransactionType>(entity =>
        {
            entity.ToTable("InventoryItemTransactionType");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<InventoryItemTrasnsactionType>(entity =>
        {
            entity.ToTable("InventoryItemTrasnsactionType");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<InventoryItemUoM>(entity =>
        {
            entity.ToTable("InventoryItemUoM");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ConvertRate).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.UnitOfMeasureFk).HasColumnName("UnitOfMeasureFK");

            entity.HasOne(d => d.InventoryItemFkNavigation).WithMany(p => p.InventoryItemUoMs)
                .HasForeignKey(d => d.InventoryItemFk)
                .HasConstraintName("FK_InventoryItemUoM_InventoryItem");

            entity.HasOne(d => d.UnitOfMeasureFkNavigation).WithMany(p => p.InventoryItemUoMs)
                .HasForeignKey(d => d.UnitOfMeasureFk)
                .HasConstraintName("FK_InventoryItemUoM_UnitOfMeasure");
        });

        modelBuilder.Entity<InventoryItemVendor>(entity =>
        {
            entity.ToTable("InventoryItemVendor");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.VendorFk).HasColumnName("VendorFK");

            entity.HasOne(d => d.InventoryItemFkNavigation).WithMany(p => p.InventoryItemVendors)
                .HasForeignKey(d => d.InventoryItemFk)
                .HasConstraintName("FK_InventoryItemVendor_InventoryItem");

            entity.HasOne(d => d.VendorFkNavigation).WithMany(p => p.InventoryItemVendors)
                .HasForeignKey(d => d.VendorFk)
                .HasConstraintName("FK_InventoryItemVendor_Vendor");
        });

        modelBuilder.Entity<InventoryStockCount>(entity =>
        {
            entity.ToTable("InventoryStockCount", tb => tb.HasTrigger("GenerateNumberForInventoryStockCount"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Axsynced).HasColumnName("AXSynced");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryStockCountStatusFk).HasColumnName("InventoryStockCountStatusFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.StockCountDate).HasColumnType("datetime");
            entity.Property(e => e.StoreFk).HasColumnName("StoreFK");

            entity.HasOne(d => d.InventoryStockCountStatusFkNavigation).WithMany(p => p.InventoryStockCounts)
                .HasForeignKey(d => d.InventoryStockCountStatusFk)
                .HasConstraintName("FK_InventoryStockCount_InventoryStockCountStatus");

            entity.HasOne(d => d.StoreFkNavigation).WithMany(p => p.InventoryStockCounts)
                .HasForeignKey(d => d.StoreFk)
                .HasConstraintName("FK_InventoryStockCount_Store");
        });

        modelBuilder.Entity<InventoryStockCountDetail>(entity =>
        {
            entity.ToTable("InventoryStockCountDetail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CountQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.InventoryStockCountFk).HasColumnName("InventoryStockCountFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.InventoryItemFkNavigation).WithMany(p => p.InventoryStockCountDetails)
                .HasForeignKey(d => d.InventoryItemFk)
                .HasConstraintName("FK_InventoryStockCountDetail_InventoryItem");

            entity.HasOne(d => d.InventoryStockCountFkNavigation).WithMany(p => p.InventoryStockCountDetails)
                .HasForeignKey(d => d.InventoryStockCountFk)
                .HasConstraintName("FK_InventoryStockCountDetail_InventoryStockCount");
        });

        modelBuilder.Entity<InventoryStockCountDetailBatch>(entity =>
        {
            entity.ToTable("InventoryStockCountDetailBatch");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BatchFk).HasColumnName("BatchFK");
            entity.Property(e => e.CountQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryStockCountDetailFk).HasColumnName("InventoryStockCountDetailFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.BatchFkNavigation).WithMany(p => p.InventoryStockCountDetailBatches)
                .HasForeignKey(d => d.BatchFk)
                .HasConstraintName("FK_InventoryStockCountDetailBatch_InventoryItemLocationBatch");

            entity.HasOne(d => d.InventoryStockCountDetailFkNavigation).WithMany(p => p.InventoryStockCountDetailBatches)
                .HasForeignKey(d => d.InventoryStockCountDetailFk)
                .HasConstraintName("FK_InventoryStockCountDetailBatch_InventoryStockCountDetail");
        });

        modelBuilder.Entity<InventoryStockCountDetailBatchSerial>(entity =>
        {
            entity.ToTable("InventoryStockCountDetailBatchSerial");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryItemLocationBatchSerialFk).HasColumnName("InventoryItemLocationBatchSerialFK");
            entity.Property(e => e.InventoryStockCountDetailBatchFk).HasColumnName("InventoryStockCountDetailBatchFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.InventoryItemLocationBatchSerialFkNavigation).WithMany(p => p.InventoryStockCountDetailBatchSerials)
                .HasForeignKey(d => d.InventoryItemLocationBatchSerialFk)
                .HasConstraintName("FK_InventoryStockCountDetailBatchSerial_InventoryItemLocationBatchSerial");

            entity.HasOne(d => d.InventoryStockCountDetailBatchFkNavigation).WithMany(p => p.InventoryStockCountDetailBatchSerials)
                .HasForeignKey(d => d.InventoryStockCountDetailBatchFk)
                .HasConstraintName("FK_InventoryStockCountDetailBatchSerial_InventoryStockCountDetailBatch");
        });

        modelBuilder.Entity<InventoryStockCountPlan>(entity =>
        {
            entity.ToTable("InventoryStockCountPlan", tb => tb.HasTrigger("GenerateNumberForInventoryStockCountPlan"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssignedToUserFk).HasColumnName("AssignedToUserFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ExecutionDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.PlanDate).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.StockCountPlanStatusFk).HasColumnName("StockCountPlanStatusFK");
            entity.Property(e => e.StockCountPlanTypeFk).HasColumnName("StockCountPlanTypeFK");

            entity.HasOne(d => d.StockCountPlanStatusFkNavigation).WithMany(p => p.InventoryStockCountPlans)
                .HasForeignKey(d => d.StockCountPlanStatusFk)
                .HasConstraintName("FK_InventoryStockCountPlan_StockCountPlanStatus");

            entity.HasOne(d => d.StockCountPlanTypeFkNavigation).WithMany(p => p.InventoryStockCountPlans)
                .HasForeignKey(d => d.StockCountPlanTypeFk)
                .HasConstraintName("FK_InventoryStockCountPlan_StockCountPlanType");
        });

        modelBuilder.Entity<InventoryStockCountPlanDetail>(entity =>
        {
            entity.ToTable("InventoryStockCountPlanDetail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssignedToUserFk).HasColumnName("AssignedToUserFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryStockCountPlanFk).HasColumnName("InventoryStockCountPlanFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.StoreFk).HasColumnName("StoreFK");

            entity.HasOne(d => d.InventoryStockCountPlanFkNavigation).WithMany(p => p.InventoryStockCountPlanDetails)
                .HasForeignKey(d => d.InventoryStockCountPlanFk)
                .HasConstraintName("FK_InventoryStockCountPlanDetail_InventoryStockCountPlan");

            entity.HasOne(d => d.StoreFkNavigation).WithMany(p => p.InventoryStockCountPlanDetails)
                .HasForeignKey(d => d.StoreFk)
                .HasConstraintName("FK_InventoryStockCountPlanDetail_Store");
        });

        modelBuilder.Entity<InventoryStockCountStatus>(entity =>
        {
            entity.ToTable("InventoryStockCountStatus");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<InventoryTransfere>(entity =>
        {
            entity.ToTable("InventoryTransfere", tb => tb.HasTrigger("AutoGenerateNumber_InventoryTransfere"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Axsynced).HasColumnName("AXSynced");
            entity.Property(e => e.CompanyFromFk).HasColumnName("CompanyFromFK");
            entity.Property(e => e.CompanyToFk).HasColumnName("CompanyToFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.FromStoreFk).HasColumnName("FromStoreFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ItemTypeFk).HasColumnName("ItemTypeFK");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.ReceivedByUserFk).HasColumnName("ReceivedByUserFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.TransferDate).HasColumnType("datetime");
            entity.Property(e => e.TransferReasonFk).HasColumnName("TransferReasonFK");
            entity.Property(e => e.TransferStatusFk).HasColumnName("TransferStatusFK");
            entity.Property(e => e.TransferredByUserFk).HasColumnName("TransferredByUserFK");

            entity.HasOne(d => d.CompanyFromFkNavigation).WithMany(p => p.InventoryTransfereCompanyFromFkNavigations)
                .HasForeignKey(d => d.CompanyFromFk)
                .HasConstraintName("FK_InventoryTransfere_CompanyFrom");

            entity.HasOne(d => d.CompanyToFkNavigation).WithMany(p => p.InventoryTransfereCompanyToFkNavigations)
                .HasForeignKey(d => d.CompanyToFk)
                .HasConstraintName("FK_InventoryTransfere_CompanyTo");

            entity.HasOne(d => d.FromStoreFkNavigation).WithMany(p => p.InventoryTransfereFromStoreFkNavigations)
                .HasForeignKey(d => d.FromStoreFk)
                .HasConstraintName("FK_InventoryTransfere_Store");

            entity.HasOne(d => d.ItemTypeFkNavigation).WithMany(p => p.InventoryTransferes)
                .HasForeignKey(d => d.ItemTypeFk)
                .HasConstraintName("FK_InventoryTransfere_ItemType");

            entity.HasOne(d => d.ToStoreFkNavigation).WithMany(p => p.InventoryTransfereToStoreFkNavigations)
                .HasForeignKey(d => d.ToStoreFk)
                .HasConstraintName("FK_InventoryTransfere_Store1");

            entity.HasOne(d => d.TransferReasonFkNavigation).WithMany(p => p.InventoryTransferes)
                .HasForeignKey(d => d.TransferReasonFk)
                .HasConstraintName("FK_InventoryTransfere_TransferReason");

            entity.HasOne(d => d.TransferStatusFkNavigation).WithMany(p => p.InventoryTransferes)
                .HasForeignKey(d => d.TransferStatusFk)
                .HasConstraintName("FK_InventoryTransfere_TransferStatus");
        });

        modelBuilder.Entity<InventoryTransfereAttachment>(entity =>
        {
            entity.ToTable("InventoryTransfereAttachment");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AttachmentId).HasColumnName("AttachmentID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryTransfereFk).HasColumnName("InventoryTransfereFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.InventoryTransfereFkNavigation).WithMany(p => p.InventoryTransfereAttachments)
                .HasForeignKey(d => d.InventoryTransfereFk)
                .HasConstraintName("FK_InventoryTransfereAttachment_InventoryTransfere");
        });

        modelBuilder.Entity<InventoryTransfereDetail>(entity =>
        {
            entity.ToTable("InventoryTransfereDetail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.InventoryTransfereFk).HasColumnName("InventoryTransfereFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.InventoryItemFkNavigation).WithMany(p => p.InventoryTransfereDetails)
                .HasForeignKey(d => d.InventoryItemFk)
                .HasConstraintName("FK_InventoryTransfereDetail_InventoryItem");

            entity.HasOne(d => d.InventoryTransfereFkNavigation).WithMany(p => p.InventoryTransfereDetails)
                .HasForeignKey(d => d.InventoryTransfereFk)
                .HasConstraintName("FK_InventoryTransfereDetail_InventoryTransfere");
        });

        modelBuilder.Entity<InventoryTransfereDetailBatch>(entity =>
        {
            entity.ToTable("InventoryTransfereDetailBatch");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BatchFk).HasColumnName("BatchFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.InventoryTransfereDetailFk).HasColumnName("InventoryTransfereDetailFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Qunatity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.ShelfFk).HasColumnName("ShelfFK");

            entity.HasOne(d => d.BatchFkNavigation).WithMany(p => p.InventoryTransfereDetailBatches)
                .HasForeignKey(d => d.BatchFk)
                .HasConstraintName("FK_InventoryTransfereDetailBatch_InventoryItemLocationBatch");

            entity.HasOne(d => d.InventoryTransfereDetailFkNavigation).WithMany(p => p.InventoryTransfereDetailBatches)
                .HasForeignKey(d => d.InventoryTransfereDetailFk)
                .HasConstraintName("FK_InventoryTransfereDetailBatch_InventoryTransfereDetail");

            entity.HasOne(d => d.ShelfFkNavigation).WithMany(p => p.InventoryTransfereDetailBatches)
                .HasForeignKey(d => d.ShelfFk)
                .HasConstraintName("FK_InventoryTransfereDetailBatch_Shelf");
        });

        modelBuilder.Entity<InventoryTransfereDetailBatchSerial>(entity =>
        {
            entity.ToTable("InventoryTransfereDetailBatchSerial");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryTransfereDetailBatchFk).HasColumnName("InventoryTransfereDetailBatchFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.SerialFk).HasColumnName("SerialFK");

            entity.HasOne(d => d.InventoryTransfereDetailBatchFkNavigation).WithMany(p => p.InventoryTransfereDetailBatchSerials)
                .HasForeignKey(d => d.InventoryTransfereDetailBatchFk)
                .HasConstraintName("FK_InventoryTransfereDetailBatchSerial_InventoryTransfereDetailBatch");

            entity.HasOne(d => d.SerialFkNavigation).WithMany(p => p.InventoryTransfereDetailBatchSerials)
                .HasForeignKey(d => d.SerialFk)
                .HasConstraintName("FK_InventoryTransfereDetailBatchSerial_InventoryItemLocationBatchSerial");
        });

        modelBuilder.Entity<InventoryTransfereSerial>(entity =>
        {
            entity.ToTable("InventoryTransfereSerial");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryItemSerialFk).HasColumnName("InventoryItemSerialFK");
            entity.Property(e => e.InventoryTransfereDetailFk).HasColumnName("InventoryTransfereDetailFK");
            entity.Property(e => e.InventoryTransfereFk).HasColumnName("InventoryTransfereFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.InventoryItemSerialFkNavigation).WithMany(p => p.InventoryTransfereSerials)
                .HasForeignKey(d => d.InventoryItemSerialFk)
                .HasConstraintName("FK_InventoryTransfereSerial_InventoryItemSerial");

            entity.HasOne(d => d.InventoryTransfereDetailFkNavigation).WithMany(p => p.InventoryTransfereSerials)
                .HasForeignKey(d => d.InventoryTransfereDetailFk)
                .HasConstraintName("FK_InventoryTransfereSerial_InventoryTransfereDetail");

            entity.HasOne(d => d.InventoryTransfereFkNavigation).WithMany(p => p.InventoryTransfereSerials)
                .HasForeignKey(d => d.InventoryTransfereFk)
                .HasConstraintName("FK_InventoryTransfereSerial_InventoryTransfere");
        });

        modelBuilder.Entity<InventoryYear>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Year");

            entity.ToTable("InventoryYear");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<InventroyItemRequestWithdraw>(entity =>
        {
            entity.ToTable("InventroyItemRequestWithdraw", tb =>
                {
                    tb.HasTrigger("AutoGenerateNumber_InventroyItemRequestWithdraw");
                    tb.HasTrigger("PDARequestLogUpdate");
                });

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssignedToUserFk).HasColumnName("AssignedToUserFK");
            entity.Property(e => e.Axsynced).HasColumnName("AXSynced");
            entity.Property(e => e.CompanyFk).HasColumnName("CompanyFK");
            entity.Property(e => e.CostCenterFk).HasColumnName("CostCenterFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.CustomerFk).HasColumnName("CustomerFK");
            entity.Property(e => e.DescriptionAr).HasColumnName("DescriptionAR");
            entity.Property(e => e.DescriptionEn).HasColumnName("DescriptionEN");
            entity.Property(e => e.EntityFormula).HasMaxLength(250);
            entity.Property(e => e.EntityId).HasColumnName("EntityID");
            entity.Property(e => e.FactoryFk).HasColumnName("FactoryFK");
            entity.Property(e => e.FactoryLineFk).HasColumnName("FactoryLineFK");
            entity.Property(e => e.InventoryItemBudgetFk).HasColumnName("InventoryItemBudgetFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ItemNeededDate).HasColumnType("datetime");
            entity.Property(e => e.ItemRequestStatusFk).HasColumnName("ItemRequestStatusFK");
            entity.Property(e => e.ItemTypeFk).HasColumnName("ItemTypeFK");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.LineFk).HasColumnName("LineFK");
            entity.Property(e => e.LocationFk).HasColumnName("LocationFK");
            entity.Property(e => e.Oufk).HasColumnName("OUFK");
            entity.Property(e => e.ProjectFk).HasColumnName("ProjectFK");
            entity.Property(e => e.ReceivedFk).HasColumnName("ReceivedFK");
            entity.Property(e => e.RequestDate).HasColumnType("datetime");
            entity.Property(e => e.RequestedByFk).HasColumnName("RequestedByFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.ScopeFk).HasColumnName("ScopeFK");
            entity.Property(e => e.SectorFk).HasColumnName("SectorFK");
            entity.Property(e => e.ServiceMainCategoryFk).HasColumnName("ServiceMainCategoryFK");
            entity.Property(e => e.SiteManagerApprovalDateTime).HasColumnType("datetime");
            entity.Property(e => e.SourceEntity).HasMaxLength(250);
            entity.Property(e => e.SourceId).HasColumnName("SourceID");
            entity.Property(e => e.SourceTypeId).HasColumnName("SourceTypeID");
            entity.Property(e => e.StoreFk).HasColumnName("StoreFK");
            entity.Property(e => e.VehicleFk).HasColumnName("VehicleFK");
            entity.Property(e => e.WarehouseManagerApprovalDateTime).HasColumnType("datetime");

            entity.HasOne(d => d.AssignedToUserFkNavigation).WithMany(p => p.InventroyItemRequestWithdrawAssignedToUserFkNavigations)
                .HasForeignKey(d => d.AssignedToUserFk)
                .HasConstraintName("FK_InventroyItemRequestWithdraw_AssignedToUser");

            entity.HasOne(d => d.CompanyFkNavigation).WithMany(p => p.InventroyItemRequestWithdraws)
                .HasForeignKey(d => d.CompanyFk)
                .HasConstraintName("FK_InventroyItemRequestWithdraw_Company");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InventroyItemRequestWithdrawCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_InventroyItemRequestWithdraw_CreatedByUser");

            entity.HasOne(d => d.ItemRequestStatusFkNavigation).WithMany(p => p.InventroyItemRequestWithdraws)
                .HasForeignKey(d => d.ItemRequestStatusFk)
                .HasConstraintName("FK_InventroyItemRequestWithdraw_ItemRequestStatus");

            entity.HasOne(d => d.ItemTypeFkNavigation).WithMany(p => p.InventroyItemRequestWithdraws)
                .HasForeignKey(d => d.ItemTypeFk)
                .HasConstraintName("FK_InventroyItemRequestWithdraw_ItemType");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.InventroyItemRequestWithdrawLastUpdatedByNavigations)
                .HasForeignKey(d => d.LastUpdatedBy)
                .HasConstraintName("FK_InventroyItemRequestWithdraw_LastUpdatedByUser");

            entity.HasOne(d => d.LineFkNavigation).WithMany(p => p.InventroyItemRequestWithdraws)
                .HasForeignKey(d => d.LineFk)
                .HasConstraintName("FK_InventroyItemRequestWithdraw_Line");

            entity.HasOne(d => d.LocationFkNavigation).WithMany(p => p.InventroyItemRequestWithdraws)
                .HasForeignKey(d => d.LocationFk)
                .HasConstraintName("FK_InventroyItemRequestWithdraw_Location");

            entity.HasOne(d => d.OufkNavigation).WithMany(p => p.InventroyItemRequestWithdraws)
                .HasForeignKey(d => d.Oufk)
                .HasConstraintName("FK_InventroyItemRequestWithdraw_OU");

            entity.HasOne(d => d.ProjectFkNavigation).WithMany(p => p.InventroyItemRequestWithdraws)
                .HasForeignKey(d => d.ProjectFk)
                .HasConstraintName("FK_InventroyItemRequestWithdraw_Project");

            entity.HasOne(d => d.ReceivedFkNavigation).WithMany(p => p.InventroyItemRequestWithdraws)
                .HasForeignKey(d => d.ReceivedFk)
                .HasConstraintName("FK_InventroyItemRequestWithdraw_Employee");

            entity.HasOne(d => d.RequestedByFkNavigation).WithMany(p => p.InventroyItemRequestWithdrawRequestedByFkNavigations)
                .HasForeignKey(d => d.RequestedByFk)
                .HasConstraintName("FK_InventroyItemRequestWithdraw_RequestedByUser");

            entity.HasOne(d => d.ScopeFkNavigation).WithMany(p => p.InventroyItemRequestWithdraws)
                .HasForeignKey(d => d.ScopeFk)
                .HasConstraintName("FK_InventroyItemRequestWithdraw_Scope");

            entity.HasOne(d => d.ServiceMainCategoryFkNavigation).WithMany(p => p.InventroyItemRequestWithdraws)
                .HasForeignKey(d => d.ServiceMainCategoryFk)
                .HasConstraintName("FK_InventroyItemRequestWithdraw_ServiceMainCategory");

            entity.HasOne(d => d.StoreFkNavigation).WithMany(p => p.InventroyItemRequestWithdraws)
                .HasForeignKey(d => d.StoreFk)
                .HasConstraintName("FK_InventroyItemRequestWithdraw_Store");

            entity.HasOne(d => d.VehicleFkNavigation).WithMany(p => p.InventroyItemRequestWithdraws)
                .HasForeignKey(d => d.VehicleFk)
                .HasConstraintName("FK_InventroyItemRequestWithdraw_Vehicle");
        });

        modelBuilder.Entity<InventroyItemRequestWithdrawAttachment>(entity =>
        {
            entity.ToTable("InventroyItemRequestWithdrawAttachment");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AttachmentId).HasColumnName("AttachmentID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventroyItemRequestWithdrawFk).HasColumnName("InventroyItemRequestWithdrawFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.InventroyItemRequestWithdrawFkNavigation).WithMany(p => p.InventroyItemRequestWithdrawAttachments)
                .HasForeignKey(d => d.InventroyItemRequestWithdrawFk)
                .HasConstraintName("FK_InventroyItemRequestWithdrawAttachment_InventroyItemRequestWithdraw");
        });

        modelBuilder.Entity<InventroyItemRequestWithdrawDetail>(entity =>
        {
            entity.ToTable("InventroyItemRequestWithdrawDetail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AvgCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DeliveredQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.IntegrationId).HasColumnName("IntegrationID");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastPurchasePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.PickedQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.RequestLineItemStatusFk).HasColumnName("RequestLineItemStatusFK");
            entity.Property(e => e.RequestWfk).HasColumnName("RequestWFK");
            entity.Property(e => e.RequestedQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.ReturnedQuantity)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.ScrapedQuantity).HasColumnType("decimal(18, 3)");

            entity.HasOne(d => d.InventoryItemFkNavigation).WithMany(p => p.InventroyItemRequestWithdrawDetails)
                .HasForeignKey(d => d.InventoryItemFk)
                .HasConstraintName("FK_InventroyItemRequestWithdrawDetail_InventoryItem");

            entity.HasOne(d => d.RequestLineItemStatusFkNavigation).WithMany(p => p.InventroyItemRequestWithdrawDetails)
                .HasForeignKey(d => d.RequestLineItemStatusFk)
                .HasConstraintName("FK_InventroyItemRequestWithdrawDetail_RequestLineItemStatus");

            entity.HasOne(d => d.RequestWfkNavigation).WithMany(p => p.InventroyItemRequestWithdrawDetails)
                .HasForeignKey(d => d.RequestWfk)
                .HasConstraintName("FK_InventroyItemRequestWithdrawDetail_InventroyItemRequestWithdraw");
        });

        modelBuilder.Entity<Isle>(entity =>
        {
            entity.ToTable("Isle");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<ItemBalanceStatus>(entity =>
        {
            entity.ToTable("ItemBalanceStatus");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<ItemExpiryType>(entity =>
        {
            entity.ToTable("ItemExpiryType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<ItemQuantityType>(entity =>
        {
            entity.ToTable("ItemQuantityType");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<ItemRequestStatus>(entity =>
        {
            entity.ToTable("ItemRequestStatus");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<ItemType>(entity =>
        {
            entity.ToTable("ItemType");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Axsynced).HasColumnName("AXSynced");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.ToTable("Language");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageName).HasMaxLength(50);
            entity.Property(e => e.LanguageNameAr).HasMaxLength(50);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Line>(entity =>
        {
            entity.ToTable("Line");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.ProjectFk).HasColumnName("ProjectFK");
            entity.Property(e => e.RowVersion)
                .HasMaxLength(8)
                .IsFixedLength();

            entity.HasOne(d => d.ProjectFkNavigation).WithMany(p => p.Lines)
                .HasForeignKey(d => d.ProjectFk)
                .HasConstraintName("FK_Line_Project");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("Location");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Axsynced).HasColumnName("AXSynced");
            entity.Property(e => e.CityFk).HasColumnName("CityFK");
            entity.Property(e => e.CompanyFk).HasColumnName("CompanyFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.LocationFk).HasColumnName("LocationFK");
            entity.Property(e => e.ProjectFk).HasColumnName("ProjectFK");
            entity.Property(e => e.RowVersion)
                .HasMaxLength(8)
                .IsFixedLength();
            entity.Property(e => e.StoreFk).HasColumnName("StoreFK");

            entity.HasOne(d => d.CityFkNavigation).WithMany(p => p.Locations)
                .HasForeignKey(d => d.CityFk)
                .HasConstraintName("FK_Location_City");

            entity.HasOne(d => d.LocationFkNavigation).WithMany(p => p.InverseLocationFkNavigation)
                .HasForeignKey(d => d.LocationFk)
                .HasConstraintName("FK_Location_Location");

            entity.HasOne(d => d.ProjectFkNavigation).WithMany(p => p.Locations)
                .HasForeignKey(d => d.ProjectFk)
                .HasConstraintName("FK_Location_Project");

            entity.HasOne(d => d.StoreFkNavigation).WithMany(p => p.Locations)
                .HasForeignKey(d => d.StoreFk)
                .HasConstraintName("FK_Location_Store");
        });

        modelBuilder.Entity<Manufacture>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Manufactures");

            entity.ToTable("Manufacture");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<MaterialCategory>(entity =>
        {
            entity.ToTable("MaterialCategory");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.MaterialGroupFk).HasColumnName("MaterialGroupFK");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.MaterialGroupFkNavigation).WithMany(p => p.MaterialCategories)
                .HasForeignKey(d => d.MaterialGroupFk)
                .HasConstraintName("FK_MaterialCategory_MaterialGroup");
        });

        modelBuilder.Entity<MaterialGroup>(entity =>
        {
            entity.ToTable("MaterialGroup");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.ShortName).HasMaxLength(50);
        });

        modelBuilder.Entity<MaterialSubCategory>(entity =>
        {
            entity.ToTable("MaterialSubCategory");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.MaterialCategoryFk).HasColumnName("MaterialCategoryFK");
            entity.Property(e => e.MaterialGroupFk).HasColumnName("MaterialGroupFK");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.MaterialCategoryFkNavigation).WithMany(p => p.MaterialSubCategories)
                .HasForeignKey(d => d.MaterialCategoryFk)
                .HasConstraintName("FK_MaterialSubCategory_MaterialCategory");
        });

        modelBuilder.Entity<MmItemsForMerge2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("MM Items For Merge_2$");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ItemNumber).HasMaxLength(255);
            entity.Property(e => e.MainItem)
                .HasMaxLength(255)
                .HasColumnName("Main Item");
        });

        modelBuilder.Entity<ModuleSetting>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Measure).HasMaxLength(100);
            entity.Property(e => e.MeasureAr).HasMaxLength(100);
            entity.Property(e => e.SettingName).HasMaxLength(500);
        });

        modelBuilder.Entity<MotorodItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("$MotorodItems");

            entity.Property(e => e.ItemCategory).HasMaxLength(255);
            entity.Property(e => e.ItemName).HasMaxLength(255);
            entity.Property(e => e.MaterialGroup).HasMaxLength(255);
            entity.Property(e => e.Unit).HasMaxLength(255);
        });

        modelBuilder.Entity<NotFoundItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("'Not found items$'");

            entity.Property(e => e.Code).HasMaxLength(255);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Duplicated)
                .HasMaxLength(255)
                .HasColumnName("Duplicated ");
            entity.Property(e => e.Id)
                .HasMaxLength(255)
                .HasColumnName("id");
            entity.Property(e => e.ItemCode).HasMaxLength(255);
            entity.Property(e => e.Store).HasMaxLength(255);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("Notification");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AttachmentType).HasMaxLength(50);
            entity.Property(e => e.Bcc).HasColumnName("BCC");
            entity.Property(e => e.Cc).HasColumnName("CC");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.NotificationDateTime).HasColumnType("datetime");
            entity.Property(e => e.NotificationSource).HasMaxLength(50);
            entity.Property(e => e.NotificationTypeId).HasColumnName("NotificationTypeID");
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.SendDate).HasColumnType("datetime");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.Subject).HasMaxLength(50);

            entity.HasOne(d => d.NotificationType).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.NotificationTypeId)
                .HasConstraintName("FK_Notification_NotificationType");

            entity.HasOne(d => d.Status).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_Notification_NotificationState");
        });

        modelBuilder.Entity<NotificationLog>(entity =>
        {
            entity.ToTable("NotificationLog");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.LoyaltyLevelId).HasColumnName("LoyaltyLevelID");
            entity.Property(e => e.TemplateId).HasColumnName("TemplateID");
        });

        modelBuilder.Entity<NotificationPlaceHolder>(entity =>
        {
            entity.ToTable("NotificationPlaceHolder");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<NotificationState>(entity =>
        {
            entity.ToTable("NotificationState");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.StatusName).HasMaxLength(50);
            entity.Property(e => e.StatusNameAr).HasMaxLength(50);
        });

        modelBuilder.Entity<NotificationTemplate>(entity =>
        {
            entity.ToTable("NotificationTemplate");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BodySms).HasColumnName("BodySMS");
            entity.Property(e => e.BodySmsar).HasColumnName("BodySMSAr");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LanguageId).HasColumnName("LanguageID");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.NotificationTypeId).HasColumnName("NotificationTypeID");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Language).WithMany(p => p.NotificationTemplates)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FK_NotificationTemplate_Language");

            entity.HasOne(d => d.NotificationType).WithMany(p => p.NotificationTemplates)
                .HasForeignKey(d => d.NotificationTypeId)
                .HasConstraintName("FK_NotificationTemplate_NotificationType");
        });

        modelBuilder.Entity<NotificationTemplateContact>(entity =>
        {
            entity.ToTable("NotificationTemplateContact");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Contact).WithMany(p => p.NotificationTemplateContacts)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("FK_NotificationTemplateContact_Contact");

            entity.HasOne(d => d.Template).WithMany(p => p.NotificationTemplateContacts)
                .HasForeignKey(d => d.TemplateId)
                .HasConstraintName("FK_NotificationTemplateContact_NotificationTemplate");
        });

        modelBuilder.Entity<NotificationType>(entity =>
        {
            entity.ToTable("NotificationType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.NotificationTypeAr).HasMaxLength(50);
            entity.Property(e => e.NotificationTypeEn).HasMaxLength(50);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Oil>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("$oil");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.InventoryItemCode).HasMaxLength(255);
            entity.Property(e => e.InventoryItemId).HasColumnName("InventoryItemID");
            entity.Property(e => e.InventoryItemName).HasMaxLength(255);
            entity.Property(e => e.IsMatch).HasMaxLength(255);
            entity.Property(e => e.Mmbalance).HasColumnName("MMBalance");
            entity.Property(e => e.StockCountDate).HasColumnType("datetime");
            entity.Property(e => e.StoreId).HasColumnName("StoreID");
            entity.Property(e => e.StoreName).HasMaxLength(255);
        });

        modelBuilder.Entity<OrderLineItemStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_VendorOrderLineItemStatus");

            entity.ToTable("OrderLineItemStatus");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Ou>(entity =>
        {
            entity.ToTable("OU");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Ownership>(entity =>
        {
            entity.ToTable("Ownership");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsEnabled).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.NameAr).HasMaxLength(50);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<PaymentTerm>(entity =>
        {
            entity.ToTable("PaymentTerm");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Pdaassignment>(entity =>
        {
            entity.ToTable("PDAAssignment");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.PdadetailFk).HasColumnName("PDADetailFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.UserFk).HasColumnName("UserFK");

            entity.HasOne(d => d.PdadetailFkNavigation).WithMany(p => p.Pdaassignments)
                .HasForeignKey(d => d.PdadetailFk)
                .HasConstraintName("FK_PDAAssignment_PDADetail");
        });

        modelBuilder.Entity<Pdadetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PDADetails");

            entity.ToTable("PDADetail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Imei).HasColumnName("IMEI");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.PdamodelFk).HasColumnName("PDAModelFK");
            entity.Property(e => e.ProductionCountryFk).HasColumnName("ProductionCountryFK");
            entity.Property(e => e.ProductionYearFk).HasColumnName("ProductionYearFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.StartingDate).HasColumnType("datetime");

            entity.HasOne(d => d.PdamodelFkNavigation).WithMany(p => p.Pdadetails)
                .HasForeignKey(d => d.PdamodelFk)
                .HasConstraintName("FK_PDADetails_PDAModel");

            entity.HasOne(d => d.ProductionCountryFkNavigation).WithMany(p => p.Pdadetails)
                .HasForeignKey(d => d.ProductionCountryFk)
                .HasConstraintName("FK_PDADetails_Country");

            entity.HasOne(d => d.ProductionYearFkNavigation).WithMany(p => p.Pdadetails)
                .HasForeignKey(d => d.ProductionYearFk)
                .HasConstraintName("FK_PDADetails_Year");
        });

        modelBuilder.Entity<Pdamodel>(entity =>
        {
            entity.ToTable("PDAModel");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<PdarequestsLog>(entity =>
        {
            entity.ToTable("PDARequestsLog");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssignedToFk).HasColumnName("AssignedToFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.PdarequestType)
                .HasMaxLength(50)
                .HasColumnName("PDARequestType");
            entity.Property(e => e.RequestFk).HasColumnName("RequestFK");
        });

        modelBuilder.Entity<PoChangeVehicle20240331>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("$po_ChangeVehicle_2024-03-31");

            entity.Property(e => e.CurrentVehicleCode)
                .HasMaxLength(255)
                .HasColumnName("Current Vehicle Code");
            entity.Property(e => e.Mrid).HasColumnName("MRID");
            entity.Property(e => e.OldVehicleId).HasColumnName("OldVehicleID");
            entity.Property(e => e.RequestNo)
                .HasMaxLength(255)
                .HasColumnName("Request No");
            entity.Property(e => e.VehicleId).HasColumnName("VehicleID");
        });

        modelBuilder.Entity<PoserviceAsset>(entity =>
        {
            entity.ToTable("POServiceAsset");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssetCode).HasMaxLength(50);
            entity.Property(e => e.AssetId).HasColumnName("AssetID");
            entity.Property(e => e.ContractAssetId).HasColumnName("ContractAssetID");
            entity.Property(e => e.ContractServiceId).HasColumnName("ContractServiceID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.PoserviceFk).HasColumnName("POServiceFK");

            entity.HasOne(d => d.PoserviceFkNavigation).WithMany(p => p.PoserviceAssets)
                .HasForeignKey(d => d.PoserviceFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_POServiceAsset_PurchaseOrderService");
        });

        modelBuilder.Entity<PoserviceDetail>(entity =>
        {
            entity.ToTable("POServiceDetail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ContractServiceId).HasColumnName("ContractServiceID");
            entity.Property(e => e.CostPerService).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.PoserviceFk).HasColumnName("POServiceFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.ServiceCategoryFk).HasColumnName("ServiceCategoryFK");
            entity.Property(e => e.ServiceFk).HasColumnName("ServiceFK");
            entity.Property(e => e.ServiceMainCategoryFk).HasColumnName("ServiceMainCategoryFK");
            entity.Property(e => e.ServiceSubCategoryFk).HasColumnName("ServiceSubCategoryFK");
            entity.Property(e => e.ServiceTypeFk).HasColumnName("ServiceTypeFK");
            entity.Property(e => e.TotalCost).HasColumnType("decimal(18, 3)");

            entity.HasOne(d => d.PoserviceFkNavigation).WithMany(p => p.PoserviceDetails)
                .HasForeignKey(d => d.PoserviceFk)
                .HasConstraintName("FK_POServiceDetail_PurchaseOrderService");

            entity.HasOne(d => d.ServiceCategoryFkNavigation).WithMany(p => p.PoserviceDetails)
                .HasForeignKey(d => d.ServiceCategoryFk)
                .HasConstraintName("FK_POServiceDetail_ServiceCategory");

            entity.HasOne(d => d.ServiceFkNavigation).WithMany(p => p.PoserviceDetails)
                .HasForeignKey(d => d.ServiceFk)
                .HasConstraintName("FK_POServiceDetail_Service");

            entity.HasOne(d => d.ServiceMainCategoryFkNavigation).WithMany(p => p.PoserviceDetails)
                .HasForeignKey(d => d.ServiceMainCategoryFk)
                .HasConstraintName("FK_POServiceDetail_ServiceMainCategory");

            entity.HasOne(d => d.ServiceSubCategoryFkNavigation).WithMany(p => p.PoserviceDetails)
                .HasForeignKey(d => d.ServiceSubCategoryFk)
                .HasConstraintName("FK_POServiceDetail_ServiceSubCategory");

            entity.HasOne(d => d.ServiceTypeFkNavigation).WithMany(p => p.PoserviceDetails)
                .HasForeignKey(d => d.ServiceTypeFk)
                .HasConstraintName("FK_POServiceDetail_ServiceType");
        });

        modelBuilder.Entity<PoserviceOutsource>(entity =>
        {
            entity.ToTable("POServiceOutsource");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ContractTaskEmployeeId).HasColumnName("ContractTaskEmployeeID");
            entity.Property(e => e.CostPerDay).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EmployeeJobFk).HasColumnName("EmployeeJobFK");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.PoserviceFk).HasColumnName("POServiceFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.TotalCost).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.WorkerTypeFk).HasColumnName("WorkerTypeFK");

            entity.HasOne(d => d.EmployeeJobFkNavigation).WithMany(p => p.PoserviceOutsources)
                .HasForeignKey(d => d.EmployeeJobFk)
                .HasConstraintName("FK_POServiceOutsource_EmployeeJob");

            entity.HasOne(d => d.PoserviceFkNavigation).WithMany(p => p.PoserviceOutsources)
                .HasForeignKey(d => d.PoserviceFk)
                .HasConstraintName("FK_POServiceOutsource_PurchaseOrderService");

            entity.HasOne(d => d.WorkerTypeFkNavigation).WithMany(p => p.PoserviceOutsources)
                .HasForeignKey(d => d.WorkerTypeFk)
                .HasConstraintName("FK_POServiceOutsource_WorkerType");
        });

        modelBuilder.Entity<PoserviceRecomendedResource>(entity =>
        {
            entity.ToTable("POServiceRecomendedResource");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ContractFk).HasColumnName("ContractFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EmployeeJobFk).HasColumnName("EmployeeJobFK");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.PoserviceFk).HasColumnName("POServiceFK");
            entity.Property(e => e.RowVersion)
                .HasMaxLength(8)
                .IsFixedLength();
            entity.Property(e => e.VendorFk).HasColumnName("VendorFK");

            entity.HasOne(d => d.EmployeeJobFkNavigation).WithMany(p => p.PoserviceRecomendedResources)
                .HasForeignKey(d => d.EmployeeJobFk)
                .HasConstraintName("FK_POServiceRecomendedResource_EmployeeJob");

            entity.HasOne(d => d.PoserviceFkNavigation).WithMany(p => p.PoserviceRecomendedResources)
                .HasForeignKey(d => d.PoserviceFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_POServiceRecomendedResource_PurchaseOrderService");

            entity.HasOne(d => d.VendorFkNavigation).WithMany(p => p.PoserviceRecomendedResources)
                .HasForeignKey(d => d.VendorFk)
                .HasConstraintName("FK_POServiceRecomendedResource_Vendor");
        });

        modelBuilder.Entity<PoserviceTermsAndCondition>(entity =>
        {
            entity.ToTable("POServiceTermsAndCondition");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.PoserviceFk).HasColumnName("POServiceFK");
            entity.Property(e => e.RowVersion)
                .HasMaxLength(8)
                .IsFixedLength();
            entity.Property(e => e.TermsAndConditionFk).HasColumnName("TermsAndConditionFK");

            entity.HasOne(d => d.TermsAndConditionFkNavigation).WithMany(p => p.PoserviceTermsAndConditions)
                .HasForeignKey(d => d.TermsAndConditionFk)
                .HasConstraintName("FK_POServiceTermsAndCondition_TermsAndCondition");
        });

        modelBuilder.Entity<PoserviceType>(entity =>
        {
            entity.ToTable("POServiceType");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<PossessionType>(entity =>
        {
            entity.ToTable("PossessionType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<ProcDatum>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.ToTable("Project");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CompanyFk).HasColumnName("CompanyFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.CustomerFk).HasColumnName("CustomerFK");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .HasMaxLength(8)
                .IsFixedLength();
            entity.Property(e => e.StoreFk).HasColumnName("StoreFK");

            entity.HasOne(d => d.CompanyFkNavigation).WithMany(p => p.Projects)
                .HasForeignKey(d => d.CompanyFk)
                .HasConstraintName("FK_Project_Company");

            entity.HasOne(d => d.StoreFkNavigation).WithMany(p => p.Projects)
                .HasForeignKey(d => d.StoreFk)
                .HasConstraintName("FK_Project_Store");
        });

        modelBuilder.Entity<Pruser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ApprovalScreenUsers");

            entity.ToTable("PRUsers");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ApprovalScreenFk).HasColumnName("ApprovalScreenFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.UserFk).HasColumnName("UserFK");

            entity.HasOne(d => d.ApprovalScreenFkNavigation).WithMany(p => p.Prusers)
                .HasForeignKey(d => d.ApprovalScreenFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApprovalScreenUsers_ApprovalScreen");

            entity.HasOne(d => d.UserFkNavigation).WithMany(p => p.Prusers)
                .HasForeignKey(d => d.UserFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApprovalScreenUsers_User");
        });

        modelBuilder.Entity<PurchaseOrderService>(entity =>
        {
            entity.ToTable("PurchaseOrderService", tb => tb.HasTrigger("PurchaseOrderService_OrderNo"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CompanyFk).HasColumnName("CompanyFK");
            entity.Property(e => e.ContractCode).HasMaxLength(50);
            entity.Property(e => e.ContractId).HasColumnName("ContractID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.InventoryItemBudgetFk).HasColumnName("InventoryItemBudgetFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.LocationFk).HasColumnName("LocationFK");
            entity.Property(e => e.OrderByUserFk).HasColumnName("OrderByUserFK");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderScreenFk).HasColumnName("OrderScreenFK");
            entity.Property(e => e.PaymentTermFk).HasColumnName("PaymentTermFK");
            entity.Property(e => e.PoserviceTypeFk).HasColumnName("POServiceTypeFK");
            entity.Property(e => e.Prfk).HasColumnName("PRFK");
            entity.Property(e => e.ProjectFk).HasColumnName("ProjectFK");
            entity.Property(e => e.RequestDate).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.ScopeFk).HasColumnName("ScopeFK");
            entity.Property(e => e.ServiceMainCategoryFk).HasColumnName("ServiceMainCategoryFK");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.TotalCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VendorFk).HasColumnName("VendorFK");
            entity.Property(e => e.VendorOrderStatusFk).HasColumnName("VendorOrderStatusFK");
            entity.Property(e => e.VendorOrderTypeFk).HasColumnName("VendorOrderTypeFK");

            entity.HasOne(d => d.CompanyFkNavigation).WithMany(p => p.PurchaseOrderServices)
                .HasForeignKey(d => d.CompanyFk)
                .HasConstraintName("FK_PurchaseOrderService_Company");

            entity.HasOne(d => d.LocationFkNavigation).WithMany(p => p.PurchaseOrderServices)
                .HasForeignKey(d => d.LocationFk)
                .HasConstraintName("FK_PurchaseOrderService_Location");

            entity.HasOne(d => d.OrderScreenFkNavigation).WithMany(p => p.PurchaseOrderServices)
                .HasForeignKey(d => d.OrderScreenFk)
                .HasConstraintName("FK_PurchaseOrderService_VendorOrderScreen");

            entity.HasOne(d => d.PaymentTermFkNavigation).WithMany(p => p.PurchaseOrderServices)
                .HasForeignKey(d => d.PaymentTermFk)
                .HasConstraintName("FK_PurchaseOrderService_PaymentTerm");

            entity.HasOne(d => d.PoserviceTypeFkNavigation).WithMany(p => p.PurchaseOrderServices)
                .HasForeignKey(d => d.PoserviceTypeFk)
                .HasConstraintName("FK_PurchaseOrderService_POServiceType");

            entity.HasOne(d => d.PrfkNavigation).WithMany(p => p.InversePrfkNavigation)
                .HasForeignKey(d => d.Prfk)
                .HasConstraintName("FK_PurchaseOrderService_PurchaseRequestService");

            entity.HasOne(d => d.ProjectFkNavigation).WithMany(p => p.PurchaseOrderServices)
                .HasForeignKey(d => d.ProjectFk)
                .HasConstraintName("FK_PurchaseOrderService_Project");

            entity.HasOne(d => d.ScopeFkNavigation).WithMany(p => p.PurchaseOrderServices)
                .HasForeignKey(d => d.ScopeFk)
                .HasConstraintName("FK_PurchaseOrderService_Scope");

            entity.HasOne(d => d.ServiceMainCategoryFkNavigation).WithMany(p => p.PurchaseOrderServices)
                .HasForeignKey(d => d.ServiceMainCategoryFk)
                .HasConstraintName("FK_PurchaseOrderService_ServiceMainCategory");

            entity.HasOne(d => d.VendorFkNavigation).WithMany(p => p.PurchaseOrderServices)
                .HasForeignKey(d => d.VendorFk)
                .HasConstraintName("FK_PurchaseOrderService_Vendor");

            entity.HasOne(d => d.VendorOrderStatusFkNavigation).WithMany(p => p.PurchaseOrderServices)
                .HasForeignKey(d => d.VendorOrderStatusFk)
                .HasConstraintName("FK_PurchaseOrderService_VendorOrderStatus");

            entity.HasOne(d => d.VendorOrderTypeFkNavigation).WithMany(p => p.PurchaseOrderServices)
                .HasForeignKey(d => d.VendorOrderTypeFk)
                .HasConstraintName("FK_PurchaseOrderService_VendorOrderType");
        });

        modelBuilder.Entity<PurchaseOrderServiceAttachment>(entity =>
        {
            entity.ToTable("PurchaseOrderServiceAttachment");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AttachmentId).HasColumnName("AttachmentID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.PurchaseOrderServiceFk).HasColumnName("PurchaseOrderServiceFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.PurchaseOrderServiceFkNavigation).WithMany(p => p.PurchaseOrderServiceAttachments)
                .HasForeignKey(d => d.PurchaseOrderServiceFk)
                .HasConstraintName("FK_PurchaseOrderServiceAttachment_PurchaseOrderService1");
        });

        modelBuilder.Entity<Rack>(entity =>
        {
            entity.ToTable("Rack");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsleFk).HasColumnName("IsleFK");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.IsleFkNavigation).WithMany(p => p.Racks)
                .HasForeignKey(d => d.IsleFk)
                .HasConstraintName("FK_Rack_Isle");
        });

        modelBuilder.Entity<Rank>(entity =>
        {
            entity.ToTable("Rank");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.NameAr).HasMaxLength(50);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<RequestLineItemStatus>(entity =>
        {
            entity.ToTable("RequestLineItemStatus");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<RequestWithdrawSerial>(entity =>
        {
            entity.ToTable("RequestWithdrawSerial");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryItemSerialFk).HasColumnName("InventoryItemSerialFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RequestWithdrawDetailFk).HasColumnName("RequestWithdrawDetailFK");
            entity.Property(e => e.RequestWithdrawFk).HasColumnName("RequestWithdrawFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.RwDeliveredQuantityFk).HasColumnName("RW_DeliveredQuantityFK");

            entity.HasOne(d => d.InventoryItemSerialFkNavigation).WithMany(p => p.RequestWithdrawSerials)
                .HasForeignKey(d => d.InventoryItemSerialFk)
                .HasConstraintName("FK_RequestWithdrawSerial_InventoryItemSerial");

            entity.HasOne(d => d.RequestWithdrawDetailFkNavigation).WithMany(p => p.RequestWithdrawSerials)
                .HasForeignKey(d => d.RequestWithdrawDetailFk)
                .HasConstraintName("FK_RequestWithdrawSerial_InventroyItemRequestWithdrawDetail");

            entity.HasOne(d => d.RequestWithdrawFkNavigation).WithMany(p => p.RequestWithdrawSerials)
                .HasForeignKey(d => d.RequestWithdrawFk)
                .HasConstraintName("FK_RequestWithdrawSerial_InventroyItemRequestWithdraw");

            entity.HasOne(d => d.RwDeliveredQuantityFkNavigation).WithMany(p => p.RequestWithdrawSerials)
                .HasForeignKey(d => d.RwDeliveredQuantityFk)
                .HasConstraintName("FK_RequestWithdrawSerial_RW_DeliveredQuantity");
        });

        modelBuilder.Entity<ReturnReason>(entity =>
        {
            entity.ToTable("ReturnReason");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IntegrationId).HasColumnName("IntegrationID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<ReturnStatus>(entity =>
        {
            entity.ToTable("ReturnStatus");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<RwDeliveredBatch>(entity =>
        {
            entity.ToTable("RW_DeliveredBatch");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Axsynced).HasColumnName("AXSynced");
            entity.Property(e => e.BatchFk).HasColumnName("BatchFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DeliveredDate).HasColumnType("datetime");
            entity.Property(e => e.DeliveredQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RequestWdfk).HasColumnName("RequestWDFK");
            entity.Property(e => e.ReturnedQuantity)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.BatchFkNavigation).WithMany(p => p.RwDeliveredBatches)
                .HasForeignKey(d => d.BatchFk)
                .HasConstraintName("FK_RW_DeliveredBatch_InventoryItemLocationBatch");

            entity.HasOne(d => d.RequestWdfkNavigation).WithMany(p => p.RwDeliveredBatches)
                .HasForeignKey(d => d.RequestWdfk)
                .HasConstraintName("FK_RW_DeliveredBatch_InventroyItemRequestWithdrawDetail");
        });

        modelBuilder.Entity<RwDeliveredQuantity>(entity =>
        {
            entity.ToTable("RW_DeliveredQuantity", tb => tb.HasTrigger("AutoGenerateNumber_RW_DeliveredQuantity"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Axsynced).HasColumnName("AXSynced");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DeliveredDate).HasColumnType("datetime");
            entity.Property(e => e.DeliveredNumber).HasMaxLength(50);
            entity.Property(e => e.DeliveredQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.MaintainableQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.RequestWdfk).HasColumnName("RequestWDFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.ScrapedQuantity).HasColumnType("decimal(18, 3)");

            entity.HasOne(d => d.RequestWdfkNavigation).WithMany(p => p.RwDeliveredQuantities)
                .HasForeignKey(d => d.RequestWdfk)
                .HasConstraintName("FK_RW_DeliveredQuantity_InventroyItemRequestWithdrawDetail");
        });

        modelBuilder.Entity<RwDeliveredSerial>(entity =>
        {
            entity.ToTable("RW_DeliveredSerial");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Axsynced).HasColumnName("AXSynced");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.RwDeliveredBatchFk).HasColumnName("RW_DeliveredBatchFK");
            entity.Property(e => e.SerialFk).HasColumnName("SerialFK");

            entity.HasOne(d => d.RwDeliveredBatchFkNavigation).WithMany(p => p.RwDeliveredSerials)
                .HasForeignKey(d => d.RwDeliveredBatchFk)
                .HasConstraintName("FK_RW_DeliveredSerial_RW_DeliveredBatch");

            entity.HasOne(d => d.SerialFkNavigation).WithMany(p => p.RwDeliveredSerials)
                .HasForeignKey(d => d.SerialFk)
                .HasConstraintName("FK_RW_DeliveredSerial_InventoryItemLocationBatchSerial");
        });

        modelBuilder.Entity<RwPickedBatch>(entity =>
        {
            entity.ToTable("RW_PickedBatch");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Axsynced).HasColumnName("AXSynced");
            entity.Property(e => e.BatchFk).HasColumnName("BatchFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.PickedDate).HasColumnType("datetime");
            entity.Property(e => e.PickedQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.RequestWdfk).HasColumnName("RequestWDFK");
            entity.Property(e => e.ReturnedQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<RwPickedQuantity>(entity =>
        {
            entity.ToTable("RW_PickedQuantity");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Axsynced).HasColumnName("AXSynced");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.PickedDate).HasColumnType("datetime");
            entity.Property(e => e.PickedQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.RequestWdfk).HasColumnName("RequestWDFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.RequestWdfkNavigation).WithMany(p => p.RwPickedQuantities)
                .HasForeignKey(d => d.RequestWdfk)
                .HasConstraintName("FK_RW_PickedQuantity_InventroyItemRequestWithdrawDetail");
        });

        modelBuilder.Entity<RwPickedSerial>(entity =>
        {
            entity.ToTable("RW_PickedSerial");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Axsynced).HasColumnName("AXSynced");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.RwPickedBatchFk).HasColumnName("RW_PickedBatchFK");
            entity.Property(e => e.SerialFk).HasColumnName("SerialFK");

            entity.HasOne(d => d.RwPickedBatchFkNavigation).WithMany(p => p.RwPickedSerials)
                .HasForeignKey(d => d.RwPickedBatchFk)
                .HasConstraintName("FK_RW_PickedSerial_RW_PickedBatch");
        });

        modelBuilder.Entity<SalesInvoice>(entity =>
        {
            entity.ToTable("SalesInvoice");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.ContactPerson).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Vatamount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VATAmount");
            entity.Property(e => e.Vatpercentage)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("VATPercentage");

            entity.HasOne(d => d.Customer).WithMany(p => p.SalesInvoices)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_SalesInvoice_Customer");

            entity.HasOne(d => d.User).WithMany(p => p.SalesInvoices)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_SalesInvoice_User");
        });

        modelBuilder.Entity<SalesInvoiceItem>(entity =>
        {
            entity.ToTable("SalesInvoiceItem");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.SalesInvoiceId).HasColumnName("SalesInvoiceID");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.SalesInvoice).WithMany(p => p.SalesInvoiceItems)
                .HasForeignKey(d => d.SalesInvoiceId)
                .HasConstraintName("FK_SalesInvoiceItem_SalesInvoice");
        });

        modelBuilder.Entity<SalesQuotation>(entity =>
        {
            entity.ToTable("SalesQuotation", tb => tb.HasTrigger("AutoGenerateNumber_SalesQuotation"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CompanyFk).HasColumnName("CompanyFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.CustomerFk).HasColumnName("CustomerFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderNo).HasMaxLength(50);
            entity.Property(e => e.RequestForQuotationFk).HasColumnName("RequestForQuotationFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.TotalCost).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.TotalRatio).HasColumnType("decimal(18, 4)");

            entity.HasOne(d => d.CustomerFkNavigation).WithMany(p => p.SalesQuotations)
                .HasForeignKey(d => d.CustomerFk)
                .HasConstraintName("FK_SalesQuotation_Customer");

            entity.HasOne(d => d.RequestForQuotationFkNavigation).WithMany(p => p.SalesQuotations)
                .HasForeignKey(d => d.RequestForQuotationFk)
                .HasConstraintName("FK_SalesQuotation_VendorOrder");
        });

        modelBuilder.Entity<SalesQuotationDetail>(entity =>
        {
            entity.ToTable("SalesQuotationDetail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CostPrice).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CostPriceRatio).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.OrderedQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.RequestForQuotationDetailFk).HasColumnName("RequestForQuotationDetailFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.SalesQuotationFk).HasColumnName("SalesQuotationFK");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.VendorCostPrice).HasColumnType("decimal(18, 3)");

            entity.HasOne(d => d.InventoryItemFkNavigation).WithMany(p => p.SalesQuotationDetails)
                .HasForeignKey(d => d.InventoryItemFk)
                .HasConstraintName("FK_SalesQuotationDetail_InventoryItem");

            entity.HasOne(d => d.RequestForQuotationDetailFkNavigation).WithMany(p => p.SalesQuotationDetails)
                .HasForeignKey(d => d.RequestForQuotationDetailFk)
                .HasConstraintName("FK_SalesQuotationDetail_VendorOrderDetail");

            entity.HasOne(d => d.SalesQuotationFkNavigation).WithMany(p => p.SalesQuotationDetails)
                .HasForeignKey(d => d.SalesQuotationFk)
                .HasConstraintName("FK_SalesQuotationDetail_SalesQuotation");
        });

        modelBuilder.Entity<Scope>(entity =>
        {
            entity.ToTable("Scope");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<SecConfiguration>(entity =>
        {
            entity.ToTable("SecConfiguration");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Key).HasMaxLength(250);
            entity.Property(e => e.Value).HasMaxLength(250);
        });

        modelBuilder.Entity<SecModel>(entity =>
        {
            entity.HasKey(e => e.ModelId).HasName("PK_Model");

            entity.ToTable("SecModel");

            entity.Property(e => e.ModelId).HasColumnName("ModelID");
            entity.Property(e => e.ModelDisplayName).HasMaxLength(250);
            entity.Property(e => e.ModelDisplayNameAr).HasMaxLength(250);
            entity.Property(e => e.ModelName).HasMaxLength(250);
            entity.Property(e => e.SecModuleId).HasColumnName("SecModuleID");

            entity.HasOne(d => d.SecModule).WithMany(p => p.SecModels)
                .HasForeignKey(d => d.SecModuleId)
                .HasConstraintName("FK_SecModel_SecModule");
        });

        modelBuilder.Entity<SecModelAttribute>(entity =>
        {
            entity.HasKey(e => e.ModelAttributeId).HasName("PK_ModelAttribute");

            entity.ToTable("SecModelAttribute");

            entity.Property(e => e.ModelAttributeId).HasColumnName("ModelAttributeID");
            entity.Property(e => e.AttributeDisplayName).HasMaxLength(250);
            entity.Property(e => e.AttributeDisplayNameAr)
                .HasMaxLength(250)
                .HasColumnName("AttributeDisplayNameAR");
            entity.Property(e => e.AttributeName).HasMaxLength(250);
            entity.Property(e => e.ModelId).HasColumnName("ModelID");

            entity.HasOne(d => d.Model).WithMany(p => p.SecModelAttributes)
                .HasForeignKey(d => d.ModelId)
                .HasConstraintName("FK_ModelAttribute_Model");
        });

        modelBuilder.Entity<SecModule>(entity =>
        {
            entity.ToTable("SecModule");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ModuleName).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
        });

        modelBuilder.Entity<SecProperty>(entity =>
        {
            entity.ToTable("SecProperty");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.SecModuleId).HasColumnName("SecModuleID");
            entity.Property(e => e.Type).HasMaxLength(250);

            entity.HasOne(d => d.SecModule).WithMany(p => p.SecProperties)
                .HasForeignKey(d => d.SecModuleId)
                .HasConstraintName("FK_SecProperty_SecModule");
        });

        modelBuilder.Entity<SecRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK_Role");

            entity.ToTable("SecRole");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(250);
            entity.Property(e => e.RoleNameAr).HasMaxLength(50);
        });

        modelBuilder.Entity<SecRoleModelAttribute>(entity =>
        {
            entity.HasKey(e => new { e.RoleId, e.ModelAttributeId }).HasName("PK_RoleModelAttribute");

            entity.ToTable("SecRoleModelAttribute");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.ModelAttributeId).HasColumnName("ModelAttributeID");

            entity.HasOne(d => d.ModelAttribute).WithMany(p => p.SecRoleModelAttributes)
                .HasForeignKey(d => d.ModelAttributeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoleModelAttribute_ModelAttribute");

            entity.HasOne(d => d.Role).WithMany(p => p.SecRoleModelAttributes)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoleModelAttribute_Role");
        });

        modelBuilder.Entity<SecRoleModule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SecRoleAllowedModule");

            entity.ToTable("SecRoleModule");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.SecModuleId).HasColumnName("SecModuleID");
            entity.Property(e => e.SecRoleId).HasColumnName("SecRoleID");

            entity.HasOne(d => d.SecModule).WithMany(p => p.SecRoleModules)
                .HasForeignKey(d => d.SecModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SecRoleAllowedModule_SecModule");

            entity.HasOne(d => d.SecRole).WithMany(p => p.SecRoleModules)
                .HasForeignKey(d => d.SecRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SecRoleAllowedModule_SecRole");
        });

        modelBuilder.Entity<SecRoleProperty>(entity =>
        {
            entity.ToTable("SecRoleProperty");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PropertyId).HasColumnName("PropertyID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Property).WithMany(p => p.SecRoleProperties)
                .HasForeignKey(d => d.PropertyId)
                .HasConstraintName("FK_SecRoleProperty_SecProperty");

            entity.HasOne(d => d.Role).WithMany(p => p.SecRoleProperties)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_SecRoleProperty_SecRole");
        });

        modelBuilder.Entity<SecRoleSecurableValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RoleSecurableValue");

            entity.ToTable("SecRoleSecurableValue");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.SecRolePropertyId).HasColumnName("SecRolePropertyID");

            entity.HasOne(d => d.SecRoleProperty).WithMany(p => p.SecRoleSecurableValues)
                .HasForeignKey(d => d.SecRolePropertyId)
                .HasConstraintName("FK_SecRoleSecurableValue_SecRoleProperty");
        });

        modelBuilder.Entity<SecRoleViewAction>(entity =>
        {
            entity.HasKey(e => new { e.ViewActionId, e.RoleId }).HasName("PK_RoleViewAction");

            entity.ToTable("SecRoleViewAction");

            entity.Property(e => e.ViewActionId).HasColumnName("ViewActionID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Role).WithMany(p => p.SecRoleViewActions)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoleViewAction_Role");

            entity.HasOne(d => d.ViewAction).WithMany(p => p.SecRoleViewActions)
                .HasForeignKey(d => d.ViewActionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoleViewAction_ViewAction");
        });

        modelBuilder.Entity<SecUserModelAtrribute>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.ModelAttributeId }).HasName("PK_UserModelAtrribute");

            entity.ToTable("SecUserModelAtrribute");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.ModelAttributeId).HasColumnName("ModelAttributeID");

            entity.HasOne(d => d.ModelAttribute).WithMany(p => p.SecUserModelAtrributes)
                .HasForeignKey(d => d.ModelAttributeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserModelAtrribute_ModelAttribute");

            entity.HasOne(d => d.User).WithMany(p => p.SecUserModelAtrributes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserModelAtrribute_User");
        });

        modelBuilder.Entity<SecUserModule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SecUserAllowedModule_1");

            entity.ToTable("SecUserModule");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.SecModuleId).HasColumnName("SecModuleID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.SecModule).WithMany(p => p.SecUserModules)
                .HasForeignKey(d => d.SecModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SecUserAllowedModule_SecModule");

            entity.HasOne(d => d.User).WithMany(p => p.SecUserModules)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SecUserAllowedModule_User");
        });

        modelBuilder.Entity<SecUserProperty>(entity =>
        {
            entity.ToTable("SecUserProperty");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.PropertyId).HasColumnName("PropertyID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Property).WithMany(p => p.SecUserProperties)
                .HasForeignKey(d => d.PropertyId)
                .HasConstraintName("FK_SecUserProperty_SecProperty");

            entity.HasOne(d => d.User).WithMany(p => p.SecUserProperties)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_SecUserProperty_User");
        });

        modelBuilder.Entity<SecUserSecurableValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_UserSecurableValue");

            entity.ToTable("SecUserSecurableValue");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.SecUserPropertyId).HasColumnName("SecUserPropertyID");

            entity.HasOne(d => d.SecUserProperty).WithMany(p => p.SecUserSecurableValues)
                .HasForeignKey(d => d.SecUserPropertyId)
                .HasConstraintName("FK_SecUserSecurableValue_SecUserProperty");
        });

        modelBuilder.Entity<SecUserViewAction>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.ViewActionId }).HasName("PK_UserViewAction");

            entity.ToTable("SecUserViewAction");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.ViewActionId).HasColumnName("ViewActionID");

            entity.HasOne(d => d.User).WithMany(p => p.SecUserViewActions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserViewAction_User");

            entity.HasOne(d => d.ViewAction).WithMany(p => p.SecUserViewActions)
                .HasForeignKey(d => d.ViewActionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserViewAction_ViewAction");
        });

        modelBuilder.Entity<SecView>(entity =>
        {
            entity.HasKey(e => e.ViewId).HasName("PK_View");

            entity.ToTable("SecView");

            entity.Property(e => e.ViewId).HasColumnName("ViewID");
            entity.Property(e => e.SecModuleId).HasColumnName("SecModuleID");
            entity.Property(e => e.Url)
                .HasMaxLength(250)
                .HasColumnName("URL");
            entity.Property(e => e.ViewDisplayName).HasMaxLength(250);
            entity.Property(e => e.ViewDisplayNameAr).HasMaxLength(250);
            entity.Property(e => e.ViewName).HasMaxLength(250);

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("FK_SecView_SecView");

            entity.HasOne(d => d.SecModule).WithMany(p => p.SecViews)
                .HasForeignKey(d => d.SecModuleId)
                .HasConstraintName("FK_SecView_SecModule");
        });

        modelBuilder.Entity<SecViewAction>(entity =>
        {
            entity.HasKey(e => e.ViewActionId).HasName("PK_ViewAction");

            entity.ToTable("SecViewAction");

            entity.Property(e => e.ViewActionId).HasColumnName("ViewActionID");
            entity.Property(e => e.Action).HasMaxLength(250);
            entity.Property(e => e.ActionName).HasMaxLength(250);
            entity.Property(e => e.ActionNameAr).HasMaxLength(250);
            entity.Property(e => e.ViewId).HasColumnName("ViewID");

            entity.HasOne(d => d.View).WithMany(p => p.SecViewActions)
                .HasForeignKey(d => d.ViewId)
                .HasConstraintName("FK_ViewAction_View");
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.ToTable("Section");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Sector>(entity =>
        {
            entity.ToTable("Sector");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsEnabled).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.NameAr).HasMaxLength(50);
            entity.Property(e => e.RowVersion)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.ToTable("Service");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.ServiceCategoryFk).HasColumnName("ServiceCategoryFK");
            entity.Property(e => e.ServiceMainCategoryFk).HasColumnName("ServiceMainCategoryFK");
            entity.Property(e => e.ServiceSubCategoryFk).HasColumnName("ServiceSubCategoryFK");
            entity.Property(e => e.ServiceTypeFk).HasColumnName("ServiceTypeFK");

            entity.HasOne(d => d.ServiceCategoryFkNavigation).WithMany(p => p.Services)
                .HasForeignKey(d => d.ServiceCategoryFk)
                .HasConstraintName("FK_Service_ServiceCategory");

            entity.HasOne(d => d.ServiceMainCategoryFkNavigation).WithMany(p => p.Services)
                .HasForeignKey(d => d.ServiceMainCategoryFk)
                .HasConstraintName("FK_Service_ServiceMainCategory");

            entity.HasOne(d => d.ServiceSubCategoryFkNavigation).WithMany(p => p.Services)
                .HasForeignKey(d => d.ServiceSubCategoryFk)
                .HasConstraintName("FK_Service_ServiceSubCategory");
        });

        modelBuilder.Entity<ServiceCategory>(entity =>
        {
            entity.ToTable("ServiceCategory");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CompanyFk).HasColumnName("CompanyFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .HasMaxLength(8)
                .IsFixedLength();
            entity.Property(e => e.ServiceMainCategoryFk).HasColumnName("ServiceMainCategoryFK");
            entity.Property(e => e.ServiceTypeFk).HasColumnName("ServiceTypeFK");

            entity.HasOne(d => d.ServiceMainCategoryFkNavigation).WithMany(p => p.ServiceCategories)
                .HasForeignKey(d => d.ServiceMainCategoryFk)
                .HasConstraintName("FK_ServiceCategory_ServiceMainCategory");

            entity.HasOne(d => d.ServiceTypeFkNavigation).WithMany(p => p.ServiceCategories)
                .HasForeignKey(d => d.ServiceTypeFk)
                .HasConstraintName("FK_ServiceCategory_ServiceType");
        });

        modelBuilder.Entity<ServiceMainCategory>(entity =>
        {
            entity.ToTable("ServiceMainCategory");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.FinanceCostCenterId).HasColumnName("FinanceCostCenterID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .HasMaxLength(8)
                .IsFixedLength();
        });

        modelBuilder.Entity<ServiceSubCategory>(entity =>
        {
            entity.ToTable("ServiceSubCategory");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CompanyFk).HasColumnName("CompanyFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .HasMaxLength(8)
                .IsFixedLength();
            entity.Property(e => e.ServiceCategoryFk).HasColumnName("ServiceCategoryFK");
            entity.Property(e => e.ServiceMainCategoryFk).HasColumnName("ServiceMainCategoryFK");
            entity.Property(e => e.ServiceTypeFk).HasColumnName("ServiceTypeFK");

            entity.HasOne(d => d.ServiceCategoryFkNavigation).WithMany(p => p.ServiceSubCategories)
                .HasForeignKey(d => d.ServiceCategoryFk)
                .HasConstraintName("FK_ServiceSubCategory_ServiceCategory");

            entity.HasOne(d => d.ServiceMainCategoryFkNavigation).WithMany(p => p.ServiceSubCategories)
                .HasForeignKey(d => d.ServiceMainCategoryFk)
                .HasConstraintName("FK_ServiceSubCategory_ServiceMainCategory");

            entity.HasOne(d => d.ServiceTypeFkNavigation).WithMany(p => p.ServiceSubCategories)
                .HasForeignKey(d => d.ServiceTypeFk)
                .HasConstraintName("FK_ServiceSubCategory_ServiceType");
        });

        modelBuilder.Entity<ServiceType>(entity =>
        {
            entity.ToTable("ServiceType");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .HasMaxLength(8)
                .IsFixedLength();
        });

        modelBuilder.Entity<Sheet1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Sheet1$");

            entity.Property(e => e.Company).HasMaxLength(255);
            entity.Property(e => e.F10).HasMaxLength(255);
            entity.Property(e => e.F11).HasMaxLength(255);
            entity.Property(e => e.F12).HasMaxLength(255);
            entity.Property(e => e.F13).HasMaxLength(255);
            entity.Property(e => e.F14).HasMaxLength(255);
            entity.Property(e => e.F15).HasMaxLength(255);
            entity.Property(e => e.F16).HasMaxLength(255);
            entity.Property(e => e.F17).HasMaxLength(255);
            entity.Property(e => e.F18).HasMaxLength(255);
            entity.Property(e => e.F19).HasMaxLength(255);
            entity.Property(e => e.F20).HasMaxLength(255);
            entity.Property(e => e.F21).HasMaxLength(255);
            entity.Property(e => e.F22).HasMaxLength(255);
            entity.Property(e => e.F23).HasMaxLength(255);
            entity.Property(e => e.F24).HasMaxLength(255);
            entity.Property(e => e.F25).HasMaxLength(255);
            entity.Property(e => e.F26).HasMaxLength(255);
            entity.Property(e => e.F27).HasMaxLength(255);
            entity.Property(e => e.F28).HasMaxLength(255);
            entity.Property(e => e.F29).HasMaxLength(255);
            entity.Property(e => e.F30).HasMaxLength(255);
            entity.Property(e => e.F31).HasMaxLength(255);
            entity.Property(e => e.F32).HasMaxLength(255);
            entity.Property(e => e.F33).HasMaxLength(255);
            entity.Property(e => e.F34).HasMaxLength(255);
            entity.Property(e => e.F35).HasMaxLength(255);
            entity.Property(e => e.F36).HasMaxLength(255);
            entity.Property(e => e.F37).HasMaxLength(255);
            entity.Property(e => e.F38).HasMaxLength(255);
            entity.Property(e => e.F39).HasMaxLength(255);
            entity.Property(e => e.F40).HasMaxLength(255);
            entity.Property(e => e.F41).HasMaxLength(255);
            entity.Property(e => e.F42).HasMaxLength(255);
            entity.Property(e => e.F43).HasMaxLength(255);
            entity.Property(e => e.Line)
                .HasMaxLength(255)
                .HasColumnName("line");
            entity.Property(e => e.Project).HasMaxLength(255);
            entity.Property(e => e.RequestNo).HasMaxLength(255);
            entity.Property(e => e.Scope).HasMaxLength(255);
            entity.Property(e => e.Store).HasMaxLength(255);
        });

        modelBuilder.Entity<Shelf>(entity =>
        {
            entity.ToTable("Shelf");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RackFk).HasColumnName("RackFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.RackFkNavigation).WithMany(p => p.Shelves)
                .HasForeignKey(d => d.RackFk)
                .HasConstraintName("FK_Shelf_Rack");
        });

        modelBuilder.Entity<Site>(entity =>
        {
            entity.ToTable("Site");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<SparePartGroup>(entity =>
        {
            entity.ToTable("SparePartGroup");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.ToTable("State", tb => tb.HasTrigger("Code_State"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CountryFk).HasColumnName("CountryFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.CountryFkNavigation).WithMany(p => p.States)
                .HasForeignKey(d => d.CountryFk)
                .HasConstraintName("FK_State_Country");
        });

        modelBuilder.Entity<StockCount20230331>(entity =>
        {
            entity.ToTable("'StockCount_2023-03-31$'");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasMaxLength(255);
            entity.Property(e => e.ItemCode).HasMaxLength(255);
            entity.Property(e => e.ItemNumber).HasMaxLength(50);
            entity.Property(e => e.Store).HasMaxLength(255);
        });

        modelBuilder.Entity<StockCountPlanStatus>(entity =>
        {
            entity.ToTable("StockCountPlanStatus");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<StockCountPlanType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_StockCounPlanType");

            entity.ToTable("StockCountPlanType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.ToTable("Store", tb => tb.HasTrigger("Code_Store"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Axsynced).HasColumnName("AXSynced");
            entity.Property(e => e.CityFk).HasColumnName("CityFK");
            entity.Property(e => e.CompanyFk).HasColumnName("CompanyFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.LocationFk).HasColumnName("LocationFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.StoreFk).HasColumnName("StoreFK");
            entity.Property(e => e.StoreKeeperFk).HasColumnName("StoreKeeperFK");

            entity.HasOne(d => d.CityFkNavigation).WithMany(p => p.Stores)
                .HasForeignKey(d => d.CityFk)
                .HasConstraintName("FK_Store_City");

            entity.HasOne(d => d.CompanyFkNavigation).WithMany(p => p.Stores)
                .HasForeignKey(d => d.CompanyFk)
                .HasConstraintName("FK_Store_Company");

            entity.HasOne(d => d.LocationFkNavigation).WithMany(p => p.Stores)
                .HasForeignKey(d => d.LocationFk)
                .HasConstraintName("FK_Store_Location");

            entity.HasOne(d => d.StoreFkNavigation).WithMany(p => p.InverseStoreFkNavigation)
                .HasForeignKey(d => d.StoreFk)
                .HasConstraintName("FK_Store_Store");

            entity.HasOne(d => d.StoreKeeperFkNavigation).WithMany(p => p.Stores)
                .HasForeignKey(d => d.StoreKeeperFk)
                .HasConstraintName("FK_Store_User");
        });

        modelBuilder.Entity<StoreKeeper>(entity =>
        {
            entity.ToTable("StoreKeeper");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.StoreFk).HasColumnName("StoreFK");
            entity.Property(e => e.StoreKeeperFk).HasColumnName("StoreKeeperFK");

            entity.HasOne(d => d.StoreFkNavigation).WithMany(p => p.StoreKeepers)
                .HasForeignKey(d => d.StoreFk)
                .HasConstraintName("FK_StoreKeeper_Store");

            entity.HasOne(d => d.StoreKeeperFkNavigation).WithMany(p => p.StoreKeepers)
                .HasForeignKey(d => d.StoreKeeperFk)
                .HasConstraintName("FK_StoreKeeper_StoreKeeper");
        });

        modelBuilder.Entity<StoreSequence>(entity =>
        {
            entity.HasKey(e => e.TableName).HasName("PK__StoreSeq__733652EFB4CC7294");

            entity.Property(e => e.TableName).HasMaxLength(250);
        });

        modelBuilder.Entity<SubSection>(entity =>
        {
            entity.ToTable("SubSection");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.SectionFk).HasColumnName("SectionFK");

            entity.HasOne(d => d.SectionFkNavigation).WithMany(p => p.SubSections)
                .HasForeignKey(d => d.SectionFk)
                .HasConstraintName("FK_SubSection_Section");
        });

        modelBuilder.Entity<SysKeyValue>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SysKeyValue");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.DescriptionAr).HasMaxLength(500);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.SysKey).HasMaxLength(100);
        });

        modelBuilder.Entity<Temp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Temp");
        });

        modelBuilder.Entity<TempBatch>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("TempBatch");

            entity.Property(e => e.BatchId)
                .ValueGeneratedOnAdd()
                .HasColumnName("BatchID");
        });

        modelBuilder.Entity<TermsAndCondition>(entity =>
        {
            entity.ToTable("TermsAndCondition");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .HasMaxLength(8)
                .IsFixedLength();
        });

        modelBuilder.Entity<ToolsType>(entity =>
        {
            entity.ToTable("ToolsType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssetGroupFk).HasColumnName("AssetGroupFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.AssetGroupFkNavigation).WithMany(p => p.ToolsTypes)
                .HasForeignKey(d => d.AssetGroupFk)
                .HasConstraintName("FK_ToolsType_AssetsGroup");
        });

        modelBuilder.Entity<TransferReason>(entity =>
        {
            entity.ToTable("TransferReason");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<TransferStatus>(entity =>
        {
            entity.ToTable("TransferStatus");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<TransfereType>(entity =>
        {
            entity.ToTable("TransfereType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<TransmissionType>(entity =>
        {
            entity.ToTable("TransmissionType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(255);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsEnabled).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.NameAr).HasMaxLength(255);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<UnitOfMeasure>(entity =>
        {
            entity.ToTable("UnitOfMeasure", tb => tb.HasTrigger("Code_UnitOfMeasure"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Axsynced).HasColumnName("AXSynced");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AdUserId).HasColumnName("AD_UserID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.Code).HasMaxLength(255);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.FullName).HasMaxLength(500);
            entity.Property(e => e.IsPda).HasColumnName("IsPDA");
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.NameAr).HasMaxLength(255);
            entity.Property(e => e.Ouid).HasColumnName("OUID");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PasswordCreationDate).HasColumnType("datetime");
            entity.Property(e => e.Phone).HasMaxLength(255);
            entity.Property(e => e.ProfilePicture)
                .HasMaxLength(1000)
                .IsFixedLength();
            entity.Property(e => e.Timestamp)
                .HasMaxLength(8)
                .IsFixedLength()
                .HasColumnName("timestamp");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .HasColumnName("UserID");

            entity.HasOne(d => d.AdUser).WithMany(p => p.Users)
                .HasForeignKey(d => d.AdUserId)
                .HasConstraintName("FK_ADUser_User");

            entity.HasOne(d => d.Employee).WithMany(p => p.Users)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_User_Employee");

            entity.HasOne(d => d.Ou).WithMany(p => p.Users)
                .HasForeignKey(d => d.Ouid)
                .HasConstraintName("FK_User_OU");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "SecUserRole",
                    r => r.HasOne<SecRole>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserRole_Role"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserRole_User"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK_UserRole");
                        j.ToTable("SecUserRole");
                        j.IndexerProperty<long>("UserId").HasColumnName("UserID");
                        j.IndexerProperty<long>("RoleId").HasColumnName("RoleID");
                    });
        });

        modelBuilder.Entity<UserSessionInfo>(entity =>
        {
            entity.ToTable("UserSessionInfo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            entity.Property(e => e.Language)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.LastHit).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.ValidModules).HasMaxLength(250);

            entity.HasOne(d => d.User).WithMany(p => p.UserSessionInfos)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserSessionInfo_User");
        });

        modelBuilder.Entity<UserSessionInfoDetail>(entity =>
        {
            entity.ToTable("UserSessionInfoDetail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.InfoDescription).HasMaxLength(250);
            entity.Property(e => e.InfoValue).HasMaxLength(250);
            entity.Property(e => e.UserSessionInfoId).HasColumnName("UserSessionInfoID");

            entity.HasOne(d => d.UserSessionInfo).WithMany(p => p.UserSessionInfoDetails)
                .HasForeignKey(d => d.UserSessionInfoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_UserSessionInfoDetail_UserSessionInfo");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.ToTable("Vehicle");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.AirFilterTypeFk).HasColumnName("AirFilterTypeFK");
            entity.Property(e => e.Barcode).HasMaxLength(100);
            entity.Property(e => e.BatteryTypeFk).HasColumnName("BatteryTypeFK");
            entity.Property(e => e.BookValue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ChassisNumber).HasMaxLength(50);
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.ColorFk).HasColumnName("ColorFK");
            entity.Property(e => e.CompanyFk).HasColumnName("CompanyFK");
            entity.Property(e => e.CostCenterFk).HasColumnName("CostCenterFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.CylindersNumber).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Depreciation).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.EmployeeFk).HasColumnName("EmployeeFK");
            entity.Property(e => e.EngineNumber).HasMaxLength(50);
            entity.Property(e => e.EngineSizeFk).HasColumnName("EngineSizeFK");
            entity.Property(e => e.EquipmentTypeFk).HasColumnName("EquipmentTypeFK");
            entity.Property(e => e.GrossWeight).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Height).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsEnabled).HasDefaultValue(true);
            entity.Property(e => e.LaborRateRatio).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Length).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.OperationDate).HasColumnType("datetime");
            entity.Property(e => e.OriginalValue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Oufk).HasColumnName("OUFK");
            entity.Property(e => e.OwnershipFk).HasColumnName("OwnershipFK");
            entity.Property(e => e.PlateNumber).HasMaxLength(50);
            entity.Property(e => e.ProjectFk).HasColumnName("ProjectFK");
            entity.Property(e => e.RetireDate).HasColumnType("datetime");
            entity.Property(e => e.Rfid)
                .HasMaxLength(100)
                .HasColumnName("RFID");
            entity.Property(e => e.RowVersion)
                .HasMaxLength(8)
                .IsFixedLength();
            entity.Property(e => e.SectorFk).HasColumnName("SectorFK");
            entity.Property(e => e.SerialNumber).HasMaxLength(50);
            entity.Property(e => e.SparePartRateRatio).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.TransmissionTypeFk).HasColumnName("TransmissionTypeFK");
            entity.Property(e => e.VehicleBrandFk).HasColumnName("VehicleBrandFK");
            entity.Property(e => e.VehicleModelFk).HasColumnName("Vehicle_ModelFK");
            entity.Property(e => e.VehicleOptionFk).HasColumnName("VehicleOptionFK");
            entity.Property(e => e.VehicleStatusFk).HasColumnName("VehicleStatusFK");
            entity.Property(e => e.VehicleTypeFk).HasColumnName("VehicleTypeFK");
            entity.Property(e => e.WheelBase).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Width).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.YearFk).HasColumnName("YearFK");

            entity.HasOne(d => d.AirFilterTypeFkNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.AirFilterTypeFk)
                .HasConstraintName("FK_Vehicle_AirFilterType");

            entity.HasOne(d => d.BatteryTypeFkNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.BatteryTypeFk)
                .HasConstraintName("FK_Vehicle_BatteryType");

            entity.HasOne(d => d.ColorFkNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.ColorFk)
                .HasConstraintName("FK_Vehicle_VehicleColor");

            entity.HasOne(d => d.CostCenterFkNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.CostCenterFk)
                .HasConstraintName("FK_Vehicle_CostCenter");

            entity.HasOne(d => d.EngineSizeFkNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.EngineSizeFk)
                .HasConstraintName("FK_Vehicle_EngineSize");

            entity.HasOne(d => d.OufkNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.Oufk)
                .HasConstraintName("FK_Vehicle_City");

            entity.HasOne(d => d.OwnershipFkNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.OwnershipFk)
                .HasConstraintName("FK_Vehicle_Ownership");

            entity.HasOne(d => d.ProjectFkNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.ProjectFk)
                .HasConstraintName("FK_Vehicle_Project");

            entity.HasOne(d => d.SectorFkNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.SectorFk)
                .HasConstraintName("FK_Vehicle_Sector");

            entity.HasOne(d => d.TransmissionTypeFkNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.TransmissionTypeFk)
                .HasConstraintName("FK_Vehicle_TransmissionType");

            entity.HasOne(d => d.VehicleBrandFkNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.VehicleBrandFk)
                .HasConstraintName("FK_Vehicle_VehicleBrand");

            entity.HasOne(d => d.VehicleModelFkNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.VehicleModelFk)
                .HasConstraintName("FK_Vehicle_Vehicle_Model");

            entity.HasOne(d => d.VehicleOptionFkNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.VehicleOptionFk)
                .HasConstraintName("FK_Vehicle_VehicleOption");

            entity.HasOne(d => d.VehicleStatusFkNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.VehicleStatusFk)
                .HasConstraintName("FK_Vehicle_VehicleStatus");

            entity.HasOne(d => d.VehicleTypeFkNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.VehicleTypeFk)
                .HasConstraintName("FK_Vehicle_VehicleType");

            entity.HasOne(d => d.YearFkNavigation).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.YearFk)
                .HasConstraintName("FK_Vehicle_InventoryYear");
        });

        modelBuilder.Entity<VehicleBrand>(entity =>
        {
            entity.ToTable("VehicleBrand");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(255);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsEnabled).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.NameAr).HasMaxLength(255);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<VehicleColor>(entity =>
        {
            entity.ToTable("VehicleColor");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsEnabled).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.NameAr).HasMaxLength(50);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<VehicleModel>(entity =>
        {
            entity.ToTable("Vehicle_Model");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(255);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsEnabled).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.NameAr).HasMaxLength(255);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.VehicleBrandFk).HasColumnName("VehicleBrandFK");
            entity.Property(e => e.YearFk).HasColumnName("YearFK");

            entity.HasOne(d => d.VehicleBrandFkNavigation).WithMany(p => p.VehicleModels)
                .HasForeignKey(d => d.VehicleBrandFk)
                .HasConstraintName("FK_Vehicle_Model_VehicleBrand");

            entity.HasOne(d => d.YearFkNavigation).WithMany(p => p.VehicleModels)
                .HasForeignKey(d => d.YearFk)
                .HasConstraintName("FK_Vehicle_Model_InventoryYear");
        });

        modelBuilder.Entity<VehicleOption>(entity =>
        {
            entity.ToTable("VehicleOption");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(250);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<VehicleStatus>(entity =>
        {
            entity.ToTable("VehicleStatus");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsEnabled).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.NameAr).HasMaxLength(50);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<VehicleType>(entity =>
        {
            entity.ToTable("VehicleType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.EquipmentTypeFk).HasColumnName("EquipmentTypeFK");
            entity.Property(e => e.ExteriorHeight).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ExteriorLenght).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ExteriorWidth).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.InteriorHeight).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.InteriorLenght).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.InteriorVolume).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.InteriorWidth).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsEnabled).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.MaxGrossWeight).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.NameAr).HasMaxLength(255);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.TareWeight).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.ToTable("Vendor", tb => tb.HasTrigger("Code_Vendor"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CityFk).HasColumnName("CityFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.FinanceId).HasColumnName("FinanceID");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.VendorStatusFk).HasColumnName("VendorStatusFK");
            entity.Property(e => e.VendorTypeFk).HasColumnName("VendorTypeFK");

            entity.HasOne(d => d.CityFkNavigation).WithMany(p => p.Vendors)
                .HasForeignKey(d => d.CityFk)
                .HasConstraintName("FK_Vendor_City");

            entity.HasOne(d => d.VendorStatusFkNavigation).WithMany(p => p.Vendors)
                .HasForeignKey(d => d.VendorStatusFk)
                .HasConstraintName("FK_Vendor_VendorStatus");

            entity.HasOne(d => d.VendorTypeFkNavigation).WithMany(p => p.Vendors)
                .HasForeignKey(d => d.VendorTypeFk)
                .HasConstraintName("FK_Vendor_VendorType");
        });

        modelBuilder.Entity<VendorAttachment>(entity =>
        {
            entity.ToTable("VendorAttachment");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AttachmentId).HasColumnName("AttachmentID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.VendorFk).HasColumnName("VendorFK");

            entity.HasOne(d => d.VendorFkNavigation).WithMany(p => p.VendorAttachments)
                .HasForeignKey(d => d.VendorFk)
                .HasConstraintName("FK_VendorAttachment_Vendor");
        });

        modelBuilder.Entity<VendorEvaluationCriterion>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<VendorOrder>(entity =>
        {
            entity.ToTable("VendorOrder", tb => tb.HasTrigger("AutoGenerateNumber_VendorOrder"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AssignedToUserFk).HasColumnName("AssignedToUserFK");
            entity.Property(e => e.Axpono).HasColumnName("AXPONo");
            entity.Property(e => e.Axsynced).HasColumnName("AXSynced");
            entity.Property(e => e.CompanyFk).HasColumnName("CompanyFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.ExpectedDeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.FactoryFk).HasColumnName("FactoryFK");
            entity.Property(e => e.FactoryLineFk).HasColumnName("FactoryLineFK");
            entity.Property(e => e.InventoryItemBudgetFk).HasColumnName("InventoryItemBudgetFK");
            entity.Property(e => e.InventroyItemRequestWithdrawFk).HasColumnName("InventroyItemRequestWithdrawFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsGta).HasColumnName("IsGTA");
            entity.Property(e => e.IsVat).HasColumnName("IsVAT");
            entity.Property(e => e.ItemTypeFk).HasColumnName("ItemTypeFK");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.LocationFk).HasColumnName("LocationFK");
            entity.Property(e => e.NotesAr).HasColumnName("NotesAR");
            entity.Property(e => e.NotesEn).HasColumnName("NotesEN");
            entity.Property(e => e.OrderByUserFk).HasColumnName("OrderByUserFK");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderScreenFk).HasColumnName("OrderScreenFK");
            entity.Property(e => e.PaymentTermFk).HasColumnName("PaymentTermFK");
            entity.Property(e => e.Prfk).HasColumnName("PRFK");
            entity.Property(e => e.ProjectFk).HasColumnName("ProjectFK");
            entity.Property(e => e.Rfqfk).HasColumnName("RFQFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.ScopeFk).HasColumnName("ScopeFK");
            entity.Property(e => e.ServiceMainCategoryFk).HasColumnName("ServiceMainCategoryFK");
            entity.Property(e => e.SourceEntity).HasMaxLength(500);
            entity.Property(e => e.SourceId).HasColumnName("SourceID");
            entity.Property(e => e.StoreFk).HasColumnName("StoreFK");
            entity.Property(e => e.TotalCost).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.VehicleFk).HasColumnName("VehicleFK");
            entity.Property(e => e.VendorFk).HasColumnName("VendorFK");
            entity.Property(e => e.VendorOrderStatusFk).HasColumnName("VendorOrderStatusFK");
            entity.Property(e => e.VendorOrderTypeFk).HasColumnName("VendorOrderTypeFK");

            entity.HasOne(d => d.AssignedToUserFkNavigation).WithMany(p => p.VendorOrderAssignedToUserFkNavigations)
                .HasForeignKey(d => d.AssignedToUserFk)
                .HasConstraintName("FK_VendorOrder_AssignedToUser");

            entity.HasOne(d => d.CompanyFkNavigation).WithMany(p => p.VendorOrders)
                .HasForeignKey(d => d.CompanyFk)
                .HasConstraintName("FK_VendorOrder_Company");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.VendorOrderCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_VendorOrder_CreatedByUser");

            entity.HasOne(d => d.InventroyItemRequestWithdrawFkNavigation).WithMany(p => p.VendorOrders)
                .HasForeignKey(d => d.InventroyItemRequestWithdrawFk)
                .HasConstraintName("FK_VendorOrder_InventroyItemRequestWithdraw");

            entity.HasOne(d => d.ItemTypeFkNavigation).WithMany(p => p.VendorOrders)
                .HasForeignKey(d => d.ItemTypeFk)
                .HasConstraintName("FK_VendorOrder_ItemType");

            entity.HasOne(d => d.LastUpdatedByNavigation).WithMany(p => p.VendorOrderLastUpdatedByNavigations)
                .HasForeignKey(d => d.LastUpdatedBy)
                .HasConstraintName("FK_VendorOrder_LastUpdatedUser");

            entity.HasOne(d => d.LocationFkNavigation).WithMany(p => p.VendorOrders)
                .HasForeignKey(d => d.LocationFk)
                .HasConstraintName("FK_VendorOrder_Location");

            entity.HasOne(d => d.OrderByUserFkNavigation).WithMany(p => p.VendorOrderOrderByUserFkNavigations)
                .HasForeignKey(d => d.OrderByUserFk)
                .HasConstraintName("FK_VendorOrder_OrderByUser");

            entity.HasOne(d => d.OrderScreenFkNavigation).WithMany(p => p.VendorOrders)
                .HasForeignKey(d => d.OrderScreenFk)
                .HasConstraintName("FK_VendorOrder_VendorOrderScreen");

            entity.HasOne(d => d.PaymentTermFkNavigation).WithMany(p => p.VendorOrders)
                .HasForeignKey(d => d.PaymentTermFk)
                .HasConstraintName("FK_VendorOrder_PaymentTerm");

            entity.HasOne(d => d.PrfkNavigation).WithMany(p => p.InversePrfkNavigation)
                .HasForeignKey(d => d.Prfk)
                .HasConstraintName("FK_VendorOrder_PR");

            entity.HasOne(d => d.ProjectFkNavigation).WithMany(p => p.VendorOrders)
                .HasForeignKey(d => d.ProjectFk)
                .HasConstraintName("FK_VendorOrder_Project");

            entity.HasOne(d => d.RfqfkNavigation).WithMany(p => p.InverseRfqfkNavigation)
                .HasForeignKey(d => d.Rfqfk)
                .HasConstraintName("FK_VendorOrder_RFQ");

            entity.HasOne(d => d.ScopeFkNavigation).WithMany(p => p.VendorOrders)
                .HasForeignKey(d => d.ScopeFk)
                .HasConstraintName("FK_VendorOrder_Scope");

            entity.HasOne(d => d.ServiceMainCategoryFkNavigation).WithMany(p => p.VendorOrders)
                .HasForeignKey(d => d.ServiceMainCategoryFk)
                .HasConstraintName("FK_VendorOrder_ServiceMainCategory");

            entity.HasOne(d => d.StoreFkNavigation).WithMany(p => p.VendorOrders)
                .HasForeignKey(d => d.StoreFk)
                .HasConstraintName("FK_VendorOrder_Store");

            entity.HasOne(d => d.VehicleFkNavigation).WithMany(p => p.VendorOrders)
                .HasForeignKey(d => d.VehicleFk)
                .HasConstraintName("FK_VendorOrder_Vehicle");

            entity.HasOne(d => d.VendorFkNavigation).WithMany(p => p.VendorOrders)
                .HasForeignKey(d => d.VendorFk)
                .HasConstraintName("FK_VendorOrder_Vendor");

            entity.HasOne(d => d.VendorOrderStatusFkNavigation).WithMany(p => p.VendorOrders)
                .HasForeignKey(d => d.VendorOrderStatusFk)
                .HasConstraintName("FK_VendorOrder_VendorOrderStatus");

            entity.HasOne(d => d.VendorOrderTypeFkNavigation).WithMany(p => p.VendorOrders)
                .HasForeignKey(d => d.VendorOrderTypeFk)
                .HasConstraintName("FK_VendorOrder_VendorOrderType");
        });

        modelBuilder.Entity<VendorOrderAttachment>(entity =>
        {
            entity.ToTable("VendorOrderAttachment");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AttachmentId).HasColumnName("AttachmentID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.VendorOrderFk).HasColumnName("VendorOrderFK");

            entity.HasOne(d => d.VendorOrderFkNavigation).WithMany(p => p.VendorOrderAttachments)
                .HasForeignKey(d => d.VendorOrderFk)
                .HasConstraintName("FK_VendorOrderAttachment_VendorOrder");
        });

        modelBuilder.Entity<VendorOrderDetail>(entity =>
        {
            entity.ToTable("VendorOrderDetail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AvgCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CostPrice).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastPurchasePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.OrderLineItemStatusFk).HasColumnName("OrderLineItemStatusFK");
            entity.Property(e => e.OrderedQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.PrdetailFk).HasColumnName("PRDetailFK");
            entity.Property(e => e.Prquantity)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("PRQuantity");
            entity.Property(e => e.QuantityOnHand).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Rfqquantity)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("RFQQuantity");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.SupplierPercentage).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalQuotationPrice).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.VendorOrderFk).HasColumnName("VendorOrderFK");

            entity.HasOne(d => d.InventoryItemFkNavigation).WithMany(p => p.VendorOrderDetails)
                .HasForeignKey(d => d.InventoryItemFk)
                .HasConstraintName("FK_VendorOrderDetail_InventoryItem");

            entity.HasOne(d => d.OrderLineItemStatusFkNavigation).WithMany(p => p.VendorOrderDetails)
                .HasForeignKey(d => d.OrderLineItemStatusFk)
                .HasConstraintName("FK_VendorOrderDetail_OrderLineItemStatus");

            entity.HasOne(d => d.PrdetailFkNavigation).WithMany(p => p.InversePrdetailFkNavigation)
                .HasForeignKey(d => d.PrdetailFk)
                .HasConstraintName("FK_VendorOrderDetail_VendorRequestDetail");

            entity.HasOne(d => d.VendorOrderFkNavigation).WithMany(p => p.VendorOrderDetails)
                .HasForeignKey(d => d.VendorOrderFk)
                .HasConstraintName("FK_VendorOrderDetail_VendorOrder");
        });

        modelBuilder.Entity<VendorOrderPartiallyReceivedNote>(entity =>
        {
            entity.ToTable("VendorOrderPartiallyReceivedNote");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.CurrentReceivedQuantity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.PartiallyReceivedReasonFk).HasColumnName("PartiallyReceivedReasonFK");
            entity.Property(e => e.VendorOrderDetailFk).HasColumnName("VendorOrderDetailFK");

            entity.HasOne(d => d.VendorOrderDetailFkNavigation).WithMany(p => p.VendorOrderPartiallyReceivedNotes)
                .HasForeignKey(d => d.VendorOrderDetailFk)
                .HasConstraintName("FK_VendorOrderPartiallyReceivedNote_VendorOrderDetail");
        });

        modelBuilder.Entity<VendorOrderQuality>(entity =>
        {
            entity.ToTable("VendorOrderQuality", tb => tb.HasTrigger("AutoGenerateNumber_VendorOrderQuality"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.ReceivedByUserFk).HasColumnName("ReceivedByUserFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.VendorOrderFk).HasColumnName("VendorOrderFK");

            entity.HasOne(d => d.VendorOrderFkNavigation).WithMany(p => p.VendorOrderQualities)
                .HasForeignKey(d => d.VendorOrderFk)
                .HasConstraintName("FK_VendorOrderQuality_VendorOrder");
        });

        modelBuilder.Entity<VendorOrderQualityAttachment>(entity =>
        {
            entity.ToTable("VendorOrderQualityAttachment");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AttachmentId).HasColumnName("AttachmentID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.VendorOrderQualityFk).HasColumnName("VendorOrderQualityFK");

            entity.HasOne(d => d.VendorOrderQualityFkNavigation).WithMany(p => p.VendorOrderQualityAttachments)
                .HasForeignKey(d => d.VendorOrderQualityFk)
                .HasConstraintName("FK_VendorOrderQualityAttachment_VendorOrderQuality");
        });

        modelBuilder.Entity<VendorOrderQualityDetail>(entity =>
        {
            entity.ToTable("VendorOrderQualityDetail", tb => tb.HasTrigger("UpdateVendorOrderStatus_WithQuality"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LandedCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.ReceivedQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.VendorOrderDetailFk).HasColumnName("VendorOrderDetailFK");
            entity.Property(e => e.VendorOrderQualityFk).HasColumnName("VendorOrderQualityFK");

            entity.HasOne(d => d.InventoryItemFkNavigation).WithMany(p => p.VendorOrderQualityDetails)
                .HasForeignKey(d => d.InventoryItemFk)
                .HasConstraintName("FK_VendorOrderQualityDetail_InventoryItem");

            entity.HasOne(d => d.VendorOrderDetailFkNavigation).WithMany(p => p.VendorOrderQualityDetails)
                .HasForeignKey(d => d.VendorOrderDetailFk)
                .HasConstraintName("FK_VendorOrderQualityDetail_VendorOrderDetail");

            entity.HasOne(d => d.VendorOrderQualityFkNavigation).WithMany(p => p.VendorOrderQualityDetails)
                .HasForeignKey(d => d.VendorOrderQualityFk)
                .HasConstraintName("FK_VendorOrderQualityDetail_VendorOrderQuality");
        });

        modelBuilder.Entity<VendorOrderQualityDetailBatch>(entity =>
        {
            entity.ToTable("VendorOrderQualityDetailBatch");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.ProductionDate).HasColumnType("datetime");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.ShelfFk).HasColumnName("ShelfFK");
            entity.Property(e => e.VendorOrderQualityDetailFk).HasColumnName("VendorOrderQualityDetailFK");

            entity.HasOne(d => d.VendorOrderQualityDetailFkNavigation).WithMany(p => p.VendorOrderQualityDetailBatches)
                .HasForeignKey(d => d.VendorOrderQualityDetailFk)
                .HasConstraintName("FK_VendorOrderQualityDetailBatch_VendorOrderQualityDetail");
        });

        modelBuilder.Entity<VendorOrderReceive>(entity =>
        {
            entity.ToTable("VendorOrderReceive", tb => tb.HasTrigger("AutoGenerateNumber_VendorOrderReceive"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AvgCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Axsynced).HasColumnName("AXSynced");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastPurchasePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.ReceivedByUserFk).HasColumnName("ReceivedByUserFK");
            entity.Property(e => e.ReceivingDate).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.VendorOrderFk).HasColumnName("VendorOrderFK");
            entity.Property(e => e.VendorOrderQualityFk).HasColumnName("VendorOrderQualityFK");

            entity.HasOne(d => d.VendorOrderFkNavigation).WithMany(p => p.VendorOrderReceives)
                .HasForeignKey(d => d.VendorOrderFk)
                .HasConstraintName("FK_VendorOrderReceive_VendorOrder");

            entity.HasOne(d => d.VendorOrderQualityFkNavigation).WithMany(p => p.VendorOrderReceives)
                .HasForeignKey(d => d.VendorOrderQualityFk)
                .HasConstraintName("FK_VendorOrderReceive_VendorOrderQuality");
        });

        modelBuilder.Entity<VendorOrderReceiveAttachment>(entity =>
        {
            entity.ToTable("VendorOrderReceiveAttachment");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AttachmentId).HasColumnName("AttachmentID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.VendorOrderReceiveFk).HasColumnName("VendorOrderReceiveFK");

            entity.HasOne(d => d.VendorOrderReceiveFkNavigation).WithMany(p => p.VendorOrderReceiveAttachments)
                .HasForeignKey(d => d.VendorOrderReceiveFk)
                .HasConstraintName("FK_VendorOrderReceiveAttachment_VendorOrderReceive");
        });

        modelBuilder.Entity<VendorOrderReceiveDetail>(entity =>
        {
            entity.ToTable("VendorOrderReceiveDetail", tb => tb.HasTrigger("UpdateVendorOrderDetailStatus"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.PartNo).HasMaxLength(250);
            entity.Property(e => e.ReceivedQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.ReturnedQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.VendorOrderQualityDetailFk).HasColumnName("VendorOrderQualityDetailFK");
            entity.Property(e => e.VendorOrderReceiveFk).HasColumnName("VendorOrderReceiveFK");

            entity.HasOne(d => d.InventoryItemFkNavigation).WithMany(p => p.VendorOrderReceiveDetails)
                .HasForeignKey(d => d.InventoryItemFk)
                .HasConstraintName("FK_VendorOrderReceiveDetail_InventoryItem");

            entity.HasOne(d => d.VendorOrderQualityDetailFkNavigation).WithMany(p => p.VendorOrderReceiveDetails)
                .HasForeignKey(d => d.VendorOrderQualityDetailFk)
                .HasConstraintName("FK_VendorOrderReceiveDetail_VendorOrderQualityDetail");

            entity.HasOne(d => d.VendorOrderReceiveFkNavigation).WithMany(p => p.VendorOrderReceiveDetails)
                .HasForeignKey(d => d.VendorOrderReceiveFk)
                .HasConstraintName("FK_VendorOrderReceiveDetail_VendorOrderReceive");
        });

        modelBuilder.Entity<VendorOrderReceiveDetailBatch>(entity =>
        {
            entity.ToTable("VendorOrderReceiveDetailBatch");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.ProductionDate).HasColumnType("datetime");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.ReturnedQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.ShelfFk).HasColumnName("ShelfFK");
            entity.Property(e => e.VendorOrderReceiveDetailFk).HasColumnName("VendorOrderReceiveDetailFK");

            entity.HasOne(d => d.ShelfFkNavigation).WithMany(p => p.VendorOrderReceiveDetailBatches)
                .HasForeignKey(d => d.ShelfFk)
                .HasConstraintName("FK_VendorOrderReceiveDetailBatch_Shelf");

            entity.HasOne(d => d.VendorOrderReceiveDetailFkNavigation).WithMany(p => p.VendorOrderReceiveDetailBatches)
                .HasForeignKey(d => d.VendorOrderReceiveDetailFk)
                .HasConstraintName("FK_VendorOrderReceiveDetailBatch_VendorOrderReceiveDetail");
        });

        modelBuilder.Entity<VendorOrderReceiveDetailBatchSerial>(entity =>
        {
            entity.ToTable("VendorOrderReceiveDetailBatchSerial");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.VendorOrderReceiveDetailBatchFk).HasColumnName("VendorOrderReceiveDetailBatchFK");

            entity.HasOne(d => d.VendorOrderReceiveDetailBatchFkNavigation).WithMany(p => p.VendorOrderReceiveDetailBatchSerials)
                .HasForeignKey(d => d.VendorOrderReceiveDetailBatchFk)
                .HasConstraintName("FK_VendorOrderReceiveDetailBatchSerial_VendorOrderReceiveDetailBatch");
        });

        modelBuilder.Entity<VendorOrderReceiveSerial>(entity =>
        {
            entity.ToTable("VendorOrderReceiveSerial");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryItemSerialFk).HasColumnName("InventoryItemSerialFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.VendorOrderReceiveDetailFk).HasColumnName("VendorOrderReceiveDetailFK");
            entity.Property(e => e.VendorOrderReceiveFk).HasColumnName("VendorOrderReceiveFK");

            entity.HasOne(d => d.InventoryItemSerialFkNavigation).WithMany(p => p.VendorOrderReceiveSerials)
                .HasForeignKey(d => d.InventoryItemSerialFk)
                .HasConstraintName("FK_VendorOrderReceiveSerial_InventoryItemSerial");

            entity.HasOne(d => d.VendorOrderReceiveDetailFkNavigation).WithMany(p => p.VendorOrderReceiveSerials)
                .HasForeignKey(d => d.VendorOrderReceiveDetailFk)
                .HasConstraintName("FK_VendorOrderReceiveSerial_VendorOrderReceiveDetail");

            entity.HasOne(d => d.VendorOrderReceiveFkNavigation).WithMany(p => p.VendorOrderReceiveSerials)
                .HasForeignKey(d => d.VendorOrderReceiveFk)
                .HasConstraintName("FK_VendorOrderReceiveSerial_VendorOrderReceive");
        });

        modelBuilder.Entity<VendorOrderScreen>(entity =>
        {
            entity.ToTable("VendorOrderScreen");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<VendorOrderStatus>(entity =>
        {
            entity.ToTable("VendorOrderStatus");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<VendorOrderType>(entity =>
        {
            entity.ToTable("VendorOrderType");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<VendorOrderVendorSelection>(entity =>
        {
            entity.ToTable("VendorOrder_VendorSelection");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.VendorFk).HasColumnName("VendorFK");
            entity.Property(e => e.VendorOrderFk).HasColumnName("VendorOrderFK");

            entity.HasOne(d => d.VendorFkNavigation).WithMany(p => p.VendorOrderVendorSelections)
                .HasForeignKey(d => d.VendorFk)
                .HasConstraintName("FK_VendorOrder_VendorSelection_Vendor");

            entity.HasOne(d => d.VendorOrderFkNavigation).WithMany(p => p.VendorOrderVendorSelections)
                .HasForeignKey(d => d.VendorOrderFk)
                .HasConstraintName("FK_VendorOrder_VendorSelection_VendorOrder");
        });

        modelBuilder.Entity<VendorOrderVendorSuggested>(entity =>
        {
            entity.ToTable("VendorOrder_VendorSuggested");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.VendorName).HasMaxLength(250);
            entity.Property(e => e.VendorOrderFk).HasColumnName("VendorOrderFK");

            entity.HasOne(d => d.VendorOrderFkNavigation).WithMany(p => p.VendorOrderVendorSuggesteds)
                .HasForeignKey(d => d.VendorOrderFk)
                .HasConstraintName("FK_VendorOrder_VendorSuggested_VendorOrder");
        });

        modelBuilder.Entity<VendorReturn>(entity =>
        {
            entity.ToTable("VendorReturn", tb => tb.HasTrigger("AutoGenerateNumber_VendorReturn"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Axsynced).HasColumnName("AXSynced");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DescriptionAr).HasColumnName("DescriptionAR");
            entity.Property(e => e.DescriptionEn).HasColumnName("DescriptionEN");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.ReturnDate).HasColumnType("datetime");
            entity.Property(e => e.ReturnStatusFk).HasColumnName("ReturnStatusFK");
            entity.Property(e => e.ReturnedByUserFk).HasColumnName("ReturnedByUserFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.VendorOrderReceiveFk).HasColumnName("VendorOrderReceiveFK");

            entity.HasOne(d => d.ReturnStatusFkNavigation).WithMany(p => p.VendorReturns)
                .HasForeignKey(d => d.ReturnStatusFk)
                .HasConstraintName("FK_VendorReturn_ReturnStatus");

            entity.HasOne(d => d.VendorOrderReceiveFkNavigation).WithMany(p => p.VendorReturns)
                .HasForeignKey(d => d.VendorOrderReceiveFk)
                .HasConstraintName("FK_VendorReturn_VendorOrderReceive");
        });

        modelBuilder.Entity<VendorReturnAttachment>(entity =>
        {
            entity.ToTable("VendorReturnAttachment");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AttachmentId).HasColumnName("AttachmentID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.VendorReturnFk).HasColumnName("VendorReturnFK");

            entity.HasOne(d => d.VendorReturnFkNavigation).WithMany(p => p.VendorReturnAttachments)
                .HasForeignKey(d => d.VendorReturnFk)
                .HasConstraintName("FK_VendorReturnAttachment_VendorReturn");
        });

        modelBuilder.Entity<VendorReturnDetail>(entity =>
        {
            entity.ToTable("VendorReturnDetail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.ReturnReasonFk).HasColumnName("ReturnReasonFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.VendorReturnFk).HasColumnName("VendorReturnFK");

            entity.HasOne(d => d.InventoryItemFkNavigation).WithMany(p => p.VendorReturnDetails)
                .HasForeignKey(d => d.InventoryItemFk)
                .HasConstraintName("FK_VendorReturnDetail_InventoryItem");

            entity.HasOne(d => d.ReturnReasonFkNavigation).WithMany(p => p.VendorReturnDetails)
                .HasForeignKey(d => d.ReturnReasonFk)
                .HasConstraintName("FK_VendorReturnDetail_ReturnReason");

            entity.HasOne(d => d.VendorReturnFkNavigation).WithMany(p => p.VendorReturnDetails)
                .HasForeignKey(d => d.VendorReturnFk)
                .HasConstraintName("FK_VendorReturnDetail_VendorReturn");
        });

        modelBuilder.Entity<VendorReturnDetailBatch>(entity =>
        {
            entity.ToTable("VendorReturnDetailBatch");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BatchFk).HasColumnName("BatchFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.ReturnReasonFk).HasColumnName("ReturnReasonFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.VendorOrderReceiveDetailBatchFk).HasColumnName("VendorOrderReceiveDetailBatchFK");
            entity.Property(e => e.VendorReturnDetailFk).HasColumnName("VendorReturnDetailFK");

            entity.HasOne(d => d.ReturnReasonFkNavigation).WithMany(p => p.VendorReturnDetailBatches)
                .HasForeignKey(d => d.ReturnReasonFk)
                .HasConstraintName("FK_VendorReturnDetailBatch_ReturnReason");
        });

        modelBuilder.Entity<VendorReturnDetailBatchSerial>(entity =>
        {
            entity.ToTable("VendorReturnDetailBatchSerial");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.ReturnReasonFk).HasColumnName("ReturnReasonFK");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.SerialFk).HasColumnName("SerialFK");
            entity.Property(e => e.VendorReturnDetailBatchFk).HasColumnName("VendorReturnDetailBatchFK");

            entity.HasOne(d => d.ReturnReasonFkNavigation).WithMany(p => p.VendorReturnDetailBatchSerials)
                .HasForeignKey(d => d.ReturnReasonFk)
                .HasConstraintName("FK_VendorReturnDetailBatchSerial_ReturnReason");

            entity.HasOne(d => d.SerialFkNavigation).WithMany(p => p.VendorReturnDetailBatchSerials)
                .HasForeignKey(d => d.SerialFk)
                .HasConstraintName("FK_VendorReturnDetailBatchSerial_VendorOrderReceiveDetailBatchSerial");

            entity.HasOne(d => d.VendorReturnDetailBatchFkNavigation).WithMany(p => p.VendorReturnDetailBatchSerials)
                .HasForeignKey(d => d.VendorReturnDetailBatchFk)
                .HasConstraintName("FK_VendorReturnDetailBatchSerial_VendorReturnDetailBatch");
        });

        modelBuilder.Entity<VendorReturnSerial>(entity =>
        {
            entity.ToTable("VendorReturnSerial");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InventoryItemSerialFk).HasColumnName("InventoryItemSerialFK");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.VendorReturnDetailFk).HasColumnName("VendorReturnDetailFK");
            entity.Property(e => e.VendorReturnFk).HasColumnName("VendorReturnFK");

            entity.HasOne(d => d.InventoryItemSerialFkNavigation).WithMany(p => p.VendorReturnSerials)
                .HasForeignKey(d => d.InventoryItemSerialFk)
                .HasConstraintName("FK_VendorReturnSerial_InventoryItemSerial");

            entity.HasOne(d => d.VendorReturnDetailFkNavigation).WithMany(p => p.VendorReturnSerials)
                .HasForeignKey(d => d.VendorReturnDetailFk)
                .HasConstraintName("FK_VendorReturnSerial_VendorReturnDetail");

            entity.HasOne(d => d.VendorReturnFkNavigation).WithMany(p => p.VendorReturnSerials)
                .HasForeignKey(d => d.VendorReturnFk)
                .HasConstraintName("FK_VendorReturnSerial_VendorReturn");
        });

        modelBuilder.Entity<VendorSpecialization>(entity =>
        {
            entity.ToTable("VendorSpecialization");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<VendorStatus>(entity =>
        {
            entity.ToTable("VendorStatus");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<VendorType>(entity =>
        {
            entity.ToTable("VendorType");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<ViewRequestStatus>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_RequestStatus");

            entity.Property(e => e.PurchaseRequestFk).HasColumnName("PurchaseRequestFK");
            entity.Property(e => e.RequestOrderStatusId).HasColumnName("RequestOrderStatusID");
            entity.Property(e => e.TotalOrderedQuantity).HasColumnType("decimal(38, 3)");
            entity.Property(e => e.TotalRequestedQuantity).HasColumnType("decimal(38, 3)");
        });

        modelBuilder.Entity<Visit>(entity =>
        {
            entity.ToTable("Visit");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Image).HasMaxLength(250);
            entity.Property(e => e.Latitude).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(18, 10)");
            entity.Property(e => e.OtherSupplier).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Customer).WithMany(p => p.Visits)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Visit_Customer");

            entity.HasOne(d => d.User).WithMany(p => p.Visits)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Visit_User");
        });

        modelBuilder.Entity<VwInventoryItemDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_InventoryItemDetails");

            entity.Property(e => e.AutoRequestQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.AvgCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Axsynced).HasColumnName("AXSynced");
            entity.Property(e => e.ChemicalGroupName).HasMaxLength(50);
            entity.Property(e => e.Concentration).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DeliveryPeriodDays).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Density).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Dft)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("DFT");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdelPeriod).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.LastPurchasePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.MaterialCategoryName).HasMaxLength(250);
            entity.Property(e => e.MaterialGroupName).HasMaxLength(250);
            entity.Property(e => e.MaterialSubCategoryName).HasMaxLength(250);
            entity.Property(e => e.MaxLevel).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.MinLevel).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Packing).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Rfid).HasColumnName("RFID");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.SpreadingRate).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.TotalQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.VolumeSolid).HasColumnType("decimal(18, 3)");
        });

        modelBuilder.Entity<VwInventoryItemDetailsClean>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_InventoryItemDetails_Clean");

            entity.Property(e => e.AutoRequestQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.AvgCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Axsynced).HasColumnName("AXSynced");
            entity.Property(e => e.ChemicalGroupName).HasMaxLength(50);
            entity.Property(e => e.Concentration).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DeliveryPeriodDays).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Density).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Dft)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("DFT");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdelPeriod).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.LastPurchasePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.MaterialCategoryName).HasMaxLength(250);
            entity.Property(e => e.MaterialGroupName).HasMaxLength(250);
            entity.Property(e => e.MaterialSubCategoryName).HasMaxLength(250);
            entity.Property(e => e.MaxLevel).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.MinLevel).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Packing).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Rfid).HasColumnName("RFID");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.SpreadingRate).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.TotalQuantity).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.VolumeSolid).HasColumnType("decimal(18, 3)");
        });

        modelBuilder.Entity<WarrantyStatus>(entity =>
        {
            entity.ToTable("WarrantyStatus");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<WorkerType>(entity =>
        {
            entity.ToTable("WorkerType");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.NameAr).HasMaxLength(250);
            entity.Property(e => e.RowVersion)
                .HasMaxLength(8)
                .IsFixedLength();
        });

        modelBuilder.Entity<WsLastSyncTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07BAA22652");

            entity.ToTable("WS_LastSyncTable");
        });

        modelBuilder.Entity<Zone>(entity =>
        {
            entity.ToTable("Zone");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CityFk).HasColumnName("CityFK");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.LocationFk).HasColumnName("LocationFK");
            entity.Property(e => e.Rfid).HasColumnName("RFID");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.SubSectionFk).HasColumnName("SubSectionFK");
            entity.Property(e => e.ZoneStatusFk).HasColumnName("ZoneStatusFK");

            entity.HasOne(d => d.CityFkNavigation).WithMany(p => p.Zones)
                .HasForeignKey(d => d.CityFk)
                .HasConstraintName("FK_Zone_City");

            entity.HasOne(d => d.LocationFkNavigation).WithMany(p => p.Zones)
                .HasForeignKey(d => d.LocationFk)
                .HasConstraintName("FK_Zone_Location");

            entity.HasOne(d => d.SiteFkNavigation).WithMany(p => p.Zones)
                .HasForeignKey(d => d.SiteFk)
                .HasConstraintName("FK_Zone_Site");

            entity.HasOne(d => d.SubSectionFkNavigation).WithMany(p => p.Zones)
                .HasForeignKey(d => d.SubSectionFk)
                .HasConstraintName("FK_Zone_SubSection");

            entity.HasOne(d => d.ZoneStatusFkNavigation).WithMany(p => p.Zones)
                .HasForeignKey(d => d.ZoneStatusFk)
                .HasConstraintName("FK_Zone_ZoneStatus");
        });

        modelBuilder.Entity<ZoneStatus>(entity =>
        {
            entity.ToTable("ZoneStatus");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.RowVersion)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<_20230515CairoOpeningBalance>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("$20230515_Cairo_OpeningBalance");

            entity.Property(e => e.AverageCostPerUnit).HasColumnName("Average Cost per unit");
            entity.Property(e => e.HeadofficeCairo).HasColumnName("Headoffice Cairo");
            entity.Property(e => e.ItemName).HasMaxLength(255);
            entity.Property(e => e.ItemNumber).HasMaxLength(255);
            entity.Property(e => e.قطاعاكتوبر).HasColumnName("قطاع اكتوبر");
            entity.Property(e => e.قطاعالقطامية).HasColumnName("قطاع القطامية");
        });

        modelBuilder.Entity<_20230515HebaOpeningBalance>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("$20230515_Heba_OpeningBalance");

            entity.Property(e => e.ItemName).HasMaxLength(255);
            entity.Property(e => e.ItemNumber).HasMaxLength(255);
            entity.Property(e => e.Store1).HasColumnName("Store_1");
            entity.Property(e => e.Store4).HasColumnName("Store_4");
            entity.Property(e => e.Store5).HasColumnName("Store_5");
            entity.Property(e => e.Store6).HasColumnName("Store_6");
            entity.Property(e => e.Store7).HasColumnName("Store_7");
            entity.Property(e => e.Store8).HasColumnName("Store_8");
        });

        modelBuilder.Entity<مسطرد>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("'مسطرد$'");

            entity.Property(e => e.Code).HasMaxLength(255);
            entity.Property(e => e.InventoryItemFk).HasColumnName("InventoryItemFK");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Unit).HasMaxLength(255);
        });
        modelBuilder.HasSequence("AssetItem_ID");
        modelBuilder.HasSequence("InventoryItem_ID");
        modelBuilder.HasSequence("Sequence_Customer").StartsAt(0L);
        modelBuilder.HasSequence("Sequence_InventroyItemRequestWithdraw").StartsAt(10972L);
        modelBuilder.HasSequence("Sequence_PurchaseOrder").StartsAt(1331L);
        modelBuilder.HasSequence("Sequence_PurchaseRequest").StartsAt(199L);
        modelBuilder.HasSequence("Sequence_RequestForQuotation");
        modelBuilder.HasSequence("Sequence_SalesQuotation").StartsAt(0L);
        modelBuilder.HasSequence("Sequence_VendorOrder");
        modelBuilder.HasSequence("Sequence_VendorOrderQuality").StartsAt(103L);
        modelBuilder.HasSequence("Sequence_VendorOrderReceive").StartsAt(103L);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
