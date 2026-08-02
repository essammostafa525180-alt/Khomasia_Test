using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class AssetStatus
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<AssetItem> AssetItems { get; set; } = new List<AssetItem>();

    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();
}
