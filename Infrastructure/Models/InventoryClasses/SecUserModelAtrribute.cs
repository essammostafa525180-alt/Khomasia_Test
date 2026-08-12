using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class SecUserModelAtrribute
{
    public long UserId { get; set; }

    public long ModelAttributeId { get; set; }

    public int? Mode { get; set; }

    public virtual SecModelAttribute ModelAttribute { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
