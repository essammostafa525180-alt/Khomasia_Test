using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class StockCount20230331
{
    public string? ItemCode { get; set; }

    public string? Store { get; set; }

    public double? Balance { get; set; }

    public string? Date { get; set; }

    public int Id { get; set; }

    public string? ItemNumber { get; set; }
}
