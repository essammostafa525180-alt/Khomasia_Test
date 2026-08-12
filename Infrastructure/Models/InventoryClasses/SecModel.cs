using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class SecModel
{
    public long ModelId { get; set; }

    public string? ModelName { get; set; }

    public string? ModelDisplayName { get; set; }

    public long? SecModuleId { get; set; }

    public string? ModelDisplayNameAr { get; set; }

    public virtual ICollection<SecModelAttribute> SecModelAttributes { get; set; } = new List<SecModelAttribute>();

    public virtual SecModule? SecModule { get; set; }
}
