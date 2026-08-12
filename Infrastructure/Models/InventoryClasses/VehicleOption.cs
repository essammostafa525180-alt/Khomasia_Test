using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class VehicleOption
{
    public long Id { get; set; }

    public string? Code { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
