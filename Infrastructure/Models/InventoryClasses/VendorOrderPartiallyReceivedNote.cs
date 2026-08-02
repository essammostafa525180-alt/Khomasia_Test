using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class VendorOrderPartiallyReceivedNote
{
    public long Id { get; set; }

    public long? VendorOrderDetailFk { get; set; }

    public long? PartiallyReceivedReasonFk { get; set; }

    public decimal? CurrentReceivedQuantity { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public virtual VendorOrderDetail? VendorOrderDetailFkNavigation { get; set; }
}
