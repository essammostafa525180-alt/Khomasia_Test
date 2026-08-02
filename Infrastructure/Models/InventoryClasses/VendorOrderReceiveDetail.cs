using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class VendorOrderReceiveDetail
{
    public long Id { get; set; }

    public long? VendorOrderReceiveFk { get; set; }

    public long? VendorOrderQualityDetailFk { get; set; }

    public long? InventoryItemFk { get; set; }

    public decimal? ReceivedQuantity { get; set; }

    public decimal? ReturnedQuantity { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public long? FromSerialize { get; set; }

    public long? ToSerialize { get; set; }

    public string? Notes { get; set; }

    public string? PartNo { get; set; }

    public string? ManufacturerCountry { get; set; }

    public virtual InventoryItem? InventoryItemFkNavigation { get; set; }

    public virtual VendorOrderQualityDetail? VendorOrderQualityDetailFkNavigation { get; set; }

    public virtual ICollection<VendorOrderReceiveDetailBatch> VendorOrderReceiveDetailBatches { get; set; } = new List<VendorOrderReceiveDetailBatch>();

    public virtual VendorOrderReceive? VendorOrderReceiveFkNavigation { get; set; }

    public virtual ICollection<VendorOrderReceiveSerial> VendorOrderReceiveSerials { get; set; } = new List<VendorOrderReceiveSerial>();
}
