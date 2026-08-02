using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class Cairo202320240721
{
    public string? ItemNumber { get; set; }

    public string? ItemName { get; set; }

    public double? Store2 { get; set; }

    public double? Store3 { get; set; }

    public double? Store9 { get; set; }

    public double? AverageCost { get; set; }

    public double? Quantity { get; set; }

    public double? TotalCost { get; set; }

    public long? InventoryItemFk { get; set; }
}
