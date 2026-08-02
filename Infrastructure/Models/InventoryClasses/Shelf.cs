using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class Shelf
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public long? RackFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<InventoryItemLocationBatch> InventoryItemLocationBatches { get; set; } = new List<InventoryItemLocationBatch>();

    public virtual ICollection<InventoryTransfereDetailBatch> InventoryTransfereDetailBatches { get; set; } = new List<InventoryTransfereDetailBatch>();

    public virtual Rack? RackFkNavigation { get; set; }

    public virtual ICollection<VendorOrderReceiveDetailBatch> VendorOrderReceiveDetailBatches { get; set; } = new List<VendorOrderReceiveDetailBatch>();
}
