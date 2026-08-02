using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class RwDeliveredSerial
{
    public long Id { get; set; }

    public long? RwDeliveredBatchFk { get; set; }

    public long? SerialFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public bool? Axsynced { get; set; }

    public virtual ICollection<InventoryItemReturnBatchSerial> InventoryItemReturnBatchSerials { get; set; } = new List<InventoryItemReturnBatchSerial>();

    public virtual RwDeliveredBatch? RwDeliveredBatchFkNavigation { get; set; }

    public virtual InventoryItemLocationBatchSerial? SerialFkNavigation { get; set; }
}
