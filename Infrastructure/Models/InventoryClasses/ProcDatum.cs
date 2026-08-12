using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class ProcDatum
{
    public long Id { get; set; }

    public string? Description { get; set; }

    public string? Query { get; set; }

    public bool IsRun { get; set; }
}
