using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryStockCountDetailBatch
{
    public long Id { get; set; }

    public long? InventoryStockCountDetailFk { get; set; }

    public long? BatchFk { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? CountQuantity { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual InventoryItemLocationBatch? BatchFkNavigation { get; set; }

    public virtual ICollection<InventoryStockCountDetailBatchSerial> InventoryStockCountDetailBatchSerials { get; set; } = new List<InventoryStockCountDetailBatchSerial>();

    public virtual InventoryStockCountDetail? InventoryStockCountDetailFkNavigation { get; set; }
}
