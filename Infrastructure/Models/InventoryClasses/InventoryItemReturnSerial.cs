using Domain.Entities;
using System;
using System.Collections.Generic;
using Domain.Aggregates.InventoryItemAggregate;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryItemReturnSerial
{
    public long Id { get; set; }

    public long? InventoryItemReturnFk { get; set; }

    public long? InventoryItemReturnDetailFk { get; set; }

    public long? InventoryItemSerialFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual InventoryItemReturnDetail? InventoryItemReturnDetailFkNavigation { get; set; }

    public virtual InventoryItemReturn? InventoryItemReturnFkNavigation { get; set; }

    public virtual InventoryItemSerial? InventoryItemSerialFkNavigation { get; set; }
}
