using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryStockCountDetail
{
    public long Id { get; set; }

    public long? InventoryStockCountFk { get; set; }

    public long? InventoryItemFk { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? CountQuantity { get; set; }

    public string? IncDecReason { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual InventoryItem? InventoryItemFkNavigation { get; set; }

    public virtual ICollection<InventoryStockCountDetailBatch> InventoryStockCountDetailBatches { get; set; } = new List<InventoryStockCountDetailBatch>();

    public virtual InventoryStockCount? InventoryStockCountFkNavigation { get; set; }
}
