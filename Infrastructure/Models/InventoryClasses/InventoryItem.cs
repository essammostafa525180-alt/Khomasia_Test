using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class InventoryItem
{
    public long Id { get; set; }

    public string? ItemNumber { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public long? ItemTypeFk { get; set; }

    public long? ChemicalGroupFk { get; set; }

    public long? AssetGroupFk { get; set; }

    public long? MaterialGroupFk { get; set; }

    public long? SparePartGroupFk { get; set; }

    public decimal? TotalQuantity { get; set; }

    public long? UnitOfMeasureFk { get; set; }

    public long? ItemExpiryTypeFk { get; set; }

    public long? WarrantyStatusFk { get; set; }

    public string? Rfid { get; set; }

    public string? EnglishDescription { get; set; }

    public string? ArabicDescription { get; set; }

    public bool? AutoReplenishment { get; set; }

    public bool? IsMaintainable { get; set; }

    public long? ManufactureFk { get; set; }

    public decimal? MinLevel { get; set; }

    public decimal? MaxLevel { get; set; }

    public decimal? AutoRequestQuantity { get; set; }

    public string? Model { get; set; }

    public decimal? DeliveryPeriodDays { get; set; }

    public decimal? Concentration { get; set; }

    public bool? IsBatch { get; set; }

    public bool? IsSerial { get; set; }

    public decimal? AvgCost { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public bool? Axsynced { get; set; }

    public decimal? IdelPeriod { get; set; }

    public decimal? LastPurchasePrice { get; set; }

    public bool? IsScrap { get; set; }

    public long? ItemQuantityTypeFk { get; set; }

    public long? MaterialCategoryFk { get; set; }

    public long? MaterialSubCategoryFk { get; set; }

    public bool IsDisabled { get; set; }

    public decimal? Density { get; set; }

    public decimal? VolumeSolid { get; set; }

    public decimal? SpreadingRate { get; set; }

    public decimal? Dft { get; set; }

    public decimal? Packing { get; set; }

    public string? ItemCode { get; set; }

    public virtual ICollection<AnnualStockCountItemMerge> AnnualStockCountItemMergeActiveInventoryItemFkNavigations { get; set; } = new List<AnnualStockCountItemMerge>();

    public virtual ICollection<AnnualStockCountItemMerge> AnnualStockCountItemMergeInventoryItemFkNavigations { get; set; } = new List<AnnualStockCountItemMerge>();

    public virtual AssetsGroup? AssetGroupFkNavigation { get; set; }

    public virtual ChemicalGroup? ChemicalGroupFkNavigation { get; set; }

    public virtual ICollection<InventoryItemAsset> InventoryItemAssets { get; set; } = new List<InventoryItemAsset>();

    public virtual ICollection<InventoryItemBudgetDetail> InventoryItemBudgetDetails { get; set; } = new List<InventoryItemBudgetDetail>();

    public virtual ICollection<InventoryItemCost> InventoryItemCosts { get; set; } = new List<InventoryItemCost>();

    public virtual ICollection<InventoryItemEquivalentSp> InventoryItemEquivalentSpEquivalentItemFkNavigations { get; set; } = new List<InventoryItemEquivalentSp>();

    public virtual ICollection<InventoryItemEquivalentSp> InventoryItemEquivalentSpInventoryItemFkNavigations { get; set; } = new List<InventoryItemEquivalentSp>();

    public virtual ICollection<InventoryItemLocationDetail> InventoryItemLocationDetails { get; set; } = new List<InventoryItemLocationDetail>();

    public virtual ICollection<InventoryItemLocation> InventoryItemLocations { get; set; } = new List<InventoryItemLocation>();

    public virtual ICollection<InventoryItemOpeningBalance> InventoryItemOpeningBalances { get; set; } = new List<InventoryItemOpeningBalance>();

    public virtual ICollection<InventoryItemReturnDetail> InventoryItemReturnDetails { get; set; } = new List<InventoryItemReturnDetail>();

    public virtual ICollection<InventoryItemSerial> InventoryItemSerials { get; set; } = new List<InventoryItemSerial>();

    public virtual ICollection<InventoryItemUoM> InventoryItemUoMs { get; set; } = new List<InventoryItemUoM>();

    public virtual ICollection<InventoryItemVendor> InventoryItemVendors { get; set; } = new List<InventoryItemVendor>();

    public virtual ICollection<InventoryStockCountDetail> InventoryStockCountDetails { get; set; } = new List<InventoryStockCountDetail>();

    public virtual ICollection<InventoryTransfereDetail> InventoryTransfereDetails { get; set; } = new List<InventoryTransfereDetail>();

    public virtual ICollection<InventroyItemRequestWithdrawDetail> InventroyItemRequestWithdrawDetails { get; set; } = new List<InventroyItemRequestWithdrawDetail>();

    public virtual ItemExpiryType? ItemExpiryTypeFkNavigation { get; set; }

    public virtual ItemQuantityType? ItemQuantityTypeFkNavigation { get; set; }

    public virtual ItemType? ItemTypeFkNavigation { get; set; }

    public virtual Manufacture? ManufactureFkNavigation { get; set; }

    public virtual MaterialCategory? MaterialCategoryFkNavigation { get; set; }

    public virtual MaterialGroup? MaterialGroupFkNavigation { get; set; }

    public virtual MaterialSubCategory? MaterialSubCategoryFkNavigation { get; set; }

    public virtual ICollection<SalesQuotationDetail> SalesQuotationDetails { get; set; } = new List<SalesQuotationDetail>();

    public virtual SparePartGroup? SparePartGroupFkNavigation { get; set; }

    public virtual UnitOfMeasure? UnitOfMeasureFkNavigation { get; set; }

    public virtual ICollection<VendorOrderDetail> VendorOrderDetails { get; set; } = new List<VendorOrderDetail>();

    public virtual ICollection<VendorOrderQualityDetail> VendorOrderQualityDetails { get; set; } = new List<VendorOrderQualityDetail>();

    public virtual ICollection<VendorOrderReceiveDetail> VendorOrderReceiveDetails { get; set; } = new List<VendorOrderReceiveDetail>();

    public virtual ICollection<VendorReturnDetail> VendorReturnDetails { get; set; } = new List<VendorReturnDetail>();

    public virtual WarrantyStatus? WarrantyStatusFkNavigation { get; set; }
}
