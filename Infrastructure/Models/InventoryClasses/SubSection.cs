using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class SubSection
{
    public long Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public long? SectionFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<AssetCommissioning> AssetCommissionings { get; set; } = new List<AssetCommissioning>();

    public virtual Section? SectionFkNavigation { get; set; }

    public virtual ICollection<Zone> Zones { get; set; } = new List<Zone>();
}
