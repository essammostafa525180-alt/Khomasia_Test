using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class SecRoleModule
{
    public long SecRoleId { get; set; }

    public long SecModuleId { get; set; }

    public long Id { get; set; }

    public bool? IsAllowed { get; set; }

    public virtual SecModule SecModule { get; set; } = null!;

    public virtual SecRole SecRole { get; set; } = null!;
}
