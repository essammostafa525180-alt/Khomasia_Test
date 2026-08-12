using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class AssetDisposed
{
    public long Id { get; set; }

    public string? OrganizationName { get; set; }

    public decimal? Cost { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public virtual Asset IdNavigation { get; set; } = null!;
}
