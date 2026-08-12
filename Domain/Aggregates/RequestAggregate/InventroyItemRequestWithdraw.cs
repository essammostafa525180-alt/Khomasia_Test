using Domain.Aggregates.CompanyAggregate;
using Domain.Aggregates.InventoryItemAggregate;
using Domain.Aggregates.LocationAggregate;
using Domain.Aggregates.StoreAggregate;
using Domain.Aggregates.UserAggregate;
using Domain.Aggregates.VehicleAggregate;
using Domain.Aggregates.VendorOrderAggregate;
using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.RequestAggregate
{
    public class InventroyItemRequestWithdraw : AggregateRootEntityBase<int>
    {
        public int? ItemTypeFk { get; set; }
        public string? RequestNo { get; set; }
        public DateTime? RequestDate { get; set; }
        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }
        public bool? IsApproved { get; set; }
        public int? RequestedByFk { get; set; }
        public string? RequestedBy { get; set; }
        public int? AssignedToUserFk { get; set; }
        public int? ItemRequestStatusFk { get; set; }
        public string? WorkOrderNo { get; set; }
        public int? StoreFk { get; set; }
        public int? SentCount { get; set; }
        public bool? Axsynced { get; set; }
        public int? ProjectFk { get; set; }
        public int? Oufk { get; set; }
        public DateTime? ItemNeededDate { get; set; }
        public int? ScopeFk { get; set; }
        public int? CompanyFk { get; set; }
        public int? ServiceMainCategoryFk { get; set; }
        public bool? SiteManagerApproval { get; set; }
        public int? SiteManagerApprovalUserId { get; set; }
        public DateTime? SiteManagerApprovalDateTime { get; set; }
        public int? WarehouseManagerApprovalUserId { get; set; }
        public DateTime? WarehouseManagerApprovalDateTime { get; set; }
        public int? LocationFk { get; set; }
        public int? InventoryItemBudgetFk { get; set; }
        public int? SourceTypeId { get; set; }
        public int? EntityId { get; set; }
        public string? EntityFormula { get; set; }
        public int? ReceivedFk { get; set; }
        public int? VehicleFk { get; set; }
        public int? LineFk { get; set; }
        public string? SourceEntity { get; set; }
        public int? SourceId { get; set; }
        public int? SectorFk { get; set; }
        public int? CostCenterFk { get; set; }
        public int? CustomerFk { get; set; }
        public int? FactoryFk { get; set; }
        public int? FactoryLineFk { get; set; }
        public User? AssignedToUserFkNavigation { get; set; }
        public Company? CompanyFkNavigation { get; set; }
        public User? CreatedByNavigation { get; set; }
        public ItemRequestStatus? ItemRequestStatusFkNavigation { get; set; }
        public ItemType? ItemTypeFkNavigation { get; set; }
        public User? LastUpdatedByNavigation { get; set; }
        public Line? LineFkNavigation { get; set; }
        public Location? LocationFkNavigation { get; set; }
        public Ou? OufkNavigation { get; set; }
        public Project? ProjectFkNavigation { get; set; }
        public Employee? ReceivedFkNavigation { get; set; }
        public User? RequestedByFkNavigation { get; set; }
        public Scope? ScopeFkNavigation { get; set; }
        public ServiceMainCategory? ServiceMainCategoryFkNavigation { get; set; }
        public Store? StoreFkNavigation { get; set; }
        public Vehicle? VehicleFkNavigation { get; set; }

        private List<ApprovalMatrix> _approvalMatrices = new List<ApprovalMatrix>();
        public IReadOnlyCollection<ApprovalMatrix> ApprovalMatrices => _approvalMatrices;

        private List<InventoryItemReturn> _inventoryItemReturns = new List<InventoryItemReturn>();
        public IReadOnlyCollection<InventoryItemReturn> InventoryItemReturns => _inventoryItemReturns;

        private List<InventroyItemRequestWithdrawAttachment> _inventroyItemRequestWithdrawAttachments = new List<InventroyItemRequestWithdrawAttachment>();
        public IReadOnlyCollection<InventroyItemRequestWithdrawAttachment> InventroyItemRequestWithdrawAttachments => _inventroyItemRequestWithdrawAttachments;

        private List<InventroyItemRequestWithdrawDetail> _inventroyItemRequestWithdrawDetails = new List<InventroyItemRequestWithdrawDetail>();
        public IReadOnlyCollection<InventroyItemRequestWithdrawDetail> InventroyItemRequestWithdrawDetails => _inventroyItemRequestWithdrawDetails;

        private List<RequestWithdrawSerial> _requestWithdrawSerials = new List<RequestWithdrawSerial>();
        public IReadOnlyCollection<RequestWithdrawSerial> RequestWithdrawSerials => _requestWithdrawSerials;

        private List<VendorOrder> _vendorOrders = new List<VendorOrder>();
        public IReadOnlyCollection<VendorOrder> VendorOrders => _vendorOrders;

        public InventroyItemRequestWithdraw()
        {
        }

        public InventroyItemRequestWithdraw(int? itemTypeFk, string? requestNo, DateTime? requestDate, string? descriptionEn, string? descriptionAr, bool? isApproved, int? requestedByFk, string? requestedBy, int? assignedToUserFk, int? itemRequestStatusFk, string? workOrderNo, int? storeFk, int? sentCount, bool? axsynced, int? projectFk, int? oufk, DateTime? itemNeededDate, int? scopeFk, int? companyFk, int? serviceMainCategoryFk, bool? siteManagerApproval, int? siteManagerApprovalUserId, DateTime? siteManagerApprovalDateTime, int? warehouseManagerApprovalUserId, DateTime? warehouseManagerApprovalDateTime, int? locationFk, int? inventoryItemBudgetFk, int? sourceTypeId, int? entityId, string? entityFormula, int? receivedFk, int? vehicleFk, int? lineFk, string? sourceEntity, int? sourceId, int? sectorFk, int? costCenterFk, int? customerFk, int? factoryFk, int? factoryLineFk, bool isActive) : this()
        {
            ItemTypeFk = itemTypeFk;
            RequestNo = requestNo;
            RequestDate = requestDate;
            DescriptionEn = descriptionEn;
            DescriptionAr = descriptionAr;
            IsApproved = isApproved;
            RequestedByFk = requestedByFk;
            RequestedBy = requestedBy;
            AssignedToUserFk = assignedToUserFk;
            ItemRequestStatusFk = itemRequestStatusFk;
            WorkOrderNo = workOrderNo;
            StoreFk = storeFk;
            SentCount = sentCount;
            Axsynced = axsynced;
            ProjectFk = projectFk;
            Oufk = oufk;
            ItemNeededDate = itemNeededDate;
            ScopeFk = scopeFk;
            CompanyFk = companyFk;
            ServiceMainCategoryFk = serviceMainCategoryFk;
            SiteManagerApproval = siteManagerApproval;
            SiteManagerApprovalUserId = siteManagerApprovalUserId;
            SiteManagerApprovalDateTime = siteManagerApprovalDateTime;
            WarehouseManagerApprovalUserId = warehouseManagerApprovalUserId;
            WarehouseManagerApprovalDateTime = warehouseManagerApprovalDateTime;
            LocationFk = locationFk;
            InventoryItemBudgetFk = inventoryItemBudgetFk;
            SourceTypeId = sourceTypeId;
            EntityId = entityId;
            EntityFormula = entityFormula;
            ReceivedFk = receivedFk;
            VehicleFk = vehicleFk;
            LineFk = lineFk;
            SourceEntity = sourceEntity;
            SourceId = sourceId;
            SectorFk = sectorFk;
            CostCenterFk = costCenterFk;
            CustomerFk = customerFk;
            FactoryFk = factoryFk;
            FactoryLineFk = factoryLineFk;
            IsActive = isActive;
        }

        public static InventroyItemRequestWithdraw Create(int? itemTypeFk, string? requestNo, DateTime? requestDate, string? descriptionEn, string? descriptionAr, bool? isApproved, int? requestedByFk, string? requestedBy, int? assignedToUserFk, int? itemRequestStatusFk, string? workOrderNo, int? storeFk, int? sentCount, bool? axsynced, int? projectFk, int? oufk, DateTime? itemNeededDate, int? scopeFk, int? companyFk, int? serviceMainCategoryFk, bool? siteManagerApproval, int? siteManagerApprovalUserId, DateTime? siteManagerApprovalDateTime, int? warehouseManagerApprovalUserId, DateTime? warehouseManagerApprovalDateTime, int? locationFk, int? inventoryItemBudgetFk, int? sourceTypeId, int? entityId, string? entityFormula, int? receivedFk, int? vehicleFk, int? lineFk, string? sourceEntity, int? sourceId, int? sectorFk, int? costCenterFk, int? customerFk, int? factoryFk, int? factoryLineFk, bool isActive)
        {

            return new InventroyItemRequestWithdraw(itemTypeFk, requestNo, requestDate, descriptionEn, descriptionAr, isApproved, requestedByFk, requestedBy, assignedToUserFk, itemRequestStatusFk, workOrderNo, storeFk, sentCount, axsynced, projectFk, oufk, itemNeededDate, scopeFk, companyFk, serviceMainCategoryFk, siteManagerApproval, siteManagerApprovalUserId, siteManagerApprovalDateTime, warehouseManagerApprovalUserId, warehouseManagerApprovalDateTime, locationFk, inventoryItemBudgetFk, sourceTypeId, entityId, entityFormula, receivedFk, vehicleFk, lineFk, sourceEntity, sourceId, sectorFk, costCenterFk, customerFk, factoryFk, factoryLineFk, isActive);
        }

        public void Update(int? itemTypeFk, string? requestNo, DateTime? requestDate, string? descriptionEn, string? descriptionAr, bool? isApproved, int? requestedByFk, string? requestedBy, int? assignedToUserFk, int? itemRequestStatusFk, string? workOrderNo, int? storeFk, int? sentCount, bool? axsynced, int? projectFk, int? oufk, DateTime? itemNeededDate, int? scopeFk, int? companyFk, int? serviceMainCategoryFk, bool? siteManagerApproval, int? siteManagerApprovalUserId, DateTime? siteManagerApprovalDateTime, int? warehouseManagerApprovalUserId, DateTime? warehouseManagerApprovalDateTime, int? locationFk, int? inventoryItemBudgetFk, int? sourceTypeId, int? entityId, string? entityFormula, int? receivedFk, int? vehicleFk, int? lineFk, string? sourceEntity, int? sourceId, int? sectorFk, int? costCenterFk, int? customerFk, int? factoryFk, int? factoryLineFk, bool isActive)
        {
            ItemTypeFk = itemTypeFk;
            RequestNo = requestNo;
            RequestDate = requestDate;
            DescriptionEn = descriptionEn;
            DescriptionAr = descriptionAr;
            IsApproved = isApproved;
            RequestedByFk = requestedByFk;
            RequestedBy = requestedBy;
            AssignedToUserFk = assignedToUserFk;
            ItemRequestStatusFk = itemRequestStatusFk;
            WorkOrderNo = workOrderNo;
            StoreFk = storeFk;
            SentCount = sentCount;
            Axsynced = axsynced;
            ProjectFk = projectFk;
            Oufk = oufk;
            ItemNeededDate = itemNeededDate;
            ScopeFk = scopeFk;
            CompanyFk = companyFk;
            ServiceMainCategoryFk = serviceMainCategoryFk;
            SiteManagerApproval = siteManagerApproval;
            SiteManagerApprovalUserId = siteManagerApprovalUserId;
            SiteManagerApprovalDateTime = siteManagerApprovalDateTime;
            WarehouseManagerApprovalUserId = warehouseManagerApprovalUserId;
            WarehouseManagerApprovalDateTime = warehouseManagerApprovalDateTime;
            LocationFk = locationFk;
            InventoryItemBudgetFk = inventoryItemBudgetFk;
            SourceTypeId = sourceTypeId;
            EntityId = entityId;
            EntityFormula = entityFormula;
            ReceivedFk = receivedFk;
            VehicleFk = vehicleFk;
            LineFk = lineFk;
            SourceEntity = sourceEntity;
            SourceId = sourceId;
            SectorFk = sectorFk;
            CostCenterFk = costCenterFk;
            CustomerFk = customerFk;
            FactoryFk = factoryFk;
            FactoryLineFk = factoryLineFk;
            IsActive = isActive;
        }
    }
}
