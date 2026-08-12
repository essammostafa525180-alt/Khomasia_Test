using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class DashboardPurchaseRequest
{
    public DateTime? OrderDate { get; set; }

    public bool? IsApproved { get; set; }

    public long? CompanyFk { get; set; }

    public string? Company { get; set; }

    public long? ProjectFk { get; set; }

    public string? Project { get; set; }

    public long? StoreFk { get; set; }

    public string? Store { get; set; }

    public long? VendorOrderStatusFk { get; set; }

    public string? VendorOrderStatus { get; set; }
}
