using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class SecUserSecurableValue
{
    public long Id { get; set; }

    public string? Value { get; set; }

    public long? SecUserPropertyId { get; set; }

    public virtual SecUserProperty? SecUserProperty { get; set; }
}
