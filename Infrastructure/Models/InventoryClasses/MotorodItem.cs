using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class MotorodItem
{
    public string? MaterialGroup { get; set; }

    public string? ItemCategory { get; set; }

    public string? ItemName { get; set; }

    public string? Unit { get; set; }

    public double? Price { get; set; }
}
