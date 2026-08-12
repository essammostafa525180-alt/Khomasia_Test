using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class VehicleType
{
    public long Id { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public decimal? InteriorVolume { get; set; }

    public long? EquipmentTypeFk { get; set; }

    public string? Description { get; set; }

    public decimal? InteriorLenght { get; set; }

    public decimal? ExteriorLenght { get; set; }

    public decimal? InteriorWidth { get; set; }

    public decimal? ExteriorWidth { get; set; }

    public decimal? InteriorHeight { get; set; }

    public decimal? ExteriorHeight { get; set; }

    public decimal? TareWeight { get; set; }

    public decimal? MaxGrossWeight { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public bool IsEnabled { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
