using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class VendorOrderDetail
{
    public long Id { get; set; }

    public long? VendorOrderFk { get; set; }

    public long? InventoryItemFk { get; set; }

    public decimal? Prquantity { get; set; }

    public decimal? Rfqquantity { get; set; }

    public decimal? OrderedQuantity { get; set; }

    public long? OrderLineItemStatusFk { get; set; }

    public decimal? CostPrice { get; set; }

    public decimal? TotalQuotationPrice { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public decimal? LastPurchasePrice { get; set; }

    public decimal? AvgCost { get; set; }

    public decimal? QuantityOnHand { get; set; }

    public decimal? SupplierPercentage { get; set; }

    public long? PrdetailFk { get; set; }

    public virtual InventoryItem? InventoryItemFkNavigation { get; set; }

    public virtual ICollection<VendorOrderDetail> InversePrdetailFkNavigation { get; set; } = new List<VendorOrderDetail>();

    public virtual OrderLineItemStatus? OrderLineItemStatusFkNavigation { get; set; }

    public virtual VendorOrderDetail? PrdetailFkNavigation { get; set; }

    public virtual ICollection<SalesQuotationDetail> SalesQuotationDetails { get; set; } = new List<SalesQuotationDetail>();

    public virtual VendorOrder? VendorOrderFkNavigation { get; set; }

    public virtual ICollection<VendorOrderPartiallyReceivedNote> VendorOrderPartiallyReceivedNotes { get; set; } = new List<VendorOrderPartiallyReceivedNote>();

    public virtual ICollection<VendorOrderQualityDetail> VendorOrderQualityDetails { get; set; } = new List<VendorOrderQualityDetail>();
}
