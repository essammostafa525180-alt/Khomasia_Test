using Domain.Primitives;

namespace Domain.Aggregates.InventoryItemAggregate
{
    public class InventoryItem : AggregateRootEntityBase<long>
    {
        public string? ItemNumber { get; set; }
         public string? Name { get; set; }
         public string? NameAr { get; set; }
         public long? ItemTypeFK { get; set; }
         public long? ChemicalGroupFK { get; set; }
         public long? AssetGroupFK { get; set; }
         public long? MaterialGroupFK { get; set; }
         public long? SparePartGroupFK { get; set; }
         public decimal? TotalQuantity { get; set; }
         public long? UnitOfMeasureFK { get; set; }
         public long? ItemExpiryTypeFK { get; set; }
         public long? WarrantyStatusFK { get; set; }
         public string? RFID { get; set; }
         public string? EnglishDescription { get; set; }
         public string? ArabicDescription { get; set; }
         public bool? AutoReplenishment { get; set; }
         public bool? IsMaintainable { get; set; }
         public long? ManufactureFK { get; set; }
         public decimal? MinLevel { get; set; }
         public decimal? MaxLevel { get; set; }
         public decimal? AutoRequestQuantity { get; set; }
         public string? Model { get; set; }
         public decimal? DeliveryPeriodDays { get; set; }
         public decimal? Concentration { get; set; }
         public bool? IsBatch { get; set; }
         public bool? IsSerial { get; set; }
         public decimal? AvgCost { get; set; }
         public bool? AXSynced { get; set; }
         public decimal? IdelPeriod { get; set; }
         public decimal? LastPurchasePrice { get; set; }
         public bool? IsScrap { get; set; }
         public long? ItemQuantityTypeFK { get; set; }
         public long? MaterialCategoryFK { get; set; }
         public long? MaterialSubCategoryFK { get; set; }
         public bool IsDisabled { get; set; }
         public decimal? Density { get; set; }
         public decimal? VolumeSolid { get; set; }
         public decimal? SpreadingRate { get; set; } 
         public decimal? DFT { get; set; }
         public decimal? Packing { get; set; }
         public string? ItemCode { get; set; }
    public InventoryItem()
        {
        }

        public InventoryItem(string? itemNumber, string? name, string? nameAr, long? itemTypeFK, long? chemicalGroupFK, long? assetGroupFK, long? materialGroupFK, long? sparePartGroupFK, decimal? totalQuantity, long? unitOfMeasureFK, long? itemExpiryTypeFK, long? warrantyStatusFK, string? rFID, string? englishDescription, string? arabicDescription, bool? autoReplenishment, bool? isMaintainable, long? manufactureFK, decimal? minLevel, decimal? maxLevel, decimal? autoRequestQuantity, string? model, decimal? deliveryPeriodDays, decimal? concentration, bool? isBatch, bool? isSerial, decimal? avgCost, bool? aXSynced, decimal? idelPeriod, decimal? lastPurchasePrice, bool? isScrap, long? itemQuantityTypeFK, long? materialCategoryFK, long? materialSubCategoryFK, bool isDisabled, decimal? density, decimal? volumeSolid, decimal? spreadingRate, decimal? dFT, decimal? packing, string? itemCode, bool isActive) : this()
        {
            ItemNumber = itemNumber;
            Name = name;
            NameAr = nameAr;
            ItemTypeFK = itemTypeFK;
            ChemicalGroupFK = chemicalGroupFK;
            AssetGroupFK = assetGroupFK;
            MaterialGroupFK = materialGroupFK;
            SparePartGroupFK = sparePartGroupFK;
            TotalQuantity = totalQuantity;
            UnitOfMeasureFK = unitOfMeasureFK;
            ItemExpiryTypeFK = itemExpiryTypeFK;
            WarrantyStatusFK = warrantyStatusFK;
            RFID = rFID;
            EnglishDescription = englishDescription;
            ArabicDescription = arabicDescription;
            AutoReplenishment = autoReplenishment;
            IsMaintainable = isMaintainable;
            ManufactureFK = manufactureFK;
            MinLevel = minLevel;
            MaxLevel = maxLevel;
            AutoRequestQuantity = autoRequestQuantity;
            Model = model;
            DeliveryPeriodDays = deliveryPeriodDays;
            Concentration = concentration;
            IsBatch = isBatch;
            IsSerial = isSerial;
            AvgCost = avgCost;
            AXSynced = aXSynced;
            IdelPeriod = idelPeriod;
            LastPurchasePrice = lastPurchasePrice;
            IsScrap = isScrap;
            ItemQuantityTypeFK = itemQuantityTypeFK;
            MaterialCategoryFK = materialCategoryFK;
            MaterialSubCategoryFK = materialSubCategoryFK;
            IsDisabled = isDisabled;
            Density = density;
            VolumeSolid = volumeSolid;
            SpreadingRate = spreadingRate;
            DFT = dFT;
            Packing = packing;
            ItemCode = itemCode;
            IsActive = isActive;
        }

