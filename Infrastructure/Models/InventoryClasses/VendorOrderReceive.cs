using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class VendorOrderReceive
{
    public long Id { get; set; }

    public string? ReceivingNo { get; set; }

    public long? ReceivedByUserFk { get; set; }

    public DateTime? ReceivingDate { get; set; }

    public long? VendorOrderFk { get; set; }

    public long? VendorOrderQualityFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public bool? Axsynced { get; set; }

    public bool? IsEmailSent { get; set; }

    public decimal? LastPurchasePrice { get; set; }

    public decimal? AvgCost { get; set; }

    public virtual VendorOrder? VendorOrderFkNavigation { get; set; }

    public virtual VendorOrderQuality? VendorOrderQualityFkNavigation { get; set; }

    public virtual ICollection<VendorOrderReceiveAttachment> VendorOrderReceiveAttachments { get; set; } = new List<VendorOrderReceiveAttachment>();

    public virtual ICollection<VendorOrderReceiveDetail> VendorOrderReceiveDetails { get; set; } = new List<VendorOrderReceiveDetail>();

    public virtual ICollection<VendorOrderReceiveSerial> VendorOrderReceiveSerials { get; set; } = new List<VendorOrderReceiveSerial>();

    public virtual ICollection<VendorReturn> VendorReturns { get; set; } = new List<VendorReturn>();
}
