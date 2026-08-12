using Domain.Aggregates.CompanyAggregate;
using Domain.Aggregates.InventoryItemAggregate;
using Domain.Aggregates.LocationAggregate;
using Domain.Aggregates.UserAggregate;
using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.AssetAggregate
{
    public class AssetItem : AggregateRootEntityBase<int>
    {
        public int? AssetStatusFk { get; set; }
        public decimal? PurchaseValue { get; set; }
        public DateOnly? PurchaseDate { get; set; }
        public int? DepartmentFk { get; set; }
        public int? ProjectFk { get; set; }
        public int? AssetLocationFk { get; set; }
        public int? EmployeeFk { get; set; }
        public DateTime? MoveDate { get; set; }
        public int? AssetWarrantyStatusFk { get; set; }
        public DateOnly? EndWarrantyDate { get; set; }
        public bool IsOperational { get; set; }
        public DateOnly? OperationDate { get; set; }
        public DateOnly? ScrapDate { get; set; }
        public DateOnly? MaintenanceDate { get; set; }
        public decimal? DepreciationRate { get; set; }
        public decimal? DepreciationDuration { get; set; }
        public DateOnly? FirstDepreciationDate { get; set; }
        public string? FixedAssetAccountCode { get; set; }
        public string? DepreciationAccountCode { get; set; }
        public int? InsuranceVendorFk { get; set; }
        public string? InsuranceAccountCode { get; set; }
        public string? PolicyNumber { get; set; }
        public DateOnly? PolicyDate { get; set; }
        public DateOnly? PolicyExpiryDate { get; set; }
        public decimal? PolicyAmount { get; set; }
        public string? ModelName { get; set; }
        public DateOnly? ManufactureDate { get; set; }
        public string? Description { get; set; }
        public byte[]? AssetRowVersion { get; set; }
        public Location? AssetLocationFkNavigation { get; set; }
        public AssetStatus? AssetStatusFkNavigation { get; set; }
        public AssetWarrantyStatus? AssetWarrantyStatusFkNavigation { get; set; }
        public Employee? EmployeeFkNavigation { get; set; }
        public InventoryItemSerial? IdNavigation { get; set; }
        public InsuranceVendor? InsuranceVendorFkNavigation { get; set; }
        public Project? ProjectFkNavigation { get; set; }

        private List<AssetItemAttachment> _assetItemAttachments = new List<AssetItemAttachment>();
        public IReadOnlyCollection<AssetItemAttachment> AssetItemAttachments => _assetItemAttachments;

        private List<AssetItemMaintenance> _assetItemMaintenances = new List<AssetItemMaintenance>();
        public IReadOnlyCollection<AssetItemMaintenance> AssetItemMaintenances => _assetItemMaintenances;

        private List<AssetItemMove> _assetItemMoves = new List<AssetItemMove>();
        public IReadOnlyCollection<AssetItemMove> AssetItemMoves => _assetItemMoves;

        private List<AssetItemScrap> _assetItemScraps = new List<AssetItemScrap>();
        public IReadOnlyCollection<AssetItemScrap> AssetItemScraps => _assetItemScraps;

        public AssetItem()
        {
        }

        public AssetItem(int? assetStatusFk, decimal? purchaseValue, DateOnly? purchaseDate, int? departmentFk, int? projectFk, int? assetLocationFk, int? employeeFk, DateTime? moveDate, int? assetWarrantyStatusFk, DateOnly? endWarrantyDate, bool isOperational, DateOnly? operationDate, DateOnly? scrapDate, DateOnly? maintenanceDate, decimal? depreciationRate, decimal? depreciationDuration, DateOnly? firstDepreciationDate, string? fixedAssetAccountCode, string? depreciationAccountCode, int? insuranceVendorFk, string? insuranceAccountCode, string? policyNumber, DateOnly? policyDate, DateOnly? policyExpiryDate, decimal? policyAmount, string? modelName, DateOnly? manufactureDate, string? description, byte[]? assetRowVersion, bool isActive) : this()
        {
            AssetStatusFk = assetStatusFk;
            PurchaseValue = purchaseValue;
            PurchaseDate = purchaseDate;
            DepartmentFk = departmentFk;
            ProjectFk = projectFk;
            AssetLocationFk = assetLocationFk;
            EmployeeFk = employeeFk;
            MoveDate = moveDate;
            AssetWarrantyStatusFk = assetWarrantyStatusFk;
            EndWarrantyDate = endWarrantyDate;
            IsOperational = isOperational;
            OperationDate = operationDate;
            ScrapDate = scrapDate;
            MaintenanceDate = maintenanceDate;
            DepreciationRate = depreciationRate;
            DepreciationDuration = depreciationDuration;
            FirstDepreciationDate = firstDepreciationDate;
            FixedAssetAccountCode = fixedAssetAccountCode;
            DepreciationAccountCode = depreciationAccountCode;
            InsuranceVendorFk = insuranceVendorFk;
            InsuranceAccountCode = insuranceAccountCode;
            PolicyNumber = policyNumber;
            PolicyDate = policyDate;
            PolicyExpiryDate = policyExpiryDate;
            PolicyAmount = policyAmount;
            ModelName = modelName;
            ManufactureDate = manufactureDate;
            Description = description;
            AssetRowVersion = assetRowVersion;
            IsActive = isActive;
        }

        public static AssetItem Create(int? assetStatusFk, decimal? purchaseValue, DateOnly? purchaseDate, int? departmentFk, int? projectFk, int? assetLocationFk, int? employeeFk, DateTime? moveDate, int? assetWarrantyStatusFk, DateOnly? endWarrantyDate, bool isOperational, DateOnly? operationDate, DateOnly? scrapDate, DateOnly? maintenanceDate, decimal? depreciationRate, decimal? depreciationDuration, DateOnly? firstDepreciationDate, string? fixedAssetAccountCode, string? depreciationAccountCode, int? insuranceVendorFk, string? insuranceAccountCode, string? policyNumber, DateOnly? policyDate, DateOnly? policyExpiryDate, decimal? policyAmount, string? modelName, DateOnly? manufactureDate, string? description, byte[]? assetRowVersion, bool isActive)
        {

            return new AssetItem(assetStatusFk, purchaseValue, purchaseDate, departmentFk, projectFk, assetLocationFk, employeeFk, moveDate, assetWarrantyStatusFk, endWarrantyDate, isOperational, operationDate, scrapDate, maintenanceDate, depreciationRate, depreciationDuration, firstDepreciationDate, fixedAssetAccountCode, depreciationAccountCode, insuranceVendorFk, insuranceAccountCode, policyNumber, policyDate, policyExpiryDate, policyAmount, modelName, manufactureDate, description, assetRowVersion, isActive);
        }

        public void Update(int? assetStatusFk, decimal? purchaseValue, DateOnly? purchaseDate, int? departmentFk, int? projectFk, int? assetLocationFk, int? employeeFk, DateTime? moveDate, int? assetWarrantyStatusFk, DateOnly? endWarrantyDate, bool isOperational, DateOnly? operationDate, DateOnly? scrapDate, DateOnly? maintenanceDate, decimal? depreciationRate, decimal? depreciationDuration, DateOnly? firstDepreciationDate, string? fixedAssetAccountCode, string? depreciationAccountCode, int? insuranceVendorFk, string? insuranceAccountCode, string? policyNumber, DateOnly? policyDate, DateOnly? policyExpiryDate, decimal? policyAmount, string? modelName, DateOnly? manufactureDate, string? description, byte[]? assetRowVersion, bool isActive)
        {
            AssetStatusFk = assetStatusFk;
            PurchaseValue = purchaseValue;
            PurchaseDate = purchaseDate;
            DepartmentFk = departmentFk;
            ProjectFk = projectFk;
            AssetLocationFk = assetLocationFk;
            EmployeeFk = employeeFk;
            MoveDate = moveDate;
            AssetWarrantyStatusFk = assetWarrantyStatusFk;
            EndWarrantyDate = endWarrantyDate;
            IsOperational = isOperational;
            OperationDate = operationDate;
            ScrapDate = scrapDate;
            MaintenanceDate = maintenanceDate;
            DepreciationRate = depreciationRate;
            DepreciationDuration = depreciationDuration;
            FirstDepreciationDate = firstDepreciationDate;
            FixedAssetAccountCode = fixedAssetAccountCode;
            DepreciationAccountCode = depreciationAccountCode;
            InsuranceVendorFk = insuranceVendorFk;
            InsuranceAccountCode = insuranceAccountCode;
            PolicyNumber = policyNumber;
            PolicyDate = policyDate;
            PolicyExpiryDate = policyExpiryDate;
            PolicyAmount = policyAmount;
            ModelName = modelName;
            ManufactureDate = manufactureDate;
            Description = description;
            AssetRowVersion = assetRowVersion;
            IsActive = isActive;
        }
    }
}
