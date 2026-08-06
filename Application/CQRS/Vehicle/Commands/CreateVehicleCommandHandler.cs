using Application.Abstractions;

namespace Application.CQRS.Vehicle.Commands;

public class CreateVehicleCommand : ICommand<Result<int>>
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
        public bool IsActive { get; set; }
}
internal class CreateVehicleCommandHandler : ICommandHandler<CreateVehicleCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateVehicleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.VehicleAggregate.Vehicle.Create(request.Code, request.Barcode, request.Rfid, request.EquipmentTypeFk, request.VehicleTypeFk, request.VehicleBrandFk, request.VehicleModelFk, request.YearFk, request.SerialNumber, request.PlateNumber, request.ColorFk, request.Description, request.VehicleStatusFk, request.OwnershipFk, request.Oufk, request.CostCenterFk, request.EmployeeFk, request.GrossWeight, request.Height, request.Width, request.WheelBase, request.Length, request.ChassisNumber, request.EngineNumber, request.EngineSizeFk, request.TransmissionTypeFk, request.CylindersNumber, request.BatteryTypeFk, request.AirFilterTypeFk, request.SectorFk, request.OperationDate, request.TagNumber, request.RetireDate, request.BookValue, request.LaborRateRatio, request.SparePartRateRatio, request.Depreciation, request.OriginalValue, request.ServiceLife, request.VehicleOptionFk, request.RemainingMonths, request.CompanyFk, request.ProjectFk, request.IsActive);

        await _unitOfWork.VehicleRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.VehicleNotInserted);
    }
}