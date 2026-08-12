using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class مسطرد
{
    public string? Code { get; set; }

    public double? G { get; set; }

    public string? Name { get; set; }

    public string? Unit { get; set; }

    public double? Quantity { get; set; }

    public double? AvgCost { get; set; }

    public long? InventoryItemFk { get; set; }
}
