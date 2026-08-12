using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class SecProperty
{
    public long Id { get; set; }

    public string? Type { get; set; }

    public string? Name { get; set; }

    public long? SecModuleId { get; set; }

    public string? NameAr { get; set; }

    public virtual SecModule? SecModule { get; set; }

    public virtual ICollection<SecRoleProperty> SecRoleProperties { get; set; } = new List<SecRoleProperty>();

    public virtual ICollection<SecUserProperty> SecUserProperties { get; set; } = new List<SecUserProperty>();
}
