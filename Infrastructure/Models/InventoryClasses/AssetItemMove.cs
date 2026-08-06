using Domain.Aggregates.LocationAggregate;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class AssetItemMove
{
    public long Id { get; set; }

    public string? Code { get; set; }

    public long? AssetItemFk { get; set; }

    public long? AssetMoveTypeFk { get; set; }

    public long? FromProjectFk { get; set; }

    public long? FromAssetLocationFk { get; set; }

    public long? ToProjectFk { get; set; }

    public long? ToAssetLocationFk { get; set; }

    public long? EmployeeFk { get; set; }

    public DateOnly? MoveDate { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public byte[]? RowVersion { get; set; }

    public long? OwnerApprovedFk { get; set; }

    public long? IsOwnerApprovedFk { get; set; }

    public DateTime? OwnerApprovedDate { get; set; }

    public long? ManagerApprovedFk { get; set; }

    public long? IsManagerApprovedFk { get; set; }

    public DateTime? ManagerApprovedDate { get; set; }

    public virtual AssetItem? AssetItemFkNavigation { get; set; }

    public virtual ICollection<AssetItemMaintenance> AssetItemMaintenances { get; set; } = new List<AssetItemMaintenance>();

    public virtual ICollection<AssetItemScrap> AssetItemScraps { get; set; } = new List<AssetItemScrap>();

    public virtual AssetMoveType? AssetMoveTypeFkNavigation { get; set; }

    public virtual Employee? EmployeeFkNavigation { get; set; }

    public virtual Location? FromAssetLocationFkNavigation { get; set; }

    public virtual Project? FromProjectFkNavigation { get; set; }

    public virtual ApprovalStatus? IsManagerApprovedFkNavigation { get; set; }

    public virtual ApprovalStatus? IsOwnerApprovedFkNavigation { get; set; }

    public virtual Employee? ManagerApprovedFkNavigation { get; set; }

    public virtual Employee? OwnerApprovedFkNavigation { get; set; }

    public virtual Location? ToAssetLocationFkNavigation { get; set; }

    public virtual Project? ToProjectFkNavigation { get; set; }
}
