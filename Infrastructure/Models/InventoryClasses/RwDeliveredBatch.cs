using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class RwDeliveredBatch
{
    public long Id { get; set; }

    public long? RequestWdfk { get; set; }

    public decimal? ReturnedQuantity { get; set; }

    public decimal? DeliveredQuantity { get; set; }

    public DateTime? DeliveredDate { get; set; }

    public long? BatchFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public bool? Axsynced { get; set; }

    public virtual InventoryItemLocationBatch? BatchFkNavigation { get; set; }

    public virtual ICollection<InventoryItemReturnBatch> InventoryItemReturnBatches { get; set; } = new List<InventoryItemReturnBatch>();

    public virtual InventroyItemRequestWithdrawDetail? RequestWdfkNavigation { get; set; }

    public virtual ICollection<RwDeliveredSerial> RwDeliveredSerials { get; set; } = new List<RwDeliveredSerial>();
}
