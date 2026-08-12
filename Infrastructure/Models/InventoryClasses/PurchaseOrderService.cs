using Domain.Aggregates.LocationAggregate;
using Domain.Aggregates.VendorAggregate;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class PurchaseOrderService
{
    public long Id { get; set; }

    public long? OrderScreenFk { get; set; }

    public long? PoserviceTypeFk { get; set; }

    public long? VendorOrderTypeFk { get; set; }

    public long? VendorFk { get; set; }

    public long? Prfk { get; set; }

    public string? OrderNo { get; set; }

    public DateTime? RequestDate { get; set; }

    public DateTime? OrderDate { get; set; }

    public long? OrderByUserFk { get; set; }

    public long? ProjectFk { get; set; }

    public long? LocationFk { get; set; }

    public long? ServiceMainCategoryFk { get; set; }

    public long? ScopeFk { get; set; }

    public long? VendorOrderStatusFk { get; set; }

    public long? PaymentTermFk { get; set; }

    public string? PaymentTerms { get; set; }

    public bool? IsApproved { get; set; }

    public int? Duration { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public long? CompanyFk { get; set; }

    public long? ContractId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? ContractCode { get; set; }

    public decimal? TotalCost { get; set; }

    public string? Description { get; set; }

    public long? InventoryItemBudgetFk { get; set; }

    public virtual ICollection<ApprovalMatrix> ApprovalMatrices { get; set; } = new List<ApprovalMatrix>();

    public virtual Company? CompanyFkNavigation { get; set; }

    public virtual ICollection<PurchaseOrderService> InversePrfkNavigation { get; set; } = new List<PurchaseOrderService>();

    public virtual Location? LocationFkNavigation { get; set; }

    public virtual VendorOrderScreen? OrderScreenFkNavigation { get; set; }

    public virtual PaymentTerm? PaymentTermFkNavigation { get; set; }

    public virtual ICollection<PoserviceAsset> PoserviceAssets { get; set; } = new List<PoserviceAsset>();

    public virtual ICollection<PoserviceDetail> PoserviceDetails { get; set; } = new List<PoserviceDetail>();

    public virtual ICollection<PoserviceOutsource> PoserviceOutsources { get; set; } = new List<PoserviceOutsource>();

    public virtual ICollection<PoserviceRecomendedResource> PoserviceRecomendedResources { get; set; } = new List<PoserviceRecomendedResource>();

    public virtual PoserviceType? PoserviceTypeFkNavigation { get; set; }

    public virtual PurchaseOrderService? PrfkNavigation { get; set; }

    public virtual Project? ProjectFkNavigation { get; set; }

    public virtual ICollection<PurchaseOrderServiceAttachment> PurchaseOrderServiceAttachments { get; set; } = new List<PurchaseOrderServiceAttachment>();

    public virtual Scope? ScopeFkNavigation { get; set; }

    public virtual ServiceMainCategory? ServiceMainCategoryFkNavigation { get; set; }

    public virtual Vendor? VendorFkNavigation { get; set; }

    public virtual VendorOrderStatus? VendorOrderStatusFkNavigation { get; set; }

    public virtual VendorOrderType? VendorOrderTypeFkNavigation { get; set; }
}
