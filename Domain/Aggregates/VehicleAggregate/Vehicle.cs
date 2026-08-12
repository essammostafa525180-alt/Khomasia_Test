using Domain.Aggregates.CompanyAggregate;
using Domain.Aggregates.RequestAggregate;
using Domain.Aggregates.VendorOrderAggregate;
using Domain.Entities;
using Domain.Primitives;
using System.Collections.Generic;

namespace Domain.Aggregates.VehicleAggregate
{
    public class Vehicle : AggregateRootEntityBase<int>
    {
        public string? Code { get; set; }
        public string? Barcode { get; set; }
        public string? Rfid { get; set; }
        public int? EquipmentTypeFk { get; set; }
        public int? VehicleTypeFk { get; set; }
        public int? VehicleBrandFk { get; set; }
        public int? VehicleModelFk { get; set; }
        public int? YearFk { get; set; }
        public string? SerialNumber { get; set; }
        public string? PlateNumber { get; set; }
        public int? ColorFk { get; set; }
        public string? Description { get; set; }
        public int? VehicleStatusFk { get; set; }
        public int? OwnershipFk { get; set; }
        public int? Oufk { get; set; }
        public int? CostCenterFk { get; set; }
        public int? EmployeeFk { get; set; }
        public decimal? GrossWeight { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal? WheelBase { get; set; }
        public decimal? Length { get; set; }
        public string? ChassisNumber { get; set; }
        public string? EngineNumber { get; set; }
        public int? EngineSizeFk { get; set; }
        public int? TransmissionTypeFk { get; set; }
        public decimal? CylindersNumber { get; set; }
        public int? BatteryTypeFk { get; set; }
        public int? AirFilterTypeFk { get; set; }
        public int? SectorFk { get; set; }
        public DateTime? OperationDate { get; set; }
        public string? TagNumber { get; set; }
        public DateTime? RetireDate { get; set; }
        public decimal? BookValue { get; set; }
        public decimal? LaborRateRatio { get; set; }
        public decimal? SparePartRateRatio { get; set; }
        public decimal? Depreciation { get; set; }
        public decimal? OriginalValue { get; set; }
        public int? ServiceLife { get; set; }
        public int? VehicleOptionFk { get; set; }
        public int? RemainingMonths { get; set; }
        public int? CompanyFk { get; set; }
        public int? ProjectFk { get; set; }
        public AirFilterType? AirFilterTypeFkNavigation { get; set; }
        public BatteryType? BatteryTypeFkNavigation { get; set; }
        public VehicleColor? ColorFkNavigation { get; set; }
        public CostCenter? CostCenterFkNavigation { get; set; }
        public EngineSize? EngineSizeFkNavigation { get; set; }
        public City? OufkNavigation { get; set; }
        public Ownership? OwnershipFkNavigation { get; set; }
        public Project? ProjectFkNavigation { get; set; }
        public Sector? SectorFkNavigation { get; set; }
        public TransmissionType? TransmissionTypeFkNavigation { get; set; }
        public VehicleBrand? VehicleBrandFkNavigation { get; set; }
        public VehicleModel? VehicleModelFkNavigation { get; set; }
        public VehicleOption? VehicleOptionFkNavigation { get; set; }
        public VehicleStatus? VehicleStatusFkNavigation { get; set; }
        public VehicleType? VehicleTypeFkNavigation { get; set; }
        public InventoryYear? YearFkNavigation { get; set; }

        private List<InventroyItemRequestWithdraw> _inventroyItemRequestWithdraws = new List<InventroyItemRequestWithdraw>();
        public IReadOnlyCollection<InventroyItemRequestWithdraw> InventroyItemRequestWithdraws => _inventroyItemRequestWithdraws;

        private List<VendorOrder> _vendorOrders = new List<VendorOrder>();
        public IReadOnlyCollection<VendorOrder> VendorOrders => _vendorOrders;

        public Vehicle()
        {
        }

        public Vehicle(string? code, string? barcode, string? rfid, int? equipmentTypeFk, int? vehicleTypeFk, int? vehicleBrandFk, int? vehicleModelFk, int? yearFk, string? serialNumber, string? plateNumber, int? colorFk, string? description, int? vehicleStatusFk, int? ownershipFk, int? oufk, int? costCenterFk, int? employeeFk, decimal? grossWeight, decimal? height, decimal? width, decimal? wheelBase, decimal? length, string? chassisNumber, string? engineNumber, int? engineSizeFk, int? transmissionTypeFk, decimal? cylindersNumber, int? batteryTypeFk, int? airFilterTypeFk, int? sectorFk, DateTime? operationDate, string? tagNumber, DateTime? retireDate, decimal? bookValue, decimal? laborRateRatio, decimal? sparePartRateRatio, decimal? depreciation, decimal? originalValue, int? serviceLife, int? vehicleOptionFk, int? remainingMonths, int? companyFk, int? projectFk, bool isActive) : this()
        {
            Code = code;
            Barcode = barcode;
            Rfid = rfid;
            EquipmentTypeFk = equipmentTypeFk;
            VehicleTypeFk = vehicleTypeFk;
            VehicleBrandFk = vehicleBrandFk;
            VehicleModelFk = vehicleModelFk;
            YearFk = yearFk;
            SerialNumber = serialNumber;
            PlateNumber = plateNumber;
            ColorFk = colorFk;
            Description = description;
            VehicleStatusFk = vehicleStatusFk;
            OwnershipFk = ownershipFk;
            Oufk = oufk;
            CostCenterFk = costCenterFk;
            EmployeeFk = employeeFk;
            GrossWeight = grossWeight;
            Height = height;
            Width = width;
            WheelBase = wheelBase;
            Length = length;
            ChassisNumber = chassisNumber;
            EngineNumber = engineNumber;
            EngineSizeFk = engineSizeFk;
            TransmissionTypeFk = transmissionTypeFk;
            CylindersNumber = cylindersNumber;
            BatteryTypeFk = batteryTypeFk;
            AirFilterTypeFk = airFilterTypeFk;
            SectorFk = sectorFk;
            OperationDate = operationDate;
            TagNumber = tagNumber;
            RetireDate = retireDate;
            BookValue = bookValue;
            LaborRateRatio = laborRateRatio;
            SparePartRateRatio = sparePartRateRatio;
            Depreciation = depreciation;
            OriginalValue = originalValue;
            ServiceLife = serviceLife;
            VehicleOptionFk = vehicleOptionFk;
            RemainingMonths = remainingMonths;
            CompanyFk = companyFk;
            ProjectFk = projectFk;
            IsActive = isActive;
        }

        public static Vehicle Create(string? code, string? barcode, string? rfid, int? equipmentTypeFk, int? vehicleTypeFk, int? vehicleBrandFk, int? vehicleModelFk, int? yearFk, string? serialNumber, string? plateNumber, int? colorFk, string? description, int? vehicleStatusFk, int? ownershipFk, int? oufk, int? costCenterFk, int? employeeFk, decimal? grossWeight, decimal? height, decimal? width, decimal? wheelBase, decimal? length, string? chassisNumber, string? engineNumber, int? engineSizeFk, int? transmissionTypeFk, decimal? cylindersNumber, int? batteryTypeFk, int? airFilterTypeFk, int? sectorFk, DateTime? operationDate, string? tagNumber, DateTime? retireDate, decimal? bookValue, decimal? laborRateRatio, decimal? sparePartRateRatio, decimal? depreciation, decimal? originalValue, int? serviceLife, int? vehicleOptionFk, int? remainingMonths, int? companyFk, int? projectFk, bool isActive)
        {

            return new Vehicle(code, barcode, rfid, equipmentTypeFk, vehicleTypeFk, vehicleBrandFk, vehicleModelFk, yearFk, serialNumber, plateNumber, colorFk, description, vehicleStatusFk, ownershipFk, oufk, costCenterFk, employeeFk, grossWeight, height, width, wheelBase, length, chassisNumber, engineNumber, engineSizeFk, transmissionTypeFk, cylindersNumber, batteryTypeFk, airFilterTypeFk, sectorFk, operationDate, tagNumber, retireDate, bookValue, laborRateRatio, sparePartRateRatio, depreciation, originalValue, serviceLife, vehicleOptionFk, remainingMonths, companyFk, projectFk, isActive);
        }

        public void Update(string? code, string? barcode, string? rfid, int? equipmentTypeFk, int? vehicleTypeFk, int? vehicleBrandFk, int? vehicleModelFk, int? yearFk, string? serialNumber, string? plateNumber, int? colorFk, string? description, int? vehicleStatusFk, int? ownershipFk, int? oufk, int? costCenterFk, int? employeeFk, decimal? grossWeight, decimal? height, decimal? width, decimal? wheelBase, decimal? length, string? chassisNumber, string? engineNumber, int? engineSizeFk, int? transmissionTypeFk, decimal? cylindersNumber, int? batteryTypeFk, int? airFilterTypeFk, int? sectorFk, DateTime? operationDate, string? tagNumber, DateTime? retireDate, decimal? bookValue, decimal? laborRateRatio, decimal? sparePartRateRatio, decimal? depreciation, decimal? originalValue, int? serviceLife, int? vehicleOptionFk, int? remainingMonths, int? companyFk, int? projectFk, bool isActive)
        {
            Code = code;
            Barcode = barcode;
            Rfid = rfid;
            EquipmentTypeFk = equipmentTypeFk;
            VehicleTypeFk = vehicleTypeFk;
            VehicleBrandFk = vehicleBrandFk;
            VehicleModelFk = vehicleModelFk;
            YearFk = yearFk;
            SerialNumber = serialNumber;
            PlateNumber = plateNumber;
            ColorFk = colorFk;
            Description = description;
            VehicleStatusFk = vehicleStatusFk;
            OwnershipFk = ownershipFk;
            Oufk = oufk;
            CostCenterFk = costCenterFk;
            EmployeeFk = employeeFk;
            GrossWeight = grossWeight;
            Height = height;
            Width = width;
            WheelBase = wheelBase;
            Length = length;
            ChassisNumber = chassisNumber;
            EngineNumber = engineNumber;
            EngineSizeFk = engineSizeFk;
            TransmissionTypeFk = transmissionTypeFk;
            CylindersNumber = cylindersNumber;
            BatteryTypeFk = batteryTypeFk;
            AirFilterTypeFk = airFilterTypeFk;
            SectorFk = sectorFk;
            OperationDate = operationDate;
            TagNumber = tagNumber;
            RetireDate = retireDate;
            BookValue = bookValue;
            LaborRateRatio = laborRateRatio;
            SparePartRateRatio = sparePartRateRatio;
            Depreciation = depreciation;
            OriginalValue = originalValue;
            ServiceLife = serviceLife;
            VehicleOptionFk = vehicleOptionFk;
            RemainingMonths = remainingMonths;
            CompanyFk = companyFk;
            ProjectFk = projectFk;
            IsActive = isActive;
        }
    }
}
