using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class AssignVendorSpecialization
{
    public long Id { get; set; }

    public long? VendorFk { get; set; }

    public long? VendorSpecializationFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Vendor? VendorFkNavigation { get; set; }

    public virtual VendorSpecialization? VendorSpecializationFkNavigation { get; set; }
}
