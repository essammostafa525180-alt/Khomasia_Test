using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class AssetCountPlan
{
    public long Id { get; set; }

    public string? PlanNumber { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public long? AssetCountPlanTypeFk { get; set; }

    public long? AssetCountPlanStatusFk { get; set; }

    public DateTime? PlaneDate { get; set; }

    public DateTime? ExecutionDate { get; set; }

    public long? AssignedToUserFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<AssetCountPlanDetail> AssetCountPlanDetails { get; set; } = new List<AssetCountPlanDetail>();

    public virtual AssetCountPlanStatus? AssetCountPlanStatusFkNavigation { get; set; }

    public virtual AssetCountPlanType? AssetCountPlanTypeFkNavigation { get; set; }

    public virtual ICollection<AssetCount> AssetCounts { get; set; } = new List<AssetCount>();
}
