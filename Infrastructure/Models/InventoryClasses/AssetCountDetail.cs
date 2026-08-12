using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class AssetCountDetail
{
    public long Id { get; set; }

    public long? AssetCountFk { get; set; }

    public long? AssetFk { get; set; }

    public long? AssetCountStatusFk { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual AssetCount? AssetCountFkNavigation { get; set; }

    public virtual ICollection<AssetCountIssue> AssetCountIssues { get; set; } = new List<AssetCountIssue>();

    public virtual AssetCountStatus? AssetCountStatusFkNavigation { get; set; }

    public virtual Asset? AssetFkNavigation { get; set; }
}
