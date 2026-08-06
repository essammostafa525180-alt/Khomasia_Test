using Domain.Aggregates.StoreAggregate;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class StoreKeeper
{
    public long Id { get; set; }

    public long? StoreFk { get; set; }

    public long? StoreKeeperFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual Store? StoreFkNavigation { get; set; }

    public virtual User? StoreKeeperFkNavigation { get; set; }
}
