using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class VendorOrderQuality
{
    public long Id { get; set; }

    public string? OrderNo { get; set; }

    public DateTime? OrderDate { get; set; }

    public long? ReceivedByUserFk { get; set; }

    public long? VendorOrderFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public bool? IsLandedCostApproved { get; set; }

    public virtual VendorOrder? VendorOrderFkNavigation { get; set; }

    public virtual ICollection<VendorOrderQualityAttachment> VendorOrderQualityAttachments { get; set; } = new List<VendorOrderQualityAttachment>();

    public virtual ICollection<VendorOrderQualityDetail> VendorOrderQualityDetails { get; set; } = new List<VendorOrderQualityDetail>();

    public virtual ICollection<VendorOrderReceive> VendorOrderReceives { get; set; } = new List<VendorOrderReceive>();
}
