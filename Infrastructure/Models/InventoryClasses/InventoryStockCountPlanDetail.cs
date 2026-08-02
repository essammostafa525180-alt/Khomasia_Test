using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryStockCountPlanDetail
{
    public long Id { get; set; }

    public long? InventoryStockCountPlanFk { get; set; }

    public long? StoreFk { get; set; }

    public long? AssignedToUserFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual InventoryStockCountPlan? InventoryStockCountPlanFkNavigation { get; set; }

    public virtual Store? StoreFkNavigation { get; set; }
}
