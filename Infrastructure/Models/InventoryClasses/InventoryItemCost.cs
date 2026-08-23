using Domain.Aggregates.InventoryItemAggregate;
using Infrastructure.Models.LookupTables;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryItemCost
{
    public long Id { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public long? InventoryItemFk { get; set; }

    public long? CompanyFk { get; set; }

    public decimal? AvgCost { get; set; }

    public decimal? TotalQuantity { get; set; }

    public virtual Company? CompanyFkNavigation { get; set; }

    public virtual InventoryItem? InventoryItemFkNavigation { get; set; }
}
