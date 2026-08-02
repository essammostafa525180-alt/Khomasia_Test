using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class City
{
    public long Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public long? StateFk { get; set; }

    public long? RelatedProjectFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public bool? Axsynced { get; set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual Project? RelatedProjectFkNavigation { get; set; }

    public virtual State? StateFkNavigation { get; set; }

    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    public virtual ICollection<Vendor> Vendors { get; set; } = new List<Vendor>();

    public virtual ICollection<Zone> Zones { get; set; } = new List<Zone>();
}
