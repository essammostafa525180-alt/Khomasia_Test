using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryTransfereDetailBatch
{
    public long Id { get; set; }

    public long? InventoryTransfereDetailFk { get; set; }

    public long? BatchFk { get; set; }

    public string? NewBatchNumber { get; set; }

    public decimal? Qunatity { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public long? ShelfFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual InventoryItemLocationBatch? BatchFkNavigation { get; set; }

    public virtual ICollection<InventoryTransfereDetailBatchSerial> InventoryTransfereDetailBatchSerials { get; set; } = new List<InventoryTransfereDetailBatchSerial>();

    public virtual InventoryTransfereDetail? InventoryTransfereDetailFkNavigation { get; set; }

    public virtual Shelf? ShelfFkNavigation { get; set; }
}
