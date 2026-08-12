using Domain.Aggregates.InventoryItemAggregate;
using Domain.Aggregates.VendorReturnAggregate;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class VendorReturnDetail
{
    public long Id { get; set; }

    public long? VendorReturnFk { get; set; }

    public long? InventoryItemFk { get; set; }

    public decimal? Quantity { get; set; }

    public long? ReturnReasonFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual InventoryItem? InventoryItemFkNavigation { get; set; }

    public virtual ReturnReason? ReturnReasonFkNavigation { get; set; }

    public virtual VendorReturn? VendorReturnFkNavigation { get; set; }

    public virtual ICollection<VendorReturnSerial> VendorReturnSerials { get; set; } = new List<VendorReturnSerial>();
}
