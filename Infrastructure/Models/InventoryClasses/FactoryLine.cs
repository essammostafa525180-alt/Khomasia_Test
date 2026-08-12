using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class FactoryLine
{
    public long Id { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public long FactoryFk { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public byte[]? RowVersion { get; set; }

    public string Name { get; set; } = null!;

    public string? NameAr { get; set; }

    public int? Capacity { get; set; }

    public string LineTypes { get; set; } = null!;

    public virtual Factory FactoryFkNavigation { get; set; } = null!;
}
