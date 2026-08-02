using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryItemLocationBatch
{
    public long Id { get; set; }

    public long? InventoryItemLocationFk { get; set; }

    public string? BatchNumber { get; set; }

    public long? ShelfFk { get; set; }

    public decimal? TotalQuantity { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public long? InventoryItemFk { get; set; }

    public DateTime? ProductionDate { get; set; }

    public virtual ICollection<InventoryItemLocationBatchSerial> InventoryItemLocationBatchSerials { get; set; } = new List<InventoryItemLocationBatchSerial>();

    public virtual InventoryItemLocation? InventoryItemLocationFkNavigation { get; set; }

    public virtual ICollection<InventoryStockCountDetailBatch> InventoryStockCountDetailBatches { get; set; } = new List<InventoryStockCountDetailBatch>();

    public virtual ICollection<InventoryTransfereDetailBatch> InventoryTransfereDetailBatches { get; set; } = new List<InventoryTransfereDetailBatch>();

    public virtual ICollection<RwDeliveredBatch> RwDeliveredBatches { get; set; } = new List<RwDeliveredBatch>();

    public virtual Shelf? ShelfFkNavigation { get; set; }
}
