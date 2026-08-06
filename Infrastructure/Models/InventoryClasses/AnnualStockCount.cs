using Domain.Aggregates.StoreAggregate;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class AnnualStockCount
{
    public long Id { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public int? YearId { get; set; }

    public long? StoreFk { get; set; }

    public bool IsCompleted { get; set; }

    public virtual ICollection<AnnualStockCountItemMerge> AnnualStockCountItemMerges { get; set; } = new List<AnnualStockCountItemMerge>();

    public virtual Store? StoreFkNavigation { get; set; }
}
