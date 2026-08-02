using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class Location
{
    public long Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public long? CityFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public bool? Axsynced { get; set; }

    public long? LocationFk { get; set; }

    public long? CompanyFk { get; set; }

    public long? ProjectFk { get; set; }

    public long? StoreFk { get; set; }

    public virtual ICollection<ApprovalMatrixConfig> ApprovalMatrixConfigs { get; set; } = new List<ApprovalMatrixConfig>();

    public virtual ICollection<AssetItemMove> AssetItemMoveFromAssetLocationFkNavigations { get; set; } = new List<AssetItemMove>();

    public virtual ICollection<AssetItemMove> AssetItemMoveToAssetLocationFkNavigations { get; set; } = new List<AssetItemMove>();

    public virtual ICollection<AssetItem> AssetItems { get; set; } = new List<AssetItem>();

    public virtual ICollection<AssignLocationSite> AssignLocationSites { get; set; } = new List<AssignLocationSite>();

    public virtual City? CityFkNavigation { get; set; }

    public virtual ICollection<InventoryItemBudget> InventoryItemBudgets { get; set; } = new List<InventoryItemBudget>();

    public virtual ICollection<InventroyItemRequestWithdraw> InventroyItemRequestWithdraws { get; set; } = new List<InventroyItemRequestWithdraw>();

    public virtual ICollection<Location> InverseLocationFkNavigation { get; set; } = new List<Location>();

    public virtual Location? LocationFkNavigation { get; set; }

    public virtual Project? ProjectFkNavigation { get; set; }

    public virtual ICollection<PurchaseOrderService> PurchaseOrderServices { get; set; } = new List<PurchaseOrderService>();

    public virtual Store? StoreFkNavigation { get; set; }

    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();

    public virtual ICollection<VendorOrder> VendorOrders { get; set; } = new List<VendorOrder>();

    public virtual ICollection<Zone> Zones { get; set; } = new List<Zone>();
}
