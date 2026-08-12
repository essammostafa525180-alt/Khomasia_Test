using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class Heba202320240721
{
    public string? ItemNumber { get; set; }

    public string? ItemName { get; set; }

    public double? Store1 { get; set; }

    public double? Store4 { get; set; }

    public double? Store5 { get; set; }

    public double? Store6 { get; set; }

    public double? Store7 { get; set; }

    public double? Store8 { get; set; }

    public double? AverageCost { get; set; }

    public double? Quantity { get; set; }

    public double? TotalCost { get; set; }

    public long? InventoryItemFk { get; set; }
}
