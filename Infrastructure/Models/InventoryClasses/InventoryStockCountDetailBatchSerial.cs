using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryStockCountDetailBatchSerial
{
    public long Id { get; set; }

    public long? InventoryStockCountDetailBatchFk { get; set; }

    public long? InventoryItemLocationBatchSerialFk { get; set; }

    public bool IsNew { get; set; }

    public bool IsSerialExist { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public virtual InventoryItemLocationBatchSerial? InventoryItemLocationBatchSerialFkNavigation { get; set; }

    public virtual InventoryStockCountDetailBatch? InventoryStockCountDetailBatchFkNavigation { get; set; }
}
