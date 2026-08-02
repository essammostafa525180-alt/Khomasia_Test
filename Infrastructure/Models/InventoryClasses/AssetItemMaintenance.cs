using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class AssetItemMaintenance
{
    public long Id { get; set; }

    public long? AssetItemFk { get; set; }

    public string? Code { get; set; }

    public long? AssetItemMoveFk { get; set; }

    public long? AssetMaintenanceStatusFk { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public byte[]? RowVersion { get; set; }

    public virtual AssetItem? AssetItemFkNavigation { get; set; }

    public virtual AssetItemMove? AssetItemMoveFkNavigation { get; set; }

    public virtual ICollection<AssetItemScrap> AssetItemScraps { get; set; } = new List<AssetItemScrap>();

    public virtual AssetMaintenanceStatus? AssetMaintenanceStatusFkNavigation { get; set; }
}
