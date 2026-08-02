using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryStockCount
{
    public long Id { get; set; }

    public string? StockCountNo { get; set; }

    public long? StoreFk { get; set; }

    public DateTime? StockCountDate { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public bool? Axsynced { get; set; }

    public long? InventoryStockCountStatusFk { get; set; }

    public virtual ICollection<InventoryStockCountDetail> InventoryStockCountDetails { get; set; } = new List<InventoryStockCountDetail>();

    public virtual InventoryStockCountStatus? InventoryStockCountStatusFkNavigation { get; set; }

    public virtual Store? StoreFkNavigation { get; set; }
}
