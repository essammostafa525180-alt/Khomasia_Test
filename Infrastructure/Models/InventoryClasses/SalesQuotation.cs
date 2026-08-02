using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class SalesQuotation
{
    public long Id { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public long? CompanyFk { get; set; }

    public long? RequestForQuotationFk { get; set; }

    public string? OrderNo { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateOnly? ExpectedDeliveryDate { get; set; }

    public long? CustomerFk { get; set; }

    public string? Notes { get; set; }

    public decimal? TotalRatio { get; set; }

    public decimal? TotalCost { get; set; }

    public virtual Customer? CustomerFkNavigation { get; set; }

    public virtual VendorOrder? RequestForQuotationFkNavigation { get; set; }

    public virtual ICollection<SalesQuotationDetail> SalesQuotationDetails { get; set; } = new List<SalesQuotationDetail>();
}
