using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class AssetItem
{
    public long Id { get; set; }

    public long? AssetStatusFk { get; set; }

    public decimal? PurchaseValue { get; set; }

    public DateOnly? PurchaseDate { get; set; }

    public long? DepartmentFk { get; set; }

    public long? ProjectFk { get; set; }

    public long? AssetLocationFk { get; set; }

    public long? EmployeeFk { get; set; }

    public DateTime? MoveDate { get; set; }

    public long? AssetWarrantyStatusFk { get; set; }

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

    public long? InsuranceVendorFk { get; set; }

    public string? InsuranceAccountCode { get; set; }

    public string? PolicyNumber { get; set; }

    public DateOnly? PolicyDate { get; set; }

    public DateOnly? PolicyExpiryDate { get; set; }

    public decimal? PolicyAmount { get; set; }

    public string? ModelName { get; set; }

    public DateOnly? ManufactureDate { get; set; }

    public string? Description { get; set; }

    public byte[]? AssetRowVersion { get; set; }

    public byte[]? RowVersion { get; set; }

    public virtual ICollection<AssetItemAttachment> AssetItemAttachments { get; set; } = new List<AssetItemAttachment>();

    public virtual ICollection<AssetItemMaintenance> AssetItemMaintenances { get; set; } = new List<AssetItemMaintenance>();

    public virtual ICollection<AssetItemMove> AssetItemMoves { get; set; } = new List<AssetItemMove>();

    public virtual ICollection<AssetItemScrap> AssetItemScraps { get; set; } = new List<AssetItemScrap>();

    public virtual Location? AssetLocationFkNavigation { get; set; }

    public virtual AssetStatus? AssetStatusFkNavigation { get; set; }

    public virtual AssetWarrantyStatus? AssetWarrantyStatusFkNavigation { get; set; }

    public virtual Employee? EmployeeFkNavigation { get; set; }

    public virtual InventoryItemSerial IdNavigation { get; set; } = null!;

    public virtual InsuranceVendor? InsuranceVendorFkNavigation { get; set; }

    public virtual Project? ProjectFkNavigation { get; set; }
}
