using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class PoserviceOutsource
{
    public long Id { get; set; }

    public long? PoserviceFk { get; set; }

    public long? WorkerTypeFk { get; set; }

    public long? EmployeeJobFk { get; set; }

    public int? Quantity { get; set; }

    public decimal? CostPerDay { get; set; }

    public decimal? TotalCost { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public long? ContractTaskEmployeeId { get; set; }

    public virtual EmployeeJob? EmployeeJobFkNavigation { get; set; }

    public virtual PurchaseOrderService? PoserviceFkNavigation { get; set; }

    public virtual WorkerType? WorkerTypeFkNavigation { get; set; }
}
