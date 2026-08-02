using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryItemOpeningBalance
{
    public long Id { get; set; }

    public long? InventoryItemFk { get; set; }

    public long? StoreFk { get; set; }

    public decimal? Quantity { get; set; }

    public DateTime? CreatedOn { get; set; }

    public long? InventoryItemLocationFk { get; set; }

    public decimal? AvgCost { get; set; }

    public virtual InventoryItem? InventoryItemFkNavigation { get; set; }

    public virtual InventoryItemLocation? InventoryItemLocationFkNavigation { get; set; }

    public virtual Store? StoreFkNavigation { get; set; }
}
