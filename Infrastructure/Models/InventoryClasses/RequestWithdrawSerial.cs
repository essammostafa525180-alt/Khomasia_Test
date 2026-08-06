using Domain.Entities;
using System;
using System.Collections.Generic;
using Domain.Aggregates.InventoryItemAggregate;

namespace Infrastructure.Models.InventoryClasses;

public partial class RequestWithdrawSerial
{
    public long Id { get; set; }

    public long? RequestWithdrawFk { get; set; }

    public long? RequestWithdrawDetailFk { get; set; }

    public long? RwDeliveredQuantityFk { get; set; }

    public long? InventoryItemSerialFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual InventoryItemSerial? InventoryItemSerialFkNavigation { get; set; }

    public virtual InventroyItemRequestWithdrawDetail? RequestWithdrawDetailFkNavigation { get; set; }

    public virtual InventroyItemRequestWithdraw? RequestWithdrawFkNavigation { get; set; }

    public virtual RwDeliveredQuantity? RwDeliveredQuantityFkNavigation { get; set; }
}
