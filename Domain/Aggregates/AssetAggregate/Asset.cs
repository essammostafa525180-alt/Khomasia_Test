using Domain.Aggregates.CompanyAggregate;
using Domain.Aggregates.InventoryItemAggregate;
using Domain.Aggregates.ZoneAggregate;
using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.AssetAggregate
{
    public class Asset : AggregateRootEntityBase<int>
    {
        public int? AssetGroupFk { get; set; }
        public AssetsGroup? AssetGroupFkNavigation { get; set; }

        public int? AssetTypeFk { get; set; }
        public int? ToolsTypeFk { get; set; }

        public AssetDisposed? AssetDisposed { get; set; }
        public AssetStatus? AssetStatusFkNavigation { get; set; }
        public AssetsType? AssetTypeFkNavigation { get; set; }
        public InventoryCurrency? CurrencyFkNavigation { get; set; }
        public EquipmentCode? EquipmentCodeFkNavigation { get; set; }
        public InsuranceVendor? InsuranceVendorFkNavigation { get; set; }
        public Manufacture? ManufactureFkNavigation { get; set; }
        public InventoryYear? ModelYearFkNavigation { get; set; }
        public Ou? OufkNavigation { get; set; }
        public PossessionType? PossessionTypeFkNavigation { get; set; }
        public Project? ProjectFkNavigation { get; set; }
        public ToolsType? ToolsTypeFkNavigation { get; set; }
        public WarrantyStatus? WarrantyStatusFkNavigation { get; set; }
        public Zone? ZoneFkNavigation { get; set; }

        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NameAr { get; set; }
        public int? ZoneFk { get; set; }
        public int? EquipmentCodeFk { get; set; }
        public string? EquipmentLocationCode { get; set; }
        public string? FunctionalCode { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? CostPerHour { get; set; }
        public int? CurrencyFk { get; set; }
        public int? WarrantyStatusFk { get; set; }
        public string? Rfid { get; set; }
        public string? Remarks { get; set; }
        public int? PossessionTypeFk { get; set; }
        public DateTime? OperationDate { get; set; }
        public bool? IsOperational { get; set; }
        public int? InsuranceVendorFk { get; set; }
        public string? PolicyNumber { get; set; }
        public DateTime? PolicyDate { get; set; }
        public DateTime? PolicyExpiryDate { get; set; }
        public decimal? PolicyAmount { get; set; }
        public int? ManufactureFk { get; set; }
        public string? Model { get; set; }
        public int? ModelYearFk { get; set; }
        public string? SerialNumber { get; set; }
        public DateTime? GuaranteeExpiryDate { get; set; }
        public string? TechnicalInformation { get; set; }
        public bool? Axsynced { get; set; }
        public int? ProjectFk { get; set; }
        public int? AssetStatusFk { get; set; }
        public decimal? PurchasePrice { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime? CheckDate { get; set; }
        public decimal? LifeTime { get; set; }
        public decimal? DepreciationRate { get; set; }
        public DateTime? PlannedDepreciationDate { get; set; }
        public DateTime? ActualDepreciationDate { get; set; }
        public int? Oufk { get; set; }



        private List<AssetAttachment> _assetAttachments = new List<AssetAttachment>();
        public IReadOnlyCollection<AssetAttachment> AssetAttachments => _assetAttachments;

        private List<AssetCommissioning> _assetCommissionings = new List<AssetCommissioning>();
        public IReadOnlyCollection<AssetCommissioning> AssetCommissionings => _assetCommissionings;

        private List<AssetComponent> _assetComponentAssetFkNavigations = new List<AssetComponent>();
        public IReadOnlyCollection<AssetComponent> AssetComponentAssetFkNavigations => _assetComponentAssetFkNavigations;

        private List<AssetComponent> _assetComponentComponentFkNavigations = new List<AssetComponent>();
        public IReadOnlyCollection<AssetComponent> AssetComponentComponentFkNavigations => _assetComponentComponentFkNavigations;

        private List<AssetCountDetail> _assetCountDetails = new List<AssetCountDetail>();
        public IReadOnlyCollection<AssetCountDetail> AssetCountDetails => _assetCountDetails;

        private List<InventoryItemAsset> _inventoryItemAssets = new List<InventoryItemAsset>();
        public IReadOnlyCollection<InventoryItemAsset> InventoryItemAssets => _inventoryItemAssets;

        public Asset()
        {
        }

        public Asset(int? assetGroupFk, int? assetTypeFk, int? toolsTypeFk, string? code, string? name, string? nameAr, int? zoneFk, int? equipmentCodeFk, string? equipmentLocationCode, string? functionalCode, decimal? quantity, decimal? costPerHour, int? currencyFk, int? warrantyStatusFk, string? rfid, string? remarks, int? possessionTypeFk, DateTime? operationDate, bool? isOperational, int? insuranceVendorFk, string? policyNumber, DateTime? policyDate, DateTime? policyExpiryDate, decimal? policyAmount, int? manufactureFk, string? model, int? modelYearFk, string? serialNumber, DateTime? guaranteeExpiryDate, string? technicalInformation, bool? axsynced, int? projectFk, int? assetStatusFk, decimal? purchasePrice, DateTime? purchaseDate, DateTime? checkDate, decimal? lifeTime, decimal? depreciationRate, DateTime? plannedDepreciationDate, DateTime? actualDepreciationDate, int? oufk, bool isActive) : this()
        {
            AssetGroupFk = assetGroupFk;
            AssetTypeFk = assetTypeFk;
            ToolsTypeFk = toolsTypeFk;
            Code = code;
            Name = name;
            NameAr = nameAr;
            ZoneFk = zoneFk;
            EquipmentCodeFk = equipmentCodeFk;
            EquipmentLocationCode = equipmentLocationCode;
            FunctionalCode = functionalCode;
            Quantity = quantity;
            CostPerHour = costPerHour;
            CurrencyFk = currencyFk;
            WarrantyStatusFk = warrantyStatusFk;
            Rfid = rfid;
            Remarks = remarks;
            PossessionTypeFk = possessionTypeFk;
            OperationDate = operationDate;
            IsOperational = isOperational;
            InsuranceVendorFk = insuranceVendorFk;
            PolicyNumber = policyNumber;
            PolicyDate = policyDate;
            PolicyExpiryDate = policyExpiryDate;
            PolicyAmount = policyAmount;
            ManufactureFk = manufactureFk;
            Model = model;
            ModelYearFk = modelYearFk;
            SerialNumber = serialNumber;
            GuaranteeExpiryDate = guaranteeExpiryDate;
            TechnicalInformation = technicalInformation;
            Axsynced = axsynced;
            ProjectFk = projectFk;
            AssetStatusFk = assetStatusFk;
            PurchasePrice = purchasePrice;
            PurchaseDate = purchaseDate;
            CheckDate = checkDate;
            LifeTime = lifeTime;
            DepreciationRate = depreciationRate;
            PlannedDepreciationDate = plannedDepreciationDate;
            ActualDepreciationDate = actualDepreciationDate;
            Oufk = oufk;
            IsActive = isActive;
        }

        public static Asset Create(int? assetGroupFk, int? assetTypeFk, int? toolsTypeFk, string? code, string? name, string? nameAr, int? zoneFk, int? equipmentCodeFk, string? equipmentLocationCode, string? functionalCode, decimal? quantity, decimal? costPerHour, int? currencyFk, int? warrantyStatusFk, string? rfid, string? remarks, int? possessionTypeFk, DateTime? operationDate, bool? isOperational, int? insuranceVendorFk, string? policyNumber, DateTime? policyDate, DateTime? policyExpiryDate, decimal? policyAmount, int? manufactureFk, string? model, int? modelYearFk, string? serialNumber, DateTime? guaranteeExpiryDate, string? technicalInformation, bool? axsynced, int? projectFk, int? assetStatusFk, decimal? purchasePrice, DateTime? purchaseDate, DateTime? checkDate, decimal? lifeTime, decimal? depreciationRate, DateTime? plannedDepreciationDate, DateTime? actualDepreciationDate, int? oufk, bool isActive)
        {

            return new Asset(assetGroupFk, assetTypeFk, toolsTypeFk, code, name, nameAr, zoneFk, equipmentCodeFk, equipmentLocationCode, functionalCode, quantity, costPerHour, currencyFk, warrantyStatusFk, rfid, remarks, possessionTypeFk, operationDate, isOperational, insuranceVendorFk, policyNumber, policyDate, policyExpiryDate, policyAmount, manufactureFk, model, modelYearFk, serialNumber, guaranteeExpiryDate, technicalInformation, axsynced, projectFk, assetStatusFk, purchasePrice, purchaseDate, checkDate, lifeTime, depreciationRate, plannedDepreciationDate, actualDepreciationDate, oufk, isActive);
        }

        public void Update(int? assetGroupFk, int? assetTypeFk, int? toolsTypeFk, string? code, string? name, string? nameAr, int? zoneFk, int? equipmentCodeFk, string? equipmentLocationCode, string? functionalCode, decimal? quantity, decimal? costPerHour, int? currencyFk, int? warrantyStatusFk, string? rfid, string? remarks, int? possessionTypeFk, DateTime? operationDate, bool? isOperational, int? insuranceVendorFk, string? policyNumber, DateTime? policyDate, DateTime? policyExpiryDate, decimal? policyAmount, int? manufactureFk, string? model, int? modelYearFk, string? serialNumber, DateTime? guaranteeExpiryDate, string? technicalInformation, bool? axsynced, int? projectFk, int? assetStatusFk, decimal? purchasePrice, DateTime? purchaseDate, DateTime? checkDate, decimal? lifeTime, decimal? depreciationRate, DateTime? plannedDepreciationDate, DateTime? actualDepreciationDate, int? oufk, bool isActive)
        {
            AssetGroupFk = assetGroupFk;
            AssetTypeFk = assetTypeFk;
            ToolsTypeFk = toolsTypeFk;
            Code = code;
            Name = name;
            NameAr = nameAr;
            ZoneFk = zoneFk;
            EquipmentCodeFk = equipmentCodeFk;
            EquipmentLocationCode = equipmentLocationCode;
            FunctionalCode = functionalCode;
            Quantity = quantity;
            CostPerHour = costPerHour;
            CurrencyFk = currencyFk;
            WarrantyStatusFk = warrantyStatusFk;
            Rfid = rfid;
            Remarks = remarks;
            PossessionTypeFk = possessionTypeFk;
            OperationDate = operationDate;
            IsOperational = isOperational;
            InsuranceVendorFk = insuranceVendorFk;
            PolicyNumber = policyNumber;
            PolicyDate = policyDate;
            PolicyExpiryDate = policyExpiryDate;
            PolicyAmount = policyAmount;
            ManufactureFk = manufactureFk;
            Model = model;
            ModelYearFk = modelYearFk;
            SerialNumber = serialNumber;
            GuaranteeExpiryDate = guaranteeExpiryDate;
            TechnicalInformation = technicalInformation;
            Axsynced = axsynced;
            ProjectFk = projectFk;
            AssetStatusFk = assetStatusFk;
            PurchasePrice = purchasePrice;
            PurchaseDate = purchaseDate;
            CheckDate = checkDate;
            LifeTime = lifeTime;
            DepreciationRate = depreciationRate;
            PlannedDepreciationDate = plannedDepreciationDate;
            ActualDepreciationDate = actualDepreciationDate;
            Oufk = oufk;
            IsActive = isActive;
        }
    }
}
