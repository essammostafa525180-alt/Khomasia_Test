using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class SalesQuotationDetail
{
    public long Id { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public long? SalesQuotationFk { get; set; }

    public long? RequestForQuotationDetailFk { get; set; }

    public long? InventoryItemFk { get; set; }

    public decimal? VendorCostPrice { get; set; }

    public decimal? CostPriceRatio { get; set; }

    public decimal? CostPrice { get; set; }

    public decimal? OrderedQuantity { get; set; }

    public decimal? TotalPrice { get; set; }

    public virtual InventoryItem? InventoryItemFkNavigation { get; set; }

    public virtual VendorOrderDetail? RequestForQuotationDetailFkNavigation { get; set; }

    public virtual SalesQuotation? SalesQuotationFkNavigation { get; set; }
}
