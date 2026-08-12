using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class DashboardInventoryItemBalancePerStore
{
    public long? CompanyFk { get; set; }

    public string? Company { get; set; }

    public long? StoreFk { get; set; }

    public string? Store { get; set; }

    public long? InventoryItemFk { get; set; }

    public string? InventoryItem { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? Cost { get; set; }
}
