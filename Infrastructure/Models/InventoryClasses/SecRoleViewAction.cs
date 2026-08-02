using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class SecRoleViewAction
{
    public long ViewActionId { get; set; }

    public long RoleId { get; set; }

    public bool? IsAllow { get; set; }

    public virtual SecRole Role { get; set; } = null!;

    public virtual SecViewAction ViewAction { get; set; } = null!;
}
