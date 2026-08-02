using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class Store
{
    public long Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public long? LocationFk { get; set; }

    public long? CityFk { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public bool? Axsynced { get; set; }

    public long? CompanyFk { get; set; }

    public bool? Main { get; set; }

    public bool? Scrap { get; set; }

    public bool? Quality { get; set; }

    public long? StoreFk { get; set; }

    public long? StoreKeeperFk { get; set; }

    public DateOnly? OnDate { get; set; }

    public virtual ICollection<AnnualStockCount> AnnualStockCounts { get; set; } = new List<AnnualStockCount>();

    public virtual City? CityFkNavigation { get; set; }

    public virtual Company? CompanyFkNavigation { get; set; }

    public virtual ICollection<InventoryItemLocationDetail> InventoryItemLocationDetails { get; set; } = new List<InventoryItemLocationDetail>();

    public virtual ICollection<InventoryItemLocation> InventoryItemLocations { get; set; } = new List<InventoryItemLocation>();

    public virtual ICollection<InventoryItemOpeningBalance> InventoryItemOpeningBalances { get; set; } = new List<InventoryItemOpeningBalance>();

    public virtual ICollection<InventoryItemSerial> InventoryItemSerials { get; set; } = new List<InventoryItemSerial>();

    public virtual ICollection<InventoryStockCountPlanDetail> InventoryStockCountPlanDetails { get; set; } = new List<InventoryStockCountPlanDetail>();

    public virtual ICollection<InventoryStockCount> InventoryStockCounts { get; set; } = new List<InventoryStockCount>();

    public virtual ICollection<InventoryTransfere> InventoryTransfereFromStoreFkNavigations { get; set; } = new List<InventoryTransfere>();

    public virtual ICollection<InventoryTransfere> InventoryTransfereToStoreFkNavigations { get; set; } = new List<InventoryTransfere>();

    public virtual ICollection<InventroyItemRequestWithdraw> InventroyItemRequestWithdraws { get; set; } = new List<InventroyItemRequestWithdraw>();

    public virtual ICollection<Store> InverseStoreFkNavigation { get; set; } = new List<Store>();

    public virtual Location? LocationFkNavigation { get; set; }

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual Store? StoreFkNavigation { get; set; }

    public virtual User? StoreKeeperFkNavigation { get; set; }

    public virtual ICollection<StoreKeeper> StoreKeepers { get; set; } = new List<StoreKeeper>();

    public virtual ICollection<VendorOrder> VendorOrders { get; set; } = new List<VendorOrder>();
}
