using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryItemReturnBatch
{
    public long Id { get; set; }

    public long? ItemReturnDetailFk { get; set; }

    public decimal? ReturnedQuantity { get; set; }

    public long? ReturnReasonFk { get; set; }

    public long? RwDeliveredBatchFk { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public long? BatchFk { get; set; }

    public virtual ICollection<InventoryItemReturnBatchSerial> InventoryItemReturnBatchSerials { get; set; } = new List<InventoryItemReturnBatchSerial>();

    public virtual InventoryItemReturnDetail? ItemReturnDetailFkNavigation { get; set; }

    public virtual ReturnReason? ReturnReasonFkNavigation { get; set; }

    public virtual RwDeliveredBatch? RwDeliveredBatchFkNavigation { get; set; }
}
