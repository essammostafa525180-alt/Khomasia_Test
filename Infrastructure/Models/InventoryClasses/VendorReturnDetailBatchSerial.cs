using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class VendorReturnDetailBatchSerial
{
    public long Id { get; set; }

    public long? VendorReturnDetailBatchFk { get; set; }

    public long? SerialFk { get; set; }

    public long? ReturnReasonFk { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ReturnReason? ReturnReasonFkNavigation { get; set; }

    public virtual VendorOrderReceiveDetailBatchSerial? SerialFkNavigation { get; set; }

    public virtual VendorReturnDetailBatch? VendorReturnDetailBatchFkNavigation { get; set; }
}
