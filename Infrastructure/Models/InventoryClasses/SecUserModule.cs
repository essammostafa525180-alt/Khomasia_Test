using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class SecUserModule
{
    public long UserId { get; set; }

    public long SecModuleId { get; set; }

    public long Id { get; set; }

    public bool? IsAllowed { get; set; }

    public virtual SecModule SecModule { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
