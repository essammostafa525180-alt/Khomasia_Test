using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class StoreSequence
{
    public string TableName { get; set; } = null!;

    public int? SequenceValue { get; set; }
}
