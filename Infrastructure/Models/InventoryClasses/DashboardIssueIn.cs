using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class DashboardIssueIn
{
    public DateTime? ReceivingDate { get; set; }

    public long? CompanyFk { get; set; }

    public string? Company { get; set; }

    public long? ProjectFk { get; set; }

    public string? Project { get; set; }

    public long? VendorFk { get; set; }

    public string? Vendor { get; set; }

    public long? StoreFk { get; set; }

    public string? Store { get; set; }
}
