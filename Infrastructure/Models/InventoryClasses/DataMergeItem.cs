using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class DataMergeItem
{
    public long? OldItemFk { get; set; }

    public long? NewItemFk { get; set; }

    public DateTime? CreatedOn { get; set; }
}
