using Domain.Aggregates.ZoneAggregate;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class AssetCount
{
    public long Id { get; set; }

    public string? AssetCountNumber { get; set; }

    public long? AssetTakerUserFk { get; set; }

    public DateTime? CountDate { get; set; }

    public long? ZoneFk { get; set; }

    public long? AssetCountPlanFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<AssetCountDetail> AssetCountDetails { get; set; } = new List<AssetCountDetail>();

    public virtual AssetCountPlan? AssetCountPlanFkNavigation { get; set; }

    public virtual Zone? ZoneFkNavigation { get; set; }
}
