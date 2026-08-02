using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class SecRoleSecurableValue
{
    public long Id { get; set; }

    public string? Value { get; set; }

    public long? SecRolePropertyId { get; set; }

    public virtual SecRoleProperty? SecRoleProperty { get; set; }
}
