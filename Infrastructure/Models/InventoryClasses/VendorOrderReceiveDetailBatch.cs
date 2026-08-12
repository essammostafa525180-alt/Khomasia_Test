using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class VendorOrderReceiveDetailBatch
{
    public long Id { get; set; }

    public long? VendorOrderReceiveDetailFk { get; set; }

    public long? ShelfFk { get; set; }

    public string? BatchNumber { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? ReturnedQuantity { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime? ProductionDate { get; set; }

    public virtual Shelf? ShelfFkNavigation { get; set; }

    public virtual ICollection<VendorOrderReceiveDetailBatchSerial> VendorOrderReceiveDetailBatchSerials { get; set; } = new List<VendorOrderReceiveDetailBatchSerial>();

    public virtual VendorOrderReceiveDetail? VendorOrderReceiveDetailFkNavigation { get; set; }
}
