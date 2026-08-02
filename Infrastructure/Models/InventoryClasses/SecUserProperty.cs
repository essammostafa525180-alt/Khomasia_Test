using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class SecUserProperty
{
    public long Id { get; set; }

    public long? UserId { get; set; }

    public long? PropertyId { get; set; }

    public int? Mode { get; set; }

    public virtual SecProperty? Property { get; set; }

    public virtual ICollection<SecUserSecurableValue> SecUserSecurableValues { get; set; } = new List<SecUserSecurableValue>();

    public virtual User? User { get; set; }
}
