using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryTransfereSerial
{
    public long Id { get; set; }

    public long? InventoryTransfereFk { get; set; }

    public long? InventoryTransfereDetailFk { get; set; }

    public long? InventoryItemSerialFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual InventoryItemSerial? InventoryItemSerialFkNavigation { get; set; }

    public virtual InventoryTransfereDetail? InventoryTransfereDetailFkNavigation { get; set; }

    public virtual InventoryTransfere? InventoryTransfereFkNavigation { get; set; }
}
