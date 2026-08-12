using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class Pruser
{
    public long Id { get; set; }

    public long ApprovalScreenFk { get; set; }

    public long UserFk { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? LastUpdatedBy { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ApprovalScreen ApprovalScreenFkNavigation { get; set; } = null!;

    public virtual User UserFkNavigation { get; set; } = null!;
}
