using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class AssignCostCenterToSector
{
    public long Id { get; set; }

    public long? SectorFk { get; set; }

    public long? CostCenterFk { get; set; }

    public bool IsActive { get; set; }

    public virtual CostCenter? CostCenterFkNavigation { get; set; }

    public virtual Sector? SectorFkNavigation { get; set; }
}
