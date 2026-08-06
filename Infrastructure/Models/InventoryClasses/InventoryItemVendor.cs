using Domain.Aggregates.InventoryItemAggregate;
using Domain.Aggregates.VendorAggregate;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryItemVendor
{
    public long Id { get; set; }

    public long? InventoryItemFk { get; set; }

    public long? VendorFk { get; set; }

    public int? VendorOrder { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual InventoryItem? InventoryItemFkNavigation { get; set; }

    public virtual Vendor? VendorFkNavigation { get; set; }
}
