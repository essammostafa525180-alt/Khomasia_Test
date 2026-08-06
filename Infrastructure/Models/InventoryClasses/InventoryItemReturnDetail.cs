using Domain.Aggregates.InventoryItemAggregate;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryItemReturnDetail
{
    public long Id { get; set; }

    public long? InventoryItemReturnFk { get; set; }

    public long? InventoryItemFk { get; set; }

    public decimal? ReturnedQuantity { get; set; }

    public long? ReturnReasonFk { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public decimal? ExternalReturnedQuantity { get; set; }

    public long? RequestWdfk { get; set; }

    public virtual InventoryItem? InventoryItemFkNavigation { get; set; }

    public virtual ICollection<InventoryItemReturnBatch> InventoryItemReturnBatches { get; set; } = new List<InventoryItemReturnBatch>();

    public virtual InventoryItemReturn? InventoryItemReturnFkNavigation { get; set; }

    public virtual ICollection<InventoryItemReturnSerial> InventoryItemReturnSerials { get; set; } = new List<InventoryItemReturnSerial>();

    public virtual ReturnReason? ReturnReasonFkNavigation { get; set; }
}
