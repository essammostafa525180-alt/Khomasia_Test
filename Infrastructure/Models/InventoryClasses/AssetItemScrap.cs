using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class AssetItemScrap
{
    public long Id { get; set; }

    public long? AssetItemFk { get; set; }

    public string? Code { get; set; }

    public long? AssetItemMoveFk { get; set; }

    public long? AssetItemMaintenanceFk { get; set; }

    public long? AssetScrapStatusFk { get; set; }

    public long? ApprovalStatusFk { get; set; }

    public decimal? SoldAmount { get; set; }

    public DateTime? ActionDate { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public byte[]? RowVersion { get; set; }

    public virtual ApprovalStatus? ApprovalStatusFkNavigation { get; set; }

    public virtual AssetItem? AssetItemFkNavigation { get; set; }

    public virtual AssetItemMaintenance? AssetItemMaintenanceFkNavigation { get; set; }

    public virtual AssetItemMove? AssetItemMoveFkNavigation { get; set; }

    public virtual AssetScrapStatus? AssetScrapStatusFkNavigation { get; set; }
}
