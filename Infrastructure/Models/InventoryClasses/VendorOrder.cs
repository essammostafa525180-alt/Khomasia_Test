using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class VendorOrder
{
    public long Id { get; set; }

    public string? OrderNo { get; set; }

    public long? OrderByUserFk { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public long? VendorFk { get; set; }

    public long? StoreFk { get; set; }

    public long? VendorOrderTypeFk { get; set; }

    public long? VendorOrderStatusFk { get; set; }

    public bool? IsApproved { get; set; }

    public string? NotesEn { get; set; }

    public string? NotesAr { get; set; }

    public DateTime? ExpectedDeliveryDate { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public bool? Axsynced { get; set; }

    public bool? InventoryApproved { get; set; }

    public string? Axpono { get; set; }

    public long? OrderScreenFk { get; set; }

    public long? Prfk { get; set; }

    public long? Rfqfk { get; set; }

    public string? WorkOrderNo { get; set; }

    public string? PaymentTerms { get; set; }

    public long? ProjectFk { get; set; }

    public long? ScopeFk { get; set; }

    public long? CompanyFk { get; set; }

    public long? ServiceMainCategoryFk { get; set; }

    public long? InventroyItemRequestWithdrawFk { get; set; }

    public long? ItemTypeFk { get; set; }

    public DateOnly? ExpireDate { get; set; }

    public long? LocationFk { get; set; }

    public long? PaymentTermFk { get; set; }

    public bool IsBlocked { get; set; }

    public long? InventoryItemBudgetFk { get; set; }

    public long? AssignedToUserFk { get; set; }

    public decimal? TotalCost { get; set; }

    public string? SourceEntity { get; set; }

    public long? SourceId { get; set; }

    public long? VehicleFk { get; set; }

    public long? FactoryFk { get; set; }

    public long? FactoryLineFk { get; set; }

    public bool? IsVat { get; set; }

    public bool? IsGta { get; set; }

    public virtual ICollection<ApprovalMatrix> ApprovalMatrices { get; set; } = new List<ApprovalMatrix>();

    public virtual User? AssignedToUserFkNavigation { get; set; }

    public virtual Company? CompanyFkNavigation { get; set; }

    public virtual User? CreatedByNavigation { get; set; }

    public virtual InventroyItemRequestWithdraw? InventroyItemRequestWithdrawFkNavigation { get; set; }

    public virtual ICollection<VendorOrder> InversePrfkNavigation { get; set; } = new List<VendorOrder>();

    public virtual ICollection<VendorOrder> InverseRfqfkNavigation { get; set; } = new List<VendorOrder>();

    public virtual ItemType? ItemTypeFkNavigation { get; set; }

    public virtual User? LastUpdatedByNavigation { get; set; }

    public virtual Location? LocationFkNavigation { get; set; }

    public virtual User? OrderByUserFkNavigation { get; set; }

    public virtual VendorOrderScreen? OrderScreenFkNavigation { get; set; }

    public virtual PaymentTerm? PaymentTermFkNavigation { get; set; }

    public virtual VendorOrder? PrfkNavigation { get; set; }

    public virtual Project? ProjectFkNavigation { get; set; }

    public virtual VendorOrder? RfqfkNavigation { get; set; }

    public virtual ICollection<SalesQuotation> SalesQuotations { get; set; } = new List<SalesQuotation>();

    public virtual Scope? ScopeFkNavigation { get; set; }

    public virtual ServiceMainCategory? ServiceMainCategoryFkNavigation { get; set; }

    public virtual Store? StoreFkNavigation { get; set; }

    public virtual Vehicle? VehicleFkNavigation { get; set; }

    public virtual Vendor? VendorFkNavigation { get; set; }

    public virtual ICollection<VendorOrderAttachment> VendorOrderAttachments { get; set; } = new List<VendorOrderAttachment>();

    public virtual ICollection<VendorOrderDetail> VendorOrderDetails { get; set; } = new List<VendorOrderDetail>();

    public virtual ICollection<VendorOrderQuality> VendorOrderQualities { get; set; } = new List<VendorOrderQuality>();

    public virtual ICollection<VendorOrderReceive> VendorOrderReceives { get; set; } = new List<VendorOrderReceive>();

    public virtual VendorOrderStatus? VendorOrderStatusFkNavigation { get; set; }

    public virtual VendorOrderType? VendorOrderTypeFkNavigation { get; set; }

    public virtual ICollection<VendorOrderVendorSelection> VendorOrderVendorSelections { get; set; } = new List<VendorOrderVendorSelection>();

    public virtual ICollection<VendorOrderVendorSuggested> VendorOrderVendorSuggesteds { get; set; } = new List<VendorOrderVendorSuggested>();
}
