using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class ReturnReason
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public long? IntegrationId { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<InventoryItemReturnBatchSerial> InventoryItemReturnBatchSerials { get; set; } = new List<InventoryItemReturnBatchSerial>();

    public virtual ICollection<InventoryItemReturnBatch> InventoryItemReturnBatches { get; set; } = new List<InventoryItemReturnBatch>();

    public virtual ICollection<InventoryItemReturnDetail> InventoryItemReturnDetails { get; set; } = new List<InventoryItemReturnDetail>();

    public virtual ICollection<VendorReturnDetailBatchSerial> VendorReturnDetailBatchSerials { get; set; } = new List<VendorReturnDetailBatchSerial>();

    public virtual ICollection<VendorReturnDetailBatch> VendorReturnDetailBatches { get; set; } = new List<VendorReturnDetailBatch>();

    public virtual ICollection<VendorReturnDetail> VendorReturnDetails { get; set; } = new List<VendorReturnDetail>();
}
