using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryItemReturnBatchSerial
{
    public long Id { get; set; }

    public long? InventoryItemReturnBatchFk { get; set; }

    public long? ReturnReasonFk { get; set; }

    public long? RwDelivedSerialFk { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual InventoryItemReturnBatch? InventoryItemReturnBatchFkNavigation { get; set; }

    public virtual ReturnReason? ReturnReasonFkNavigation { get; set; }

    public virtual RwDeliveredSerial? RwDelivedSerialFkNavigation { get; set; }
}
