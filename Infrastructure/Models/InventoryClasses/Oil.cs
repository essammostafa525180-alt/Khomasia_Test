using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class Oil
{
    public double? StoreId { get; set; }

    public string? StoreName { get; set; }

    public DateTime? StockCountDate { get; set; }

    public double? InventoryItemId { get; set; }

    public string? InventoryItemCode { get; set; }

    public string? InventoryItemName { get; set; }

    public double? AvgCost { get; set; }

    public double? TotalQuantity { get; set; }

    public double? StockCountQuantity { get; set; }

    public double? Mmbalance { get; set; }

    public string? IsMatch { get; set; }

    public double? Id { get; set; }

    public double? IsUpdated { get; set; }
}
