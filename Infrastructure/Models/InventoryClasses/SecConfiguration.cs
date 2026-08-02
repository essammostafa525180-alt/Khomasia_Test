using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class SecConfiguration
{
    public long Id { get; set; }

    public string? Key { get; set; }

    public string? Value { get; set; }
}
