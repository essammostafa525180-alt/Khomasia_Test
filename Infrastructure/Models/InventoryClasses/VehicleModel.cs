using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class VehicleModel
{
    public long Id { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public long? VehicleBrandFk { get; set; }

    public long? YearFk { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public bool IsEnabled { get; set; }

    public virtual VehicleBrand? VehicleBrandFkNavigation { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    public virtual InventoryYear? YearFkNavigation { get; set; }
}
