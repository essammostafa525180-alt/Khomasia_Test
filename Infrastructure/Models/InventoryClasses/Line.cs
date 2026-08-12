using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class Line
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public long? ProjectFk { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public byte[]? RowVersion { get; set; }

    public virtual ICollection<InventroyItemRequestWithdraw> InventroyItemRequestWithdraws { get; set; } = new List<InventroyItemRequestWithdraw>();

    public virtual Project? ProjectFkNavigation { get; set; }
}
