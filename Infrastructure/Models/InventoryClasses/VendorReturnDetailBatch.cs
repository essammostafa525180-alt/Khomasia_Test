using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class VendorReturnDetailBatch
{
    public long Id { get; set; }

    public long? VendorReturnDetailFk { get; set; }

    public decimal? Quantity { get; set; }

    public long? ReturnReasonFk { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public long? BatchFk { get; set; }

    public long? VendorOrderReceiveDetailBatchFk { get; set; }

    public virtual ReturnReason? ReturnReasonFkNavigation { get; set; }

    public virtual ICollection<VendorReturnDetailBatchSerial> VendorReturnDetailBatchSerials { get; set; } = new List<VendorReturnDetailBatchSerial>();
}
