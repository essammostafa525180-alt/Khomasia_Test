using Domain.Aggregates.LocationAggregate;
using Domain.Aggregates.StoreAggregate;
using Domain.Aggregates.VendorOrderAggregate;
using Infrastructure.Models.LookupTables;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class Project
{
    public long Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public long? CompanyFk { get; set; }

    public long? StoreFk { get; set; }

    public long? CustomerFk { get; set; }

    public virtual ICollection<ApprovalMatrixConfig> ApprovalMatrixConfigs { get; set; } = new List<ApprovalMatrixConfig>();

    public virtual ICollection<AssetItemMove> AssetItemMoveFromProjectFkNavigations { get; set; } = new List<AssetItemMove>();

    public virtual ICollection<AssetItemMove> AssetItemMoveToProjectFkNavigations { get; set; } = new List<AssetItemMove>();

    public virtual ICollection<AssetItem> AssetItems { get; set; } = new List<AssetItem>();

    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Company? CompanyFkNavigation { get; set; }

    public virtual ICollection<InventoryItemBudget> InventoryItemBudgets { get; set; } = new List<InventoryItemBudget>();

    public virtual ICollection<InventroyItemRequestWithdraw> InventroyItemRequestWithdraws { get; set; } = new List<InventroyItemRequestWithdraw>();

    public virtual ICollection<Line> Lines { get; set; } = new List<Line>();

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual ICollection<PurchaseOrderService> PurchaseOrderServices { get; set; } = new List<PurchaseOrderService>();

    public virtual Store? StoreFkNavigation { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    public virtual ICollection<VendorOrder> VendorOrders { get; set; } = new List<VendorOrder>();
}
