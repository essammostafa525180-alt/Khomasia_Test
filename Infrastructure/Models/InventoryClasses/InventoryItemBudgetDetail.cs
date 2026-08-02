using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryItemBudgetDetail
{
    public long Id { get; set; }

    public long? InventoryItemBudgetFk { get; set; }

    public long? ItemTypeFk { get; set; }

    public long? InventoryItemFk { get; set; }

    public int? BudgetQuantity { get; set; }

    public decimal? BudgetCost { get; set; }

    public virtual InventoryItemBudget? InventoryItemBudgetFkNavigation { get; set; }

    public virtual InventoryItem? InventoryItemFkNavigation { get; set; }

    public virtual ItemType? ItemTypeFkNavigation { get; set; }
}
