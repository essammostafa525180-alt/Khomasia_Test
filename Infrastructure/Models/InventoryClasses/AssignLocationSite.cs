using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class AssignLocationSite
{
    public long Id { get; set; }

    public long? LocationFk { get; set; }

    public long? SiteFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Location? LocationFkNavigation { get; set; }

    public virtual Site? SiteFkNavigation { get; set; }
}
