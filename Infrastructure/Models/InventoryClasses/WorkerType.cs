using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class WorkerType
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[]? RowVersion { get; set; }

    public virtual ICollection<PoserviceOutsource> PoserviceOutsources { get; set; } = new List<PoserviceOutsource>();
}
