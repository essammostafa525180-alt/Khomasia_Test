using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class SysKeyValue
{
    public long Id { get; set; }

    public string? SysKey { get; set; }

    public string? SysValue { get; set; }

    public string? Description { get; set; }

    public string? DescriptionAr { get; set; }
}
