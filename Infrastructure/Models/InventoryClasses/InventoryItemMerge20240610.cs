using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryItemMerge20240610
{
    public string? ItemNumber2024 { get; set; }

    public string? ItemNumber2023 { get; set; }

    public long? ItemNumber2024Id { get; set; }

    public long? ItemNumber2023Id { get; set; }

    public decimal? TotalQuantity2023 { get; set; }

    public decimal? OpeningQuantity2024 { get; set; }

    public decimal? TotalQuantity2024 { get; set; }
}
