using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryItemLocationBatchSerial
{
    public long Id { get; set; }

    public long? InventoryItemLocationBatchFk { get; set; }

    public string? SerialNumber { get; set; }

    public bool? IsAvailable { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual InventoryItemLocationBatch? InventoryItemLocationBatchFkNavigation { get; set; }

    public virtual ICollection<InventoryStockCountDetailBatchSerial> InventoryStockCountDetailBatchSerials { get; set; } = new List<InventoryStockCountDetailBatchSerial>();

    public virtual ICollection<InventoryTransfereDetailBatchSerial> InventoryTransfereDetailBatchSerials { get; set; } = new List<InventoryTransfereDetailBatchSerial>();

    public virtual ICollection<RwDeliveredSerial> RwDeliveredSerials { get; set; } = new List<RwDeliveredSerial>();
}
