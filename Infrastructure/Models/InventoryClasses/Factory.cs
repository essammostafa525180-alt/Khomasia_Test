using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class Factory
{
    public long Id { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public string? Address { get; set; }

    public bool IsActive { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public byte[]? RowVersion { get; set; }

    public string Name { get; set; } = null!;

    public string? NameAr { get; set; }

    public virtual ICollection<FactoryLine> FactoryLines { get; set; } = new List<FactoryLine>();
}
