using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryItem2024
{
    public string? Store { get; set; }

    public string? ItemCardEn { get; set; }

    public string? ItemCardAr { get; set; }

    public string? MaterialGroup { get; set; }

    public string? MaterialCategory { get; set; }

    public string? MaterialSubCategory { get; set; }

    public double? TotalQuantity { get; set; }

    public string? UnitOfMeasure { get; set; }

    public string? MaterialGroup1 { get; set; }

    public long? MaterialGroupFk { get; set; }

    public long? MaterialCategoryFk { get; set; }

    public long? MaterialSubCategoryFk { get; set; }

    public long? UnitOfMeasureFk { get; set; }
}
