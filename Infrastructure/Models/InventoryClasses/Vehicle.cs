using System;
using System.Collections.Generic;

namespace Infrastructure.Models.InventoryClasses;

public partial class Vehicle
{
    public long Id { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? LastUpdatedOn { get; set; }

    public string? Code { get; set; }

    public string? Barcode { get; set; }

    public string? Rfid { get; set; }

    public long? EquipmentTypeFk { get; set; }

    public long? VehicleTypeFk { get; set; }

    public long? VehicleBrandFk { get; set; }

    public long? VehicleModelFk { get; set; }

    public long? YearFk { get; set; }

    public string? SerialNumber { get; set; }

    public string? PlateNumber { get; set; }

    public long? ColorFk { get; set; }

    public string? Description { get; set; }

    public long? VehicleStatusFk { get; set; }

    public long? OwnershipFk { get; set; }

    public long? Oufk { get; set; }

    public long? CostCenterFk { get; set; }

    public long? EmployeeFk { get; set; }

    public decimal? GrossWeight { get; set; }

    public decimal? Height { get; set; }

    public decimal? Width { get; set; }

    public decimal? WheelBase { get; set; }

    public decimal? Length { get; set; }

    public string? ChassisNumber { get; set; }

    public string? EngineNumber { get; set; }

    public long? EngineSizeFk { get; set; }

    public long? TransmissionTypeFk { get; set; }

    public decimal? CylindersNumber { get; set; }

    public long? BatteryTypeFk { get; set; }

    public long? AirFilterTypeFk { get; set; }

    public long? SectorFk { get; set; }

    public DateTime? OperationDate { get; set; }

    public string? TagNumber { get; set; }

    public DateTime? RetireDate { get; set; }

    public bool IsActive { get; set; }

    public byte[]? RowVersion { get; set; }

    public bool? IsSynced { get; set; }

    public bool IsEnabled { get; set; }

    public decimal? BookValue { get; set; }

    public decimal? LaborRateRatio { get; set; }

    public decimal? SparePartRateRatio { get; set; }

    public decimal? Depreciation { get; set; }

    public decimal? OriginalValue { get; set; }

    public int? ServiceLife { get; set; }

    public long? VehicleOptionFk { get; set; }

    public int? RemainingMonths { get; set; }

    public long? CompanyFk { get; set; }

    public long? ProjectFk { get; set; }

    public virtual AirFilterType? AirFilterTypeFkNavigation { get; set; }

    public virtual BatteryType? BatteryTypeFkNavigation { get; set; }

    public virtual VehicleColor? ColorFkNavigation { get; set; }

    public virtual CostCenter? CostCenterFkNavigation { get; set; }

    public virtual EngineSize? EngineSizeFkNavigation { get; set; }

    public virtual ICollection<InventroyItemRequestWithdraw> InventroyItemRequestWithdraws { get; set; } = new List<InventroyItemRequestWithdraw>();

    public virtual City? OufkNavigation { get; set; }

    public virtual Ownership? OwnershipFkNavigation { get; set; }

    public virtual Project? ProjectFkNavigation { get; set; }

    public virtual Sector? SectorFkNavigation { get; set; }

    public virtual TransmissionType? TransmissionTypeFkNavigation { get; set; }

    public virtual VehicleBrand? VehicleBrandFkNavigation { get; set; }

    public virtual VehicleModel? VehicleModelFkNavigation { get; set; }

    public virtual VehicleOption? VehicleOptionFkNavigation { get; set; }

    public virtual VehicleStatus? VehicleStatusFkNavigation { get; set; }

    public virtual VehicleType? VehicleTypeFkNavigation { get; set; }

    public virtual ICollection<VendorOrder> VendorOrders { get; set; } = new List<VendorOrder>();

    public virtual InventoryYear? YearFkNavigation { get; set; }
}
