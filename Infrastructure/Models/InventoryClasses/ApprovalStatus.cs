using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class ApprovalStatus
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<ApprovalMatrix> ApprovalMatrices { get; set; } = new List<ApprovalMatrix>();

    public virtual ICollection<ApprovalMatrixDetail> ApprovalMatrixDetails { get; set; } = new List<ApprovalMatrixDetail>();

    public virtual ICollection<AssetItemMove> AssetItemMoveIsManagerApprovedFkNavigations { get; set; } = new List<AssetItemMove>();

    public virtual ICollection<AssetItemMove> AssetItemMoveIsOwnerApprovedFkNavigations { get; set; } = new List<AssetItemMove>();

    public virtual ICollection<AssetItemScrap> AssetItemScraps { get; set; } = new List<AssetItemScrap>();
}