        public static InventoryItem Create(string? itemNumber, string? name, string? nameAr, long? itemTypeFK, long? chemicalGroupFK, long? assetGroupFK, long? materialGroupFK, long? sparePartGroupFK, decimal? totalQuantity, long? unitOfMeasureFK, long? itemExpiryTypeFK, long? warrantyStatusFK, string? rFID, string? englishDescription, string? arabicDescription, bool? autoReplenishment, bool? isMaintainable, long? manufactureFK, decimal? minLevel, decimal? maxLevel, decimal? autoRequestQuantity, string? model, decimal? deliveryPeriodDays, decimal? concentration, bool? isBatch, bool? isSerial, decimal? avgCost, bool? aXSynced, decimal? idelPeriod, decimal? lastPurchasePrice, bool? isScrap, long? itemQuantityTypeFK, long? materialCategoryFK, long? materialSubCategoryFK, bool isDisabled, decimal? density, decimal? volumeSolid, decimal? spreadingRate, decimal? dFT, decimal? packing, string? itemCode, bool isActive)
        {
            return new InventoryItem(itemNumber, name, nameAr, itemTypeFK, chemicalGroupFK, assetGroupFK, materialGroupFK, sparePartGroupFK, totalQuantity, unitOfMeasureFK, itemExpiryTypeFK, warrantyStatusFK, rFID, englishDescription, arabicDescription, autoReplenishment, isMaintainable, manufactureFK, minLevel, maxLevel, autoRequestQuantity, model, deliveryPeriodDays, concentration, isBatch, isSerial, avgCost, aXSynced, idelPeriod, lastPurchasePrice, isScrap, itemQuantityTypeFK, materialCategoryFK, materialSubCategoryFK, isDisabled, density, volumeSolid, spreadingRate, dFT, packing, itemCode, isActive);
        }

        public void Update(string? itemNumber, string? name, string? nameAr, long? itemTypeFK, long? chemicalGroupFK, long? assetGroupFK, long? materialGroupFK, long? sparePartGroupFK, decimal? totalQuantity, long? unitOfMeasureFK, long? itemExpiryTypeFK, long? warrantyStatusFK, string? rFID, string? englishDescription, string? arabicDescription, bool? autoReplenishment, bool? isMaintainable, long? manufactureFK, decimal? minLevel, decimal? maxLevel, decimal? autoRequestQuantity, string? model, decimal? deliveryPeriodDays, decimal? concentration, bool? isBatch, bool? isSerial, decimal? avgCost, bool? aXSynced, decimal? idelPeriod, decimal? lastPurchasePrice, bool? isScrap, long? itemQuantityTypeFK, long? materialCategoryFK, long? materialSubCategoryFK, bool isDisabled, decimal? density, decimal? volumeSolid, decimal? spreadingRate, decimal? dFT, decimal? packing, string? itemCode, bool isActive)
        {
            ItemNumber = itemNumber;
            Name = name;
            NameAr = nameAr;
            ItemTypeFK = itemTypeFK;
            ChemicalGroupFK = chemicalGroupFK;
            AssetGroupFK = assetGroupFK;
            MaterialGroupFK = materialGroupFK;
            SparePartGroupFK = sparePartGroupFK;
            TotalQuantity = totalQuantity;
            UnitOfMeasureFK = unitOfMeasureFK;
            ItemExpiryTypeFK = itemExpiryTypeFK;
            WarrantyStatusFK = warrantyStatusFK;
            RFID = rFID;
            EnglishDescription = englishDescription;
            ArabicDescription = arabicDescription;
            AutoReplenishment = autoReplenishment;
            IsMaintainable = isMaintainable;
            ManufactureFK = manufactureFK;
            MinLevel = minLevel;
            MaxLevel = maxLevel;
            AutoRequestQuantity = autoRequestQuantity;
            Model = model;
            DeliveryPeriodDays = deliveryPeriodDays;
            Concentration = concentration;
            IsBatch = isBatch;
            IsSerial = isSerial;
            AvgCost = avgCost;
            AXSynced = aXSynced;
            IdelPeriod = idelPeriod;
            LastPurchasePrice = lastPurchasePrice;
            IsScrap = isScrap;
            ItemQuantityTypeFK = itemQuantityTypeFK;
            MaterialCategoryFK = materialCategoryFK;
            MaterialSubCategoryFK = materialSubCategoryFK;
            IsDisabled = isDisabled;
            Density = density;
            VolumeSolid = volumeSolid;
            SpreadingRate = spreadingRate;
            DFT = dFT;
            Packing = packing;
            ItemCode = itemCode;
            IsActive = isActive;
        }
    }
}