using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class VwInventoryItemDetailsClean
{
    public long Id { get; set; }

    public string? ItemNumber { get; set; }

    public string? Name { get; set; }

    public string? NameAr { get; set; }

    public string? ItemTypeName { get; set; }

    public string? ChemicalGroupName { get; set; }

    public string? MaterialGroupName { get; set; }

    public string? SparePartGroupName { get; set; }

    public decimal? TotalQuantity { get; set; }

    public string? UnitOfMeasureName { get; set; }

    public string? ItemExpiryTypeName { get; set; }

    public string? WarrantyStatusName { get; set; }

    public string? Rfid { get; set; }

    public string? EnglishDescription { get; set; }

    public string? ArabicDescription { get; set; }

    public bool? AutoReplenishment { get; set; }

    public bool? IsMaintainable { get; set; }

    public string? ManufactureName { get; set; }

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

    public string? ItemQuantityTypeName { get; set; }

    public string? MaterialCategoryName { get; set; }

    public string? MaterialSubCategoryName { get; set; }

    public bool IsDisabled { get; set; }

    public decimal? Density { get; set; }

    public decimal? VolumeSolid { get; set; }

    public decimal? SpreadingRate { get; set; }

    public decimal? Dft { get; set; }

    public decimal? Packing { get; set; }

    public string? ItemCode { get; set; }
}
