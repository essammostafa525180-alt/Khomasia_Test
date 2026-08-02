using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class VendorOrderQualityDetailBatch
{
    public long Id { get; set; }

    public long? VendorOrderQualityDetailFk { get; set; }

    public long? ShelfFk { get; set; }

    public string? BatchNumber { get; set; }

    public decimal? Quantity { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public DateTime? ProductionDate { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual VendorOrderQualityDetail? VendorOrderQualityDetailFkNavigation { get; set; }
}
