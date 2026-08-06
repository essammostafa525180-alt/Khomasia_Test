using Domain.Aggregates.InventoryItemAggregate;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryItemUoM
{
    public long Id { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public long? InventoryItemFk { get; set; }

    public long? UnitOfMeasureFk { get; set; }

    public decimal? ConvertRate { get; set; }

    public virtual InventoryItem? InventoryItemFkNavigation { get; set; }

    public virtual UnitOfMeasure? UnitOfMeasureFkNavigation { get; set; }
}
