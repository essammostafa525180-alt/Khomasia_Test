using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class SecRoleProperty
{
    public long Id { get; set; }

    public long? RoleId { get; set; }

    public long? PropertyId { get; set; }

    public int? Mode { get; set; }

    public virtual SecProperty? Property { get; set; }

    public virtual SecRole? Role { get; set; }

    public virtual ICollection<SecRoleSecurableValue> SecRoleSecurableValues { get; set; } = new List<SecRoleSecurableValue>();
}
