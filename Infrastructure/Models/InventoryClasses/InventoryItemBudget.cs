using Domain.Aggregates.LocationAggregate;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryItemBudget
{
    public long Id { get; set; }

    public long? CompanyFk { get; set; }

    public long? ProjectFk { get; set; }

    public long? LocationFk { get; set; }

    public long? ServiceMainCategoryFk { get; set; }

    public long? ScopeFk { get; set; }

    public byte[]? RowVersion { get; set; }

    public virtual Company? CompanyFkNavigation { get; set; }

    public virtual ICollection<InventoryItemBudgetDetail> InventoryItemBudgetDetails { get; set; } = new List<InventoryItemBudgetDetail>();

    public virtual Location? LocationFkNavigation { get; set; }

    public virtual Project? ProjectFkNavigation { get; set; }

    public virtual Scope? ScopeFkNavigation { get; set; }

    public virtual ServiceMainCategory? ServiceMainCategoryFkNavigation { get; set; }
}
