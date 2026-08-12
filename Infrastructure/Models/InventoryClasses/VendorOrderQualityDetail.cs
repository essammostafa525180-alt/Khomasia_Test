using Domain.Aggregates.InventoryItemAggregate;
using Domain.Entities;
using System;
using System.Collections.Generic;
using Domain.Aggregates.VendorOrderAggregate;

namespace Infrastructure.Models.InventoryClasses;

public partial class VendorOrderQualityDetail
{
    public long Id { get; set; }

    public long? VendorOrderQualityFk { get; set; }

    public long? VendorOrderDetailFk { get; set; }

    public long? InventoryItemFk { get; set; }

    public decimal? ReceivedQuantity { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public decimal? LandedCost { get; set; }

    public virtual InventoryItem? InventoryItemFkNavigation { get; set; }

    public virtual VendorOrderDetail? VendorOrderDetailFkNavigation { get; set; }

    public virtual ICollection<VendorOrderQualityDetailBatch> VendorOrderQualityDetailBatches { get; set; } = new List<VendorOrderQualityDetailBatch>();

    public virtual VendorOrderQuality? VendorOrderQualityFkNavigation { get; set; }

    public virtual ICollection<VendorOrderReceiveDetail> VendorOrderReceiveDetails { get; set; } = new List<VendorOrderReceiveDetail>();
}
