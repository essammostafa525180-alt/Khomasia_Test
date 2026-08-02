using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class VendorOrderVendorSelection
{
    public long Id { get; set; }

    public long? VendorOrderFk { get; set; }

    public long? VendorFk { get; set; }

    public bool IsSelected { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public virtual Vendor? VendorFkNavigation { get; set; }

    public virtual VendorOrder? VendorOrderFkNavigation { get; set; }
}
