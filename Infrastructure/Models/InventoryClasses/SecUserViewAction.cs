using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class SecUserViewAction
{
    public long UserId { get; set; }

    public long ViewActionId { get; set; }

    public bool? IsAllow { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual SecViewAction ViewAction { get; set; } = null!;
}
