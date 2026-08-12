using Domain.Aggregates.VendorAggregate;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class PoserviceRecomendedResource
{
    public long Id { get; set; }

    public long PoserviceFk { get; set; }

    public long? ContractFk { get; set; }

    public long? EmployeeJobFk { get; set; }

    public long? VendorFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual EmployeeJob? EmployeeJobFkNavigation { get; set; }

    public virtual PurchaseOrderService PoserviceFkNavigation { get; set; } = null!;

    public virtual Vendor? VendorFkNavigation { get; set; }
}
