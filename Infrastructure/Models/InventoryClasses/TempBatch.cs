using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class TempBatch
{
    public long? RowNumber { get; set; }

    public long BatchId { get; set; }
}
