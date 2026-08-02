using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class Heba202320240721merge
{
    public long Id { get; set; }

    public string? DeletedItemNumber { get; set; }

    public string? ItemNumber { get; set; }

    public long? InventoryItemFk { get; set; }

    public double? NewAverageCost { get; set; }

    public double? DeletedAverageCost { get; set; }
}
