using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class AssetCountIssue
{
    public long Id { get; set; }

    public string? IssueNumber { get; set; }

    public long? AssetCountDetailFk { get; set; }

    public long? AssetCountIssueStatusFk { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual AssetCountDetail? AssetCountDetailFkNavigation { get; set; }

    public virtual AssetCountIssueStatus? AssetCountIssueStatusFkNavigation { get; set; }
}
