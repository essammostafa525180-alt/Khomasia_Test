using Application.Abstractions;

namespace Application.CQRS.Asset.Commands;

public class CreateAssetCommand : ICommand<Result<int>>
{
        public int? AssetGroupFk { get; set; }
        public int? AssetTypeFk { get; set; }
        public int? ToolsTypeFk { get; set; }
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
        public bool IsActive { get; set; }
}
internal class CreateAssetCommandHandler : ICommandHandler<CreateAssetCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateAssetCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<int>> Handle(CreateAssetCommand request, CancellationToken cancellationToken)
    {
        var entity = Domain.Aggregates.AssetAggregate.Asset.Create(request.AssetGroupFk, request.AssetTypeFk, request.ToolsTypeFk, request.Code, request.Name, request.NameAr, request.ZoneFk, request.EquipmentCodeFk, request.EquipmentLocationCode, request.FunctionalCode, request.Quantity, request.CostPerHour, request.CurrencyFk, request.WarrantyStatusFk, request.Rfid, request.Remarks, request.PossessionTypeFk, request.OperationDate, request.IsOperational, request.InsuranceVendorFk, request.PolicyNumber, request.PolicyDate, request.PolicyExpiryDate, request.PolicyAmount, request.ManufactureFk, request.Model, request.ModelYearFk, request.SerialNumber, request.GuaranteeExpiryDate, request.TechnicalInformation, request.Axsynced, request.ProjectFk, request.AssetStatusFk, request.PurchasePrice, request.PurchaseDate, request.CheckDate, request.LifeTime, request.DepreciationRate, request.PlannedDepreciationDate, request.ActualDepreciationDate, request.Oufk, request.IsActive);

        await _unitOfWork.AssetRepository.AddAsync(entity);
        var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result > 0
            ? Result<int>.Success(entity.Id)
            : Result<int>.Failure(Errors.AssetNotInserted);
    }
}