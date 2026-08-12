using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class AssetComponent
{
    public long Id { get; set; }

    public long? AssetFk { get; set; }

    public long? ComponentFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public virtual Asset? AssetFkNavigation { get; set; }

    public virtual Asset? ComponentFkNavigation { get; set; }
}
