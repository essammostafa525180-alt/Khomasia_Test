using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class SecRoleModelAttribute
{
    public long RoleId { get; set; }

    public long ModelAttributeId { get; set; }

    public int? Mode { get; set; }

    public virtual SecModelAttribute ModelAttribute { get; set; } = null!;

    public virtual SecRole Role { get; set; } = null!;
}
