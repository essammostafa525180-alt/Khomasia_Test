using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class Zone
{
    public long Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public long? LocationFk { get; set; }

    public long? CityFk { get; set; }

    public long? SiteFk { get; set; }

    public long? SubSectionFk { get; set; }

    public long? ZoneStatusFk { get; set; }

    public string? Rfid { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<AssetCountPlanDetail> AssetCountPlanDetails { get; set; } = new List<AssetCountPlanDetail>();

    public virtual ICollection<AssetCount> AssetCounts { get; set; } = new List<AssetCount>();

    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();

    public virtual City? CityFkNavigation { get; set; }

    public virtual Location? LocationFkNavigation { get; set; }

    public virtual Site? SiteFkNavigation { get; set; }

    public virtual SubSection? SubSectionFkNavigation { get; set; }

    public virtual ZoneStatus? ZoneStatusFkNavigation { get; set; }
}
