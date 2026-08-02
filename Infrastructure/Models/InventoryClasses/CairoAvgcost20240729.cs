using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class CairoAvgcost20240729
{
    public double? Id { get; set; }

    public string? ItemNumber { get; set; }

    public string? ItemName { get; set; }

    public string? Store { get; set; }

    public double? OpeningBalance { get; set; }

    public double? Avgcost { get; set; }

    public double? TotalCost { get; set; }
}
