using Domain.Aggregates.InventoryItemAggregate;
using Domain.Aggregates.InventoryTransfereAggregate;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryTransfereDetail
{
    public long Id { get; set; }

    public long? InventoryTransfereFk { get; set; }

    public long? InventoryItemFk { get; set; }

    public decimal? Quantity { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual InventoryItem? InventoryItemFkNavigation { get; set; }

    public virtual ICollection<InventoryTransfereDetailBatch> InventoryTransfereDetailBatches { get; set; } = new List<InventoryTransfereDetailBatch>();

    public virtual InventoryTransfere? InventoryTransfereFkNavigation { get; set; }

    public virtual ICollection<InventoryTransfereSerial> InventoryTransfereSerials { get; set; } = new List<InventoryTransfereSerial>();
}
