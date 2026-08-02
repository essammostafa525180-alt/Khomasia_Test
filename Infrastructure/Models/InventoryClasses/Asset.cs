using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class Asset
{
    public long Id { get; set; }

    public long? AssetGroupFk { get; set; }

    public long? AssetTypeFk { get; set; }

    public long? ToolsTypeFk { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public long? ZoneFk { get; set; }

    public long? EquipmentCodeFk { get; set; }

    public string? EquipmentLocationCode { get; set; }

    public string? FunctionalCode { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? CostPerHour { get; set; }

    public long? CurrencyFk { get; set; }

    public long? WarrantyStatusFk { get; set; }

    public string? Rfid { get; set; }

    public string? Remarks { get; set; }

    public long? PossessionTypeFk { get; set; }

    public DateTime? OperationDate { get; set; }

    public bool? IsOperational { get; set; }

    public long? InsuranceVendorFk { get; set; }

    public string? PolicyNumber { get; set; }

    public DateTime? PolicyDate { get; set; }

    public DateTime? PolicyExpiryDate { get; set; }

    public decimal? PolicyAmount { get; set; }

    public long? ManufactureFk { get; set; }

    public string? Model { get; set; }

    public long? ModelYearFk { get; set; }

    public string? SerialNumber { get; set; }

    public DateTime? GuaranteeExpiryDate { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? TechnicalInformation { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public long? CreatedBy { get; set; }

    public long? LastUpdatedBy { get; set; }

    public bool IsActive { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public bool? Axsynced { get; set; }

    public long? ProjectFk { get; set; }

    public long? AssetStatusFk { get; set; }

    public decimal? PurchasePrice { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public DateTime? CheckDate { get; set; }

    public decimal? LifeTime { get; set; }

    public decimal? DepreciationRate { get; set; }

    public DateTime? PlannedDepreciationDate { get; set; }

    public DateTime? ActualDepreciationDate { get; set; }

    public long? Oufk { get; set; }

    public virtual ICollection<AssetAttachment> AssetAttachments { get; set; } = new List<AssetAttachment>();

    public virtual ICollection<AssetCommissioning> AssetCommissionings { get; set; } = new List<AssetCommissioning>();

    public virtual ICollection<AssetComponent> AssetComponentAssetFkNavigations { get; set; } = new List<AssetComponent>();

    public virtual ICollection<AssetComponent> AssetComponentComponentFkNavigations { get; set; } = new List<AssetComponent>();

    public virtual ICollection<AssetCountDetail> AssetCountDetails { get; set; } = new List<AssetCountDetail>();

    public virtual AssetDisposed? AssetDisposed { get; set; }

    public virtual AssetsGroup? AssetGroupFkNavigation { get; set; }

    public virtual AssetStatus? AssetStatusFkNavigation { get; set; }

    public virtual AssetsType? AssetTypeFkNavigation { get; set; }

    public virtual InventoryCurrency? CurrencyFkNavigation { get; set; }

    public virtual EquipmentCode? EquipmentCodeFkNavigation { get; set; }

    public virtual InsuranceVendor? InsuranceVendorFkNavigation { get; set; }

    public virtual ICollection<InventoryItemAsset> InventoryItemAssets { get; set; } = new List<InventoryItemAsset>();

    public virtual Manufacture? ManufactureFkNavigation { get; set; }

    public virtual InventoryYear? ModelYearFkNavigation { get; set; }

    public virtual Ou? OufkNavigation { get; set; }

    public virtual PossessionType? PossessionTypeFkNavigation { get; set; }

    public virtual Project? ProjectFkNavigation { get; set; }

    public virtual ToolsType? ToolsTypeFkNavigation { get; set; }

    public virtual WarrantyStatus? WarrantyStatusFkNavigation { get; set; }

    public virtual Zone? ZoneFkNavigation { get; set; }
}
