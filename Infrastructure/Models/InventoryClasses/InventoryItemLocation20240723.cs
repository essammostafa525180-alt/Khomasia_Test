using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryItemLocation20240723
{
    public long Id { get; set; }

    public long? InventoryItemFk { get; set; }

    public long? StoreFk { get; set; }

    public decimal? Quantity { get; set; }

    public long? ItemQuantityTypeFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;
}
