using Domain.Aggregates.LocationAggregate;
using Domain.Aggregates.StoreAggregate;
using Domain.Aggregates.VendorOrderAggregate;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventroyItemRequestWithdraw
{
    public long Id { get; set; }

    public long? ItemTypeFk { get; set; }

    public string? RequestNo { get; set; }

    public DateTime? RequestDate { get; set; }

    public string? DescriptionEn { get; set; }

    public string? DescriptionAr { get; set; }

    public bool? IsApproved { get; set; }

    public long? RequestedByFk { get; set; }

    public string? RequestedBy { get; set; }

    public long? AssignedToUserFk { get; set; }

    public long? ItemRequestStatusFk { get; set; }

    public string? WorkOrderNo { get; set; }

    public long? StoreFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public int? SentCount { get; set; }

    public bool? Axsynced { get; set; }

    public long? ProjectFk { get; set; }

    public long? Oufk { get; set; }

    public DateTime? ItemNeededDate { get; set; }

    public long? ScopeFk { get; set; }

    public long? CompanyFk { get; set; }

    public long? ServiceMainCategoryFk { get; set; }

    public bool? SiteManagerApproval { get; set; }

    public long? SiteManagerApprovalUserId { get; set; }

    public DateTime? SiteManagerApprovalDateTime { get; set; }

    public long? WarehouseManagerApprovalUserId { get; set; }

    public DateTime? WarehouseManagerApprovalDateTime { get; set; }

    public long? LocationFk { get; set; }

    public long? InventoryItemBudgetFk { get; set; }

    public long? SourceTypeId { get; set; }

    public long? EntityId { get; set; }

    public string? EntityFormula { get; set; }

    public long? ReceivedFk { get; set; }

    public long? VehicleFk { get; set; }

    public long? LineFk { get; set; }

    public string? SourceEntity { get; set; }

    public long? SourceId { get; set; }

    public long? SectorFk { get; set; }

    public long? CostCenterFk { get; set; }

    public long? CustomerFk { get; set; }

    public long? FactoryFk { get; set; }

    public long? FactoryLineFk { get; set; }

    public virtual ICollection<ApprovalMatrix> ApprovalMatrices { get; set; } = new List<ApprovalMatrix>();

    public virtual User? AssignedToUserFkNavigation { get; set; }

    public virtual Company? CompanyFkNavigation { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual ICollection<InventoryItemReturn> InventoryItemReturns { get; set; } = new List<InventoryItemReturn>();

    public virtual ICollection<InventroyItemRequestWithdrawAttachment> InventroyItemRequestWithdrawAttachments { get; set; } = new List<InventroyItemRequestWithdrawAttachment>();

    public virtual ICollection<InventroyItemRequestWithdrawDetail> InventroyItemRequestWithdrawDetails { get; set; } = new List<InventroyItemRequestWithdrawDetail>();

    public virtual ItemRequestStatus? ItemRequestStatusFkNavigation { get; set; }

    public virtual ItemType? ItemTypeFkNavigation { get; set; }

    public virtual User? LastUpdatedByNavigation { get; set; }

    public virtual Line? LineFkNavigation { get; set; }

    public virtual Location? LocationFkNavigation { get; set; }

    public virtual Ou? OufkNavigation { get; set; }

    public virtual Project? ProjectFkNavigation { get; set; }

    public virtual Employee? ReceivedFkNavigation { get; set; }

    public virtual ICollection<RequestWithdrawSerial> RequestWithdrawSerials { get; set; } = new List<RequestWithdrawSerial>();

    public virtual User? RequestedByFkNavigation { get; set; }

    public virtual Scope? ScopeFkNavigation { get; set; }

    public virtual ServiceMainCategory? ServiceMainCategoryFkNavigation { get; set; }

    public virtual Store? StoreFkNavigation { get; set; }

    public virtual Vehicle? VehicleFkNavigation { get; set; }

    public virtual ICollection<VendorOrder> VendorOrders { get; set; } = new List<VendorOrder>();
}
