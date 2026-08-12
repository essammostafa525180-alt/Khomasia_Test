using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class AssetMaintenanceStatus
{
    public long Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<AssetItemMaintenance> AssetItemMaintenances { get; set; } = new List<AssetItemMaintenance>();
}
