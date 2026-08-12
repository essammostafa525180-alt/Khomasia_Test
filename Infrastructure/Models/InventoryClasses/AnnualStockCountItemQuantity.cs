using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class AnnualStockCountItemQuantity
{
    public long Id { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public long? AnnualStockCountFk { get; set; }

    public long? InventoryItemFk { get; set; }

    public string? NewName { get; set; }

    public decimal? CurrentQuantity { get; set; }

    public decimal? StockQuantity { get; set; }

    public Guid? RefId { get; set; }
}
