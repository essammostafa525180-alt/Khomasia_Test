using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryItemSerial
{
    public long Id { get; set; }

    public long? InventoryItemFk { get; set; }

    public long? StoreFk { get; set; }

    public string? SerialNumber { get; set; }

    public long? InventoryItemSerialStatusFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual AssetItem? AssetItem { get; set; }

    public virtual InventoryItem? InventoryItemFkNavigation { get; set; }

    public virtual ICollection<InventoryItemReturnSerial> InventoryItemReturnSerials { get; set; } = new List<InventoryItemReturnSerial>();

    public virtual InventoryItemSerialStatus? InventoryItemSerialStatusFkNavigation { get; set; }

    public virtual ICollection<InventoryTransfereSerial> InventoryTransfereSerials { get; set; } = new List<InventoryTransfereSerial>();

    public virtual ICollection<RequestWithdrawSerial> RequestWithdrawSerials { get; set; } = new List<RequestWithdrawSerial>();

    public virtual Store? StoreFkNavigation { get; set; }

    public virtual ICollection<VendorOrderReceiveSerial> VendorOrderReceiveSerials { get; set; } = new List<VendorOrderReceiveSerial>();

    public virtual ICollection<VendorReturnSerial> VendorReturnSerials { get; set; } = new List<VendorReturnSerial>();
}
