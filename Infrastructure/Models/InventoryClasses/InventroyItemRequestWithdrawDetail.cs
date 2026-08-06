using Domain.Aggregates.InventoryItemAggregate;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventroyItemRequestWithdrawDetail
{
    public long Id { get; set; }

    public long? RequestWfk { get; set; }

    public long? InventoryItemFk { get; set; }

    public decimal? RequestedQuantity { get; set; }

    public decimal? PickedQuantity { get; set; }

    public decimal? DeliveredQuantity { get; set; }

    public decimal? ReturnedQuantity { get; set; }

    public decimal? ScrapedQuantity { get; set; }

    public long? RequestLineItemStatusFk { get; set; }

    public long? FromSerial { get; set; }

    public long? ToSerial { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public long? IntegrationId { get; set; }

    public bool? IsSync { get; set; }

    public decimal? LastPurchasePrice { get; set; }

    public decimal? AvgCost { get; set; }

    public virtual InventoryItem? InventoryItemFkNavigation { get; set; }

    public virtual RequestLineItemStatus? RequestLineItemStatusFkNavigation { get; set; }

    public virtual InventroyItemRequestWithdraw? RequestWfkNavigation { get; set; }

    public virtual ICollection<RequestWithdrawSerial> RequestWithdrawSerials { get; set; } = new List<RequestWithdrawSerial>();

    public virtual ICollection<RwDeliveredBatch> RwDeliveredBatches { get; set; } = new List<RwDeliveredBatch>();

    public virtual ICollection<RwDeliveredQuantity> RwDeliveredQuantities { get; set; } = new List<RwDeliveredQuantity>();

    public virtual ICollection<RwPickedQuantity> RwPickedQuantities { get; set; } = new List<RwPickedQuantity>();
}
