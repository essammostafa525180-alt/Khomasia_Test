using Domain.Entities;
using System;
using System.Collections.Generic;
using Domain.Aggregates.VendorOrderAggregate;

namespace Infrastructure.Models.InventoryClasses;

public partial class OrderLineItemStatus
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<VendorOrderDetail> VendorOrderDetails { get; set; } = new List<VendorOrderDetail>();
}
