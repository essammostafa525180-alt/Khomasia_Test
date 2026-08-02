using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class Sector
{
    public long Id { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public bool IsActive { get; set; }

    public byte[]? RowVersion { get; set; }

    public bool IsEnabled { get; set; }

    public virtual ICollection<AssignCostCenterToSector> AssignCostCenterToSectors { get; set; } = new List<AssignCostCenterToSector>();

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
