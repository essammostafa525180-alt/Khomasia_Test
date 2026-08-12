using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class VendorOrderReceiveDetailBatchSerial
{
    public long Id { get; set; }

    public long? VendorOrderReceiveDetailBatchFk { get; set; }

    public string? SerialNumber { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual VendorOrderReceiveDetailBatch? VendorOrderReceiveDetailBatchFkNavigation { get; set; }

    public virtual ICollection<VendorReturnDetailBatchSerial> VendorReturnDetailBatchSerials { get; set; } = new List<VendorReturnDetailBatchSerial>();
}
