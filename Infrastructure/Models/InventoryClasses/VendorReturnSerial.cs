using Domain.Aggregates.VendorReturnAggregate;
using Domain.Entities;
using System;
using System.Collections.Generic;
using Domain.Aggregates.InventoryItemAggregate;

namespace Infrastructure.Models.InventoryClasses;

public partial class VendorReturnSerial
{
    public long Id { get; set; }

    public long? VendorReturnFk { get; set; }

    public long? VendorReturnDetailFk { get; set; }

    public long? InventoryItemSerialFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual InventoryItemSerial? InventoryItemSerialFkNavigation { get; set; }

    public virtual VendorReturnDetail? VendorReturnDetailFkNavigation { get; set; }

    public virtual VendorReturn? VendorReturnFkNavigation { get; set; }
}
