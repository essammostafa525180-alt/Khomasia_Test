using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class Pdadetail
{
    public long Id { get; set; }

    public long? PdamodelFk { get; set; }

    public string? Imei { get; set; }

    public long? ProductionYearFk { get; set; }

    public long? ProductionCountryFk { get; set; }

    public DateTime? StartingDate { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<Pdaassignment> Pdaassignments { get; set; } = new List<Pdaassignment>();

    public virtual Pdamodel? PdamodelFkNavigation { get; set; }

    public virtual Country? ProductionCountryFkNavigation { get; set; }

    public virtual InventoryYear? ProductionYearFkNavigation { get; set; }
}
